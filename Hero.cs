using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Hero
    {
        private string _heroName;
        public string HeroName 
        { 
            get { return _heroName; }
            set { _heroName = value; }
        }

        private int _baseStrength;

        private int _baseDefence;

        private int _maxHealth;

        private int _currentHealth;

        private Weapon _equippedWeapon;

        private Armor _equippedArmor;

        public Hero()
        {
            HeroName = null;
        }
    }
}
