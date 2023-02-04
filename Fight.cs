using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Fight
    {
        private Hero _hero { get; set; }
        public Monster Monster { get; set; }

        public Fight(Hero hero, Monster monster)
        {
            _hero = hero;
            Monster = monster;
        }

        public int Fighting()
        {
            Console.WriteLine($"You encounter a {Monster.Name}! (power: {Monster.BaseStrength}, defense: {Monster.BaseDefence})");
            Console.WriteLine(Monster.FlavorText);
            Console.WriteLine();
            while (_hero.CurrentHealth > 0 && Monster.CurrentHealth > 0) 
            {
                //Thread.Sleep(2000);
                HeroTurn();
                Console.WriteLine($"{_hero.Name} HP: {_hero.CurrentHealth} | {Monster.Name} HP: {Monster.CurrentHealth}");
                if (Monster.CurrentHealth <= 0)
                {
                    Win();
                    return 1;
                }
                Console.WriteLine();

                //Thread.Sleep(2000);
                MonsterTurn();
                Console.WriteLine($"{_hero.Name} HP: {_hero.CurrentHealth} | {Monster.Name} HP: {Monster.CurrentHealth}");
                if (_hero.CurrentHealth <= 0)
                {
                    Lose();
                    return -1;
                }
                Console.WriteLine();
            }
            return -1;
        }

        private void HeroTurn()
        {
            double damage = Math.Round(_hero.BaseStrength + _hero.EquippedWeapon.Power - Monster.BaseDefence, 2);
            damage *= RandomMultiplier();
            

            if (damage > 0)
            {
                Console.WriteLine($"{_hero.Name} deals {damage} to {Monster.Name}");
                Monster.CurrentHealth -= damage;
            } else
            {
                Console.WriteLine($"You deal zero damage to {Monster.Name}!");
            }
        }

        private void MonsterTurn()
        {
            double damage = Math.Round(Monster.BaseStrength - (_hero.BaseDefence + _hero.EquippedArmor.Power), 2);
            damage *= RandomMultiplier();
            Console.WriteLine($"{Monster.Name} deals {damage} to {_hero.Name}");

            if (damage > 0)
            {
                Console.WriteLine($"{_hero.Name} deals {damage} to {Monster.Name}");
                _hero.CurrentHealth -= damage;
            } else
            {
                Console.WriteLine($"{_hero.Name} takes zero damage!");
            }
            
        }

        private void Win()
        {
            Console.WriteLine("The hero wins");
            ResetHealth();
        }

        private void Lose()
        {
            Console.WriteLine("The hero has died!");
            ResetHealth();
        }

        // returns a value between 0 and 1 with two points of precision
        private double RandomMultiplier()
        {
            Random random = new Random();
            return Math.Round(random.NextDouble(), 3);
        }

        private void ResetHealth()
        {
            Monster.CurrentHealth = Monster.MaxHealth;
            _hero.CurrentHealth = _hero.MaxHealth;
        }
    }
}
