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
            rowHP.SubItems.Add((game.Player.HP + "/" + game.Player.MaxHP).ToString());
            ListViewItem rowLvl = new ListViewItem("Floor");
            rowLvl.SubItems.Add(game.Player.Level.ToString());
            ListViewItem rowExp = new ListViewItem("Exp");
            rowExp.SubItems.Add((game.Player.CurrentExp + "/" + game.Player.NextExp).ToString());
            pgbExp.Maximum = game.Player.NextExp;
            pgbExp.Value = game.Player.CurrentExp;

            lstCharSheet.Items.AddRange(new ListViewItem[] { rowFloor, rowHP, rowLvl, rowExp });
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
