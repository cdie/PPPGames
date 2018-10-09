using PPPGames.Models;
using PPPGames.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Helpers
{
    public static class GameManager
    {

        public static void RunGame()
        {

            Console.WriteLine("Warrior 1 : Perceval [100 pts of life] - Sword level 10");
            Console.WriteLine("Warrior 2 : Arthur [75 pts of life] - Sword level 99");

            var perceval = new Knight
            {
                Name = "Perceval",
                Alive = true,
                PointsOfLife = 100,
                Weapon = new Sword()
            };
            var arthur = new Knight
            {
                Name = "Arthur",
                Alive = true,
                PointsOfLife = 75,
                Weapon = new Excalibur()
            };

            while (perceval.Alive && arthur.Alive)
            {
                Console.WriteLine("Press 1 to make Perceval hit Arthur");
                Console.WriteLine("Press 2 to make Arthure hit Perceval");

                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                {
                    perceval.Hit(arthur);
                }
                else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                {
                    arthur.Hit(perceval);
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine($"Arthur's life : {arthur.PointsOfLife}");
                Console.WriteLine($"Perceval's life : {perceval.PointsOfLife}");

            }

            Console.WriteLine();
            Console.WriteLine($"Arthur is {(arthur.Alive ? "alive" : "dead")} !");
            Console.WriteLine($"Perceval is {(perceval.Alive ? "alive" : "dead")} !");
            Console.WriteLine();
            Console.WriteLine("Do you want to save game result into a file ? (y/n)");

            var choice = Console.ReadKey().Key;
            if (choice == ConsoleKey.Y)
            {
                GameSaver.SaveGameToText(arthur, perceval);
            }
        }

    }
}
