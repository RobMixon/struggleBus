using System;
using System.Collections.Generic;

namespace guessingGame {
    class Program {
        static void Main (string[] args) {

            Console.WriteLine ("Guess the number that I am thinking from 0-10 and I will grant you one wish!");

            int secretNumber = 42;
            int guess = Convert.ToInt32 (Console.ReadLine ());

            if (guess == secretNumber) {
                Console.WriteLine ("Impossible! How did you know?");
            } else {
                Console.WriteLine ("Bwahahah, incorrect! Guess again");
            }
        }
    }
}