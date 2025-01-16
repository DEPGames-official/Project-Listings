import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:shared_preferences/shared_preferences.dart';

class CacheServices{
  static void determineUserRole(DocumentSnapshot<Map<String, dynamic>> documentSnapshot) {
    final FirebaseAuth auth = FirebaseAuth.instance;

    String userId = auth.currentUser?.uid ?? '';
    String hostId = documentSnapshot.data()?['hoster'] ?? '';

    // Determine the user's role based on your logic
    String userRole = userId == hostId ? 'host' : 'participant';

    // Save user role and session ID to shared preferences
    saveToSharedPreferences(userRole, documentSnapshot.id);
  }

  static Future<void> saveToSharedPreferences(String userRole, String sessionId) async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    await prefs.setString('userRole', userRole);
    await prefs.setString('sessionId', sessionId);
  }

  static Future<void> retrieveFromSharedPreferences() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String userRole = prefs.getString('userRole') ?? 'participant';
    String sessionId = prefs.getString('sessionId') ?? '';

    print('User Role: $userRole');
    print('Session ID: $sessionId');
  }
}

