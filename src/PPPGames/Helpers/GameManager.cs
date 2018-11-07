using PPPGames.Infrastructure.Abstractions;
using PPPGames.Models;
using PPPGames.Models.Abstractions;
using PPPGames.Models.Armor;
using PPPGames.Models.FightSkills;
using PPPGames.Models.Stuff;
using PPPGames.Models.WeaponEnhancers;
using PPPGames.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPPGames.Helpers
{
    public class GameManager
    {
        private readonly IGameSaver _gameSaver;

        public GameManager(IGameSaver gameSaver = null)
        {
            _gameSaver = gameSaver;
        }

        public async Task RunGameAsync()
        {
            try
            {
                Console.WriteLine("Warrior 1 : Perceval [100 pts of life] - Sword level 10");
                Console.WriteLine("Warrior 2 : Arthur [75 pts of life] - Sword level 99");

                var perceval = new Knight(
                    new KnightState("Perceval", 100, 100),
                    new BasicStuff(),
                    new SnakeFightSkill());
                var arthur = new Knight(
                    new KnightState("Arthur", 10000, 75),
                    new EpicStuff(),
                    new SnakeFightSkill());

                while (perceval.GetKnightState().Alive && arthur.GetKnightState().Alive)
                {
                    Console.WriteLine("Press 1 to make Perceval hit Arthur");
                    Console.WriteLine("Press 2 to make Arthur hit Perceval");

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
                    Console.WriteLine($"Arthur's stats : life = {arthur.GetKnightState().PointsOfLife} | armor = {arthur.Armor.Resistance}");
                    Console.WriteLine($"Perceval's stats : life = {perceval.GetKnightState().PointsOfLife} | armor = {perceval.Armor.Resistance}");

                }

                Console.WriteLine();
                Console.WriteLine($"Arthur is {(arthur.GetKnightState().Alive ? "alive" : "dead")} !");
                Console.WriteLine($"Perceval is {(perceval.GetKnightState().Alive ? "alive" : "dead")} !");
                Console.WriteLine();
                if (_gameSaver != null)
                {
                    Console.WriteLine("Do you want to save game result into a file ? (y/n)");

                    var choice = Console.ReadKey().Key;
                    if (choice == ConsoleKey.Y)
                    {
                        await _gameSaver.SaveGameResultAsync(arthur, perceval);
                    }
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
