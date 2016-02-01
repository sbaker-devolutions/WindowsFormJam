using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormJam
{
    public partial class frmGame : Form
    {
        private Game game;
        public static string path = AppDomain.CurrentDomain.BaseDirectory;

        public frmGame()
        {
            InitializeComponent();
            game = new Game(this);
            GameScreen.BackgroundImage = game.Render();
            
        }

        private void lstCharSheet_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstCharSheet.Columns[e.ColumnIndex].Width;
        }

        private void RefreshFrame(Image image)
        {
            GameScreen.BackgroundImage = image;
        }

        private void frmGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    game.moveChar('N');
                    break;
                case 'a':
                    game.moveChar('W');
                    break;
                case 's':
                    game.moveChar('S');
                    break;
                case 'd':
                    game.moveChar('E');
                    break;
            }
            RefreshFrame(game.Render());
        }
    }

}
