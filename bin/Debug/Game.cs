using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        private string[,] currentMap;
        private List<Mob> mobs = new List<Mob>();
        public int Floor { get; private set; }
        //private List<Item> itemList;
        

        public Game(frmGame form)
        {
            string pw = "allobaker";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(pw);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);

            Player = new Player("a", this);
            GameForm = form;
            if (DB.ConnectionTest())
            {
                Floor = 1;
                currentMap = LoadMap();
                //MobGeneration();
                //Player.Spawn(currentMap);
            }
            else
            {
                MessageBox.Show("Could not load game data.");
            }

            Maze m = new Maze(16,16);
            m.Generation();
            currentMap = m.GetMaze();
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
                        switch (currentMap[i,j])
                        {
                            case "w":
                                g.FillRectangle(wall, new Rectangle(i * (frame.Width / NBTILE), j * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
                                break;
                            case "s":
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

        private string[,] LoadMap()
        {
            /*if (Floor == 1)
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
            }*/

            string[,] map = new string[16, 16];
            int[,] weight = new int[16, 16];
            Random rng = new Random();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = "w";
                    weight[i, j] = rng.Next(1, 99);
                }
            }

            return map;
        }

        public void MobGeneration()
        {
            Random rng = new Random();
            int nbMob = rng.Next(3, 10);
            mobs = new List<Mob>();

            string cmd = "SELECT * FROM Mobs WHERE minFloor <= " + Floor.ToString() + "AND maxFloor >= " + Floor.ToString();
            DataTable dataTable = new DataTable();
            DB.ExecCmd(cmd, dataTable);

            for (int i = 0; i < nbMob; i++)
            {
                int mobId = rng.Next(0, dataTable.Rows.Count);
                var mobData = dataTable.Rows[rng.Next(0, dataTable.Rows.Count)];
                int cX = rng.Next(1,15);
                int cY = rng.Next(1,15);
                bool canSpawn = false;
                while (!canSpawn)
                {
                    cX = rng.Next(1, 15);
                    cY = rng.Next(1, 15);
                    if (currentMap[cX,cY] == "f")
                    {
                        canSpawn = true;
                        for (int j = 0; j < mobs.Count; j++)
                        {
                            if (mobs[j].X == cX && mobs[j].Y == cY)
                                canSpawn = false;
                        } 
                    }
                }
                Mob mob = new Mob((string)mobData["Name"], 
                    (int)mobData["baseHP"], 
                    (int)mobData["baseAttack"], 
                    cX, cY, 
                    (int)mobData["minLevel"], 
                    (int)mobData["baseExp"],
                    (int)mobData["baseGold"]);
                mobs.Add(mob);
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
            if (newX >= 0 && newX < NBTILE && newY >= 0 && newY < NBTILE)
            {
                switch (currentMap[newX, newY])
                {
                    case "s":
                        Floor++;
                        currentMap = LoadMap();
                        MobGeneration();
                        Player.Spawn(currentMap);
                        break;
                    case "f":
                    case "c":
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
