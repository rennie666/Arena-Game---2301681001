using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Game
{
    public class Knight : Hero
    {
        const int BlockDamageChance = 10;
        private const int ExtraDamageChance = 5;

        static readonly Weapon Sword = new Weapon(50, "Sword", "Precision Shot: 5% chance of an instant kill");

        public Knight(string name) : base(name, Sword)
        {

        }

        public override void TakeDamage(int incomingDamage)
        {
            //Apply armor
            int damageReduceCoef = Random.Shared.Next(20, 61);
            incomingDamage =
                incomingDamage - ((incomingDamage * damageReduceCoef) / 100);
            //Apply special skill: block
            if (ThrowDice(BlockDamageChance)) incomingDamage = 0;
            //Default behavior
            base.TakeDamage(incomingDamage);
        }

        public override int Attack()
        {
            int attack = base.Attack();
            if (ThrowDice(ExtraDamageChance)) attack = attack * 150 / 100;
            return attack;
        }
    }
}
