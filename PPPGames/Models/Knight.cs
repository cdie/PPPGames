using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models
{
    public class Knight
    {
        public string Name { get; set; }
        public int PointsOfLife { get; set; }
        public int SwordDamage { get; set; }
        public bool Alive { get; set; }

        public void Hit(Knight other)
        {
            other.TakeHit(this);
        }

        public void TakeHit(Knight other)
        {
            PointsOfLife = (int)Math.Max(0, PointsOfLife - other.SwordDamage);
            Alive = PointsOfLife > 0;
        }

    }
}
