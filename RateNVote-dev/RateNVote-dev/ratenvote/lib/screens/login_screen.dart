import 'package:flutter/material.dart';
import 'package:ratenvote/authentication/auth_services.dart';
import 'main_navigation_screen.dart';
import 'package:ratenvote/validation/validators.dart';

class LoginScreen extends StatefulWidget {
  const LoginScreen({super.key});

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  final _formKey = GlobalKey<FormState>();
  // User Info
  late String _email;
  late String _password;

  bool _isLoggingIn = false;

  // Function to handle navigation after successful login
  void _navigateToSessionOptionsScreen() {
    Navigator.pushAndRemoveUntil(
      context,
      MaterialPageRoute(builder: (context) => const MainNavigationScreen()),
          (_) => false,
    );
  }

  void showSnackBarCustom(String text) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text(text)),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Login'),
      ),
      body: Form(
        key: _formKey,
        child: Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              // Email input field with validation
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: TextFormField(
                  decoration: const InputDecoration(
                    labelText: 'Email',
                    border: OutlineInputBorder(),
                  ),
                  keyboardType: TextInputType.emailAddress,
                  validator: Validators.validateEmail,
                  onSaved: (value) => _email = value!,
                ),
              ),

              // Password input field with validation
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: TextFormField(
                  decoration: const InputDecoration(
                    labelText: 'Password',
                    border: OutlineInputBorder(),
                  ),
                  obscureText: true, // Hides the entered text
                  onSaved: (value) => _password = value!,
                ),
              ),

              // Login button
              _isLoggingIn
                  ? const CircularProgressIndicator() // Show a loading indicator when logging in
                  : ElevatedButton(
                onPressed: () async {
                  // Perform login logic using the entered email and password
                  // For now, navigate to the session options screen if the form is valid
                  if (_formKey.currentState!.validate()) {
                    _formKey.currentState!.save();
                    setState(() {
                      _isLoggingIn = true;
                    });

                    await AuthServices.signinUser(
                      _email,
                      _password,
                      _navigateToSessionOptionsScreen,
                      showSnackBarCustom,
                    );

                    setState(() {
                      _isLoggingIn = false;
                    });
                  }
                },
                child: const Text('Login'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
