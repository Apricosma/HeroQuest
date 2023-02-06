using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Armor : Weapon
    {
        // armor has a small power level to add to the attack of the hero, along with a defense value
        private double _armorValue;
        public double ArmorValue { get { return _armorValue; } }

        public Armor(string name, double power, double armor) : base(name, power)
        {
            _armorValue = armor;
        }
    }
}