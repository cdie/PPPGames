using PPPGames.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPPGames.Infrastructure.Abstractions
{
    public interface IGameSaver
    {

        Task SaveGameResultAsync(Knight firstWarrior, Knight secondWarrior);

    }
}
