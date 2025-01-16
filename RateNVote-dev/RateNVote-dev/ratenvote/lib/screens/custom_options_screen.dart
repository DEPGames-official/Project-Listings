import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:ratenvote/screens/voting_results_screen.dart';
import 'package:ratenvote/screens/voting_screen_host.dart';
import 'package:ratenvote/providers/voting_modes_provider.dart';
import 'package:ratenvote/sessions/create_session/create_session.dart';
import 'package:ratenvote/sessions/session_helpers/save_session.dart';

class CustomOptionsScreen extends StatefulWidget {
  const CustomOptionsScreen({
    super.key,
    required this.sessionId,
    required this.selectedVotingMode,
    required this.votingModesProvider,
    required this.hosterWantsToVote,
  });

  final String sessionId;
  final String selectedVotingMode;
  final VotingModesProvider votingModesProvider;
  final bool hosterWantsToVote;

  @override
  _CustomOptionsScreenState createState() => _CustomOptionsScreenState();
}

class _CustomOptionsScreenState extends State<CustomOptionsScreen> {
  List<String> votingOptions = [];

  TextEditingController optionController = TextEditingController();

  void _showDuplicateInputSnackbar() {
    ScaffoldMessenger.of(context).showSnackBar(
      const SnackBar(
        content: Text('Can\'t add duplicate inputs'),
        duration: Duration(seconds: 2),
      ),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Custom Voting Options'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            TextField(
              controller: optionController,
              decoration: const InputDecoration(
                labelText: 'Enter Voting Option',
              ),
            ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                final newOption = optionController.text.trim();
                if (newOption.isNotEmpty) {
                  if (!votingOptions.contains(newOption)) {
                    setState(() {
                      votingOptions.add(newOption);
                      optionController.clear();
                    });
                  } else {
                    _showDuplicateInputSnackbar();
                  }
                }
              },
              child: const Text('Add Option'),
            ),
            const SizedBox(height: 16),
            Expanded(
              child: ReorderableListView(
                dragStartBehavior: DragStartBehavior.start,
                onReorder: (oldIndex, newIndex) {
                  setState(() {
                    if (newIndex > oldIndex) {
                      newIndex -= 1;
                    }
                    final String item = votingOptions.removeAt(oldIndex);
                    votingOptions.insert(newIndex, item);
                  });
                },
                children: List.generate(
                  votingOptions.length,
                      (index) {
                    return Row(
                      key: ValueKey(votingOptions[index]),
                      children: [
                        Expanded(
                          child: Text(votingOptions[index]),
                        ),
                        IconButton(
                          icon: const Icon(Icons.delete),
                          onPressed: () {
                            setState(() {
                              votingOptions.removeAt(index);
                            });
                          },
                        ),
                        ReorderableDragStartListener(
                          key: ValueKey(votingOptions[index]),
                          index: index,
                          child: const Icon(Icons.drag_handle),
                        ),
                      ],
                    );
                  },
                ),
              ),
            ),
            const SizedBox(height: 16),
            ElevatedButton(
              onPressed: () {
                createSession(widget.sessionId,
                    widget.selectedVotingMode,
                    widget.votingModesProvider,
                    widget.hosterWantsToVote,
                    votingOptions: votingOptions);
                // Save the session to SharedPreferences
                saveSessionToSharedPreferences(widget.sessionId, "me");

                if (widget.hosterWantsToVote) {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(
                      builder: (context) => VotingScreenHost(
                          sessionId: widget.sessionId,
                          selectedVotingMode:
                          widget.selectedVotingMode,
                          votingOptions: votingOptions),
                    ),
                  );
                } else {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(
                      builder: (context) => VotingResultsScreen(sessionId: widget.sessionId),
                    ),
                  );
                }
              },
              child: const Text('Start'),
            ),
          ],
        ),
      ),
    );
  }
}
