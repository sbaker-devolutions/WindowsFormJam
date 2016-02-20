using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;

namespace WindowsFormJam
{
    //https://channel9.msdn.com/coding4fun/blog/Getting-lost-and-found-with-the-C-Maze-Generator-and-Solver
    class Maze
    {
        private int width;
        private int height;

        //private List<Tile> maze;
        private Stack<Tile> stack;
        //private List<Tuple<int, int>> drill;

        private Dictionary<string, Tile> maze;
        private Tile currentTile;

        public Maze(int _width, int _height)
        {
            width = _width;
            height = _height;
            //maze = new string[width, height];
            maze = new Dictionary<string, Tile>();
            stack = new Stack<Tile>();
            //Have all walls in your maze intact (not broken)
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //maze[i, j] = "w";
                    Tile tile = new Tile(i, j, "w");
                    maze.Add(DictTrans(i, j), tile);
                    //Choose a start point, push it into the stack. Call this initial square 'current square
                    if (i == 0 && j == 1)
                    {
                        tile.Type = "c";
                        stack.Push(tile);
                        currentTile = tile;
                    }

                }

            }
        }

        public void Generation()
        {
            Random rng = new Random();
            //bool[,] intact = new bool[width, height];
            //for (int i = 0; i < width; i++)
            //{
            //    for (int j = 0; j < height; j++)
            //    {
            //        intact[i, j] = true;
            //    }
            //}
            //intact[currentTile.X, currentTile.Y] = false;

            //Repeat while the stack is not empty
            while (stack.Count > 0)
            {
                //Get list of all neighboring squares to the current square where those 
                //neighbors have all their walls intact (unvisited)
                List<Tile> tiles = new List<Tile>();
                //currentTile = stack.Peek();


                Tile tile;
                Tile lastTile = new Tile();

                maze.TryGetValue(DictTrans(currentTile.X, currentTile.Y - 1), out tile);
                if (tile != null)//intact[tile.X, tile.Y]) //&& tile.Type == "w"
                {
                    lastTile = tile;
                    if(tile.Type == "w")
                        tiles.Add(tile);
                }
                maze.TryGetValue(DictTrans(currentTile.X + 1, currentTile.Y), out tile);
                if (tile != null)//intact[tile.X, tile.Y])
                {
                    lastTile = tile;
                    if (tile.Type == "w")
                        tiles.Add(tile);
                }
                maze.TryGetValue(DictTrans(currentTile.X, currentTile.Y + 1), out tile);
                if (tile != null)//intact[tile.X, tile.Y])
                {
                    lastTile = tile;
                    if (tile.Type == "w")
                        tiles.Add(tile);
                }
                maze.TryGetValue(DictTrans(currentTile.X - 1, currentTile.Y), out tile);
                if (tile != null)//intact[tile.X, tile.Y])
                {
                    lastTile = tile;
                    if (tile.Type == "w")
                        tiles.Add(tile);
                }



                //maze.TryGetValue(DictTrans(currentTile.X - 1, currentTile.Y - 1), out tile);
                //if (tile != null && tile.Type == "w")//intact[tile.X, tile.Y])
                //    tiles.Add(tile);
                //maze.TryGetValue(DictTrans(currentTile.X + 1, currentTile.Y - 1), out tile);
                //if (tile != null && tile.Type == "w")//intact[tile.X, tile.Y])
                //    tiles.Add(tile);
                //maze.TryGetValue(DictTrans(currentTile.X + 1, currentTile.Y + 1), out tile);
                //if (tile != null && tile.Type == "w")//intact[tile.X, tile.Y])
                //    tiles.Add(tile);
                //maze.TryGetValue(DictTrans(currentTile.X - 1, currentTile.Y + 1), out tile);
                //if (tile != null && tile.Type == "w")//intact[tile.X, tile.Y])
                //    tiles.Add(tile);

              

                //If there are neighbors (i.e., List.Count > 0):
                if (tiles.Count > 0)
                {
                    //Choose one of the neighbors at random. Call it 'temp'.
                    Tile temp = tiles[rng.Next(tiles.Count)];
                    //Knock the wall between 'temp' and the current square.
                    lastTile.Type = "f";
                    //intact[temp.X, temp.Y] = false;
                    //Push the current square into the stack.
                    stack.Push(lastTile);
                    //Make the current square equals 'temp'.
                    currentTile = temp;
                }
                //Else if there are no neighbors
                else
                {
                    //pop a square from the stack. Make current square equal to it.
                    stack.Pop();
                    //currentTile = stack.Peek();
                }
            }
        }

        private int[] DictTrans(string data)
        {
            string[] ints = data.Split(',');

            return new int[] { int.Parse(ints[0]), int.Parse(ints[1]) };
        }

        private string DictTrans(int x, int y)
        {
            return x.ToString() + "," + y.ToString();
        }

        public string[,] GetMaze()
        {
            string[,] strMaze = new string[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    strMaze[i, j] = maze[DictTrans(i, j)].Type;
                }
            }

            return strMaze;
        }

        /*public void Generation()
        {
            Random rng = new Random();
            Tuple<int, int> m,n;
            Dictionary<int, int> bob = new Dictionary<int, int>();
            while (drill.Count > 0)
            {
                m = drill[0];
                n = drill[drill.Count-1];

                while(m != n)
                {
                    bool remove = false;
                    switch(rng.Next(0,3))
                    {
                        case 0:
                            
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                }
            }
        }*/
    }

}
