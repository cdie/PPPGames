using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.Weapons
{
    class Hand : IWeapon
    {
        public int Damage => 1;

        public int Weight => 0;
    }
}
