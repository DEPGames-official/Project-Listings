
import 'package:flutter/material.dart';

import 'package:ratenvote/sessions/session_helpers/get_sessions.dart';

import '../sessions/join_sessions/join_session.dart';

class RecentSessionsScreen extends StatefulWidget {
  const RecentSessionsScreen({super.key});

  @override
  _RecentSessionsScreenState createState() => _RecentSessionsScreenState();
}

class _RecentSessionsScreenState extends State<RecentSessionsScreen> {
  late Future<List<Map<String, String>>> savedSessions;
  bool _loading = false;

  @override
  void initState() {
    super.initState();
    // Fetch saved sessions when the widget is first created
    savedSessions = getSavedSessions();
  }

  @override
  Widget build(BuildContext context) {
    return PopScope(
      canPop: false,
      child: Scaffold(
        appBar: AppBar(
          title: const Text('Recent Sessions'),
        ),
        body: FutureBuilder<List<Map<String, String>>>(
          future: savedSessions,
          builder: (context, AsyncSnapshot<List<Map<String, String>>> snapshot) {
            if (snapshot.connectionState == ConnectionState.waiting) {
              // Show a loading indicator while fetching data
              return const CircularProgressIndicator();
            } else if (snapshot.hasError) {
              // Handle errors
              return Text('Error: ${snapshot.error}');
            } else {
              // Display the data when available
              List<Map<String, String>> sessions = snapshot.data ?? [];
              return ListView.builder(
                itemCount: sessions.length,
                itemBuilder: (context, index) {
                  String sessionId = '${sessions[index]['sessionId']}';
                  String hostName = sessions[index]['hosterName'] ?? 'Unknown Host';

                  return GestureDetector(
                    onTap: () {
                      _startSessionQuery(sessionId);
                    },
                    child: Card(
                      child: ListTile(
                        title: Text('Session $sessionId'),
                        subtitle: Text('Hosted by: $hostName'),
                        // Add more details or actions as needed
                      ),
                    ),
                  );
                },
              );
            }
          },
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
