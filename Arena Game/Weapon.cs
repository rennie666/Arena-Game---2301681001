using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena_Game
{
    public class Weapon
    {
        public int Damage { get; }
        public string Name { get; }
        public string SpecialAbility { get; }

        public Weapon(int damage, string name, string specialAbility)
        {
            Damage = damage;
            Name = name;
            SpecialAbility = specialAbility;
        }
    }

}
