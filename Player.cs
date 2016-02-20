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

        public string Name { get; private set; }

        public int Str { get; private set; }    //amount of dmg done
        public int Dex { get; private set; }    //chances to hit
        public int Agi { get; private set; }    //chances to get hit
        public int Cons { get; private set; }   //max HP
        public int Char { get; private set; }   //affect sell/buy price

        public int currentHP { get; private set; }
        //public int MaxHP { get; private set; }

        public int Level { get; protected set; }
        public int CurrentExp { get;  set; }
        //public int NextExp { get; private set; }

        public int Gold { get; set; }
        //public Weapon Weapon { get; private set; }    //equipement

        public int X { get; set; }
        public int Y { get; set; }

        public Player(string name, int ID, Game game)
        {
            Name = name;
            this.game = game;
        }

        public Player(string name, int str, int dex, int agi, int cons, int charisma, Game game)
        {
            Name = name;

            Str = str;
            Dex = dex;
            Agi = Agi;
            Cons = cons;
            Char = charisma;

            currentHP = cons * 10;

            Level = 1;
            CurrentExp = 0;

            Gold = 0;

            this.game = game;
        }

        public void TakeDmg(int attack)
        {
            currentHP -= attack;

            if(currentHP <= 0)
            {
                //using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Char.csv"))
                //{
                //    writer.Write(this.toString());
                //}
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

        public void Spawn(string[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i,j] == "c")
                    {
                        X = j;
                        Y = i;
                    }
                }
            }
        }

        //public string toString()
        //{
        //    return MaxHP.ToString() + ";" + Level.ToString() + ";" + CurrentExp.ToString() + ";" + Gold.ToString();
        //}
    }
}
