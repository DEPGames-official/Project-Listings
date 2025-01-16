import 'package:flutter/material.dart';
import 'package:ratenvote/custom/picker_carousel.dart';
import 'package:ratenvote/screens/voting_results_screen.dart';

import 'package:ratenvote/services/firestore_service.dart';

class VotingScreenClient extends StatefulWidget {
  final String sessionId;
  final List<String>? votingOptions;

  const VotingScreenClient(
      {super.key, required this.sessionId, required this.votingOptions});

  @override
  _VotingScreenClientState createState() => _VotingScreenClientState();
}

class _VotingScreenClientState extends State<VotingScreenClient> {
  late bool _loading = false;
  dynamic selectedOption;

  @override
  Widget build(BuildContext context) {

    List<String>? votingOptions = widget.votingOptions;
    String sessionId = widget.sessionId;

    selectedOption ??= votingOptions?[0];

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
                // Use the PickerCarousel widget for voting
                PickerCarousel(
                  votingOptions: votingOptions!.cast<String>(),
                  onItemSelected: (option) {
                    setState(() {
                      selectedOption =
                          option; // Update selected number in the parent
                    });
                  },
                ),
                if (!_loading)
                  ElevatedButton(
                    onPressed: () async {
                      setState(() {
                        _loading = true;
                      });

                      try {
                        // Store the context before entering the async function
                        BuildContext currentContext = context;

                        await FirestoreServices.updateUserSessionVote(
                            sessionId, selectedOption.toString());

                        // Navigate to the next screen after the update is successful
                        if (context.mounted) {
                          Navigator.of(currentContext).pushReplacement(
                            MaterialPageRoute(
                              builder: (context) => VotingResultsScreen(sessionId: sessionId),
                            ),
                          );
                        }
                      } finally {
                        setState(() {
                          _loading = false;
                        });
                      }
                    },
                    child: const Text('Submit Vote'),
                  )
                else
                  const CircularProgressIndicator(),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
