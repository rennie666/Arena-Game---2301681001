using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Game
{
    
        public class Archer : Hero
        {
            private const int DoubleDamageChance = 20;

            static readonly Weapon Bow = new Weapon(40, "Bow", "Critical Strike: 20% chance to deal double damage.");
            public Archer(string name) : base(name, Bow)
            {
                Strength = 120;
            }

            public override int Attack()
            {
                int attack = base.Attack();
                if (ThrowDice(DoubleDamageChance))
                {
                    attack *= 2;
                }
                return attack;
            }

            public override void TakeDamage(int incomingDamage)
            {
                int mitigation = Weapon.Name == "Bow" ? 15 : 0;
                incomingDamage -= mitigation;
                if (incomingDamage < 0) incomingDamage = 0;
                base.TakeDamage(incomingDamage);
            }
        }

    }

