import 'package:flutter/material.dart';
import 'package:ratenvote/services/firestore_service.dart';
import 'package:ratenvote/sessions/join_sessions/join_session.dart';
import 'package:ratenvote/sessions/session_helpers/save_session.dart';

class JoinSessionScreen extends StatefulWidget {
  const JoinSessionScreen({super.key});

  @override
  _JoinSessionScreenState createState() => _JoinSessionScreenState();
}

class _JoinSessionScreenState extends State<JoinSessionScreen> {
  final TextEditingController _sessionIdController = TextEditingController();

  bool _loading = false;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Join Voting Session'),
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: TextField(
                controller: _sessionIdController,
                decoration: const InputDecoration(
                  labelText: 'Enter Session Code',
                  border: OutlineInputBorder(),
                ),
              ),
            ),
            // Show the button or loading indicator based on the _loading state
            if (!_loading)
              ElevatedButton(
                onPressed: () async {
                  // Get the entered session code
                  String sessionId = _sessionIdController.text;


                  String? hosterName = await FirestoreServices.getHosterName(sessionId);
                  saveSessionToSharedPreferences(sessionId, hosterName!);

                  _startSessionQuery(sessionId);
                },
                child: const Text('Join Session'),
              )
            else
              const CircularProgressIndicator(),
          ],
        ),
      ),
    );
  }

  Future<void> _startSessionQuery(String sessionId) async {
    JoinSessionHelper.startSessionQuery(
      context,
      sessionId,
          (bool loading) {
        setState(() {
          _loading = loading;
        });
      },
    );
  }

}
