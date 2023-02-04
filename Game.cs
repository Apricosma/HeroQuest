using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GameAssignment
{
    public static class Game
    {
        private static HashSet<Weapon> Weapons = new HashSet<Weapon>();
        private static HashSet<Armor> Armors = new HashSet<Armor>();
        private static HashSet<Monster> Monsters = new HashSet<Monster>
        {
            new Monster("Bloopy Slime", 0.8, 0.8, 6),
            new Monster("Shy Goblin", 1.2, 0.4, 10),
            new Monster("Sturdy Kobold", 1.6, 3, 18)
        };

        private static Hero hero = new Hero(null, 4, 2, 10);
        public static Weapon TerribadDagger = new Weapon("Terribad Dagger", 1.5);
        public static Armor MiniatureShield = new Armor("Miniature Shield", 0.4, 1.2);    

        private static void setHeroName()
        {
            string gameIntro = "You find yourself weightless, assaulted by a nigh divine brilliance of searing light" +
                "\nWhat happened? You remember nothing of what you were doing an instant ago, a serene sort of forgetfullness filling your mind." +

                "\nThe blistering light gradually begins to fade away as you vision hazes to. You feel your feet make contact with the ground," +
                "and the inescapable, familiar sensation of gravity take hold of you once more." +
                "\nWithin your hand lays a shoddy dagger in disrepair, and your other, a shield barely larger than a book." +
                "\nThe only thing you remember is your name. What may it be, champion?";

            Console.WriteLine(gameIntro);
            string playerName = Console.ReadLine();
            while(true)
            {
                if (playerName.Length < 2 || playerName.Length > 20)
                {
                    Console.WriteLine("You must have missremembered, champion. Your name must be no less than 2 and no greater than 20 letters.");
                    playerName = Console.ReadLine();
                } else
                {
                    hero.Name = playerName;
                    hero.EquipWeapon(TerribadDagger);
                    Weapons.Add(TerribadDagger);

                    hero.EquipArmor(MiniatureShield);
                    Armors.Add(MiniatureShield);

                    // for inventory testing
                    Weapon Fists = new Weapon("Fists", 0.8);
                    Weapons.Add(Fists);
                    return;
                }
            }
            
        }

        private static void GameMenu()
        {
           
            while(true)
            {
                Console.WriteLine("1. Statistics | 2. Inventory | 3. Fight");
                int selection;
                string input = Console.ReadLine();

                if (!int.TryParse(input, out selection))
                {
                    Console.WriteLine("Invalid input. Only enter numbers");
                    continue;
                }

                if (selection < 1 || selection > 3)
                {
                    Console.WriteLine("Please only enter numbers between 1 and 3");
                    continue;
                }

                switch(selection)
                {
                    case 1:
                        // statistics
                        break;
                    case 2:
                        // inventory
                        DisplayInventoryMenu();
                        break;
                    case 3:
                        Console.WriteLine("Good luck, {hero.HeroName}");
                        break;
                        
                }
            }
        }

        private static void StashWeapon(Weapon weapon)
        {
            Weapons.Add(weapon);
        }

        private static void StashArmor(Armor armor)
        {
            Armors.Add(armor);
        }

        private static void DisplayInventoryMenu()
        {
            Console.WriteLine("welcome to your inventory");

            bool looping = true;

            while(looping)
            {
                Console.WriteLine("1. Display all weapons | 2. Display all armor | 3. Equip a piece of gear | 4. Leave inventory");
                int selection;
                string input = Console.ReadLine();

                if (!int.TryParse(input, out selection))
                {
                    Console.WriteLine("Invalid input. Only enter numbers");
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        GetAllWeapons();
                        break;
                    case 2:
                        GetAllArmors();
                        break;
                    case 3:
                        ChangeEquippedItem();
                        break;
                    case 4:
                        looping = false;
                        return;
                }
            }
        }

        private static void GetAllWeapons()
        {
            foreach (Weapon w in Weapons)
            {
                Console.WriteLine($"{w.Name} | Power: {w.Power}");
            }
        }

        private static void GetAllArmors() 
        {
            foreach (Armor a in Armors)
            {
                Console.WriteLine($"{a.Name} | Power: {a.Power} | Armor: {a.ArmorValue}");
            }
        }

        private static void ChangeEquippedItem()
        {
            bool looping = true;

            while(looping)
            {
                Console.WriteLine("1. Change weapon | 2. Change armor | 3. Return to Inventory");
                int selection;
                string input = Console.ReadLine();

                if (!int.TryParse(input, out selection))
                {
                    Console.WriteLine("Invalid input. Only enter numbers");
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        GetAllWeapons();
                        ChangeEquippedWeapon();
                        break;
                    case 2:
                        GetAllArmors();
                        ChangeEquippedArmor();
                        break;
                    case 3:
                        DisplayInventoryMenu();
                        return;
                }
            }
        }

        private static void ChangeEquippedWeapon()
        {
            Console.WriteLine("Enter the name of the weapon you want to equip");
            string weaponName = Console.ReadLine();

            Weapon weapon = Weapons.FirstOrDefault(w => w.Name == weaponName);
            if (weapon == hero.EquippedWeapon)
            {
                Console.WriteLine("You already have that weapon equipped");
                return;
            }
            if (weapon != null)
            {
                hero.EquipWeapon(weapon);
                Console.WriteLine($"{hero.Name} equipped {weapon.Name}");
            } else
            {
                Console.WriteLine("You don't own that weapon! Make sure you've typed the name correctly");
            }
        }

        private static void ChangeEquippedArmor()
        {
            Console.WriteLine("Enter the name of the armor you want to equip");
            string armorName = Console.ReadLine();

            Armor armor = Armors.FirstOrDefault(a => a.Name == armorName);
            if (armor != null)
            {
                hero.EquipArmor(armor);
                Console.WriteLine($"{hero.Name} equipped {armor.Name}");
            }
        }

        public static Monster GetRandomMonster()
        {
            Random random = new Random();
            int index = random.Next(0, Monsters.Count);

            Monster randomMonster = Monsters.ElementAt(index);
            return randomMonster;
        }

        public static void StartGame()
        {
            setHeroName();
            GameMenu();
        }
    }
}
