# Kursach
Xamarin.Forms app, that supports both cipher and decipher using Viginette cipher method. Allows for any cyrillic codeword to be used during cipher. Tests are applied in a different project in the same solution. Please use the AnroidAppEncoding for testing.
AndroidAppEncoding - main app, that was debugged and tested on emulators.
-Services
--CipherController.cs - logic class, that ciphers and deciphers by a certain keyword
---Methods:
------VerifyText - method that checks if the input text is valid
------VerifyCodeword - methods that checks in the input codeword is valid
------GateControl - method that serves as a main station for getting and calling other methods in that class
------Cipherer - method that ciphers text using the codeword that was applied
------Decipherer - method that deciphers the text
------NormalifyCodeword - method that lenghtens codeword to the length of text by copying itself
------GetTable - method that launches at the start to get vigenette square for future calculations
-Views
--MainPage.xaml - app main and only page where all the interaction is happening, also contains MainPage.xaml.cs with the code behind the xaml page
App.xaml - format page, where different design presets are present
AndroidAppEncoding.Tests - class with test methods
-UnitTest1.cs
--Methods:
------Cipherer_test1 testing cipher
------Cipherer_test2 testing cipher
------Cipherer_test3 testing decipher
