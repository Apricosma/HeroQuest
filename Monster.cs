using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameAssignment
{
    public class Monster : Hero
    {
        public Monster(string name, double strength, double defence, double maxHealth ) : base(name, strength, defence, maxHealth) 
        {

        }
    }
}
