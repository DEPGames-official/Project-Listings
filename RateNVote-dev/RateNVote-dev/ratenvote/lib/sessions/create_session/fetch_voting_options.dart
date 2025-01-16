import 'package:ratenvote/providers/voting_modes_provider.dart';

List<String> fetchVotingOptions(String votingMode, VotingModesProvider votingModesProvider) {
  // Retrieve the options from the provider based on the selected voting mode
  ServerMode? selectedMode = votingModesProvider.serverModes.firstWhere(
          (mode) => mode.name == votingMode,
      orElse: () => ServerMode(name: 'ERROR GETTING OPTIONS', options: ['ERROR']));

  return selectedMode.options;
}