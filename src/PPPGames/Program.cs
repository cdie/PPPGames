using PPPGames.Helpers;
using PPPGames.Models;
using System;
using System.IO;

namespace PPPGames
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PPPGames - Let's get ready !");

            GameManager.RunGame();

            Console.WriteLine();
            Console.WriteLine("Game finished ! Press enter to exit");
            Console.Read();
        }
    }
}
