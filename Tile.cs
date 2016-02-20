using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Type { get; set; }

        public Tile(int x,int y, string type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public Tile() { }
    }
}
