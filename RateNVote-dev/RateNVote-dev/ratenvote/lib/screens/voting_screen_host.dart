import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:ratenvote/custom/picker_carousel.dart';
import 'package:ratenvote/screens/voting_results_screen.dart';
import 'package:ratenvote/providers/voting_modes_provider.dart';
import 'package:ratenvote/sessions/create_session/fetch_voting_options.dart';

import 'package:ratenvote/services/firestore_service.dart';

class VotingScreenHost extends StatefulWidget {
  final String sessionId;
  final String selectedVotingMode;
  final List<String>? votingOptions;

  const VotingScreenHost({
    super.key,
    required this.sessionId,
    required this.selectedVotingMode,
    this.votingOptions
  });

  @override
  _VotingScreenHostState createState() => _VotingScreenHostState();
}

class _VotingScreenHostState extends State<VotingScreenHost> {

  final FirebaseAuth _auth = FirebaseAuth.instance;
  final FirebaseFirestore _firestore = FirebaseFirestore.instance;

  dynamic selectedOption;

  @override
  Widget build(BuildContext context) {

    List<String>? votingOptions = widget.votingOptions;
    String sessionId = widget.sessionId;
    String selectedVotingMode = widget.selectedVotingMode;
    selectedOption ??= votingOptions?[0];


    if(votingOptions == null){
      VotingModesProvider votingModesProvider = VotingModesProvider.instance;
      votingOptions =
      fetchVotingOptions(selectedVotingMode, votingModesProvider);
    }

    return Scaffold(
      appBar: AppBar(
        title: const Text('Voting Screen'),
      ),
      body: Stack(
        children: [
          Positioned(
            top: 15,
            left: 0,
            right: 0,
            child: Center(
              child: Text(
                'Session Code: $sessionId',
                style:
                    const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
              ),
            ),
          ),
          Center(
            child: Column(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text('Welcome to the Voting Screen for Host!'),
                Column(
                  children: [
                    PickerCarousel(
                      votingOptions: votingOptions,
                      onItemSelected: (option) {
                        print(option);
                        setState(() {
                          selectedOption =
                              option; // Update selected number in the parent
                        });
                        print(selectedOption);
                      },
                    ),
                    ElevatedButton(
                      onPressed: () async {
                        await FirestoreServices.updateHostSessionVote(sessionId, selectedOption.toString());
                        // Perform any async operations before navigating if needed

                        // Navigate to the next screen after the update is successful
                        if(context.mounted){
                          Navigator.of(context).pushReplacement(
                            MaterialPageRoute(
                              builder: (context) =>
                              VotingResultsScreen(sessionId: sessionId), // Replace with the actual screen you want to navigate to
                            ),
                          );
                        }

                      },
                      child: const Text('Submit Vote'),
                    ),
                  ],
                )
              ],
            ),
          ),
        ],
      ),
    );
  }
}
