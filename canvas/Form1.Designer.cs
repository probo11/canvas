namespace canvas
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rectButton = new System.Windows.Forms.Button();
            this.elipButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.seleButton = new System.Windows.Forms.Button();
            this.moveButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.minButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rectButton
            // 
            this.rectButton.Location = new System.Drawing.Point(12, 29);
            this.rectButton.Name = "rectButton";
            this.rectButton.Size = new System.Drawing.Size(75, 23);
            this.rectButton.TabIndex = 1;
            this.rectButton.Text = "Rectangle";
            this.rectButton.UseVisualStyleBackColor = true;
            this.rectButton.Click += new System.EventHandler(this.rectButton_Click);
            // 
            // elipButton
            // 
            this.elipButton.Location = new System.Drawing.Point(93, 29);
            this.elipButton.Name = "elipButton";
            this.elipButton.Size = new System.Drawing.Size(75, 23);
            this.elipButton.TabIndex = 2;
            this.elipButton.Text = "Elipse";
            this.elipButton.UseVisualStyleBackColor = true;
            this.elipButton.Click += new System.EventHandler(this.elipButton_Click);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 58);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1297, 554);
            this.canvas.TabIndex = 3;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // seleButton
            // 
            this.seleButton.Location = new System.Drawing.Point(174, 29);
            this.seleButton.Name = "seleButton";
            this.seleButton.Size = new System.Drawing.Size(75, 23);
            this.seleButton.TabIndex = 4;
            this.seleButton.Text = "Select";
            this.seleButton.UseVisualStyleBackColor = true;
            this.seleButton.Click += new System.EventHandler(this.seleButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.Enabled = false;
            this.moveButton.Location = new System.Drawing.Point(255, 29);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(75, 23);
            this.moveButton.TabIndex = 7;
            this.moveButton.Text = "Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.moveButton_Click);
            // 
            // plusButton
            // 
            this.plusButton.Enabled = false;
            this.plusButton.Location = new System.Drawing.Point(1030, 29);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(27, 23);
            this.plusButton.TabIndex = 8;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label1.Location = new System.Drawing.Point(973, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Resize";
            // 
            // minButton
            // 
            this.minButton.Enabled = false;
            this.minButton.Location = new System.Drawing.Point(1063, 29);
            this.minButton.Name = "minButton";
            this.minButton.Size = new System.Drawing.Size(27, 23);
            this.minButton.TabIndex = 11;
            this.minButton.Text = "-";
            this.minButton.UseVisualStyleBackColor = true;
            this.minButton.Click += new System.EventHandler(this.minButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1321, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 624);
            this.Controls.Add(this.minButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.moveButton);
            this.Controls.Add(this.seleButton);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.elipButton);
            this.Controls.Add(this.rectButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = " PAINt";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button rectButton;
        private System.Windows.Forms.Button elipButton;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button seleButton;
        private System.Windows.Forms.Button moveButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button minButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

