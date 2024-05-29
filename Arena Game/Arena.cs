namespace Arena_Game
{
    public class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;

            attacker = HeroA;
            defender = HeroB;

            while (true)
            {
                int damage = attacker.Attack();
                LogBattleEvent(attacker, defender, damage);

                defender.TakeDamage(damage);
                if (defender.IsDead)
                {
                    LogBattleEvent(attacker, defender, 0, true);
                    return attacker;
                }

                // Swap the heroes
                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }

        private void LogBattleEvent(Hero attacker, Hero defender, int damage, bool isDefenderDead = false)
        {
            if (isDefenderDead)
            {
                Console.WriteLine($"{defender.Name} has been defeated by {attacker.Name}!");
            }
            else
            {
                Console.WriteLine($"{attacker.Name} attacked {defender.Name} for {damage} damage.");
            }
        }
    }
}
