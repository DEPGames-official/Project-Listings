String generateSessionId() {
  DateTime now = DateTime.now();
  int milliseconds = now.millisecondsSinceEpoch;

  // Extracting the last 5 and first 5 digits
  int last5 = milliseconds % 100000;
  int first5 = (milliseconds ~/ 1000000) % 100000;

  // Combining the last 5 and first 5 digits
  int sessionId = last5 + first5;

  return sessionId.toString();
}
