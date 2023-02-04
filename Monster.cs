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

        public Monster(string name, double strength, double defence, double maxHealth, string flavorText ) : base(name, strength, defence, maxHealth) 
        {
            Name = name;
            FlavorText = flavorText;
        }
    }
}
