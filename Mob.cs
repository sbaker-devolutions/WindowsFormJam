using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Mob
    {
        public string Name { get; private set; }
        public int CurrentHP { get;  set; }
        public int MaxHP { get; private set; }
        public int Level { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Exp { get; private set; }
        public int Attack { get; private set; }
        public int Gold { get; private set; }

        public Mob(string Id, int baseHP, int attack, int x, int y, int lvl, int baseExp, int gold)
        {
            Name = Id;
            X = x;
            Y = y;
            Level = lvl;
            CurrentHP = baseHP * lvl;
            MaxHP = CurrentHP;
            Exp = baseExp * lvl;
            Attack = attack;
            Gold = gold;
        }

        public bool TakeDmg(int amount, Player player)
        {
            CurrentHP -= amount;
            if (CurrentHP <= 0)
            {
                CurrentHP = 0;
                player.GetExp(Exp);
                player.Gold += Gold;
                return true;
            }
            return false;
        }
    }
}
