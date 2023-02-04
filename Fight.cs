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
        private Monster _monster { get; set; }

        public Fight(Hero hero, Monster monster)
        {
            _hero = hero;
            _monster = monster;
        }

        public void Fighting()
        {
            Console.WriteLine($"You encounter a {_monster.Name}! (power: {_monster.BaseStrength}, defense: {_monster.BaseDefence})");
            Console.WriteLine(_monster.FlavorText);
            Console.WriteLine();
            while (_hero.CurrentHealth > 0 && _monster.CurrentHealth > 0) 
            {
                Thread.Sleep(2000);
                HeroTurn();
                Console.WriteLine($"{_hero.Name} HP: {_hero.CurrentHealth} | {_monster.Name} HP: {_monster.CurrentHealth}");
                if (_monster.CurrentHealth <= 0)
                {
                    Win();
                    return;
                }
                Console.WriteLine();

                Thread.Sleep(2000);
                MonsterTurn();
                Console.WriteLine($"{_hero.Name} HP: {_hero.CurrentHealth} | {_monster.Name} HP: {_monster.CurrentHealth}");
                if (_hero.CurrentHealth <= 0)
                {
                    Lose();
                    return;
                }
                Console.WriteLine();
            }

        }

        private void HeroTurn()
        {
            double damage = Math.Round(_hero.BaseStrength + _hero.EquippedWeapon.Power - _monster.BaseDefence, 2);
            damage *= RandomMultiplier();
            

            if (damage > 0)
            {
                Console.WriteLine($"{_hero.Name} deals {damage} to {_monster.Name}");
                _monster.CurrentHealth -= damage;
            } else
            {
                Console.WriteLine($"You deal zero damage to {_monster.Name}!");
            }
        }

        private void MonsterTurn()
        {
            double damage = Math.Round(_monster.BaseStrength - (_hero.BaseDefence + _hero.EquippedArmor.Power), 2);
            damage *= RandomMultiplier();
            Console.WriteLine($"{_monster.Name} deals {damage} to {_hero.Name}");

            if (damage > 0)
            {
                Console.WriteLine($"{_hero.Name} deals {damage} to {_monster.Name}");
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
            return Math.Round(random.NextDouble(), 2);
        }

        private void ResetHealth()
        {
            _monster.CurrentHealth = _monster.MaxHealth;
            _hero.CurrentHealth = _hero.MaxHealth;
        }
    }
}
