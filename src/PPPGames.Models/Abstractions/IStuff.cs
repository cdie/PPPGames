using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.Abstractions
{
    public interface IStuff
    {
        IArmor Armor { get; }
        IWeapon Weapon { get; }
        IWeaponEnhancer WeaponEnhancer { get; }

    }
}
