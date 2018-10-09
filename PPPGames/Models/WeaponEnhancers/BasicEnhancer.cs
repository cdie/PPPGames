using PPPGames.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.WeaponEnhancers
{
    class BasicEnhancer : IWeaponEnhancer
    {
        public int EnhancementValue => 10;
    }
}
