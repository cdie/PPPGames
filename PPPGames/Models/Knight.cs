using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models
{
    class Knight : Warrior
    {
        public override void Hit(Warrior other)
        {
            other.TakeHit(this);
        }
    }
}
