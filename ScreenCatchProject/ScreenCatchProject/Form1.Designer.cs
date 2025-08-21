namespace ScreenCatchProject
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.drLine = new System.Windows.Forms.Button();
            this.Font = new System.Windows.Forms.Button();
            this.caption = new System.Windows.Forms.Button();
            this.Circle = new System.Windows.Forms.Button();
            this.DrawLine = new System.Windows.Forms.Button();
            this.DrawRectangle = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.Color = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.CopyClipboard = new System.Windows.Forms.Button();
            this.CleanCanvas = new System.Windows.Forms.Button();
            this.ColorChoosen = new System.Windows.Forms.PictureBox();
            this.CatchAreaPicture = new System.Windows.Forms.Button();
            this.SavePicture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorChoosen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 74);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1773, 509);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.drLine);
            this.panel2.Controls.Add(this.Font);
            this.panel2.Controls.Add(this.caption);
            this.panel2.Controls.Add(this.Circle);
            this.panel2.Controls.Add(this.DrawLine);
            this.panel2.Controls.Add(this.DrawRectangle);
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Controls.Add(this.Color);
            this.panel2.Controls.Add(this.Create);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.radioButton2);
            this.panel2.Controls.Add(this.radioButton1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.trackBar1);
            this.panel2.Controls.Add(this.CopyClipboard);
            this.panel2.Controls.Add(this.CleanCanvas);
            this.panel2.Controls.Add(this.ColorChoosen);
            this.panel2.Controls.Add(this.CatchAreaPicture);
            this.panel2.Controls.Add(this.SavePicture);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1773, 77);
            this.panel2.TabIndex = 2;
            // 
            // drLine
            // 
            this.drLine.Location = new System.Drawing.Point(12, 30);
            this.drLine.Name = "drLine";
            this.drLine.Size = new System.Drawing.Size(50, 23);
            this.drLine.TabIndex = 24;
            this.drLine.Text = "button1";
            this.drLine.UseVisualStyleBackColor = true;
            this.drLine.Click += new System.EventHandler(this.drLine_Click);
            // 
            // Font
            // 
            this.Font.Location = new System.Drawing.Point(1529, 31);
            this.Font.Name = "Font";
            this.Font.Size = new System.Drawing.Size(75, 23);
            this.Font.TabIndex = 23;
            this.Font.Text = "button1";
            this.Font.UseVisualStyleBackColor = true;
            this.Font.Click += new System.EventHandler(this.Font_Click);
            // 
            // caption
            // 
            this.caption.Location = new System.Drawing.Point(325, 25);
            this.caption.Name = "caption";
            this.caption.Size = new System.Drawing.Size(59, 28);
            this.caption.TabIndex = 22;
            this.caption.Text = "button1";
            this.caption.UseVisualStyleBackColor = true;
            this.caption.Click += new System.EventHandler(this.caption_Click);
            // 
            // Circle
            // 
            this.Circle.Location = new System.Drawing.Point(149, 31);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(75, 23);
            this.Circle.TabIndex = 21;
            this.Circle.Text = "button1";
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.Click += new System.EventHandler(this.Circle_Click);
            // 
            // DrawLine
            // 
            this.DrawLine.Location = new System.Drawing.Point(68, 30);
            this.DrawLine.Name = "DrawLine";
            this.DrawLine.Size = new System.Drawing.Size(75, 23);
            this.DrawLine.TabIndex = 20;
            this.DrawLine.Text = "button1";
            this.DrawLine.UseVisualStyleBackColor = true;
            this.DrawLine.Click += new System.EventHandler(this.DrawLine_Click);
            // 
            // DrawRectangle
            // 
            this.DrawRectangle.Location = new System.Drawing.Point(244, 31);
            this.DrawRectangle.Name = "DrawRectangle";
            this.DrawRectangle.Size = new System.Drawing.Size(75, 23);
            this.DrawRectangle.TabIndex = 19;
            this.DrawRectangle.Text = "DrawRectangle";
            this.DrawRectangle.UseVisualStyleBackColor = true;
            this.DrawRectangle.Click += new System.EventHandler(this.DrawRectangle_Click);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.White;
            this.Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Exit.Location = new System.Drawing.Point(1675, 23);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(95, 37);
            this.Exit.TabIndex = 18;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Color
            // 
            this.Color.BackColor = System.Drawing.Color.White;
            this.Color.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Color.Location = new System.Drawing.Point(1099, 23);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(95, 37);
            this.Color.TabIndex = 17;
            this.Color.Text = "Color";
            this.Color.UseVisualStyleBackColor = false;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // Create
            // 
            this.Create.BackColor = System.Drawing.Color.White;
            this.Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Create.Location = new System.Drawing.Point(383, 23);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(95, 37);
            this.Create.TabIndex = 16;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = false;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "FullScreen Picture",
            "ActiveWindow Picture"});
            this.comboBox2.Location = new System.Drawing.Point(484, 33);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 21);
            this.comboBox2.TabIndex = 15;
            this.comboBox2.Text = "Regime";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(1258, 34);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Pencil";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(1200, 34);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Brush";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 second",
            "2 seconds ",
            "3 seconds",
            "4 seconds",
            "5 seconds",
            "10 seconds"});
            this.comboBox1.Location = new System.Drawing.Point(938, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(120, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "Timer";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.trackBar1.Location = new System.Drawing.Point(1318, 23);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // CopyClipboard
            // 
            this.CopyClipboard.BackColor = System.Drawing.Color.White;
            this.CopyClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CopyClipboard.Location = new System.Drawing.Point(736, 23);
            this.CopyClipboard.Name = "CopyClipboard";
            this.CopyClipboard.Size = new System.Drawing.Size(95, 37);
            this.CopyClipboard.TabIndex = 6;
            this.CopyClipboard.Text = "CopyPicture";
            this.CopyClipboard.UseVisualStyleBackColor = false;
            this.CopyClipboard.Click += new System.EventHandler(this.CopyClipboard_Click);
            // 
            // CleanCanvas
            // 
            this.CleanCanvas.BackColor = System.Drawing.Color.White;
            this.CleanCanvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CleanCanvas.Location = new System.Drawing.Point(1428, 23);
            this.CleanCanvas.Name = "CleanCanvas";
            this.CleanCanvas.Size = new System.Drawing.Size(95, 37);
            this.CleanCanvas.TabIndex = 4;
            this.CleanCanvas.Text = "Clean";
            this.CleanCanvas.UseVisualStyleBackColor = false;
            this.CleanCanvas.Click += new System.EventHandler(this.CleanCanvas_Click);
            // 
            // ColorChoosen
            // 
            this.ColorChoosen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorChoosen.Location = new System.Drawing.Point(1064, 31);
            this.ColorChoosen.Name = "ColorChoosen";
            this.ColorChoosen.Size = new System.Drawing.Size(29, 23);
            this.ColorChoosen.TabIndex = 0;
            this.ColorChoosen.TabStop = false;
            // 
            // CatchAreaPicture
            // 
            this.CatchAreaPicture.BackColor = System.Drawing.Color.White;
            this.CatchAreaPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CatchAreaPicture.Location = new System.Drawing.Point(635, 23);
            this.CatchAreaPicture.Name = "CatchAreaPicture";
            this.CatchAreaPicture.Size = new System.Drawing.Size(95, 37);
            this.CatchAreaPicture.TabIndex = 2;
            this.CatchAreaPicture.Text = "CatchArea";
            this.CatchAreaPicture.UseVisualStyleBackColor = false;
            this.CatchAreaPicture.Click += new System.EventHandler(this.CatchAreaPicture_Click);
            // 
            // SavePicture
            // 
            this.SavePicture.BackColor = System.Drawing.Color.White;
            this.SavePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SavePicture.Location = new System.Drawing.Point(837, 23);
            this.SavePicture.Name = "SavePicture";
            this.SavePicture.Size = new System.Drawing.Size(95, 37);
            this.SavePicture.TabIndex = 1;
            this.SavePicture.Text = "SavePicture";
            this.SavePicture.UseVisualStyleBackColor = false;
            this.SavePicture.Click += new System.EventHandler(this.SavePicture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1773, 583);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorChoosen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button SavePicture;
        private System.Windows.Forms.Button CatchAreaPicture;
        private System.Windows.Forms.Button CleanCanvas;
        private System.Windows.Forms.Button CopyClipboard;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox ColorChoosen;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Button DrawRectangle;
        private System.Windows.Forms.Button DrawLine;
        private System.Windows.Forms.Button Circle;
        private System.Windows.Forms.Button caption;
        private System.Windows.Forms.Button Font;
        private System.Windows.Forms.Button drLine;
    }
}

