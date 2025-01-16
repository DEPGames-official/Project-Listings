import 'package:flutter/material.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:ratenvote/screens/voting_screen_client.dart';
import 'package:ratenvote/screens/voting_screen_host.dart';
import 'package:ratenvote/screens/voting_results_screen.dart';
import 'package:ratenvote/services/firestore_service.dart';

class JoinSessionHelper {
  static Future<void> startSessionQuery(
      BuildContext context,
      String sessionId,
      Function(bool) setLoading,
      ) async {
    final FirebaseFirestore firestore = FirebaseFirestore.instance;
    late Future<DocumentSnapshot<Map<String, dynamic>>> sessionFuture;

    // Set loading to true
    setLoading(true);

    // Start the session query
    sessionFuture = firestore.collection('sessions').doc(sessionId).get();

    // Handle the result of the session query
    sessionFuture.then((documentSnapshot) async {
      // Set loading to false
      setLoading(false);

      if (documentSnapshot.exists) {
        final Map<String, dynamic>? data = documentSnapshot.data();
        final String hoster = data?['hoster'];
        final Map<String, dynamic>? currentUserInfo = await FirestoreServices.getUserInfo();
        final String? currentUserName = currentUserInfo?['userName'];
        final String? currentUserId = currentUserInfo?['userId'];

        // Check if the user is the host or a client
        if (data?['hoster_name'] == currentUserName) {
          final String hosterVote = data?['hoster_vote'];

          // Check if the host has voted
          if (hosterVote != 'N/A') {
            // Host has voted, navigate to voting results screen
            Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => VotingResultsScreen(
                  sessionId: sessionId
                ),
              ),
            );
          } else {
            // Host hasn't voted, navigate to voting screen for host
            Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => VotingScreenHost(
                  sessionId: sessionId, selectedVotingMode: data?['voting_mode'],
                ),
              ),
            );
          }
        } else {
          final DocumentSnapshot<Map<String, dynamic>> userSnapshot =
          await firestore.collection('sessions').doc(sessionId).collection('users').doc(currentUserId).get();
          final String? userVote = userSnapshot.data()?['user_vote'];

          // Check if the client has voted
          if (userVote != 'N/A' && userVote != null) {
            // Client has voted, navigate to voting results screen
            Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => VotingResultsScreen(
                  sessionId: sessionId
                ),
              ),
            );
          } else {
            await FirestoreServices.setSessionWithUser(sessionId);
            // Client hasn't voted, navigate to voting screen for client
            Navigator.push(
              context,
              MaterialPageRoute(
                builder: (context) => VotingScreenClient(
                  sessionId: sessionId,
                  votingOptions:
                  data?['voting_options']?.cast<String>() ?? [],
                ),
              ),
            );
          }
        }

        // Update the session document with the user information
        //await FirestoreServices.setSessionWithUser(sessionId);
      } else {
        // Document doesn't exist, show error message
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(
            content: Text('Session does not exist.'),
            duration: Duration(seconds: 3),
          ),
        );
      }
    }).catchError((error) {
      // Handle errors

      // Set loading to false
      setLoading(false);

      // Show error message
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text('Error querying session: $error'),
          duration: const Duration(seconds: 3),
        ),
      );
    });
  }
}
