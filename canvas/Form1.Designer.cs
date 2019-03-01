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
            this.rectButton = new System.Windows.Forms.Button();
            this.elipButton = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.seleButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // rectButton
            // 
            this.rectButton.Location = new System.Drawing.Point(12, 16);
            this.rectButton.Name = "rectButton";
            this.rectButton.Size = new System.Drawing.Size(75, 23);
            this.rectButton.TabIndex = 1;
            this.rectButton.Text = "Rectangle";
            this.rectButton.UseVisualStyleBackColor = true;
            this.rectButton.Click += new System.EventHandler(this.rectButton_Click);
            // 
            // elipButton
            // 
            this.elipButton.Location = new System.Drawing.Point(93, 16);
            this.elipButton.Name = "elipButton";
            this.elipButton.Size = new System.Drawing.Size(75, 23);
            this.elipButton.TabIndex = 2;
            this.elipButton.Text = "Elipse";
            this.elipButton.UseVisualStyleBackColor = true;
            this.elipButton.Click += new System.EventHandler(this.elipButton_Click);
            // 
            // canvas
            // 
            this.canvas.Location = new System.Drawing.Point(12, 45);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1297, 567);
            this.canvas.TabIndex = 3;
            this.canvas.TabStop = false;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // seleButton
            // 
            this.seleButton.Location = new System.Drawing.Point(174, 16);
            this.seleButton.Name = "seleButton";
            this.seleButton.Size = new System.Drawing.Size(75, 23);
            this.seleButton.TabIndex = 4;
            this.seleButton.Text = "Select";
            this.seleButton.UseVisualStyleBackColor = true;
            this.seleButton.Click += new System.EventHandler(this.seleButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 624);
            this.Controls.Add(this.seleButton);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.elipButton);
            this.Controls.Add(this.rectButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button rectButton;
        private System.Windows.Forms.Button elipButton;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button seleButton;
    }
}

