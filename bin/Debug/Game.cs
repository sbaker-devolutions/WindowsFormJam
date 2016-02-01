using System;
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
        public static Game Instance; 
        private const int NBTILE = 16;
        private frmGame gameForm;
        public Player Player { get; private set; }
        private string[] maps;
        private string[] currentMap;
        private List<Mob> mobs;
        public int Floor { get; private set; }

        public Game(frmGame form)
        {
            gameForm = form;
            Player = new Player(20, 1);
            Floor = 1;
            currentMap = LoadMap();
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
                penHp.Color = Color.FromArgb(255-red, red, 0);
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
            mobs = new List<Mob>();
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

            MobGeneration();

            return map;
        }

        public void MobGeneration()
        {
            Random rng = new Random();
            int nbMob = rng.Next(1, 5);

            
            for (int i = 0; i < nbMob; i++)
            {
                mobs.Add(new Mob("Bat", 5, 1, rng.Next(2, 15), rng.Next(2, 15), 1, 2, 1));
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
                    Player.Spawn(currentMap);
                    break;
                case 'f':
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
            if(mob.TakeDmg(1, Player))
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
