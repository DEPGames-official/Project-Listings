import 'package:flutter/material.dart';
import 'package:ratenvote/providers/voting_modes_provider.dart';
import 'package:ratenvote/screens/voting_results_screen.dart';
import 'package:ratenvote/screens/voting_screen_host.dart';
import 'package:ratenvote/sessions/create_session/create_session.dart';
import 'package:ratenvote/sessions/create_session/session_id_algorithm.dart';
import 'package:ratenvote/sessions/session_helpers/save_session.dart';
import 'package:ratenvote/screens/custom_options_screen.dart';

class CreateSessionScreen extends StatefulWidget {
  const CreateSessionScreen({super.key});

  @override
  _CreateSessionScreenState createState() => _CreateSessionScreenState();
}

class _CreateSessionScreenState extends State<CreateSessionScreen> {
  String selectedVotingMode = 'Custom';
  bool hosterWantsToVote = false;
  List<String> predefinedModes = ['Custom', '0 To 10', 'Fibonacci Series To 13'];

  @override
  Widget build(BuildContext context) {
    VotingModesProvider votingModesProvider = VotingModesProvider.instance;
    List<String> availableModesNames = votingModesProvider.serverModes.map((mode) => mode.name).toList();
    List<String> combinedModes = {...predefinedModes, ...availableModesNames}.toList();

    return Scaffold(
      appBar: AppBar(
        title: const Text('Create Voting Session'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Container(
                padding: const EdgeInsets.symmetric(horizontal: 12.0),
                decoration: BoxDecoration(
                  borderRadius: BorderRadius.circular(8.0),
                  border: Border.all(color: Colors.grey),
                ),
                child: DropdownButton<String>(
                  isExpanded: true,
                  hint: const Text('Select Voting Mode'),
                  value: selectedVotingMode,
                  onChanged: (String? newValue) {
                    setState(() {
                      selectedVotingMode = newValue!;
                    });
                  },
                  items: combinedModes
                      .map<DropdownMenuItem<String>>((String value) {
                    return DropdownMenuItem<String>(
                      value: value,
                      child: Text(value),
                    );
                  })
                      .toList(),
                ),
              ),
            ),

            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                const Text('Do you want to vote?'),
                Checkbox(
                  value: hosterWantsToVote,
                  onChanged: (bool? newValue) {
                    setState(() {
                      hosterWantsToVote = newValue ?? false;
                    });
                  },
                ),
              ],
            ),

            ElevatedButton(
              onPressed: () {
                String sessionId = generateSessionId();
                if(selectedVotingMode == 'Custom'){
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => CustomOptionsScreen(sessionId: sessionId, selectedVotingMode: selectedVotingMode, votingModesProvider: votingModesProvider, hosterWantsToVote: hosterWantsToVote),
                    ),
                  );
                  return;
                }


                createSession(sessionId, selectedVotingMode, votingModesProvider, hosterWantsToVote);

                // Save the session to SharedPreferences
                saveSessionToSharedPreferences(sessionId, "me");

                if (hosterWantsToVote) {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(
                      builder: (context) => VotingScreenHost(sessionId: sessionId, selectedVotingMode: selectedVotingMode),
                    ),
                  );
                } else {
                  Navigator.pushReplacement(
                    context,
                    MaterialPageRoute(
                      builder: (context) => VotingResultsScreen(sessionId: sessionId),
                    ),
                  );
                }
              },
              child: const Text('Start Voting'),
            ),
          ],
        ),
      ),
    );
  }
}
