import 'dart:convert';
import 'package:shared_preferences/shared_preferences.dart';

import 'package:shared_preferences/shared_preferences.dart';
import 'dart:convert';

Future<List<Map<String, String>>> getSavedSessions() async {
  SharedPreferences prefs = await SharedPreferences.getInstance();

  // Retrieve the saved sessions from SharedPreferences
  List<String> savedSessionsJson = prefs.getStringList('saved_sessions') ?? [];

  // Convert the JSON strings to a list of maps
  var savedSessions = savedSessionsJson.map<Map<String, String>>((String session) {
    Map<String, dynamic> sessionMap = jsonDecode(session);
    return {'sessionId': sessionMap['sessionId'], 'hosterName': sessionMap['hosterName']};
  }).toList();

  // Reverse the list
  savedSessions = savedSessions.reversed.toList();

  return savedSessions;
}
