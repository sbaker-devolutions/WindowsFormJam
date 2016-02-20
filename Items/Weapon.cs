using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Weapon : Item
    {
        public int Attack { get; private set; }
        public int Str { get; private set; }    //amount of dmg done
        public int Dex { get; private set; }    //chances to hit
        public int Agi { get; private set; }    //chances to get hit
        public int Char { get; private set; }   //affect sell/buy price

        public Weapon()
        {
            Str = 3;
        }
    }
}
