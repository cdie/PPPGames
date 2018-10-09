using PPPGames.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPPGames.Models
{
    public class Knight
    {
        public string Name { get; set; }
        public int PointsOfLife { get; set; }
        public int Strenght { get; set; }
        public IWeapon Weapon { get; private set; }
        public bool Alive { get; set; }

        public void Hit(Knight other)
        {
            if (Weapon.Weight > Strenght)
            {
                throw new InvalidOperationException("Such a knight, with this strength, cannot carry a sooooo heavy weapon !");
            }
            other.TakeHit(this);
        }

        public void TakeHit(Knight other)
        {
            PointsOfLife = (int)Math.Max(0, PointsOfLife - other.Weapon.Damage);
            Alive = PointsOfLife > 0;
        }

        public Knight(IWeapon weapon)
        {
            if (Weapon.Weight > Strenght)
            {
                Weapon = new Hand();
            }
            else
            {
                Weapon = weapon;
            }
        }

    }
}
