using PPPGames.Models.Abstractions;
using PPPGames.Models.Armor;
using PPPGames.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.Stuff
{
    public class EpicStuff : IStuff
    {
        public IArmor Armor { get; }

        public IWeapon Weapon { get; }

        public IWeaponEnhancer WeaponEnhancer { get; }

        public EpicStuff()
        {
            Armor = new BasicArmor();
            Weapon = new Excalibur();
            WeaponEnhancer = null; //Excalibur doesn't need any enhancements, be realistic please...
        }

    }
}
