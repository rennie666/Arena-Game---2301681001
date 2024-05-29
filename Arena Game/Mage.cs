using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Game
{
    public class Mage : Hero
    {
        static readonly Weapon Wand = new Weapon(30, "Wand", "Healing Wave: 25% chance to heal the hero after each attack.");

        public Mage(string name) : base(name, Wand)
        {
            Strength = 80; 
        }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(20)) 
            {
                attack *= 2; 
            }
            return attack;
        }

        public override void TakeDamage(int incomingDamage)
        {
            if (ThrowDice(25)) 
            {
                incomingDamage = 0;
            }
            base.TakeDamage(incomingDamage);
        }
    }
}

