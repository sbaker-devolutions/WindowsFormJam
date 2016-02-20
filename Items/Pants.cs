using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Pants : Item
    {
        public int Defence { get; private set; }
        public int Dex { get; private set; }    //chances to hit
        public int Agi { get; private set; }    //chances to get hit
        public int Cons { get; private set; }   //max HP
        public int Char { get; private set; }   //affect sell/buy price
    }
}
