using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Mob:Player
    {
        public string Name { get; private set; }

        public Mob(string Id, int HP, int x, int y, int lvl):base(HP, lvl)
        {
            Name = Id;
            X = x;
            Y = y;
            Level = lvl;
        }
    }
}
