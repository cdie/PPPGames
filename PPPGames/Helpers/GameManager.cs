using PPPGames.Models;
using PPPGames.Models.Abstractions;
using PPPGames.Models.Armor;
using PPPGames.Models.FightSkills;
using PPPGames.Models.WeaponEnhancers;
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
            try
            {
                Console.WriteLine("Warrior 1 : Perceval [100 pts of life] - Sword level 10");
                Console.WriteLine("Warrior 2 : Arthur [75 pts of life] - Sword level 99");

                var perceval = new Knight(100, new Sword(), new BasicArmor(), new BasicEnhancer(), new SnakeFightSkill())
                {
                    Name = "Perceval",
                    Alive = true,
                    PointsOfLife = 100
                };
                var arthur = new Knight(10000, new Excalibur(), new BasicArmor(), new BasicEnhancer(), new SnakeFightSkill())
                {
                    Name = "Arthur",
                    Alive = true,
                    PointsOfLife = 75
                };

                while (perceval.Alive && arthur.Alive)
                {
                    Console.WriteLine("Press 1 to make Perceval hit Arthur");
                    Console.WriteLine("Press 2 to make Arthure hit Perceval");

                    var key = Console.ReadKey().Key;
                    Console.WriteLine();

                    if (key == ConsoleKey.D1 || key == ConsoleKey.NumPad1)
                    {
                        perceval.Hit(arthur);
                    }
                    else if (key == ConsoleKey.D2 || key == ConsoleKey.NumPad2)
                    {
                        arthur.Hit(perceval);
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Arthur's stats : life = {arthur.PointsOfLife} | armor = {arthur.Armor.Resistance}");
                    Console.WriteLine($"Perceval's stats : life = {perceval.PointsOfLife} | armor = {perceval.Armor.Resistance}");

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
            catch (Exception e)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Whooooops ... Our wonderful game just crashed ... :-(");
                Console.WriteLine("But here's some important pieces of information : ");
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}
