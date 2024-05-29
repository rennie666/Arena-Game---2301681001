namespace Arena_Game
{
    public class Hero
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; set; }
        protected int StartingHealth { get; private set; }
        public bool IsDead { get { return Health <= 0; } }
        public Weapon Weapon { get; private set; }
        public int Wins { get; set; } 

        public Hero(string name, Weapon weapon)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
            Strength = 100;
            Weapon = weapon;
            Wins = 0; 
        }

        public Hero(string name)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
            Strength = 100;
            Wins = 0; 
        }

        public virtual int Attack()
        {
            int attackDamage = CalculateBaseAttackDamage();

            if (Weapon != null && !string.IsNullOrEmpty(Weapon.SpecialAbility))
            {
                if (Weapon.SpecialAbility.Contains("Critical Strike"))
                {
                    if (ThrowDice(20)) 
                    {
                        attackDamage *= 2; 
                        Console.WriteLine("Critical Strike!");
                    }
                }
                else if (Weapon.SpecialAbility.Contains("Precision Shot"))
                {
                    if (ThrowDice(5)) 
                    {
                        attackDamage = 500;
                        Console.WriteLine("Precision Shot");
                    }
                }
                else if (Weapon.SpecialAbility.Contains("Healing Wave"))
                {
                    if (ThrowDice(25)) 
                    {
                        Heal(StartingHealth * 20 / 100); 
                        Console.WriteLine($"{Name} activates Healing Wave!");
                    }

                }
            }

            return attackDamage;
        }

        protected int CalculateBaseAttackDamage()
        {
            return (Strength * Random.Shared.Next(80, 121)) / 100 + (Weapon?.Damage ?? 0);
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            if (incomingDamage < 0) return;
            Health = Health - incomingDamage;
        }

        protected bool ThrowDice(int chance)
        {
            int dice = Random.Shared.Next(101);
            return dice <= chance;
        }

        protected void Heal(int value)
        {
            Health = Health + value;
            if (Health > StartingHealth) Health = StartingHealth;
        }
    }
}