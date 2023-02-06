using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Upgrades
    {
        private double _powerCost = 10;
        public double PowerCost { get { return _powerCost; } }
        public void UpdatePowerCost()
        {
            _powerCost = _powerCost * 1.15;
        }

        private double _defenceCost = 10;
        public double DefenceCost { get { return _defenceCost; } }
        public void UpdateDefenceCost()
        {
            _defenceCost = _defenceCost * 1.15;
        }

        private double _healthCost = 10;
        public double HealthCost { get { return _healthCost; } }
        public void UpdateHealthCost()
        {
            _healthCost = _healthCost * 1.15;
        }
    }
}
