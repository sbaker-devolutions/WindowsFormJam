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
            ((System.ComponentModel.ISupportInitialize)(this.GameScreen)).BeginInit();
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
            this.lstCharSheet.Size = new System.Drawing.Size(187, 197);
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
            this.colValue.Width = 102;
            // 
            // frmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lstCharSheet);
            this.Controls.Add(this.GameScreen);
            this.KeyPreview = true;
            this.Name = "frmGame";
            this.Text = "GameJam";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmGame_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.GameScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox GameScreen;
        private System.Windows.Forms.ListView lstCharSheet;
        private System.Windows.Forms.ColumnHeader colTrait;
        private System.Windows.Forms.ColumnHeader colValue;
    }
}

