using PPPGames.Models.Abstractions;
using PPPGames.Models.Armor;
using PPPGames.Models.WeaponEnhancers;
using PPPGames.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.Stuff
{
    public class BasicStuff : IStuff
    {

        public IArmor Armor { get; private set; }

        public IWeapon Weapon { get; private set; }

        public IWeaponEnhancer WeaponEnhancer { get; private set; }

        public BasicStuff()
        {
            Armor = new BasicArmor();
            Weapon = new Sword();
            WeaponEnhancer = new BasicEnhancer();
        }

    }
}
