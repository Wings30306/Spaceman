using System;

namespace Spaceman
{
    class Game
    {
        public static void Greeting()
        {
            Console.WriteLine("Oh hello there, I'm the Doctor. " +
                "You must be the cryptanalyst from UNIT. \n" +
                "You're just in time, the Cybermen have created a tractor beam to beam up humans to convert,\n" +
                "and we need to break the code to disable the beam. Can you do it? Here's the code, each _ is a letter:");
        }

        string codeword;
        string currentWord;
        int maxWrongGuesses;
        int currentWrongGuesses;
        string[] guesses;
        string[] codewords = new string[] { "Torchwood", "Gallifrey", "Dalek", "River", "Cyberman", "TARDIS" };
        Ufo spaceship = new Ufo();
        
        public Game()
        {
            Random rnd = new Random();
            int wordIndex = rnd.Next(codewords.Length);
            codeword = codewords[wordIndex].ToLower();
            maxWrongGuesses = 5;
            currentWrongGuesses = 0;
            foreach (char c in codeword)
            {
                currentWord += "_";
            }
        }

        public bool DidWin()
        {
            return codeword.Equals(currentWord);
        }

        public bool DidLose()
        {
            return currentWrongGuesses >= maxWrongGuesses;
        }

        public void Display()
        {
            Console.WriteLine(spaceship.Stringify());
            Console.WriteLine(currentWord);
            Console.WriteLine($"You have {maxWrongGuesses - currentWrongGuesses} wrong guesses remaining.");
        }

        /* Extra challenge: 
         * The game doesn’t record past guesses and doesn’t check if a user has already guessed a letter. Add that feature.
         */

        public void Ask()
        {
            Console.WriteLine("Guess a letter");
            string guess = Console.ReadLine().ToLower();
            if (guess.Length == 1)
            {
                Console.WriteLine($"Your guess was {guess}.");
                if (codeword.Contains(guess))
                {
                    Console.WriteLine($"Yay! {guess.ToUpper()} is in the codeword!");
                    for (int i = 0; i < codeword.Length; i++)
                    {
                        if (codeword[i].ToString() == guess)
                        {
                            currentWord = currentWord.Remove(i, 1).Insert(i, guess);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Oh no, {guess} is not in the codeword!");
                    currentWrongGuesses++;
                    spaceship.AddPart();
                }
            }
            else
            {
                Console.WriteLine("Please guess one letter at a time!");
            }
        }
    }

    


}