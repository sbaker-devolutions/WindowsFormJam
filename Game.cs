﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormJam
{
    public class Game
    {
        private const int NBTILE = 16;
        public frmGame GameForm { get; private set; }
        public Player Player { get; private set; }
        private string[] maps;
        private string[] currentMap;
        private List<Mob> mobs;
        public int Floor { get; private set; }
        private List<Mob> mobList;
        //private List<Item> itemList;

        public Game(frmGame form)
        {
            GameForm = form;
            Player = new Player(AppDomain.CurrentDomain.BaseDirectory + "Char.csv", this);
            Floor = 1;
            LoadMobs();
            //LoadItems();
            currentMap = LoadMap();
            MobGeneration();
            Player.Spawn(currentMap);

        }

        public Image Render()
        {
            Bitmap frame = new Bitmap(512, 512);
            Graphics g;

            int TileWidth = (frame.Width / NBTILE);
            int TileHeight = (frame.Height / NBTILE);

            g = Graphics.FromImage(frame);
            g.Clear(Color.Black);

            SolidBrush character = new SolidBrush(Color.BlueViolet);
            SolidBrush wall = new SolidBrush(Color.Brown);
            SolidBrush floor = new SolidBrush(Color.DarkGray);
            SolidBrush stair = new SolidBrush(Color.Gray);

            try
            {
                for (int i = 0; i < NBTILE; i++)
                {
                    for (int j = 0; j < NBTILE; j++)
                    {
                        switch (currentMap[j][i])
                        {
                            case 'w':
                                g.FillRectangle(wall, new Rectangle(i * (frame.Width / NBTILE), j * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
                                break;
                            case 's':
                                g.FillRectangle(stair, new Rectangle(i * (frame.Width / NBTILE), j * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
                                break;
                            default:
                                g.FillRectangle(floor, new Rectangle(i * (frame.Width / NBTILE), j * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            Pen penHp = new Pen(Color.Red, 3);
            for (int i = 0; i < mobs.Count; i++)
            {
                int red = mobs[i].MaxHP - mobs[i].CurrentHP;
                red = mobs[i].CurrentHP * 255 / mobs[i].MaxHP;
                penHp.Color = Color.FromArgb(255 - red, red, 0);
                int lifebar = mobs[i].X * TileWidth + mobs[i].CurrentHP * 32 / mobs[i].MaxHP;

                Image image = (Image)Properties.Resources.ResourceManager.GetObject(mobs[i].Name);
                g.DrawImage(image, new Rectangle(mobs[i].X * TileWidth, mobs[i].Y * TileHeight, TileWidth, TileHeight));
                g.DrawLine(penHp, new Point(mobs[i].X * TileWidth, mobs[i].Y * TileHeight + TileWidth - 2),
                    new Point(lifebar, mobs[i].Y * TileHeight + TileWidth - 2));
            }

            //g.FillRectangle(character, new Rectangle(Player.X * (frame.Width / NBTILE), Player.Y * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
            g.DrawImage(Properties.Resources.Char, new Rectangle(Player.X * (frame.Width / NBTILE), Player.Y * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));

            Pen pen = new Pen(Color.White, 1);
            for (int i = 0; i < frame.Width; i = i + frame.Height / NBTILE)
            {
                for (int j = 0; j < frame.Height; j = j + frame.Width / NBTILE)
                {
                    //grid
                    g.DrawLine(pen, new Point(i, 0), new Point(i, frame.Height));
                    g.DrawLine(pen, new Point(0, j), new Point(frame.Width, j));

                }
            }

            return frame;
        }

        private string[] LoadMap()
        {
            if (Floor == 1)
            {
                maps = new string[File.ReadLines(frmGame.path + "map.txt").Count()];
                int i = 0;
                string line;
                StreamReader file = new StreamReader(frmGame.path + "map.txt");
                while ((line = file.ReadLine()) != null)
                {
                    maps[i] = line;
                    i++;
                }
            }

            if (Floor * 16 > maps.Length)
            {
                Floor = 1;
            }

            string[] map = new string[16];

            for (int i = 0; i < 16; i++)
            {
                int t = (Floor) * 16 + i;
                map[i] = maps[t - 16];
            }

            //load mob and items
            for (int i = 0; i < map.Length; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    switch (map[i][j])
                    {
                        case 'm':   //mob
                            break;
                        case 'M':   //boss
                            break;
                        case 'i':   //item
                            break;
                        case 'I':   //epic loot
                            break;
                    }
                }
            }
            return map;
        }

        public void MobGeneration()
        {
            Random rng = new Random();
            int nbMob = rng.Next(1, 5);
            mobs = new List<Mob>();

            Mob mob;
            for (int i = 0; i < nbMob; i++)
            {
                int mobId = rng.Next(0, mobList.Count);
                mob = new Mob(mobList[mobId].Name, mobList[mobId].MaxHP, mobList[mobId].Attack, rng.Next(1, 15), rng.Next(1, 15), rng.Next(1,5), mobList[mobId].Exp, mobList[mobId].Gold);
                bool spawn = false;
                while (!spawn)
                {
                    if (currentMap[mob.X][mob.Y] == 'f')
                    {
                        spawn = true;
                        for (int j = 0; j < mobs.Count; j++)
                        {
                            if (mob.X == mobs[j].X && mob.Y == mobs[j].Y)
                                spawn = false;
                        }
                    }
                    mob = new Mob(mobList[mobId].Name, mobList[mobId].MaxHP, mobList[mobId].Attack, rng.Next(1, 15), rng.Next(1, 15), rng.Next(1, 5), mobList[mobId].Exp, mobList[mobId].Gold);
                }
                mobs.Add(mob);
            }
        }

        public void LoadMobs()
        {
            mobList = new List<Mob>();
            int i = 0;
            string line;
            StreamReader file = new StreamReader(frmGame.path + "mob.csv");
            while ((line = file.ReadLine()) != null)
            {
                string[] data = line.Split(';');
                //Id;baseHp;Attack;baseExp;baseGold
                mobList.Add(new Mob(data[0], int.Parse(data[1]), int.Parse(data[2]), -1, -1, 1, int.Parse(data[3]), int.Parse(data[4])));
                i++;
            }
        }

        public void ItemGeneration()
        {
            Random rng = new Random();
        }

        public void moveChar(char dir)
        {
            int newX = Player.X;
            int newY = Player.Y;
            switch (dir)
            {
                case 'N':
                    newY--;
                    break;
                case 'E':
                    newX++;
                    break;
                case 'S':
                    newY++;
                    break;
                case 'W':
                    newX--;
                    break;
            }
            switch (currentMap[newY][newX])
            {
                case 's':
                    Floor++;
                    currentMap = LoadMap();
                    MobGeneration();
                    Player.Spawn(currentMap);
                    break;
                case 'f':
                case 'c':
                    int combat = -1;
                    for (int i = 0; i < mobs.Count; i++)
                    {
                        if (mobs[i].X == newX && mobs[i].Y == newY)
                        {
                            combat = i;
                        }
                    }
                    if (combat == -1)
                    {
                        Player.X = newX;
                        Player.Y = newY;
                    }
                    else
                    {
                        Battle(mobs[combat]);
                    }
                    break;
            }
        }

        private void Battle(Mob mob)
        {
            if (mob.TakeDmg(1, Player))
            {
                mobs.Remove(mob);
            }
            Player.TakeDmg(mob.Attack);
        }

        private Bitmap ResizeBitmap(Bitmap source, int width, int height)
        {
            Bitmap img = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(img);
            g.DrawImage(source, 0, 0, width, height);
            return img;
        }
    }
}
