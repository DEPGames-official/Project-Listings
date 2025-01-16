// validators.dart

class Validators {
  // Function to check if the entered email is in a valid format
  static String? validateEmail(String? value) {
    if (value == null || !RegExp(r'^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$').hasMatch(value)) {
      return 'Enter a valid email address';
    }
    return null; // Return null if the email is valid
  }

  // Function to check if the entered password is not empty
  // Function to check if the entered password is not empty and meets the minimum length requirement
  static String? validatePassword(String? value) {
    if (value == null || value.isEmpty) {
      return 'Password cannot be empty';
    } else if (value.length < 6) {
      return 'Password must be at least 6 characters long';
    }
    return null; // Return null if the password is valid
  }

// Function to check if the entered password matches the confirmation and meets the minimum length requirement
  static String? validateConfirmPassword(String? value, String? password) {
    if (value != password) {
      return 'Passwords do not match';
    }
    return null; // Return null if the passwords match and are valid
  }

}
