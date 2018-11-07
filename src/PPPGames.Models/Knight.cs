using PPPGames.Models.Abstractions;
using PPPGames.Models.Weapons;
using System;

namespace PPPGames.Models
{
    public class Knight
    {
        public string Name { get; set; }
        public int PointsOfLife { get; set; }
        public int Strenght { get; set; }
        public IWeapon Weapon { get; private set; }
        public IArmor Armor { get; private set; }
        public bool Alive { get; set; }
        public IFightSkill FightSkill { get; private set; }

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
            var damage = other.Weapon.Damage;

            if (FightSkill != null)
            {
                var reducer = FightSkill.GetDamageReducer();
                if (reducer > 0)
                {
                    damage -= FightSkill.GetDamageReducer();
                    Console.WriteLine($"{Name} avoid {reducer} pts of damage by using skill!");
                }
                else
                {
                    Console.WriteLine($"{Name} tried to avoid damage by using skill, but failed...");
                }
            }

            var totalDamage = damage;
            if (Armor?.Resistance > 0)
            {
                Armor.TakeDamage(damage);
                totalDamage -= Armor.Resistance;
                Console.WriteLine($"{Name} avoid {damage} pts of damage, thanks to it's wonderful armor !");
            }
            if(totalDamage > 0)
            {
                PointsOfLife = (int)Math.Max(0, PointsOfLife - totalDamage);
                Console.WriteLine($"Outch, {Name} takes {damage} pts of damage.");
            }
            Alive = PointsOfLife > 0;
        }

        public Knight(int strenght, IStuff stuff, IFightSkill fightSkill)
        {
            if (stuff == null)
            {
                throw new ArgumentNullException(nameof(stuff));
            }

            Strenght = strenght;
            if (stuff.Weapon.Weight > Strenght)
            {
                Weapon = new Hand();
            }
            else
            {
                Weapon = stuff.Weapon;
            }

            Armor = stuff.Armor;
            if (stuff.WeaponEnhancer != null)
            {
                Weapon.EnhanceWeapon(stuff.WeaponEnhancer);
            }

            FightSkill = fightSkill;
        }

    }
}
