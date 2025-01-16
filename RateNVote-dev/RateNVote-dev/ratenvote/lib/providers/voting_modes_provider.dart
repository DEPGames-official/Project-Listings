import 'package:flutter/foundation.dart';

class ServerMode {
  final String name;
  final List<String> options;

  ServerMode({required this.name, required this.options});
}

class VotingModesProvider with ChangeNotifier {
  List<ServerMode> _serverModes = [];

  // Private constructor to prevent instantiation from outside
  VotingModesProvider._();

  static VotingModesProvider? _instance; // Make _instance nullable

  // Getter to access the single instance
  static VotingModesProvider get instance {
    _instance ??= VotingModesProvider._(); // Create an instance if it doesn't exist
    return _instance!;
  }

  List<ServerMode> get serverModes => _serverModes;

  set serverModes(List<ServerMode> modes) {
    _serverModes = modes;
    notifyListeners();
  }
}
