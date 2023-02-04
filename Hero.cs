using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Hero
    {
        private string _name;
        public string Name 
        { 
            get { return _name; }
            set { _name = value; }
        }

        private double _baseStrength;
        public double BaseStrength 
        { 
            get { return _baseStrength; }
            set { _baseStrength = value; } // for powering up
        }

        private double _baseDefence;
        public double BaseDefence
        {
            get { return _baseDefence; }
            set { _baseDefence = value; }
        }

        private double _maxHealth;
        public double MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                _maxHealth = value;
            }
        }

        private double _currentHealth;
        public double CurrentHealth 
        { 
            get { return _currentHealth; }
            set { _currentHealth = value; }
        }

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

        public string GetStats()
        {
            return $"Power: {BaseStrength} | Defence: {BaseDefence} | Current health: {CurrentHealth}/{MaxHealth}";
        }

        public string GetInventory()
        {
            return $"Weapon: {EquippedWeapon}, Armor: {EquippedArmor}";
        }

        public Hero(string name, double strength, double defence, double maxHealth)
        {
            Name = null;
            BaseStrength = strength;
            BaseDefence = defence;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
    }
}
