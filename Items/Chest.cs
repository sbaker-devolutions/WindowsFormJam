using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Chest : Item
    {
        public int Defence { get;  private set; }
        public int Str { get; private set; }    //amount of dmg done
        public int Dex { get; private set; }    //chances to hit
        public int Agi { get; private set; }    //chances to get hit
        public int Cons { get; private set; }   //max HP
        public int Char { get; private set; }   //affect sell/buy price
    }
}
