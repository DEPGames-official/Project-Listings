import 'package:flutter/material.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'main_navigation_screen.dart';

class VotingResultsScreen extends StatelessWidget {
  final String sessionId;

  const VotingResultsScreen({super.key, required this.sessionId});

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: () async {
        Navigator.pushAndRemoveUntil(
          context,
          MaterialPageRoute(builder: (context) => const MainNavigationScreen()),
              (_) => false,
        );
        return false; // Do not allow the back button press
      },
      child: Scaffold(
        appBar: AppBar(
          title: const Text('Results'),
        ),
        body: SingleChildScrollView(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Padding(
                padding: const EdgeInsets.all(16.0),
                child: StreamBuilder(
                  stream: FirebaseFirestore.instance
                      .collection('sessions')
                      .doc(sessionId)
                      .snapshots(),
                  builder: (context, AsyncSnapshot<DocumentSnapshot> snapshot) {
                    if (snapshot.connectionState == ConnectionState.waiting) {
                      return const CircularProgressIndicator();
                    }

                    if (snapshot.hasError) {
                      WidgetsBinding.instance.addPostFrameCallback((_) {
                        ScaffoldMessenger.of(context).showSnackBar(
                          SnackBar(
                            content: Text('Error: ${snapshot.error}'),
                            duration: const Duration(seconds: 3),
                          ),
                        );
                      });

                      return const Text('Error occurred.');
                    }

                    if (!snapshot.hasData || snapshot.data == null) {
                      return const Text('Session not found.');
                    }

                    String hosterName = snapshot.data!['hoster_name'] ?? 'Unknown';
                    String hosterVote = snapshot.data!['hoster_vote'] ?? 'N/A';

                    return Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Text(
                          'Session Code: $sessionId',
                          style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                        ),
                        const SizedBox(),
                        Text(
                          'Hoster: $hosterName\nHoster Vote: $hosterVote',
                          style: const TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                        ),
                      ],
                    );
                  },
                ),
              ),
              StreamBuilder(
                stream: FirebaseFirestore.instance
                    .collection('sessions')
                    .doc(sessionId)
                    .collection('users')
                    .snapshots(),
                builder: (context, AsyncSnapshot<QuerySnapshot> snapshot) {
                  if (snapshot.connectionState == ConnectionState.waiting) {
                    return const Center(
                      child: CircularProgressIndicator(),
                    );
                  }

                  if (snapshot.hasError) {
                    WidgetsBinding.instance.addPostFrameCallback((_) {
                      ScaffoldMessenger.of(context).showSnackBar(
                        SnackBar(
                          content: Text('Error: ${snapshot.error}'),
                          duration: const Duration(seconds: 3),
                        ),
                      );
                    });

                    return const Center(
                      child: Text('Error occurred.'),
                    );
                  }

                  if (snapshot.data == null || snapshot.data!.docs.isEmpty) {
                    return const Center(
                      child: Text('No votes yet.'),
                    );
                  }

                  List<Widget> userWidgets = snapshot.data!.docs.map((DocumentSnapshot document) {
                    Map<String, dynamic> data = document.data() as Map<String, dynamic>;
                    String userName = data['name'];
                    String userVote = data['user_vote'] ?? 'N/A';

                    return ListTile(
                      title: Text(userName),
                      subtitle: Text('Vote: $userVote'),
                      contentPadding: const EdgeInsets.symmetric(horizontal: 16.0, vertical: 0.0),
                    );
                  }).toList();

                  return ListView(
                    shrinkWrap: true,
                    children: userWidgets,
                  );
                },
              ),
            ],
          ),
        ),
      ),
    );
  }
}
