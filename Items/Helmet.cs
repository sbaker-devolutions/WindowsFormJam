using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Helmet : Item
    {
        public int Defence { get; private set; }
        public int Dex { get; private set; }    //chances to hit
        public int Cons { get; private set; }   //max HP
        public int Char { get; private set; }   //affect sell/buy price
    }
}
