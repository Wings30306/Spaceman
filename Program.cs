using System;

namespace Spaceman
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Greeting();
            Game game = new Game();
            while (game.DidWin() != true && game.DidLose() != true)
            {
                game.Display();
                game.Ask();
            }

            if (game.DidWin())
            {
                Console.WriteLine("Well done, you've beaten the Cybermen, the human is free!");
            }

            if (game.DidLose())
            {
                Console.WriteLine("Oh no, the Cybermen have succeeded in abducting the human! Better luck next time!");
            }
        }
    }
}
