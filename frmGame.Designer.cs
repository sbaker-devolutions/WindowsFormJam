namespace WindowsFormJam
{
    partial class frmGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameScreen = new System.Windows.Forms.PictureBox();
            this.lstCharSheet = new System.Windows.Forms.ListView();
            this.colTrait = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pgbExp = new System.Windows.Forms.ProgressBar();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.picChest = new System.Windows.Forms.PictureBox();
            this.picPants = new System.Windows.Forms.PictureBox();
            this.picBoots = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoots)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // GameScreen
            // 
            this.GameScreen.Location = new System.Drawing.Point(12, 12);
            this.GameScreen.Name = "GameScreen";
            this.GameScreen.Size = new System.Drawing.Size(512, 512);
            this.GameScreen.TabIndex = 0;
            this.GameScreen.TabStop = false;
            // 
            // lstCharSheet
            // 
            this.lstCharSheet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTrait,
            this.colValue});
            this.lstCharSheet.Location = new System.Drawing.Point(530, 12);
            this.lstCharSheet.Name = "lstCharSheet";
            this.lstCharSheet.Size = new System.Drawing.Size(242, 197);
            this.lstCharSheet.TabIndex = 1;
            this.lstCharSheet.UseCompatibleStateImageBehavior = false;
            this.lstCharSheet.View = System.Windows.Forms.View.Details;
            this.lstCharSheet.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstCharSheet_ColumnWidthChanging);
            // 
            // colTrait
            // 
            this.colTrait.Text = "Stats";
            this.colTrait.Width = 80;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 157;
            // 
            // pgbExp
            // 
            this.pgbExp.Location = new System.Drawing.Point(530, 215);
            this.pgbExp.Name = "pgbExp";
            this.pgbExp.Size = new System.Drawing.Size(242, 23);
            this.pgbExp.TabIndex = 2;
            // 
            // picHead
            // 
            this.picHead.Location = new System.Drawing.Point(633, 271);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(32, 32);
            this.picHead.TabIndex = 3;
            this.picHead.TabStop = false;
            // 
            // picChest
            // 
            this.picChest.Location = new System.Drawing.Point(633, 309);
            this.picChest.Name = "picChest";
            this.picChest.Size = new System.Drawing.Size(32, 32);
            this.picChest.TabIndex = 4;
            this.picChest.TabStop = false;
            // 
            // picPants
            // 
            this.picPants.Location = new System.Drawing.Point(633, 347);
            this.picPants.Name = "picPants";
            this.picPants.Size = new System.Drawing.Size(32, 32);
            this.picPants.TabIndex = 5;
            this.picPants.TabStop = false;
            // 
            // picBoots
            // 
            this.picBoots.Location = new System.Drawing.Point(633, 385);
            this.picBoots.Name = "picBoots";
            this.picBoots.Size = new System.Drawing.Size(32, 32);
            this.picBoots.TabIndex = 6;
            this.picBoots.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(595, 309);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(671, 309);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.picBoots);
            this.Controls.Add(this.picPants);
            this.Controls.Add(this.picChest);
            this.Controls.Add(this.picHead);
            this.Controls.Add(this.pgbExp);
            this.Controls.Add(this.lstCharSheet);
            this.Controls.Add(this.GameScreen);
            this.KeyPreview = true;
            this.Name = "frmGame";
            this.Text = "GameJam";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmGame_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.GameScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoots)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameScreen;
        private System.Windows.Forms.ListView lstCharSheet;
        private System.Windows.Forms.ColumnHeader colTrait;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.ProgressBar pgbExp;
        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.PictureBox picChest;
        private System.Windows.Forms.PictureBox picPants;
        private System.Windows.Forms.PictureBox picBoots;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

