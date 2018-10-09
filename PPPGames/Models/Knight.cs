using PPPGames.Models.Abstractions;
using PPPGames.Models.Armor;
using PPPGames.Models.FightSkills;
using PPPGames.Models.WeaponEnhancers;
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

            if (Armor?.Resistance > 0)
            {
                Armor.TakeDamage(damage);
                Console.WriteLine($"{Name} avoid {damage} pts of damage, thanks to it's wonderful armor !");
            }
            else
            {
                PointsOfLife = (int)Math.Max(0, PointsOfLife - damage);
                Console.WriteLine($"Outch, {Name} takes {damage} pts of damage.");
            }
            Alive = PointsOfLife > 0;
        }

        public Knight(int strenght, IWeapon weapon, BasicArmor armor, BasicEnhancer weaponEnhancer, SnakeFightSkill fightSkill)
        {
            Strenght = strenght;
            if (weapon.Weight > Strenght)
            {
                Weapon = new Hand();
            }
            else
            {
                Weapon = weapon;
            }

            Armor = armor;
            if (weaponEnhancer != null)
            {
                Weapon.EnhanceWeapon(weaponEnhancer);
            }

            FightSkill = fightSkill;
        }

    }
}
