using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormJam
{
    class Player
    {
        private Game game;

        public string Name { get; private set; }

        private int str { get; set; }    //amount of dmg done
        private int dex { get; set; }    //chances to hit
        private int agi { get; set; }    //chances to get hit
        private int cons { get; set; }   //max HP
        private int charisma { get; set; }   //affect sell/buy price

        public int currentHP { get; private set; }
        //public int MaxHP { get; private set; }

        public int Level { get; protected set; }
        public int CurrentExp { get; set; }
        //public int NextExp { get; private set; }

        public int Gold { get; set; }

        private Item[] equipement;
        private enum equip { Weapon, Helmet, Chest, Pants, Boots }
        private Weapon weapon { get; set; }    //equipement
        private Helmet helmet { get; set; }
        private Chest chest { get; set; }
        private Pants pants { get; set; }
        private Boots boots { get; set; }

        public List<Item> Inventory { get; private set; }

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

            this.str = str;
            this.dex = dex;
            this.agi = agi;
            this.cons = cons;
            this.charisma = charisma;

            currentHP = cons * 10;

            Level = 1;
            CurrentExp = 0;

            Gold = 0;

            this.game = game;
        }

        public void TakeDmg(int attack)
        {
            currentHP -= attack;

            if (currentHP <= 0)
            {
                //using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Char.csv"))
                //{
                //    writer.Write(this.toString());
                //}
                game.GameForm.DeathAnimation();
                //game.GameForm.game = new Game(game.GameForm);

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
                    if (map[i, j] == "c")
                    {
                        X = j;
                        Y = i;
                    }
                }
            }
        }

        public void Equip(Item item)
        {
            //TODO: put equipment back into inventory
            switch(item.GetType().ToString())
            {
                case "Weapon":
                    equipement[(int)equip.Weapon] = item;
                    weapon = (Weapon)item;
                    break;
                case "Helmet":
                    equipement[(int)equip.Helmet] = item;
                    helmet = (Helmet)item;
                    break;
                case "Chest":
                    equipement[(int)equip.Chest] = item;
                    chest = (Chest)item;
                    break;
                case "Pants":
                    equipement[(int)equip.Pants] = item;
                    pants = (Pants)item;
                    break;
                case "Boots":
                    equipement[(int)equip.Boots] = item;
                    boots = (Boots)item;
                    break;
            }
        }

        public int Strength
        {
            get
            {
                var property = weapon.GetType().GetProperty("Str");
                return 0;
            }
            set { }
        }

        //public string toString()
        //{
        //    return MaxHP.ToString() + ";" + Level.ToString() + ";" + CurrentExp.ToString() + ";" + Gold.ToString();
        //}
    }
}