using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models
{
    public abstract class Warrior
    {
        public string Name { get; set; }
        public int PointsOfLife { get; set; }
        public int SwordDamage { get; set; }
        public bool Alive { get; set; }

        public abstract void Hit(Warrior other);

        public void TakeHit(Warrior other)
        {
            PointsOfLife = (int)Math.Max(0, PointsOfLife - other.SwordDamage);
            Alive = PointsOfLife > 0;
        }

    }
}
