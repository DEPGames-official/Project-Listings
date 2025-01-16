import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:ratenvote/providers/voting_modes_provider.dart';
import 'package:ratenvote/services/firestore_service.dart';
import 'package:ratenvote/sessions/create_session/fetch_voting_options.dart';

Future<void> createSession(String sessionIdPassed, String selectedVotingMode,
    VotingModesProvider votingModesProvider, bool hosterWantsToVote, {List<String>? votingOptions}) async {
  FirestoreServices firestoreServices = FirestoreServices();

  String sessionId = sessionIdPassed;
  String hoster;
  String? hosterName;
  String hostingTime = Timestamp.now().toString();

  final Map<String, dynamic>? currentHosterInfo = await FirestoreServices.getUserInfo();
  final String? currentHosterName = currentHosterInfo?['userName'];
  hoster = currentHosterInfo?['userId'];
  hosterName = currentHosterName;

  if(votingOptions == null){
    // Fetch voting options from another script
    List<String> votingOptions =
    fetchVotingOptions(selectedVotingMode, votingModesProvider);
  }


  if (hosterWantsToVote) {
    // Create a session document with the hoster voting
    await FirebaseFirestore.instance.collection('sessions').doc(sessionId).set({
      'hoster': hoster,
      'hoster_name': hosterName,
      'hoster_vote': "N/A",
      'voting_mode': selectedVotingMode,
      if (votingOptions != null) 'voting_options': votingOptions,
      'hosting_time': hostingTime,
    });
  } else {
    // Create a session document without the hoster voting
    await FirebaseFirestore.instance.collection('sessions').doc(sessionId).set({
      'hoster': hoster,
      'hoster_name': hosterName,
      'hoster_vote': "Not Voting",
      'voting_mode': selectedVotingMode,
      if (votingOptions != null) 'voting_options': votingOptions,
      'hosting_time': hostingTime,
    });
  }
}
