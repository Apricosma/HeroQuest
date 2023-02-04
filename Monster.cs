using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Monster : Hero
    {
        private string _flavorText;
        public string FlavorText
        {
            get { return _flavorText; }
            set { _flavorText = value; }
        }

        private HashSet<Weapon> _dropWeapons = new HashSet<Weapon>()
        {
            new Weapon("Hammer of bonking", 4),
            new Weapon("A paperclip", 0.2),
            new Weapon("Excalibur", 6),
            new Weapon("Frostmourne", 9.5)
        };

        public Weapon GetRandomWeaponDrop()
        {
            HashSet<Weapon> weaponDrops;
            weaponDrops = _dropWeapons.ToHashSet();

            Random random = new Random();
            int index = random.Next(0, weaponDrops.Count);

            Weapon weapon = weaponDrops.ElementAt(index);

            return weapon;
        }

        public Monster(string name, double strength, double defence, double maxHealth, string flavorText ) : base(name, strength, defence, maxHealth) 
        {
            Name = name;
            FlavorText = flavorText;
        }
    }
}
