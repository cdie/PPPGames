using PPPGames.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models
{
    public interface IWeapon
    {

        int Damage { get; }
        int Weight { get; }

        void EnhanceWeapon(IWeaponEnhancer enhancer);

    }
}
