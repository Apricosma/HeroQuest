using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Weapon
    {
        private string _name;
        public string Name { get { return _name; } }
        public void _setWeaponName(string weaponName)
        {
            _name = weaponName;
        }

        // I kind of want to make the weapon power a multiplier rather than a base gain,
        // but I'll leave it as flat for now
        private double _power;
        public double Power { get { return _power; } }
        public void _setWeaponPower(double weaponPower)
        {
            _power = weaponPower;
        }

        // possible armor penetration system
        // private int _armorPen ?

        public Weapon(string name, double power)
        {
            _setWeaponName(name);
            _setWeaponPower(power);
        }
    }
}