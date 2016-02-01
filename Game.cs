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
        private const int NBTILE = 16;
        private frmGame gameForm;
        private Player player;
        private string[] maps;
        private string[] currentMap;
        private int floor;

        public Game(frmGame form)
        {
            gameForm = form;     
            player = new Player(20);
            floor = 1;
            currentMap = LoadMap();
            player.Spawn(currentMap);
            
        }

        public Image Render()
        {
            Bitmap frame = new Bitmap(512, 512);
            Graphics g;

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
                        switch(currentMap[j][i])
                        {
                            case 'w':
                                g.FillRectangle(wall, new Rectangle(i * (frame.Width / NBTILE), j * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
                                break;
                            case 's':
                                g.FillRectangle(stair, new Rectangle(i * (frame.Width / NBTILE), j * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
                                break;
                            case 'f':
                            case 'c':
                                g.FillRectangle(floor, new Rectangle(i * (frame.Width / NBTILE), j * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }

            g.FillRectangle(character, new Rectangle(player.X * (frame.Width / NBTILE), player.Y * (frame.Height / NBTILE), frame.Width / NBTILE, frame.Height / NBTILE));

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
            if(floor == 1)
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

            if(floor * 16 > maps.Length)
            {
                floor = 1;
            }

            string[] map = new string[16];
            
            for (int i = 0; i < 16; i++)
            {
                int t = (floor) * 16 +i;
                map[i] = maps[t-16];
            }

            return map;
        }

        public void moveChar(char dir)
        {
            int newX = player.X;
            int newY = player.Y;
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
            switch(currentMap[newY][newX])
            {
                case 's':
                    floor++;
                    currentMap = LoadMap();
                    player.Spawn(currentMap);
                    break;
                case 'f':
                    player.X = newX;
                    player.Y = newY;
                    break;
            }
        }

    }
}
