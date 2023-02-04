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

        private double _baseStrength = 4;
        public double BaseStrength 
        { 
            get { return _baseStrength; }
            set { _baseStrength = value; } // for powering up
        }

        private double _baseDefence = 2;
        public double BaseDefence
        {
            get { return _baseDefence; }
            set { _baseDefence = value; }
        }

        private double _maxHealth = 10;
        public double MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                _maxHealth = value;
            }
        }

        private int _currentHealth;

        private Weapon _equippedWeapon;
        public Weapon EquippedWeapon { get { return _equippedWeapon; } }
        public void EquipWeapon(Weapon weapon)
        {
            _equippedWeapon = weapon;
        }

        private Armor _equippedArmor;
        public Armor EquippedArmor { get { return _equippedArmor; } }
        public void EquipArmor(Armor armor)
        {
            _equippedArmor = armor;
        }

        public Hero()
        {
            HeroName = null;
        }
    }
}
