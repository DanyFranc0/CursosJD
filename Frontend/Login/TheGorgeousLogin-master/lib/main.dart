import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
// import 'package:the_gorgeous_login/pages/login_page.dart';
import 'package:the_gorgeous_login/pages/test.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  SystemChrome.setPreferredOrientations(<DeviceOrientation>[
    DeviceOrientation.portraitUp,
    DeviceOrientation.portraitDown,
  ]);

  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      debugShowCheckedModeBanner: false,
      title: 'Inicio de sesion',
      home: Categorias(),
    );
  }
}