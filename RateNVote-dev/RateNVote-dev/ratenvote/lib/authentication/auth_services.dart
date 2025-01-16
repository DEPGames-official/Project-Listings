import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:ratenvote/services/firestore_service.dart';

class AuthServices {
  static signupUser(
      String email, String password, String fullName, VoidCallback onSuccess, showSnackBarCustom) async {
    try {
      UserCredential userCredential = await FirebaseAuth.instance
          .createUserWithEmailAndPassword(email: email, password: password);

      await FirebaseAuth.instance.currentUser!.updateDisplayName(fullName);
      await FirebaseAuth.instance.currentUser!.verifyBeforeUpdateEmail(email);
      await FirestoreServices.saveUser(fullName, email, userCredential.user!.uid);

      // Call the provided callback function for successful login
      onSuccess();
      showSnackBarCustom('Registration Successful');

    } on FirebaseAuthException catch (e) {
      if (e.code == 'weak-password') {
        showSnackBarCustom('Password Provided is too weak');
      } else if (e.code == 'email-already-in-use') {
        showSnackBarCustom('Email Provided already Exists');
      }
      else{
        showSnackBarCustom(e.code);
      }
    } catch (e) {
      showSnackBarCustom(e.toString());
    }
  }

  static signinUser(String email, String password, VoidCallback onSuccess, showSnackBarCustom) async {
    try {
      await FirebaseAuth.instance
          .signInWithEmailAndPassword(email: email, password: password);

      // Call the provided callback function for successful login
      onSuccess();
      showSnackBarCustom("Login Successful");

    } on FirebaseAuthException catch (e) {
      if (e.code == 'user-not-found') {
        showSnackBarCustom('User not found');
      } else if (e.code == 'INVALID_LOGIN_CREDENTIALS') {
        showSnackBarCustom('Invalid Login Credentials');
      }
      else{
        showSnackBarCustom(e.code);
      }
    }catch (e){
      showSnackBarCustom(e.toString());
    }
  }

  static signOutUser(VoidCallback onSuccess, showSnackBarCustom) async {
    try {
      await FirebaseAuth.instance.signOut();
      // Call the provided callback function for successful sign-out
      onSuccess();
      showSnackBarCustom('Sign Out Successful');
    } catch (e) {
      showSnackBarCustom(e.toString());
    }
  }
}