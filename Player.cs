using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    public class Player
    {
        public int HP { get; private set; }
        public int MaxHP { get; private set; }
        public int Level { get; protected set; }

        public int CurrentExp { get;  set; }
        public int NextExp { get; private set; }
        public int Gold { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Player(int mHP, int lvl)
        {
            MaxHP = mHP;
            HP = mHP;
            Level = lvl;
            CurrentExp = 0;
            NextExp = (5 + Level) * Level;
        }

        public void TakeDmg(int attack)
        {
            HP -= attack;
        }

        public void GetExp(int amount)
        {
            if (CurrentExp + amount >= NextExp)
            {
                Level++;
                CurrentExp = Math.Abs(CurrentExp - NextExp);
                NextExp = (5 + Level) * Level;
            }
            else
            {
                CurrentExp += amount;
            }
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
