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
        private static Hero hero = new Hero();

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
                    hero.HeroName = playerName;
                    return;
                }
            }
            
        }

        private static void GameMenu()
        {
            Console.WriteLine("1. New Game | 2. Continue(NYI) | 3. Quit");
            
            while(true)
            {
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
                        Console.WriteLine($"Starting game, {hero.HeroName}.");
                        // start the game
                        break;
                    case 2:
                        Console.WriteLine("Not yet implemented");
                        // continue where left off
                        return;
                    case 3:
                        // quit the game
                        Console.WriteLine("Thanks for playing");
                        return;
                        
                }
            }
        }

        public static void StartGame()
        {
            setHeroName();
            GameMenu();
        }
    }
}
