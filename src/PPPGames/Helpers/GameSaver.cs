using PPPGames.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PPPGames.Helpers
{
    public static class GameSaver
    {

        public static void SaveGameToText(Knight firstWarrior, Knight secondWarrior)
        {
            File.AppendAllText("./game-resume.txt", "--- PPP GAMES ---" + Environment.NewLine +
                   $"Result of game of {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}  " + Environment.NewLine +
                   GetWarriorInfos(firstWarrior) + Environment.NewLine +
                   GetWarriorInfos(secondWarrior));
        }

        private static string GetWarriorInfos(Knight warrior)
            => $"{warrior.GetKnightState().Name} is {(warrior.GetKnightState().Alive ? "alive (" + warrior.GetKnightState().PointsOfLife + " pts of life)" : "dead")} !";

    }
}
