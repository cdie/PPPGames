using PPPGames.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.FightSkills
{
    class SnakeFightSkill : IFightSkill
    {

        private Random r = new Random();

        public int GetDamageReducer()
        {
            return r.Next() % 2 == 0 ? 5 : 0;
        }
    }
}
