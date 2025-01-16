import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:ratenvote/authentication/auth_services.dart';
import 'package:ratenvote/services/firestore_service.dart';
import 'create_session_screen.dart';
import 'join_session_screen.dart';

class SessionOptionsScreen extends StatefulWidget {
  const SessionOptionsScreen({super.key});

  @override
  _SessionOptionsScreenState createState() => _SessionOptionsScreenState();
}

class _SessionOptionsScreenState extends State<SessionOptionsScreen> {
  bool _signingOut = false;

  @override
  void initState() {
    super.initState();
    //Updates and returns provider stored modes
    FirestoreServices.fetchAvailableServerModes();
  }


  void _navigateToWelcomeScreen() {
    Navigator.pushNamedAndRemoveUntil(
      context,
      '/',
          (route) => false, // This line removes all the previous routes from the stack
    );
  }

  void _joinSessionScreen(){
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => const JoinSessionScreen(),
      ),
    );
  }

  void _createSessionScreen(){
    Navigator.push(
      context,
      MaterialPageRoute(
        builder: (context) => const CreateSessionScreen(),
      ),
    );
  }


  void showSnackBarCustom(String text){
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text(text)),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Session Options'),
        automaticallyImplyLeading: false,
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            ElevatedButton(
              onPressed: () {
                FirebaseAuth auth = FirebaseAuth.instance;
                User? user = auth.currentUser;
                print(user);
                _createSessionScreen();
              },
              child: const Text('Create a Voting Session'),
            ),
            ElevatedButton(
              onPressed: () {
                _joinSessionScreen();
              },
              child: const Text('Join a Voting Session'),
            ),
            const SizedBox(height: 20),
            ElevatedButton.icon(
              onPressed: _signingOut ? null : () async {
                setState(() {
                  _signingOut = true;
                });
                try {
                  await AuthServices.signOutUser(
                      _navigateToWelcomeScreen, showSnackBarCustom);
                } catch (e) {
                  print('Error signing out: $e');
                } finally {
                  setState(() {
                    _signingOut = false;
                  });
                }
              },
              icon: Icon(Icons.exit_to_app,
                  color: _signingOut ? Colors.grey : Colors.red),
              label: Text(
                'Sign Out',
                style: TextStyle(
                  color: _signingOut ? Colors.grey : Colors.red,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }

}
