using PPPGames.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.Armor
{
    public class BasicArmor : IArmor
    {
        public int Resistance { get; private set; } = 150;

        public void TakeDamage(int damage)
        {
            Resistance = Math.Max(0, Resistance - damage);
        }
    }
}
