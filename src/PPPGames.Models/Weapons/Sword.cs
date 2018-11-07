using System;
using System.Collections.Generic;
using System.Text;
using PPPGames.Models.Abstractions;

namespace PPPGames.Models.Weapons
{
    public class Sword : IWeapon
    {
        public virtual int Damage { get; private set; } = 10;

        public virtual int Weight => 8;


        public void EnhanceWeapon(IWeaponEnhancer enhancer)
        {
            Damage += enhancer.EnhancementValue;
        }
    }
}
