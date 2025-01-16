import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';

import 'package:ratenvote/providers/voting_modes_provider.dart';

class FirestoreServices {
  static saveUser(String name, email, uid) async {
    await FirebaseFirestore.instance
        .collection('users')
        .doc(uid)
        .set({'email': email, 'name': name});
  }

  static List<Map<String, dynamic>> availableModes = [];

  static Future<List<ServerMode>> fetchAvailableServerModes() async {
    VotingModesProvider votingModesProvider = VotingModesProvider.instance;

    final QuerySnapshot<Map<String, dynamic>> querySnapshot =
    await FirebaseFirestore.instance.collection('voting_mode').get();

    List<ServerMode> serverModes = querySnapshot.docs.map((doc) {
      String name = doc.id;
      List<dynamic> rawOptions = doc.data()['options'];
      List<String> options = rawOptions.map((rawOption) => rawOption.toString())
          .toList();
      return ServerMode(name: name, options: options);
    }).toList();

    votingModesProvider.serverModes =
        serverModes; // Assuming provider is an instance of VotingModesProvider

    return serverModes;
  }

  static Future<Map<String, dynamic>?> getUserInfo() async {
    User? user = FirebaseAuth.instance.currentUser;

    if (user != null) {
      String userId = user.uid;

      try {
        DocumentSnapshot<Map<String, dynamic>> snapshot =
        await FirebaseFirestore.instance
            .collection('users')
            .doc(userId)
            .get();

        if (snapshot.exists) {
          // The document exists, you can access the user's name and ID
          Map<String, dynamic> userData = {
            'userId': userId,
            'userName': snapshot.data()?['name'],
          };

          return userData;
        }
      } catch (e) {
        print('Error fetching user document: $e');
      }
    }
    return null;
  }

  static Future<String?> getHosterName(String sessionId) async {
    try {
      // Get the session document
      DocumentSnapshot<Map<String, dynamic>> sessionSnapshot =
      await FirebaseFirestore.instance.collection('sessions').doc(sessionId).get();

      if (sessionSnapshot.exists) {
        // Retrieve the hoster's name from the session document
        return sessionSnapshot.data()?['hoster_name'];
      } else {
        // Session document doesn't exist
        return null;
      }
    } catch (error) {
      // Error occurred during the query
      print('Error getting hoster name: $error');
      return null;
    }
  }

  static Future<void> setSessionWithUser(String sessionCode) async {
    final FirebaseAuth auth = FirebaseAuth.instance;
    final FirebaseFirestore firestore = FirebaseFirestore.instance;

    // Get the current user's information (username)
    User? currentUser = auth.currentUser;

    if (currentUser != null) {
      // Update the session document with the user information
      await firestore
          .collection('sessions')
          .doc(sessionCode)
          .collection('users')
          .doc(currentUser.uid)
          .set({
        'name': currentUser.displayName ?? 'Unknown User',
        'user_vote': 'N/A', // Assuming the user hasn't voted initially
      });
    } else {
      // Handle the case where the user is not signed in
      print('User not signed in.');
      // You might want to show an error message to the user
    }
  }

  static Future<void> updateUserSessionVote(String sessionCode, String userVote) async {

    final FirebaseAuth auth = FirebaseAuth.instance;
    final FirebaseFirestore firestore = FirebaseFirestore.instance;

    User? currentUser = auth.currentUser;

    if (currentUser != null) {
      // Update only the 'user_vote' field in the document
      await firestore
          .collection('sessions')
          .doc(sessionCode)
          .collection('users')
          .doc(currentUser.uid)
          .update({
        'user_vote': userVote,
      });
    } else {
      // Handle the case where the user is not signed in
      print('User not signed in.');
    }
  }

  static Future<void> updateHostSessionVote(String sessionCode, String hosterVote) async {

    final FirebaseAuth auth = FirebaseAuth.instance;
    final FirebaseFirestore firestore = FirebaseFirestore.instance;

    User? currentUser = auth.currentUser;

    if (currentUser != null) {
      // Update only the 'user_vote' field in the document
      await firestore
          .collection('sessions')
          .doc(sessionCode)
          .update({
        'hoster_vote': hosterVote,
      });
    } else {
      // Handle the case where the user is not signed in
      print('User not signed in.');
    }
  }
}