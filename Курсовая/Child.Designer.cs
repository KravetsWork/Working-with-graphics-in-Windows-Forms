namespace Coursework
{
    partial class Child
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemImageInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPixelValue = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemPaint = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemInscriprion = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemFont = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLine = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemEllipse = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBoxPixelValue = new System.Windows.Forms.GroupBox();
            this.labelDistance = new System.Windows.Forms.Label();
            this.labelCoord = new System.Windows.Forms.Label();
            this.progressBarAlpha = new System.Windows.Forms.ProgressBar();
            this.Green = new System.Windows.Forms.Label();
            this.progressBarRed = new System.Windows.Forms.ProgressBar();
            this.Blue = new System.Windows.Forms.Label();
            this.Red = new System.Windows.Forms.Label();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.labelGreen = new System.Windows.Forms.Label();
            this.labelBlue = new System.Windows.Forms.Label();
            this.labelRed = new System.Windows.Forms.Label();
            this.Alpha = new System.Windows.Forms.Label();
            this.progressBarBlue = new System.Windows.Forms.ProgressBar();
            this.progressBarGreen = new System.Windows.Forms.ProgressBar();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBoxPixelValue.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.MenuItemPixelValue,
            this.MenuItemPaint});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(538, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemImageInfo,
            this.MenuItemOpen,
            this.MenuItemSave,
            this.MenuItemSaveAs});
            this.fileToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.fileToolStripMenuItem.MergeIndex = 1;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Visible = false;
            // 
            // MenuItemImageInfo
            // 
            this.MenuItemImageInfo.Enabled = false;
            this.MenuItemImageInfo.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.MenuItemImageInfo.MergeIndex = 1;
            this.MenuItemImageInfo.Name = "MenuItemImageInfo";
            this.MenuItemImageInfo.Size = new System.Drawing.Size(173, 22);
            this.MenuItemImageInfo.Text = "image information";
            this.MenuItemImageInfo.Click += new System.EventHandler(this.MenuItemImageInfo_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.MenuItemOpen.MergeIndex = 1;
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.Size = new System.Drawing.Size(173, 22);
            this.MenuItemOpen.Text = "Open image";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Enabled = false;
            this.MenuItemSave.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.MenuItemSave.MergeIndex = 2;
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.Size = new System.Drawing.Size(173, 22);
            this.MenuItemSave.Text = "Save image";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemSaveAs
            // 
            this.MenuItemSaveAs.Enabled = false;
            this.MenuItemSaveAs.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.MenuItemSaveAs.MergeIndex = 3;
            this.MenuItemSaveAs.Name = "MenuItemSaveAs";
            this.MenuItemSaveAs.Size = new System.Drawing.Size(173, 22);
            this.MenuItemSaveAs.Text = "Save as";
            this.MenuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAs_Click);
            // 
            // MenuItemPixelValue
            // 
            this.MenuItemPixelValue.Enabled = false;
            this.MenuItemPixelValue.Name = "MenuItemPixelValue";
            this.MenuItemPixelValue.Size = new System.Drawing.Size(74, 20);
            this.MenuItemPixelValue.Text = "Pixel value";
            this.MenuItemPixelValue.Click += new System.EventHandler(this.MenuItemPixelValue_Click);
            // 
            // MenuItemPaint
            // 
            this.MenuItemPaint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemInscriprion,
            this.MenuItemFont,
            this.MenuItemWrite,
            this.MenuItemLine,
            this.MenuItemEllipse,
            this.MenuItemRectangle});
            this.MenuItemPaint.Enabled = false;
            this.MenuItemPaint.Name = "MenuItemPaint";
            this.MenuItemPaint.Size = new System.Drawing.Size(46, 20);
            this.MenuItemPaint.Text = "Paint";
            this.MenuItemPaint.MouseHover += new System.EventHandler(this.MenuItemPaint_MouseHover);
            // 
            // MenuItemInscriprion
            // 
            this.MenuItemInscriprion.Name = "MenuItemInscriprion";
            this.MenuItemInscriprion.Size = new System.Drawing.Size(130, 22);
            this.MenuItemInscriprion.Text = "Inscription";
            this.MenuItemInscriprion.Click += new System.EventHandler(this.MenuItemInscriprion_Click);
            // 
            // MenuItemFont
            // 
            this.MenuItemFont.Name = "MenuItemFont";
            this.MenuItemFont.Size = new System.Drawing.Size(130, 22);
            this.MenuItemFont.Text = "Font";
            this.MenuItemFont.Click += new System.EventHandler(this.MenuItemFont_Click);
            // 
            // MenuItemWrite
            // 
            this.MenuItemWrite.Enabled = false;
            this.MenuItemWrite.Name = "MenuItemWrite";
            this.MenuItemWrite.Size = new System.Drawing.Size(130, 22);
            this.MenuItemWrite.Text = "Write";
            this.MenuItemWrite.Click += new System.EventHandler(this.MenuItemWrite_Click);
            // 
            // MenuItemLine
            // 
            this.MenuItemLine.Enabled = false;
            this.MenuItemLine.Name = "MenuItemLine";
            this.MenuItemLine.Size = new System.Drawing.Size(130, 22);
            this.MenuItemLine.Text = "Line";
            this.MenuItemLine.Click += new System.EventHandler(this.MenuItemLine_Click);
            // 
            // MenuItemEllipse
            // 
            this.MenuItemEllipse.Enabled = false;
            this.MenuItemEllipse.Name = "MenuItemEllipse";
            this.MenuItemEllipse.Size = new System.Drawing.Size(130, 22);
            this.MenuItemEllipse.Text = "Ellipse";
            this.MenuItemEllipse.Click += new System.EventHandler(this.MenuItemEllipse_Click);
            // 
            // MenuItemRectangle
            // 
            this.MenuItemRectangle.Enabled = false;
            this.MenuItemRectangle.Name = "MenuItemRectangle";
            this.MenuItemRectangle.Size = new System.Drawing.Size(130, 22);
            this.MenuItemRectangle.Text = "Rectangle";
            this.MenuItemRectangle.Click += new System.EventHandler(this.MenuItemRectangle_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(95, 29);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(247, 109);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // groupBoxPixelValue
            // 
            this.groupBoxPixelValue.BackColor = System.Drawing.Color.DimGray;
            this.groupBoxPixelValue.Controls.Add(this.labelDistance);
            this.groupBoxPixelValue.Controls.Add(this.labelCoord);
            this.groupBoxPixelValue.Controls.Add(this.progressBarAlpha);
            this.groupBoxPixelValue.Controls.Add(this.Green);
            this.groupBoxPixelValue.Controls.Add(this.progressBarRed);
            this.groupBoxPixelValue.Controls.Add(this.Blue);
            this.groupBoxPixelValue.Controls.Add(this.Red);
            this.groupBoxPixelValue.Controls.Add(this.labelAlpha);
            this.groupBoxPixelValue.Controls.Add(this.labelGreen);
            this.groupBoxPixelValue.Controls.Add(this.labelBlue);
            this.groupBoxPixelValue.Controls.Add(this.labelRed);
            this.groupBoxPixelValue.Controls.Add(this.Alpha);
            this.groupBoxPixelValue.Controls.Add(this.progressBarBlue);
            this.groupBoxPixelValue.Controls.Add(this.progressBarGreen);
            this.groupBoxPixelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPixelValue.ForeColor = System.Drawing.Color.White;
            this.groupBoxPixelValue.Location = new System.Drawing.Point(12, 144);
            this.groupBoxPixelValue.MinimumSize = new System.Drawing.Size(500, 107);
            this.groupBoxPixelValue.Name = "groupBoxPixelValue";
            this.groupBoxPixelValue.Size = new System.Drawing.Size(520, 107);
            this.groupBoxPixelValue.TabIndex = 2;
            this.groupBoxPixelValue.TabStop = false;
            this.groupBoxPixelValue.Visible = false;
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.BackColor = System.Drawing.Color.Transparent;
            this.labelDistance.Location = new System.Drawing.Point(267, 21);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(205, 60);
            this.labelDistance.TabIndex = 15;
            this.labelDistance.Text = "Distance\r\nнажмите левую кнопку мыши \r\nдля перемещения\r\n \r\n";
            this.labelDistance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelDistance_MouseDown);
            this.labelDistance.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelDistance_MouseMove);
            this.labelDistance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelDistance_MouseUp);
            // 
            // labelCoord
            // 
            this.labelCoord.AutoSize = true;
            this.labelCoord.Location = new System.Drawing.Point(6, 0);
            this.labelCoord.MaximumSize = new System.Drawing.Size(0, 30);
            this.labelCoord.Name = "labelCoord";
            this.labelCoord.Size = new System.Drawing.Size(45, 15);
            this.labelCoord.TabIndex = 9;
            this.labelCoord.Text = "Coord";
            this.labelCoord.DoubleClick += new System.EventHandler(this.labelCoord_DoubleClick);
            // 
            // progressBarAlpha
            // 
            this.progressBarAlpha.Location = new System.Drawing.Point(6, 21);
            this.progressBarAlpha.Maximum = 255;
            this.progressBarAlpha.Name = "progressBarAlpha";
            this.progressBarAlpha.Size = new System.Drawing.Size(111, 15);
            this.progressBarAlpha.TabIndex = 1;
            // 
            // Green
            // 
            this.Green.AutoSize = true;
            this.Green.Location = new System.Drawing.Point(168, 84);
            this.Green.Name = "Green";
            this.Green.Size = new System.Drawing.Size(46, 15);
            this.Green.TabIndex = 13;
            this.Green.Text = "Green";
            // 
            // progressBarRed
            // 
            this.progressBarRed.BackColor = System.Drawing.Color.Black;
            this.progressBarRed.Location = new System.Drawing.Point(6, 42);
            this.progressBarRed.Maximum = 255;
            this.progressBarRed.Name = "progressBarRed";
            this.progressBarRed.Size = new System.Drawing.Size(111, 15);
            this.progressBarRed.TabIndex = 2;
            // 
            // Blue
            // 
            this.Blue.AutoSize = true;
            this.Blue.Location = new System.Drawing.Point(168, 63);
            this.Blue.Name = "Blue";
            this.Blue.Size = new System.Drawing.Size(36, 15);
            this.Blue.TabIndex = 12;
            this.Blue.Text = "Blue";
            // 
            // Red
            // 
            this.Red.AutoSize = true;
            this.Red.Location = new System.Drawing.Point(168, 42);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(33, 15);
            this.Red.TabIndex = 11;
            this.Red.Text = "Red";
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.BackColor = System.Drawing.Color.Transparent;
            this.labelAlpha.ForeColor = System.Drawing.Color.Transparent;
            this.labelAlpha.Location = new System.Drawing.Point(168, 21);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(43, 15);
            this.labelAlpha.TabIndex = 10;
            this.labelAlpha.Text = "Alpha";
            // 
            // labelGreen
            // 
            this.labelGreen.BackColor = System.Drawing.Color.Lime;
            this.labelGreen.Location = new System.Drawing.Point(123, 84);
            this.labelGreen.Name = "labelGreen";
            this.labelGreen.Size = new System.Drawing.Size(15, 15);
            this.labelGreen.TabIndex = 8;
            // 
            // labelBlue
            // 
            this.labelBlue.BackColor = System.Drawing.Color.Blue;
            this.labelBlue.Location = new System.Drawing.Point(123, 63);
            this.labelBlue.Name = "labelBlue";
            this.labelBlue.Size = new System.Drawing.Size(15, 15);
            this.labelBlue.TabIndex = 7;
            // 
            // labelRed
            // 
            this.labelRed.BackColor = System.Drawing.Color.Red;
            this.labelRed.ForeColor = System.Drawing.Color.Black;
            this.labelRed.Location = new System.Drawing.Point(123, 42);
            this.labelRed.Name = "labelRed";
            this.labelRed.Size = new System.Drawing.Size(15, 15);
            this.labelRed.TabIndex = 6;
            // 
            // Alpha
            // 
            this.Alpha.AutoSize = true;
            this.Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Alpha.ForeColor = System.Drawing.Color.Turquoise;
            this.Alpha.Location = new System.Drawing.Point(123, 21);
            this.Alpha.Name = "Alpha";
            this.Alpha.Size = new System.Drawing.Size(43, 15);
            this.Alpha.TabIndex = 5;
            this.Alpha.Text = "Alpha";
            // 
            // progressBarBlue
            // 
            this.progressBarBlue.Location = new System.Drawing.Point(6, 63);
            this.progressBarBlue.Maximum = 255;
            this.progressBarBlue.Name = "progressBarBlue";
            this.progressBarBlue.Size = new System.Drawing.Size(111, 15);
            this.progressBarBlue.TabIndex = 4;
            // 
            // progressBarGreen
            // 
            this.progressBarGreen.Location = new System.Drawing.Point(6, 84);
            this.progressBarGreen.Maximum = 255;
            this.progressBarGreen.Name = "progressBarGreen";
            this.progressBarGreen.Size = new System.Drawing.Size(111, 15);
            this.progressBarGreen.TabIndex = 3;
            // 
            // Child
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 277);
            this.Controls.Add(this.groupBoxPixelValue);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1200, 600);
            this.MinimumSize = new System.Drawing.Size(550, 300);
            this.Name = "Child";
            this.Text = "Child";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Child_FormClosing);
            this.Resize += new System.EventHandler(this.Child_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBoxPixelValue.ResumeLayout(false);
            this.groupBoxPixelValue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemImageInfo;
        public System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPixelValue;
        private System.Windows.Forms.GroupBox groupBoxPixelValue;
        private System.Windows.Forms.Label labelRed;
        private System.Windows.Forms.Label Alpha;
        private System.Windows.Forms.ProgressBar progressBarBlue;
        private System.Windows.Forms.ProgressBar progressBarGreen;
        private System.Windows.Forms.ProgressBar progressBarRed;
        private System.Windows.Forms.ProgressBar progressBarAlpha;
        private System.Windows.Forms.Label labelGreen;
        private System.Windows.Forms.Label labelBlue;
        private System.Windows.Forms.Label labelCoord;
        private System.Windows.Forms.Label Green;
        private System.Windows.Forms.Label Blue;
        private System.Windows.Forms.Label Red;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.ToolStripMenuItem MenuItemPaint;
        private System.Windows.Forms.ToolStripMenuItem MenuItemFont;
        private System.Windows.Forms.ToolStripMenuItem MenuItemInscriprion;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLine;
        private System.Windows.Forms.ToolStripMenuItem MenuItemEllipse;
        private System.Windows.Forms.ToolStripMenuItem MenuItemRectangle;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem MenuItemWrite;
    }
}