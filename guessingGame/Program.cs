using System;
using System.Collections.Generic;

namespace guessingGame {
    class Program {
        static void Main (string [] args) {

            bool result = doYouWantToPlayAGame ();
            if (result) {
                Console.WriteLine ("Great Job!");
            }
            else {
                Console.WriteLine ("SOrry try again");
            }
        }
        static Boolean doYouWantToPlayAGame () {
            Console.WriteLine ("Lets Play a guessing game!");
            int numTries = difficultyLevel ();
            bool cheater = false;
            if (numTries == 100) {
                cheater = true;
                Console.WriteLine ($"You are a cheater!");
            }
            else {
                Console.WriteLine ($"You get {numTries} attempts");
            }
            int secretNumber = getSecretNumber ();
            bool winner = false;
            int numGuesses = 0;
            while ((numGuesses < numTries && !winner && !cheater) || (cheater && !winner)) {
                int guessNumber = guessANumber ();
                if (guessNumber != secretNumber) {
                    Console.WriteLine ($"Your guess({guessNumber})");
                    if (guessNumber < secretNumber) {
                        Console.WriteLine ("Hint: Your guess was to low");
                    }
                    else {
                        Console.WriteLine ("Hint: Your guess was to high");
                    }
                    Console.WriteLine ("Sorry, wrong number!");
                    if (!cheater) {
                        Console.WriteLine ($"You have {numTries-numGuesses-1} guesses let...");
                        numGuesses++;
                        if (numGuesses == numTries) {
                            Console.WriteLine ("You've used up four guesses! Game over!");
                            Console.WriteLine ($"The secret number was {secretNumber}");
                        }
                    }
                }
                else {
                    winner = true;
                    Console.WriteLine ("Congrats! You guessed the correct number");
                }
            }
            return winner;
        }
        static int getSecretNumber () {
            int secretNumber = new Random ().Next (1, 101);
            return secretNumber;
        }
        static int guessANumber () {
            Console.WriteLine ("Guess the secret number:");
            string answer = Console.ReadLine ().ToLower ();
            while (testNumber (answer) == false) {
                Console.Write ("Guess the secret number?");
                answer = Console.ReadLine ().ToLower ();
            }
            int answerNumeric = Int32.Parse (answer);
            return answerNumeric;
        }
        static Boolean testNumber (string testNumberValue) {
            return int.TryParse (testNumberValue, out int numberValue);
        }
        static int difficultyLevel () {
            List<string> levels = new List<string> () {
                "easy",
                "medium",
                "hard",
                "cheater"
            };
            presentLevels ();
            string diffLevel = Console.ReadLine ().ToLower ();
            while (!levels.Contains (diffLevel)) {
                presentLevels ();
                diffLevel = Console.ReadLine ().ToLower ();
            };
            switch (diffLevel) {
                case "easy":
                    return 8;
                case "medium":
                    return 6;
                case "hard":
                    return 4;
                default:
                    return 100;
            };
        }
        static void presentLevels () {
            Console.WriteLine ("Enter a difficulty level");
            Console.WriteLine ("Easy: 8 guesses ");
            Console.WriteLine ("Medium: 6 guesses ");
            Console.WriteLine ("Hard: 4 guesses ");
            Console.WriteLine ("Cheater: guess until you get it right ");
        }
    }
}