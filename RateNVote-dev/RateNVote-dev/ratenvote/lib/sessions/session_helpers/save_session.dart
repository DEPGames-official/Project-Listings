import 'package:shared_preferences/shared_preferences.dart';

Future<void> saveSessionToSharedPreferences(String sessionId, String hosterName) async {
  SharedPreferences prefs = await SharedPreferences.getInstance();

  // Retrieve existing sessions or create an empty list
  List<String> savedSessions = prefs.getStringList('saved_sessions') ?? [];

  // Add the new session to the list
  savedSessions.add('{"sessionId":"$sessionId","hosterName":"$hosterName"}');

  // Limit the number of saved sessions to 5
  if (savedSessions.length > 5) {
    savedSessions.removeAt(0);
  }

  // Save the updated list to SharedPreferences
  prefs.setStringList('saved_sessions', savedSessions);

  print("SAVED CREATED SESSION");
}