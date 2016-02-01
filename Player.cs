using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Player
    {
        public int HP { get; private set; }
        public int MaxHP { get; private set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Player(int mHP)
        {
            MaxHP = mHP;
            HP = mHP;
        }

        public void Spawn(string[] map)
        {
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    if (map[i][j] == 'c')
                    {
                        X = j;
                        Y = i;
                    }
                }
            }
        }
    }
}
