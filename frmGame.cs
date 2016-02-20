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
        private Game game { get; set; }
        public static string path = AppDomain.CurrentDomain.BaseDirectory;

        public frmGame()
        {
            InitializeComponent();
            game = new Game(this);
            RefreshFrame(game.Render());

            pgbExp.Style = ProgressBarStyle.Continuous;
            pgbExp.ForeColor = Color.FromArgb(6030325);
            
        }

        private void lstCharSheet_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstCharSheet.Columns[e.ColumnIndex].Width;
        }

        private void RefreshFrame(Image image)
        {
            GameScreen.BackgroundImage = image;

            lstCharSheet.Items.Clear();
            ListViewItem rowFloor = new ListViewItem("Floor");
            rowFloor.SubItems.Add(game.Floor.ToString());
            ListViewItem rowHP = new ListViewItem("HP");
            //rowHP.SubItems.Add((game.Player.HP + "/" + game.Player.MaxHP).ToString());
            ListViewItem rowLvl = new ListViewItem("Level");
            rowLvl.SubItems.Add(game.Player.Level.ToString());
            ListViewItem rowExp = new ListViewItem("Exp");
            rowExp.SubItems.Add((game.Player.CurrentExp + "/" + ((5 + game.Player.Level) * game.Player.Level)).ToString());
            ListViewItem rowGold = new ListViewItem("Gold");
            rowGold.SubItems.Add((game.Player.Gold).ToString());
            pgbExp.Maximum = ((5 + game.Player.Level) * game.Player.Level);
            pgbExp.Value = game.Player.CurrentExp;

            lstCharSheet.Items.AddRange(new ListViewItem[] { rowFloor, rowHP, rowLvl, rowExp, rowGold });
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

        public void DeathAnimation()
        {
            Bitmap frame = (Bitmap)game.Render();
            Graphics g;
            g = Graphics.FromImage(frame);

            SolidBrush dark = new SolidBrush(Color.FromArgb(200,0,0,0));
            g.FillRectangle(dark, new Rectangle(0, 0, GameScreen.Width, GameScreen.Height));
            RefreshFrame(frame);

            MessageBox.Show("You deaded!");
        }
    }

}
