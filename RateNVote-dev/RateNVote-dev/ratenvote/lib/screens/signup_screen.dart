import 'package:flutter/material.dart';
import 'package:ratenvote/authentication/auth_services.dart';
import 'package:ratenvote/screens/session_options_screen.dart';
import 'package:ratenvote/validation/validators.dart';

class SignupScreen extends StatefulWidget {
  const SignupScreen({super.key});

  @override
  _SignupScreenState createState() => _SignupScreenState();
}

class _SignupScreenState extends State<SignupScreen> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  bool _isRegistering = false;

  // Function to handle navigation after successful signup
  void _navigateToSessionOptionsScreen() {
    Navigator.pushAndRemoveUntil(
      context,
      MaterialPageRoute(builder: (context) => const SessionOptionsScreen()),
          (_) => false,
    );
  }

  void showSnackBarCustom(String text) {
    ScaffoldMessenger.of(context).showSnackBar(
      SnackBar(content: Text(text)),
    );
  }

  late String _name;
  late String _surname;
  late String _email;
  late String _password;

  late String _fullName;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Sign Up'),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: ListView(
          children: [
            Form(
              key: _formKey,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  TextFormField(
                    decoration: const InputDecoration(
                      labelText: 'Name',
                      border: OutlineInputBorder(),
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Name cannot be empty';
                      }
                      return null;
                    },
                    onSaved: (value) => _name = value!,
                  ),
                  const SizedBox(height: 16.0),
                  TextFormField(
                    decoration: const InputDecoration(
                      labelText: 'Surname',
                      border: OutlineInputBorder(),
                    ),
                    validator: (value) {
                      if (value == null || value.isEmpty) {
                        return 'Surname cannot be empty';
                      }
                      return null;
                    },
                    onSaved: (value) => _surname = value!,
                  ),
                  const SizedBox(height: 16.0),
                  TextFormField(
                    decoration: const InputDecoration(
                      labelText: 'Email',
                      border: OutlineInputBorder(),
                    ),
                    keyboardType: TextInputType.emailAddress,
                    validator: Validators.validateEmail,
                    onSaved: (value) => _email = value!,
                  ),
                  const SizedBox(height: 16.0),
                  TextFormField(
                    decoration: const InputDecoration(
                      labelText: 'Password',
                      border: OutlineInputBorder(),
                    ),
                    obscureText: true, // Hides the entered text
                    validator: Validators.validatePassword,
                    onChanged: (value) {
                      setState(() {
                        _password = value;
                      });
                    },
                  ),
                  const SizedBox(height: 16.0),
                  TextFormField(
                    decoration: const InputDecoration(
                      labelText: 'Confirm Password',
                      border: OutlineInputBorder(),
                    ),
                    obscureText: true, // Hides the entered text
                    validator: (value) =>
                        Validators.validateConfirmPassword(value, _password),
                    onChanged: (value) {
                      setState(() {
                      });
                    },
                  ),
                  const SizedBox(height: 16.0),
                  _isRegistering
                      ? const CircularProgressIndicator() // Show a loading indicator when registering
                      : ElevatedButton(
                    onPressed: () async {
                      if (_formKey.currentState!.validate()) {
                        _formKey.currentState!.save();
                        setState(() {
                          _isRegistering = true;
                        });

                        _fullName = '$_name $_surname';
                        await AuthServices.signupUser(
                          _email,
                          _password,
                          _fullName,
                          _navigateToSessionOptionsScreen,
                          showSnackBarCustom,
                        );

                        setState(() {
                          _isRegistering = false;
                        });
                      }
                    },
                    child: const Text('Sign Up'),
                  ),
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
