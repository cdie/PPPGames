using PPPGames.Infrastructure.Abstractions;
using PPPGames.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PPPGames.Infrastructure.Implementation
{
    public class FileGameSaver : IGameSaver
    {
        private readonly DirectoryInfo _directory;

        public FileGameSaver(DirectoryInfo directory)
        {
            _directory = directory ?? throw new ArgumentNullException(nameof(directory));
        }

        public Task SaveGameResultAsync(Knight firstWarrior, Knight secondWarrior)
        {
            return Task.Run(() => File.AppendAllText(Path.Combine(_directory.FullName, "game-resume.txt"), "--- PPP GAMES ---" + Environment.NewLine +
                   $"Result of game of {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}  " + Environment.NewLine +
                   GetWarriorInfos(firstWarrior) + Environment.NewLine +
                   GetWarriorInfos(secondWarrior) + Environment.NewLine));
        }

        private string GetWarriorInfos(Knight warrior)
            => $"{warrior.GetKnightState().Name} is {(warrior.GetKnightState().Alive ? "alive (" + warrior.GetKnightState().PointsOfLife + " pts of life)" : "dead")} !";
    }
}
