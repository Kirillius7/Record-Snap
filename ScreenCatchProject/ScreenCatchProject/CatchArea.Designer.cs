namespace ScreenCatchProject
{
    partial class CatchArea
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.FiguresPanel = new System.Windows.Forms.Panel();
            this.PenLineButton = new System.Windows.Forms.Button();
            this.StraightLineButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.CircleButton = new System.Windows.Forms.Button();
            this.TextButton = new System.Windows.Forms.Button();
            this.TxtFntButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.CleanCanvas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_second = new System.Windows.Forms.Panel();
            this.comboBoxAudio = new System.Windows.Forms.ComboBox();
            this.comboBoxFPS = new System.Windows.Forms.ComboBox();
            this.AreaRecordButton = new System.Windows.Forms.Button();
            this.RecordVideoButton = new System.Windows.Forms.Button();
            this.StopRecordButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_third = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ColorChoosen = new System.Windows.Forms.PictureBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_first = new System.Windows.Forms.Panel();
            this.ScreenAreaButton = new System.Windows.Forms.Button();
            this.FullScreenButton = new System.Windows.Forms.Button();
            this.TabScreenButton = new System.Windows.Forms.Button();
            this.comboBoxWindows = new System.Windows.Forms.ComboBox();
            this.comboBoxTimer = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.figureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.straightLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanCompletelyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeLastDrawingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.FiguresPanel.SuspendLayout();
            this.panel_second.SuspendLayout();
            this.panel_third.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorChoosen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel_first.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel2.Controls.Add(this.FiguresPanel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel_second);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel_third);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel_first);
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1773, 151);
            this.panel2.TabIndex = 3;
            // 
            // FiguresPanel
            // 
            this.FiguresPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FiguresPanel.Controls.Add(this.PenLineButton);
            this.FiguresPanel.Controls.Add(this.StraightLineButton);
            this.FiguresPanel.Controls.Add(this.RectangleButton);
            this.FiguresPanel.Controls.Add(this.CircleButton);
            this.FiguresPanel.Controls.Add(this.TextButton);
            this.FiguresPanel.Controls.Add(this.TxtFntButton);
            this.FiguresPanel.Controls.Add(this.UndoButton);
            this.FiguresPanel.Controls.Add(this.CleanCanvas);
            this.FiguresPanel.Location = new System.Drawing.Point(1380, 62);
            this.FiguresPanel.Name = "FiguresPanel";
            this.FiguresPanel.Size = new System.Drawing.Size(361, 81);
            this.FiguresPanel.TabIndex = 43;
            this.FiguresPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.FiguresPanel_Paint);
            // 
            // PenLineButton
            // 
            this.PenLineButton.BackColor = System.Drawing.Color.White;
            this.PenLineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PenLineButton.Location = new System.Drawing.Point(16, 6);
            this.PenLineButton.Name = "PenLineButton";
            this.PenLineButton.Size = new System.Drawing.Size(75, 30);
            this.PenLineButton.TabIndex = 23;
            this.PenLineButton.Text = "Pen";
            this.PenLineButton.UseVisualStyleBackColor = false;
            this.PenLineButton.Click += new System.EventHandler(this.PenLineButton_Click);
            // 
            // StraightLineButton
            // 
            this.StraightLineButton.BackColor = System.Drawing.Color.White;
            this.StraightLineButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StraightLineButton.Location = new System.Drawing.Point(16, 44);
            this.StraightLineButton.Name = "StraightLineButton";
            this.StraightLineButton.Size = new System.Drawing.Size(75, 30);
            this.StraightLineButton.TabIndex = 24;
            this.StraightLineButton.Text = "Line";
            this.StraightLineButton.UseVisualStyleBackColor = false;
            this.StraightLineButton.Click += new System.EventHandler(this.StraightLineButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.BackColor = System.Drawing.Color.White;
            this.RectangleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RectangleButton.Location = new System.Drawing.Point(100, 6);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(84, 30);
            this.RectangleButton.TabIndex = 25;
            this.RectangleButton.Text = "Rectangle";
            this.RectangleButton.UseVisualStyleBackColor = false;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // CircleButton
            // 
            this.CircleButton.BackColor = System.Drawing.Color.White;
            this.CircleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CircleButton.Location = new System.Drawing.Point(100, 44);
            this.CircleButton.Name = "CircleButton";
            this.CircleButton.Size = new System.Drawing.Size(84, 30);
            this.CircleButton.TabIndex = 26;
            this.CircleButton.Text = "Circle";
            this.CircleButton.UseVisualStyleBackColor = false;
            this.CircleButton.Click += new System.EventHandler(this.CircleButton_Click);
            // 
            // TextButton
            // 
            this.TextButton.BackColor = System.Drawing.Color.White;
            this.TextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextButton.Location = new System.Drawing.Point(190, 6);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new System.Drawing.Size(75, 30);
            this.TextButton.TabIndex = 27;
            this.TextButton.Text = "Text";
            this.TextButton.UseVisualStyleBackColor = false;
            this.TextButton.Click += new System.EventHandler(this.TextButton_Click);
            // 
            // TxtFntButton
            // 
            this.TxtFntButton.BackColor = System.Drawing.Color.White;
            this.TxtFntButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TxtFntButton.Location = new System.Drawing.Point(190, 44);
            this.TxtFntButton.Name = "TxtFntButton";
            this.TxtFntButton.Size = new System.Drawing.Size(75, 30);
            this.TxtFntButton.TabIndex = 28;
            this.TxtFntButton.Text = "Text Font";
            this.TxtFntButton.UseVisualStyleBackColor = false;
            this.TxtFntButton.Click += new System.EventHandler(this.TxtFntButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.BackColor = System.Drawing.Color.White;
            this.UndoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UndoButton.Location = new System.Drawing.Point(271, 44);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 30);
            this.UndoButton.TabIndex = 32;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = false;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // CleanCanvas
            // 
            this.CleanCanvas.BackColor = System.Drawing.Color.White;
            this.CleanCanvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CleanCanvas.Location = new System.Drawing.Point(271, 6);
            this.CleanCanvas.Name = "CleanCanvas";
            this.CleanCanvas.Size = new System.Drawing.Size(75, 30);
            this.CleanCanvas.TabIndex = 4;
            this.CleanCanvas.Text = "Clean";
            this.CleanCanvas.UseVisualStyleBackColor = false;
            this.CleanCanvas.Click += new System.EventHandler(this.CleanCanvas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(652, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 18);
            this.label3.TabIndex = 42;
            this.label3.Text = "Recording";
            // 
            // panel_second
            // 
            this.panel_second.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_second.Controls.Add(this.comboBoxAudio);
            this.panel_second.Controls.Add(this.comboBoxFPS);
            this.panel_second.Controls.Add(this.AreaRecordButton);
            this.panel_second.Controls.Add(this.RecordVideoButton);
            this.panel_second.Controls.Add(this.StopRecordButton);
            this.panel_second.Location = new System.Drawing.Point(647, 62);
            this.panel_second.Name = "panel_second";
            this.panel_second.Size = new System.Drawing.Size(454, 81);
            this.panel_second.TabIndex = 41;
            this.panel_second.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_second_Paint);
            // 
            // comboBoxAudio
            // 
            this.comboBoxAudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxAudio.FormattingEnabled = true;
            this.comboBoxAudio.Items.AddRange(new object[] {
            "with Audio",
            "without Audio"});
            this.comboBoxAudio.Location = new System.Drawing.Point(316, 45);
            this.comboBoxAudio.Name = "comboBoxAudio";
            this.comboBoxAudio.Size = new System.Drawing.Size(121, 23);
            this.comboBoxAudio.TabIndex = 45;
            this.comboBoxAudio.Text = "Audio";
            this.comboBoxAudio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudio_SelectedIndexChanged);
            // 
            // comboBoxFPS
            // 
            this.comboBoxFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxFPS.FormattingEnabled = true;
            this.comboBoxFPS.Items.AddRange(new object[] {
            "5 FPS",
            "7 FPS",
            "9 FPS",
            "10 FPS",
            "11 FPS",
            "15 FPS",
            "25 FPS",
            "30 FPS",
            "35 FPS",
            "45 FPS"});
            this.comboBoxFPS.Location = new System.Drawing.Point(316, 13);
            this.comboBoxFPS.Name = "comboBoxFPS";
            this.comboBoxFPS.Size = new System.Drawing.Size(121, 23);
            this.comboBoxFPS.TabIndex = 44;
            this.comboBoxFPS.Text = "FPS";
            this.comboBoxFPS.SelectedIndexChanged += new System.EventHandler(this.comboBoxFPS_SelectedIndexChanged);
            // 
            // AreaRecordButton
            // 
            this.AreaRecordButton.BackColor = System.Drawing.Color.White;
            this.AreaRecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AreaRecordButton.Location = new System.Drawing.Point(215, 22);
            this.AreaRecordButton.Name = "AreaRecordButton";
            this.AreaRecordButton.Size = new System.Drawing.Size(95, 35);
            this.AreaRecordButton.TabIndex = 21;
            this.AreaRecordButton.Text = "Select area";
            this.AreaRecordButton.UseVisualStyleBackColor = false;
            this.AreaRecordButton.Click += new System.EventHandler(this.AreaRecordButton_Click);
            // 
            // RecordVideoButton
            // 
            this.RecordVideoButton.BackColor = System.Drawing.Color.White;
            this.RecordVideoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RecordVideoButton.Location = new System.Drawing.Point(13, 23);
            this.RecordVideoButton.Name = "RecordVideoButton";
            this.RecordVideoButton.Size = new System.Drawing.Size(95, 37);
            this.RecordVideoButton.TabIndex = 19;
            this.RecordVideoButton.Text = "Start";
            this.RecordVideoButton.UseVisualStyleBackColor = false;
            this.RecordVideoButton.Click += new System.EventHandler(this.RecordVideoButton_Click);
            // 
            // StopRecordButton
            // 
            this.StopRecordButton.BackColor = System.Drawing.Color.White;
            this.StopRecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StopRecordButton.Location = new System.Drawing.Point(114, 23);
            this.StopRecordButton.Name = "StopRecordButton";
            this.StopRecordButton.Size = new System.Drawing.Size(95, 35);
            this.StopRecordButton.TabIndex = 20;
            this.StopRecordButton.Text = "Stop";
            this.StopRecordButton.UseVisualStyleBackColor = false;
            this.StopRecordButton.Click += new System.EventHandler(this.StopRecordButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(1114, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 40;
            this.label2.Text = "Drawing";
            // 
            // panel_third
            // 
            this.panel_third.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_third.Controls.Add(this.radioButton1);
            this.panel_third.Controls.Add(this.ColorChoosen);
            this.panel_third.Controls.Add(this.radioButton3);
            this.panel_third.Controls.Add(this.trackBar1);
            this.panel_third.Controls.Add(this.radioButton2);
            this.panel_third.Location = new System.Drawing.Point(1109, 60);
            this.panel_third.Name = "panel_third";
            this.panel_third.Size = new System.Drawing.Size(265, 81);
            this.panel_third.TabIndex = 39;
            this.panel_third.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_third_Paint);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(75, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Brush";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // ColorChoosen
            // 
            this.ColorChoosen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ColorChoosen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorChoosen.Location = new System.Drawing.Point(23, 28);
            this.ColorChoosen.Name = "ColorChoosen";
            this.ColorChoosen.Size = new System.Drawing.Size(29, 23);
            this.ColorChoosen.TabIndex = 0;
            this.ColorChoosen.TabStop = false;
            this.ColorChoosen.Click += new System.EventHandler(this.ColorChoosen_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(75, 51);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(62, 17);
            this.radioButton3.TabIndex = 31;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "DotLine";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.trackBar1.Location = new System.Drawing.Point(145, 14);
            this.trackBar1.Maximum = 20;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickFrequency = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(75, 30);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.Text = "Pencil";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(65, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Screenshot";
            // 
            // panel_first
            // 
            this.panel_first.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_first.Controls.Add(this.ScreenAreaButton);
            this.panel_first.Controls.Add(this.FullScreenButton);
            this.panel_first.Controls.Add(this.TabScreenButton);
            this.panel_first.Controls.Add(this.comboBoxWindows);
            this.panel_first.Controls.Add(this.comboBoxTimer);
            this.panel_first.Location = new System.Drawing.Point(60, 62);
            this.panel_first.Name = "panel_first";
            this.panel_first.Size = new System.Drawing.Size(579, 81);
            this.panel_first.TabIndex = 37;
            this.panel_first.Tag = "Screen";
            this.panel_first.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_first_Paint);
            // 
            // ScreenAreaButton
            // 
            this.ScreenAreaButton.BackColor = System.Drawing.Color.White;
            this.ScreenAreaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ScreenAreaButton.Location = new System.Drawing.Point(13, 21);
            this.ScreenAreaButton.Name = "ScreenAreaButton";
            this.ScreenAreaButton.Size = new System.Drawing.Size(95, 37);
            this.ScreenAreaButton.TabIndex = 2;
            this.ScreenAreaButton.Text = "Screen Area";
            this.ScreenAreaButton.UseVisualStyleBackColor = false;
            this.ScreenAreaButton.Click += new System.EventHandler(this.ScreenAreaButton_Click);
            // 
            // FullScreenButton
            // 
            this.FullScreenButton.BackColor = System.Drawing.Color.White;
            this.FullScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullScreenButton.Location = new System.Drawing.Point(114, 21);
            this.FullScreenButton.Name = "FullScreenButton";
            this.FullScreenButton.Size = new System.Drawing.Size(95, 37);
            this.FullScreenButton.TabIndex = 14;
            this.FullScreenButton.Text = "Full Screen";
            this.FullScreenButton.UseVisualStyleBackColor = false;
            this.FullScreenButton.Click += new System.EventHandler(this.FullScreenButton_Click);
            // 
            // TabScreenButton
            // 
            this.TabScreenButton.BackColor = System.Drawing.Color.White;
            this.TabScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TabScreenButton.Location = new System.Drawing.Point(342, 23);
            this.TabScreenButton.Name = "TabScreenButton";
            this.TabScreenButton.Size = new System.Drawing.Size(95, 35);
            this.TabScreenButton.TabIndex = 18;
            this.TabScreenButton.Text = "Tab Screen";
            this.TabScreenButton.UseVisualStyleBackColor = false;
            this.TabScreenButton.Click += new System.EventHandler(this.TabScreenButton_Click);
            // 
            // comboBoxWindows
            // 
            this.comboBoxWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxWindows.FormattingEnabled = true;
            this.comboBoxWindows.Location = new System.Drawing.Point(215, 29);
            this.comboBoxWindows.Name = "comboBoxWindows";
            this.comboBoxWindows.Size = new System.Drawing.Size(121, 23);
            this.comboBoxWindows.TabIndex = 17;
            this.comboBoxWindows.Text = "Windows";
            // 
            // comboBoxTimer
            // 
            this.comboBoxTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTimer.FormattingEnabled = true;
            this.comboBoxTimer.Items.AddRange(new object[] {
            "1 second",
            "2 seconds ",
            "3 seconds",
            "4 seconds",
            "5 seconds",
            "10 seconds"});
            this.comboBoxTimer.Location = new System.Drawing.Point(443, 29);
            this.comboBoxTimer.Name = "comboBoxTimer";
            this.comboBoxTimer.Size = new System.Drawing.Size(121, 23);
            this.comboBoxTimer.TabIndex = 11;
            this.comboBoxTimer.Text = "Timer";
            this.comboBoxTimer.SelectedIndexChanged += new System.EventHandler(this.comboBoxTimer_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.drawToolStripMenuItem,
            this.rubberToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1773, 24);
            this.menuStrip1.TabIndex = 33;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // drawToolStripMenuItem
            // 
            this.drawToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.figureToolStripMenuItem,
            this.writeTextToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.drawToolStripMenuItem.Name = "drawToolStripMenuItem";
            this.drawToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.drawToolStripMenuItem.Text = "Draw";
            // 
            // figureToolStripMenuItem
            // 
            this.figureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.cToolStripMenuItem,
            this.straightLineToolStripMenuItem});
            this.figureToolStripMenuItem.Name = "figureToolStripMenuItem";
            this.figureToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.figureToolStripMenuItem.Text = "Figures";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            this.rectangleToolStripMenuItem.Click += new System.EventHandler(this.rectangleToolStripMenuItem_Click);
            // 
            // cToolStripMenuItem
            // 
            this.cToolStripMenuItem.Name = "cToolStripMenuItem";
            this.cToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.cToolStripMenuItem.Text = "Circle";
            this.cToolStripMenuItem.Click += new System.EventHandler(this.cToolStripMenuItem_Click);
            // 
            // straightLineToolStripMenuItem
            // 
            this.straightLineToolStripMenuItem.Name = "straightLineToolStripMenuItem";
            this.straightLineToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.straightLineToolStripMenuItem.Text = "Straight Line";
            this.straightLineToolStripMenuItem.Click += new System.EventHandler(this.straightLineToolStripMenuItem_Click);
            // 
            // writeTextToolStripMenuItem
            // 
            this.writeTextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.adjustToolStripMenuItem});
            this.writeTextToolStripMenuItem.Name = "writeTextToolStripMenuItem";
            this.writeTextToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.writeTextToolStripMenuItem.Text = "Write text";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.textToolStripMenuItem.Text = "Text";
            // 
            // adjustToolStripMenuItem
            // 
            this.adjustToolStripMenuItem.Name = "adjustToolStripMenuItem";
            this.adjustToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.adjustToolStripMenuItem.Text = "Text Font";
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // rubberToolStripMenuItem
            // 
            this.rubberToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanCompletelyToolStripMenuItem,
            this.removeLastDrawingToolStripMenuItem});
            this.rubberToolStripMenuItem.Name = "rubberToolStripMenuItem";
            this.rubberToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.rubberToolStripMenuItem.Text = "Rubber";
            // 
            // cleanCompletelyToolStripMenuItem
            // 
            this.cleanCompletelyToolStripMenuItem.Name = "cleanCompletelyToolStripMenuItem";
            this.cleanCompletelyToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.cleanCompletelyToolStripMenuItem.Text = "Clean completely";
            this.cleanCompletelyToolStripMenuItem.Click += new System.EventHandler(this.cleanCompletelyToolStripMenuItem_Click);
            // 
            // removeLastDrawingToolStripMenuItem
            // 
            this.removeLastDrawingToolStripMenuItem.Name = "removeLastDrawingToolStripMenuItem";
            this.removeLastDrawingToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.removeLastDrawingToolStripMenuItem.Text = "Undo";
            this.removeLastDrawingToolStripMenuItem.Click += new System.EventHandler(this.removeLastDrawingToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(0, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1773, 435);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // CatchArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1773, 583);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CatchArea";
            this.Text = "Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CatchArea_FormClosing);
            this.Load += new System.EventHandler(this.CatchArea_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CatchArea_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.FiguresPanel.ResumeLayout(false);
            this.panel_second.ResumeLayout(false);
            this.panel_third.ResumeLayout(false);
            this.panel_third.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ColorChoosen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel_first.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox ColorChoosen;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button CleanCanvas;
        private System.Windows.Forms.Button ScreenAreaButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxTimer;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button FullScreenButton;
        private System.Windows.Forms.ComboBox comboBoxWindows;
        private System.Windows.Forms.Button TabScreenButton;
        private System.Windows.Forms.Button AreaRecordButton;
        private System.Windows.Forms.Button StopRecordButton;
        private System.Windows.Forms.Button RecordVideoButton;
        private System.Windows.Forms.Button StraightLineButton;
        private System.Windows.Forms.Button PenLineButton;
        private System.Windows.Forms.Button CircleButton;
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.Button TextButton;
        private System.Windows.Forms.Button TxtFntButton;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem figureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem straightLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanCompletelyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeLastDrawingToolStripMenuItem;
        private System.Windows.Forms.Panel panel_first;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_third;
        private System.Windows.Forms.Panel panel_second;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel FiguresPanel;
        private System.Windows.Forms.ComboBox comboBoxFPS;
        private System.Windows.Forms.ComboBox comboBoxAudio;
    }
}