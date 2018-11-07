using PPPGames.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models.WeaponEnhancers
{
    public class BasicEnhancer : IWeaponEnhancer
    {
        public int EnhancementValue => 10;
    }
}
