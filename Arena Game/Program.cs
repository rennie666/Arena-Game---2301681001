using Arena_Game;
using System;
using System.Collections.Generic;

namespace ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rounds;
            bool validInput = false;

            do
            {
                Console.Write("Enter number of battles:");
                if (!int.TryParse(Console.ReadLine(), out rounds) || rounds <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer for the number of battles.");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);

            List<Hero> heroes = new List<Hero>
            {
                new Knight("Sir Lancelot"),
                new Rogue("Robin Hood"),
                new Archer("Lara Kroft"),
                new Mage("Merlin")
            };

            for (int i = 0; i < rounds; i++)
            {
                Console.WriteLine("Choose the heroes to battle:");
                Hero attacker = ChooseHero(heroes, "attacker", null);
                Hero defender = ChooseHero(heroes, "defender", attacker);

                Console.WriteLine($"Arena fight between: {attacker.Name} and {defender.Name}");
                Arena arena = new Arena(attacker, defender);
                Hero winner = arena.Battle();
                Console.WriteLine($"Winner is: {winner.Name}");
                Console.WriteLine();

                IncrementWins(winner, heroes);
            }

            Console.WriteLine();
            DisplayWins(heroes);

            Console.ReadLine();
        }

        static string GetHeroInfo(Hero hero)
        {
            string info = $"{hero.Name} ({hero.GetType().Name})";
            if (hero.Weapon != null)
            {
                info += $" with a {hero.Weapon.Name}";
            }
            return info;
        }

        static Hero ChooseHero(List<Hero> heroes, string role, Hero attacker)
        {
            int choice;
            bool validInput = false;

            do
            {
                Console.WriteLine($"Choose {role}:");
                for (int i = 0; i < heroes.Count; i++)
                {
                    if (heroes[i] != attacker)
                    {
                        Console.WriteLine($"{i + 1}. {GetHeroInfo(heroes[i])}");
                    }
                }

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > heroes.Count)
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the hero.");
                }
                else if (heroes[choice - 1] == attacker)
                {
                    Console.WriteLine("You cannot choose the same hero as the attacker.");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);

            return heroes[choice - 1];
        }

        static void IncrementWins(Hero winner, List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                if (hero == winner)
                {
                    hero.Wins++;
                }
            }
        }

        static void DisplayWins(List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine($"{hero.Name}'s wins: {hero.Wins} ");
            }
        }
    }
}
