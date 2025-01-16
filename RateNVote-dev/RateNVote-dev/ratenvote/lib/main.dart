import 'package:firebase_auth/firebase_auth.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:flutter/material.dart';
import 'package:ratenvote/firebase_options.dart';
import 'package:ratenvote/screens/main_navigation_screen.dart';
import 'screens/welcome_screen.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp(options: DefaultFirebaseOptions.currentPlatform);
  runApp(
    const MyApp(),
  );
}


class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: StreamBuilder(
        stream: FirebaseAuth.instance.authStateChanges(),
        builder: (context, snapshot) {
          if (snapshot.hasData) {
            // If the user is logged in, show the main navigation structure
            return const MainNavigationScreen();
          } else {
            // If the user is not logged in, show the WelcomeScreen
            return const WelcomeScreen();
          }
        },
      ),
    );
  }
}
