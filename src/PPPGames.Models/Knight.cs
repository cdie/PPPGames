using PPPGames.Models.Abstractions;
using PPPGames.Models.Weapons;
using System;

namespace PPPGames.Models
{
    public struct KnightState
    {
        public string Name { get; private set; }
        public int PointsOfLife { get; private set; }
        public bool Alive { get; private set; }
        public int Strenght { get; private set; }

        public KnightState(string name, int strenght, int pointsOfLife)
            : this(name, strenght, pointsOfLife, true)
        {
        }
        public KnightState(string name, int strenght, int pointsOfLife, bool alive)
        {
            Name = name;
            Strenght = strenght;
            PointsOfLife = pointsOfLife;
            Alive = alive;
        }

        public KnightState TakeDamage(int damage)
        {
            var po = Math.Max(0, PointsOfLife - damage);
            bool alive = Alive;
            if (po == 0)
            {
                alive = false;
            }
            return new KnightState(Name, Strenght, po, alive);

        }

    }

    public class Knight
    {
        private KnightState _state;

        public IWeapon Weapon { get; private set; }
        public IArmor Armor { get; private set; }
        public IFightSkill FightSkill { get; private set; }

        public void Hit(Knight other)
        {
            if (Weapon.Weight > _state.Strenght)
            {
                throw new InvalidOperationException("Such a knight, with this strength, cannot carry a sooooo heavy weapon !");
            }
            other.TakeHit(this);
        }

        public KnightState GetKnightState()
            => _state;

        private void TakeHit(Knight other)
        {
            var damage = other.Weapon.Damage;

            if (FightSkill != null)
            {
                var reducer = FightSkill.GetDamageReducer();
                if (reducer > 0)
                {
                    damage -= FightSkill.GetDamageReducer();
                    Console.WriteLine($"{_state.Name} avoid {reducer} pts of damage by using skill!");
                }
                else
                {
                    Console.WriteLine($"{_state.Name} tried to avoid damage by using skill, but failed...");
                }
            }

            var totalDamage = damage;
            if (Armor?.Resistance > 0)
            {
                Armor.TakeDamage(damage);
                totalDamage -= Armor.Resistance;
                Console.WriteLine($"{_state.Name} avoid {damage} pts of damage, thanks to it's wonderful armor !");
            }
            if (totalDamage > 0)
            {
                _state = _state.TakeDamage(totalDamage);
                Console.WriteLine($"Outch, {_state.Name} takes {damage} pts of damage.");
            }
        }

        public Knight(KnightState state, IStuff stuff, IFightSkill fightSkill)
        {
            if (stuff == null)
            {
                throw new ArgumentNullException(nameof(stuff));
            }
            _state = state;
            if (stuff.Weapon.Weight > _state.Strenght)
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
