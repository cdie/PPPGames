using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.Weapons
{
    public class Sword : IWeapon
    {
        public virtual int Damage => 10;

        public virtual int Weight => 8;
    }
}
