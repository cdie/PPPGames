using System;
using System.Collections.Generic;
using System.Text;
using PPPGames.Models.Abstractions;

namespace PPPGames.Models.Weapons
{
    class Hand : IWeapon
    {
        public int Damage { get; private set; } = 1;

        public int Weight => 0;

        public void EnhanceWeapon(IWeaponEnhancer enhancer)
        {
            Damage += enhancer.EnhancementValue;
        }
    }
}
