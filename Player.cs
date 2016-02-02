using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    public class Player
    {
        private Game game;
        public int HP { get; private set; }
        public int MaxHP { get; private set; }
        public int Level { get; protected set; }

        public int CurrentExp { get;  set; }
        //public int NextExp { get; private set; }
        public int Gold { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Player(string path, Game _game)
        {
            string[] data;
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    data = reader.ReadToEnd().Split(';');
                }
                game = _game;
                MaxHP = int.Parse(data[0]);
                HP = MaxHP;
                Level = int.Parse(data[1]);
                CurrentExp = int.Parse(data[2]);
                Gold = int.Parse(data[3]);
            }
            catch(Exception ex)
            {
                game = _game;
                MaxHP = 20;
                HP = 20;
                Level = 1;
                CurrentExp = 0;
                Gold = 0;
            }
        }

        public void TakeDmg(int attack)
        {
            HP -= attack;

            if(HP <= 0)
            {
                using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Char.csv"))
                {
                    writer.Write(this.toString());
                }
                game.GameForm.DeathAnimation();
                game.GameForm.game = new Game(game.GameForm);
                
            }
        }

        public void GetExp(int amount)
        {
            if (CurrentExp + amount >= (5 + Level) * Level)//NextExp)
            {
                Level++;
                CurrentExp = Math.Abs(CurrentExp - /*NextExp*/((5 + Level) * Level));
                //NextExp = (5 + Level) * Level;
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

        public string toString()
        {
            return MaxHP.ToString() + ";" + Level.ToString() + ";" + CurrentExp.ToString() + ";" + Gold.ToString();
        }
    }
}
