using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using NAudio.Wave;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;



namespace ScreenCatchProject
{
    public partial class CatchArea : Form
    {
        frmCapture frmCapture = new frmCapture();

        private Bitmap originalImage;

        private Bitmap drawingImage;
        private Graphics drawingGraphics;
        private Point previousPoint;
        private Pen drawingPen = new Pen(System.Drawing.Color.Black, 2);
        private string timer;
        private string fpsSettings;
        private int seconds = 1;
        private int fps = 5;
        Dictionary<string, char> list = new Dictionary<string, char>();
        private VideoFileWriter videoWriter;
        private System.Windows.Forms.Timer timer1;
        private Rectangle screenBounds;

        //
        private WaveInEvent waveIn;
        private MemoryStream audioStream;
        private BinaryWriter audioWriter;
        //

        public CatchArea()
        {
            InitializeComponent();
            drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.Load += CatchArea_Load;
            this.AutoScroll = true;
            clr = System.Drawing.Color.Black;
            ColorChoosen.BackColor = drawingPen.Color;
            LoadOpenWindows();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000 / 30; // 30 FPS
            timer1.Tick += Timer_Tick;
            screenBounds = Screen.PrimaryScreen.Bounds;
            PenLineButton.BackColor = System.Drawing.Color.LightCyan;
            StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
            RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
            CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
            TextButton.BackColor = System.Drawing.Color.WhiteSmoke;

            panel2.BackColor = Color.Gainsboro;

            System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

            // Set up the delays for the ToolTip
            toolTip.AutoPopDelay = 5000; // Time the tooltip remains visible (in milliseconds)
            toolTip.InitialDelay = 1000; // Time before the tooltip appears when hovering (in milliseconds)
            toolTip.ReshowDelay = 500;   // Time between tooltips (in milliseconds)

            // Set up the ToolTip text for the Button
            toolTip.SetToolTip(this.PenLineButton, "Ctrl + Q");
            toolTip.SetToolTip(this.StraightLineButton, "Ctrl + W");
            toolTip.SetToolTip(this.RectangleButton, "Ctrl + E");
            toolTip.SetToolTip(this.CircleButton, "Ctrl + R");

            toolTip.SetToolTip(this.ScreenAreaButton, "Ctrl + J");
            toolTip.SetToolTip(this.FullScreenButton, "Ctrl + K");
            toolTip.SetToolTip(this.TabScreenButton, "Ctrl + L");

            toolTip.SetToolTip(this.RecordVideoButton, "Ctrl + B");
            toolTip.SetToolTip(this.StopRecordButton, "Ctrl + N");
            toolTip.SetToolTip(this.AreaRecordButton, "Ctrl + M");

            toolTip.SetToolTip(this.UndoButton, "Ctrl + Z");


            panel_first.Location = new Point(120, 52);
            label1.Location = new Point(130, 41);
            panel_second.Location = new Point(707, 52);
            label3.Location = new Point(717, 41);
            panel_third.Location = new Point(1169, 52);
            label2.Location = new Point(1179, 41);
            FiguresPanel.Location = new Point(1442, 52);


            windowRefreshTimer = new System.Windows.Forms.Timer();
            windowRefreshTimer.Interval = 3000; // Оновлення кожні 3 секунди
            windowRefreshTimer.Tick += (s, ev) => LoadOpenWindows();
            windowRefreshTimer.Start();


            //

            //


        }
        private System.Windows.Forms.Timer windowRefreshTimer;
        //private void CatchAreaPicture_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Thread.Sleep(seconds * 1000);
        //    frmCapture.ShowDialog(); // form shows up as a modal dialog window
        //    this.Show();
        //    originalImage = new Bitmap(Clipboard.GetImage());

        //    pictureBox1.Image = originalImage;
        //    pictureBox1.Width = originalImage.Width;
        //    pictureBox1.Height = originalImage.Height;
        //    drawingImage = new Bitmap(originalImage);
        //    drawingGraphics = Graphics.FromImage(drawingImage);
        //    previousPoint = Point.Empty;
        //    //history.Push(new Bitmap(pictureBox1.Image));
        //    check1 = false;
        //}

        private void CleanCanvas_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                originalImage = new Bitmap(originalImage);
                pictureBox1.Image = originalImage;
                drawingImage = new Bitmap(originalImage); // Create a copy for drawing
                drawingGraphics = Graphics.FromImage(drawingImage);

                history.Clear();
                history.Push(pictureBox1.Image);
                if(checkbutton)
                    Clipboard.SetImage(pictureBox1.Image);
            }
        }

        private void CatchArea_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.KeyPreview = true;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    previousPoint = Point.Empty;
            //}
            if (e.Button == MouseButtons.Left)
            {
                
                if (drawingGraphics != null && currentRectangle != Rectangle.Empty && isDrawingRectangle)
                {
                    // Draw the final rectangle on the drawing surface
                    drawingGraphics.DrawRectangle(drawingPen, currentRectangle);
                    pictureBox1.Image = drawingImage;

                    // Reset the rectangle
                    currentRectangle = Rectangle.Empty;
                }
                else if (drawingGraphics != null && currentCircle != Rectangle.Empty && isDrawingCircle)
                {
                    // Draw the final circle on the drawing surface
                    drawingGraphics.DrawEllipse(drawingPen, currentCircle);
                    pictureBox1.Image = drawingImage;

                    // Reset the circle
                    currentCircle = Rectangle.Empty;
                }
                else if (drawingGraphics != null && isDrawingLine)
                {
                    drawingGraphics.DrawLine(drawingPen, startPoint1, endPoint1);
                    pictureBox1.Image = drawingImage;
                    startPoint1 = Point.Empty;
                    endPoint1 = Point.Empty;
                }

                if (pictureBox1.Image != null)
                {
                    history.Push(new Bitmap(pictureBox1.Image));

                    if (checkbutton)
                        Clipboard.SetImage(pictureBox1.Image);
                    previousPoint = Point.Empty;
                }
                else
                {
                    MessageBox.Show("No image to work with");
                }

                
                //history.Add(pictureBox1.Image);
                //history.Push(new Bitmap(pictureBox1.Image));
            }
            
        }
        //private void button14_Click(object sender, EventArgs e)
        //{
        //    //Image img = new Bitmap(history.Pop());
        //    if (history.Count > 1)
        //    {
        //        history.Pop();
        //        drawingImage = new Bitmap(history.Peek());
        //        drawingGraphics = Graphics.FromImage(drawingImage);

        //        pictureBox1.Image = drawingImage;
        //    }

        //    pictureBox1.Invalidate();
        //}
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //   previousPoint = e.Location;
            //}
            if (e.Button == MouseButtons.Left && isDrawingRectangle)
            {
                previousPoint = e.Location;
                currentRectangle = new Rectangle(e.Location, new Size(0, 0));
            }
            else if (e.Button == MouseButtons.Left && isDrawingCircle)
            {
                previousPoint = e.Location;
                currentCircle = new Rectangle(e.Location, new Size(0, 0));
            }
            else if (e.Button == MouseButtons.Left && isDrawingLine)
            {
                startPoint1 = e.Location;
                endPoint1 = e.Location;
            }
            else if(e.Button == MouseButtons.Left && isTyping)
            {
                previousPoint = e.Location;
            }
            else
                previousPoint = e.Location;
        }

        Stack<Image> history = new Stack<Image>();

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && previousPoint != Point.Empty && drawingGraphics != null)
            //{
            //   drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
            //   pictureBox1.Image = drawingImage;
            //   previousPoint = e.Location;
            //}
            if (e.Button == MouseButtons.Left && drawingGraphics != null)
            {
                if (currentRectangle != null && isDrawingRectangle)
                {
                    // Determine the rectangle's top-left corner and its size based on the mouse position
                    int x = Math.Min(previousPoint.X, e.X);
                    int y = Math.Min(previousPoint.Y, e.Y);
                    int width = Math.Abs(e.X - previousPoint.X);
                    int height = Math.Abs(e.Y - previousPoint.Y);

                    // Update the rectangle's location and size
                    currentRectangle = new Rectangle(x, y, width, height);

                    // Repaint the picture box to show the current rectangle
                    pictureBox1.Invalidate();
                }
                else if (isDrawingCircle && currentCircle != null)
                {
                    // Determine the circle's top-left corner and its size based on the mouse position
                    int diameter = Math.Max(Math.Abs(e.X - previousPoint.X), Math.Abs(e.Y - previousPoint.Y));
                    int x = previousPoint.X - diameter / 2;
                    int y = previousPoint.Y - diameter / 2;

                    // Update the circle's location and size
                    currentCircle = new Rectangle(x, y, diameter, diameter);

                    // Repaint the picture box to show the current circle
                    pictureBox1.Invalidate();
                }
                else if (isDrawingLine)
                {
                    endPoint1 = e.Location;
                    pictureBox1.Invalidate(); // Redraw to update the line being drawn
                }
                else if(isTyping)
                {
                    endPoint1 = e.Location;
                    pictureBox1.Invalidate(); // Redraw to update the line being drawn

                    if (check2)
                    {
                        TextButton.BackColor = System.Drawing.Color.LightCyan;
                        CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                        RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                        StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                        PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                    }
                }
                else
                {
                    drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
                    pictureBox1.Image = drawingImage;
                    previousPoint = e.Location;
                }

                
            }
        }
        private int width = 0;
        private bool changeWidth = false;
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawingPen.Width = trackBar1.Value;
            width = trackBar1.Value;
            changeWidth = true;
        }

        int buttonNumber = 1;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            drawingPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            buttonNumber = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;

            drawingPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

            buttonNumber = 2;
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    timer = comboBoxTimer.Text;
        //    string timerNew = " ";

        //    foreach (char ch in timer)
        //        if (char.IsDigit(ch))
        //            timerNew += ch;
        //    seconds = Convert.ToInt32(timerNew);
        //}

        private void CatchArea_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Dispose();
        }

        private Bitmap screenshot;

        //private void BigScreen_Click(object sender, EventArgs e)
        //{
        //    //Form1 frm1 = new Form1();
        //    //frm1.Show();
        //    //this.Close();

        //    this.Hide();
        //    Thread.Sleep(seconds * 1000);

        //    screenshot = CaptureScreen();

        //    originalImage = screenshot;

        //    pictureBox1.Image = originalImage;
        //    history.Push(new Bitmap(pictureBox1.Image));
        //    drawingImage = new Bitmap(originalImage);
        //    drawingGraphics = Graphics.FromImage(drawingImage);
        //    previousPoint = Point.Empty;

        //    pictureBox1.Width = originalImage.Width;
        //    pictureBox1.Height = originalImage.Height;
        //    check1 = false;
        //    this.Show();
        //}

        private Bitmap CaptureScreen()
        {
            // Create a bitmap of the screen
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            bounds.Height = bounds.Height;

            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            return bitmap;
        }

        private bool check1 = true;
        private bool check2 = true;
        private bool check3 = true;
        private bool check4 = false;
        bool checkbutton = true;

        private void Exit_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            if (checkSaveLocal && !check1)
            {
                // Display a message box asking the user if they want to close the application
                DialogResult result = MessageBox.Show("Do you really want to leave?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Shut down the application if the user clicks "Yes"
                    Application.Exit();
                }

            }
            else
            {
                Application.Exit();
            }
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private const int CB_SETDROPPEDWIDTH = 0x160;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOZORDER = 0x0004;
        private void LoadOpenWindows()
        {
            //EnumWindows(new EnumWindowsProc((hWnd, lParam) =>
            //{
            //    if (IsWindowVisible(hWnd))
            //    {
            //        int length = GetWindowTextLength(hWnd);
            //        if (length > 0)
            //        {
            //            var windowTitle = new System.Text.StringBuilder(length + 1);
            //            GetWindowText(hWnd, windowTitle, windowTitle.Capacity);

            //            string title = windowTitle.ToString();

            //            // Filter out unwanted applications
            //            if (title != "Program Manager" &&  title != "Параметры" && title != "Microsoft Text Input Application" && title != "MainForm")
            //            {
            //                comboBox2.Items.Add(new WindowItem { Handle = hWnd, Title = title });
            //            }
            //        }
            //    }
            //    return true;
            //}), IntPtr.Zero);

            //comboBox2.DisplayMember = "Title";

            //HashSet<string> existingTitles = new HashSet<string>();
            //foreach (WindowItem item in comboBox2.Items)
            //{
            //    existingTitles.Add(item.Title);
            //}

            //EnumWindows(new EnumWindowsProc((hWnd, lParam) =>
            //{
            //    if (IsWindowVisible(hWnd))
            //    {
            //        int length = GetWindowTextLength(hWnd);
            //        if (length > 0)
            //        {
            //            var windowTitle = new System.Text.StringBuilder(length + 1);
            //            GetWindowText(hWnd, windowTitle, windowTitle.Capacity);

            //            string title = windowTitle.ToString();

            //            // Фільтрація непотрібних вікон
            //            if (title != "Program Manager" && title != "Параметры" &&
            //                title != "Microsoft Text Input Application" && title != "Application"
            //                && title[0] != '?' && title[0] != '(')
            //            {
            //                if (!existingTitles.Contains(title))
            //                {
            //                    comboBox2.Items.Add(new WindowItem { Handle = hWnd, Title = title });
            //                }
            //            }
            //        }
            //    }
            //    return true;
            //}), IntPtr.Zero);

            //comboBox2.DisplayMember = "Title";

            Dictionary<IntPtr, string> newWindows = new Dictionary<IntPtr, string>();
            List<IntPtr> openWindowHandles = new List<IntPtr>();

            EnumWindows(new EnumWindowsProc((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd))
                {
                    int length = GetWindowTextLength(hWnd);
                    if (length > 0)
                    {
                        var windowTitle = new System.Text.StringBuilder(length + 1);
                        GetWindowText(hWnd, windowTitle, windowTitle.Capacity);

                        string title = windowTitle.ToString();

                        // Фільтрація непотрібних вікон
                        if (title != "Program Manager" && title != "Параметры" &&
                            title != "Microsoft Text Input Application" && title != "Application")
                        {
                            openWindowHandles.Add(hWnd);
                            newWindows[hWnd] = title;

                            if (!existingWindows.ContainsKey(hWnd))
                            {
                                // Додаємо нове вікно, якщо його не було
                                comboBoxWindows.Items.Add(new WindowItem { Handle = hWnd, Title = title });
                            }
                            else if (existingWindows[hWnd] != title)
                            {
                                // Якщо назва вікна змінилася, оновлюємо її в списку
                                UpdateWindowTitle(hWnd, title);
                            }
                        }
                    }
                }
                return true;
            }), IntPtr.Zero);

            // Видаляємо закриті вікна
            for (int i = comboBoxWindows.Items.Count - 1; i >= 0; i--)
            {
                WindowItem item = (WindowItem)comboBoxWindows.Items[i];
                if (!openWindowHandles.Contains(item.Handle))
                {
                    comboBoxWindows.Items.RemoveAt(i);
                    existingWindows.Remove(item.Handle);
                }
            }

            existingWindows = newWindows;
            comboBoxWindows.DisplayMember = "Title";



        }
        private Dictionary<IntPtr, string> existingWindows = new Dictionary<IntPtr, string>();

        private void UpdateWindowTitle(IntPtr hWnd, string newTitle)
        {
            for (int i = 0; i < comboBoxWindows.Items.Count; i++)
            {
                WindowItem item = (WindowItem)comboBoxWindows.Items[i];
                if (item.Handle == hWnd)
                {
                    comboBoxWindows.Items[i] = new WindowItem { Handle = hWnd, Title = newTitle };
                    existingWindows[hWnd] = newTitle;
                    break;
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (comboBoxWindows.SelectedItem is WindowItem selectedWindow)
        //    {

        //                // Capture the window and save it with the chosen name, location, and extension
        //        this.Hide();
        //        Thread.Sleep(1000);
        //        CaptureWindow(selectedWindow.Handle);
        //        this.Show();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a window first.");
        //    }
        //}
        private void CaptureWindow(IntPtr hWnd)
        {
            GetWindowRect(hWnd, out RECT rect);
            int width = rect.Right - rect.Left;
            int height = rect.Bottom - rect.Top;

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(new Point(rect.Left, rect.Top), Point.Empty, new Size(width, height));
            }

            //bmp.Save("screenshot.png");
            //bmp.Save(filePath);
            //MessageBox.Show("Screenshot captured and saved as screenshot.png");

            //this.Hide();
            //Thread.Sleep(seconds * 1000);

            //screenshot = CaptureScreen();

            //originalImage = screenshot;

            //pictureBox1.Image = originalImage;
            //history.Clear();
            //history.Push(new Bitmap(pictureBox1.Image));
            //drawingImage = new Bitmap(originalImage);
            //drawingGraphics = Graphics.FromImage(drawingImage);
            //previousPoint = Point.Empty;

            //pictureBox1.Width = originalImage.Width;
            //pictureBox1.Height = originalImage.Height;
            //check1 = false;
            //this.Show();

            

            //originalImage = new Bitmap(bmp);

            //pictureBox1.Image = originalImage;

            //pictureBox1.Width = originalImage.Width;
            //pictureBox1.Height = originalImage.Height;
            //drawingImage = new Bitmap(originalImage);
            //drawingGraphics = Graphics.FromImage(drawingImage);
            //previousPoint = Point.Empty;

            originalImage = new Bitmap(bmp);

            pictureBox1.Image = originalImage;
            history.Clear();
            history.Push(new Bitmap(pictureBox1.Image));
            
            drawingImage = new Bitmap(originalImage);
            drawingGraphics = Graphics.FromImage(drawingImage);
            previousPoint = Point.Empty;
            
            pictureBox1.Width = originalImage.Width;
            pictureBox1.Height = originalImage.Height;
        }


        private string currentFilePath;
        List<int> data = new List<int>();

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    StartRecording();
        //}

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    StopRecording();
        //}        
        //private void button4_Click(object sender, EventArgs e)
        //{
        //    Form2 f = new Form2();
        //    this.Hide();
        //    Thread.Sleep(1000);
        //    f.ShowDialog(); // form shows up as a modal dialog window
        //    this.Show();

        //    data = f.Data();
        //}
        private void StartRecording()
        {
            if (withAudio == false)
            {
                videoWriter = new VideoFileWriter();
                videoWriter.Open("output2.mp4", screenBounds.Width, screenBounds.Height, 12, VideoCodec.MPEG4);
                timer1.Start();
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    //saveFileDialog.Filter = "MP4 Video Files (*.mp4)|*.mp4";
                    saveFileDialog.Filter = "MP4 Video Files (*.mp4)|*.mp4|AVI Video Files (*.avi)|*.avi|MOV Video Files (*.mov)|*.mov|MKV Video Files (*.mkv)|*.mkv";

                    saveFileDialog.Title = "Save Video File";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;

                        //videoWriter = new VideoFileWriter();
                        //videoWriter.Open(currentFilePath, screenBounds.Width, screenBounds.Height, 30, VideoCodec.MPEG4);
                        if (data.Count > 0)
                        {
                            Point customStartingPoint = new Point(data[0], data[1]);

                            // Calculate the new width and height based on the custom starting point
                            //int customWidth = data[2] + customStartingPoint.X;
                            //int customHeight = data[3] + customStartingPoint.Y;

                            int customWidth = data[2];
                            int customHeight = data[3];

                            if (customWidth % 2 != 0)
                                customWidth += 1;
                            if (customHeight % 2 != 0)
                                customHeight += 1;

                            videoWriter = new VideoFileWriter();
                            videoWriter.Open(currentFilePath, customWidth, customHeight, fps, VideoCodec.MPEG4);
                        }
                        else
                        {
                            Point customStartingPoint = new Point(0, 0);

                            // Calculate the new width and height based on the custom starting point
                            int customWidth = screenBounds.Width - customStartingPoint.X;
                            int customHeight = screenBounds.Height - customStartingPoint.Y;

                            videoWriter = new VideoFileWriter();
                            videoWriter.Open(currentFilePath, customWidth, customHeight, fps, VideoCodec.MPEG4);
                        }

                        timer1.Start();
                        MessageBox.Show("Recording has started.");

                    }
                    else
                    {
                        MessageBox.Show("Recording not started. No file selected.");
                    }
                }
            }
            else if (withAudio == true)
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "MP4 Video Files (*.mp4)|*.mp4";
                    saveFileDialog.Title = "Save Video File";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        audioFilePath = Path.ChangeExtension(currentFilePath, ".wav");

                        int width = screenBounds.Width;
                        int height = screenBounds.Height;

                        if (width % 2 != 0) width += 1;
                        if (height % 2 != 0) height += 1;

                        // Ініціалізація відеозапису
                        videoWriter = new VideoFileWriter();
                        videoWriter.Open(currentFilePath, width, height, fps, VideoCodec.MPEG4);

                        // Ініціалізація аудіозапису (Wave формат)
                        waveIn = new WaveInEvent();
                        waveIn.WaveFormat = new WaveFormat(44100, 1); // 44.1 kHz, моно
                        waveFileWriter = new WaveFileWriter(audioFilePath, waveIn.WaveFormat);
                        waveIn.DataAvailable += WaveIn_DataAvailable;
                        waveIn.StartRecording();

                        isRecording = true;
                        timer1.Start();

                        MessageBox.Show("Recording has started.");
                    }
                    else
                    {
                        MessageBox.Show("Recording not started. No file selected.");
                    }
                }
            }
        }
        private WaveFileWriter waveFileWriter;
        private bool isRecording = false;
        private string audioFilePath;
        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (isRecording)
            {
                waveFileWriter.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        private void StopRecording()
        {
            if (withAudio == false)
            {
                timer1.Stop();
                videoWriter.Close();
                videoWriter.Dispose();
                MessageBox.Show("Recording stopped and saved.");
            }
            else
            {
                if (isRecording)
                {
                    isRecording = false;
                    timer1.Stop();

                    // Завершуємо аудіозапис
                    waveIn.StopRecording();
                    waveIn.Dispose();
                    waveFileWriter.Close();
                    waveFileWriter.Dispose();

                    // Завершуємо відеозапис
                    videoWriter.Close();
                    videoWriter.Dispose();

                    // Об’єднуємо аудіо та відео
                    Task.Run(() => MergeAudioWithVideo(currentFilePath, audioFilePath));

                    MessageBox.Show("Recording stopped.");
                }
            }

        }
        private void MergeAudioWithVideo(string videoPath, string audioPath)
        {
            string outputPath = Path.ChangeExtension(videoPath, "_with_audio.mp4");

            string arguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -c:v copy -c:a aac -strict experimental \"{outputPath}\"";

            var process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "ffmpeg";
            process.StartInfo.Arguments = arguments;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();

            MessageBox.Show("Video with audio saved as: " + videoPath);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {

            //using (Bitmap bitmap = new Bitmap(screenBounds.Width, screenBounds.Height))
            //{
            //    using (Graphics g = Graphics.FromImage(bitmap))
            //    {
            //        //g.CopyFromScreen(screenBounds.Location, Point.Empty, screenBounds.Size);
            //        g.CopyFromScreen(customStartingPoint, Point.Empty, screenBounds.Size);
            //    }
            //    videoWriter.WriteVideoFrame(bitmap);
            //}

            if (data.Count > 0)
            {
                Point customStartingPoint = new Point(data[0], data[1]);
                //int customWidth = data[2] + customStartingPoint.X;
                //int customHeight = data[3] + customStartingPoint.Y;

                int customWidth = data[2];
                int customHeight = data[3];

                if (customWidth % 2 != 0)
                    customWidth += 1;
                if (customHeight % 2 != 0)
                    customHeight += 1;

                using (Bitmap bitmap = new Bitmap(customWidth, customHeight))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Capture the screen starting from the custom point
                        g.CopyFromScreen(customStartingPoint, Point.Empty, new Size(customWidth, customHeight));
                    }
                    videoWriter.WriteVideoFrame(bitmap);
                }
            }
            else
            {
                Point customStartingPoint = new Point(0, 0);
                int customWidth = screenBounds.Width - customStartingPoint.X;
                int customHeight = screenBounds.Height - customStartingPoint.Y;

                using (Bitmap bitmap = new Bitmap(customWidth, customHeight))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Capture the screen starting from the custom point
                        g.CopyFromScreen(customStartingPoint, Point.Empty, new Size(customWidth, customHeight));
                    }
                    videoWriter.WriteVideoFrame(bitmap);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Form3 frm3 = new Form3(checkbutton, check2, check3);
            //frm3.Show();
            //DialogResult result = frm3.ShowDialog();

            //// After the additional form is closed, retrieve the result
            //if (result == DialogResult.Cancel)
            //{

            //    checkbutton = frm3.check1Provide();
            //    check2 = frm3.check2Provide();
            //    check3 = frm3.check3Provide();

            //    if (check4)
            //        FiguresPanel.Visible = true;
            //    else
            //    {
            //        FiguresPanel.Visible = false;
            //        panel_first.Location = new Point(400, 61);
            //        panel_second.Location = new Point(1088, 61);
            //        panel_third.Location = new Point(1508, 61);
            //    }
            //}
            //if(!check2)
            //{
            //    PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
            //    StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
            //    RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
            //    CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
            //    TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            //}
        }

        private bool isDrawingRectangle = false;
        private bool isDrawingCircle = false;
        private bool isTyping = false;
        private Point startPoint;
        private Rectangle currentRectangle;
        private Rectangle currentCircle = Rectangle.Empty;

        private Point clickPosition;

        private bool isDrawingLine = false; // Indicates if the user is drawing a straight line
        private Point startPoint1;           // The starting point of the straight line
        private Point endPoint1;

        //private void button6_Click(object sender, EventArgs e)
        //{
        //    isDrawingRectangle = false;
        //    isDrawingCircle = false;
        //    isDrawingLine = false;
        //    isTyping = false;
        //    if (check2)
        //    {
        //        PenLineButton.BackColor = System.Drawing.Color.LightCyan;
        //        StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //    }
        //}

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    isDrawingLine = true;
        //    isDrawingCircle = false;
        //    isDrawingRectangle = false;
        //    isTyping = false;

        //    if (check2)
        //    {
        //        StraightLineButton.BackColor = System.Drawing.Color.LightCyan;
        //        PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //    }
        //}

        //private void button8_Click(object sender, EventArgs e)
        //{
        //    isDrawingRectangle = true;
        //    isDrawingCircle = false;
        //    isDrawingLine = false;
        //    isTyping = false;

        //    if (check2)
        //    {
        //        RectangleButton.BackColor = System.Drawing.Color.LightCyan;
        //        PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //    }
        //}

        //private void button9_Click(object sender, EventArgs e)
        //{
        //    isDrawingCircle = true;
        //    isDrawingRectangle = false; // Ensure that rectangle drawing is disabled
        //    isDrawingLine = false;
        //    isTyping = false;

        //    if (check2)
        //    {
        //        CircleButton.BackColor = System.Drawing.Color.LightCyan;
        //        PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //    }
        //}

        //private void button10_Click(object sender, EventArgs e)
        //{
        //    isTyping = true;
        //    isDrawingRectangle = false;
        //    isDrawingCircle = false;
        //    isDrawingLine = false;
        //    if (check2)
        //    {
        //        TextButton.BackColor = System.Drawing.Color.LightCyan;
        //        CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //        PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
        //    }
        //}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (currentRectangle != Rectangle.Empty)
            {
                // Draw the current rectangle on the PictureBox
                e.Graphics.DrawRectangle(drawingPen, currentRectangle);
            }
            if (currentCircle != Rectangle.Empty)
            {
                // Draw the current circle on the PictureBox
                e.Graphics.DrawEllipse(drawingPen, currentCircle);
            }
            if (isDrawingLine && !startPoint1.IsEmpty && !endPoint1.IsEmpty)
            {
                e.Graphics.DrawLine(drawingPen, startPoint1, endPoint1);
            }
        }
        private string typeFont = "Arial";
        private float typeSize = 14;

        //private void button11_Click(object sender, EventArgs e)
        //{
        //    using (FontDialog fontDialog = new FontDialog())
        //    {
        //        // Set the initial font to the current font of the label

        //        // Show the dialog and check if the user clicked OK
        //        if (fontDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            // Apply the selected font to the label
        //            typeFont = fontDialog.Font.FontFamily.Name.ToString();
        //            typeSize = fontDialog.Font.Size;
        //        }
        //    }
        //}
        public static string ShowDialog(string text, string caption)
        {
            // Create a new form for the dialog
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 10, Top = 10, Text = text, Width = 260 };
            System.Windows.Forms.TextBox inputBox = new System.Windows.Forms.TextBox() { Left = 10, Top = 40, Width = 260 };
            System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Ok", Left = 200, Width = 70, Top = 70 };

            // Set the DialogResult to OK when the button is clicked
            confirmation.Click += (sender, e) => { prompt.DialogResult = DialogResult.OK; };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.AcceptButton = confirmation;

            // Show the dialog and return the entered text only once
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return inputBox.Text;
            }

            // Dispose of the form properly to ensure it's cleaned up
            prompt.Dispose();

            return string.Empty;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isTyping)
            {
                string inputText = ShowDialog("Enter text:", "Input Text");

                if (!string.IsNullOrEmpty(inputText))
                {
                    // Draw the text on the image at the clicked position
                    using (Font font = new Font(typeFont, typeSize))
                    //using (SolidBrush brush = new SolidBrush(System.Drawing.Color.White))
                    using (SolidBrush brush = new SolidBrush(drawingPen.Color))
                    {
                        drawingGraphics.DrawString(inputText, font, brush, new PointF(e.X, e.Y - 5));
                        pictureBox1.Image = drawingImage;
                    }

                    // Refresh the PictureBox to show the updated image
                    //pictureBox1.Refresh();

                    //isTyping = false;
                }
            }
        }        
        
        Color clr = new Color();

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            drawingPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }

        private void CatchArea_KeyDown(object sender, KeyEventArgs e)
        {
            //bool hasValues = list.Values.Any(value => value != '\0');
            //if (!hasValues)
            if(check3)
            {
                if (e.Control == true && e.KeyCode == Keys.C)
                {
                    //copyToolStripMenuItem.PerformClick();
                    copyClipboard();
                }
                if (e.Control == true && e.KeyCode == Keys.S)
                {
                    saveAsToolStripMenuItem.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.Z)
                {
                    UndoButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.Q)
                {
                    PenLineButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.W)
                {
                    StraightLineButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.E)
                {
                    RectangleButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.R)
                {
                    CircleButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.T)
                {
                    TextButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.J)
                {
                    ScreenAreaButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.K)
                {
                    FullScreenButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.L)
                {
                    TabScreenButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.B)
                {
                    RecordVideoButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.N)
                {
                    StopRecordButton.PerformClick();
                }
                if (e.Control == true && e.KeyCode == Keys.M)
                {
                    AreaRecordButton.PerformClick();
                }
            }
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawingCircle = true;
            isDrawingRectangle = false; // Ensure that rectangle drawing is disabled
            isDrawingLine = false;

            if (check2)
            {
                CircleButton.BackColor = System.Drawing.Color.LightCyan;
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
        private void copyClipboard()
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
            else
                MessageBox.Show("Nothing to copy to a Clipboard!");
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
            else
                MessageBox.Show("Nothing to copy to a Clipboard!");
        }
        bool checkSaveLocal = false;
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (pictureBox1.Image != null)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                    saveFileDialog.FileName = "Untitled";

                    if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        return;

                    pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                    checkSaveLocal = true; // 
                    MessageBox.Show("Successfully saved to a computer!");
                }
                else
                    MessageBox.Show("Nothing to save to a computer!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3(check1, check2, check3,check4, checkbutton);
            //frm3.Show();
            DialogResult result = frm3.ShowDialog();

            // After the additional form is closed, retrieve the result
            if (result == DialogResult.Cancel)
            {
                check1 = frm3.check1Provide();
                check2 = frm3.check2Provide();
                check3 = frm3.check3Provide();
                check4 = frm3.check4Provide();
                checkbutton = frm3.check5Provide();
            }
            if (!check2)
            {
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
            if(check4)
            {
                label1.ForeColor = Color.White;
                label2.ForeColor = Color.White;
                label3.ForeColor = Color.White;
                panel2.BackColor = SystemColors.ControlDarkDark;
                pictureBox1.BackColor = SystemColors.ControlDark;

                this.BackColor = SystemColors.ControlDark;
                radioButton1.ForeColor = Color.White;
                radioButton2.ForeColor = Color.White;
                radioButton3.ForeColor = Color.White;


            }
            if (!check4)
            {
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label3.ForeColor = Color.Black;
                panel2.BackColor = Color.Gainsboro;
                this.BackColor = SystemColors.ControlLightLight;
                pictureBox1.BackColor = SystemColors.ControlLightLight;

                radioButton1.ForeColor = Color.Black;
                radioButton2.ForeColor = Color.Black;
                radioButton3.ForeColor = Color.Black;

            }
        }
        private void panel_first_Paint(object sender, PaintEventArgs e)
        {
            if (check4)
            {
                using (Pen pen = new Pen(Color.White, 3))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, panel_first.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, panel_first.Height - 3, panel_first.Width, panel_first.Height-3);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, panel_first.Height-3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, panel_first.Width-3, 0, panel_first.Width-3, panel_first.Height-3);

                }
            }
            else if(!check4)
            {
                //using (Pen pen = new Pen(Color.Black, 3))
                //{
                //    // Верхня лінія
                //    e.Graphics.DrawLine(pen, 0, 0, panel_first.Width - 1, 0);
                //    //// Нижня лінія
                //    e.Graphics.DrawLine(pen, 0, panel_first.Height - 3, panel_first.Width, panel_first.Height - 3);
                //    //// Ліва лінія
                //    e.Graphics.DrawLine(pen, 0, 0, 0, panel_first.Height - 3);
                //    //// Права лінія                           
                //    e.Graphics.DrawLine(pen, panel_first.Width - 3, 0, panel_first.Width - 3, panel_first.Height - 3);

                //}
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, panel_first.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, panel_first.Height - 2, panel_first.Width, panel_first.Height - 2);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, panel_first.Height - 3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, panel_first.Width - 2, 0, panel_first.Width - 2, panel_first.Height - 2);

                }
            }
        }
        private void panel_second_Paint(object sender, PaintEventArgs e)
        {
            if (check4)
            {
                using (Pen pen = new Pen(Color.White, 3))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, panel_second.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, panel_second.Height - 3, panel_second.Width, panel_second.Height - 3);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, panel_second.Height - 3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, panel_second.Width - 3, 0, panel_second.Width - 3, panel_second.Height - 3);

                }
            }
            else if (!check4)
            {
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, panel_second.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, panel_second.Height - 2, panel_second.Width, panel_second.Height - 2);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, panel_second.Height - 3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, panel_second.Width - 2, 0, panel_second.Width - 2, panel_second.Height - 2);

                }
            }
        }

        private void panel_third_Paint(object sender, PaintEventArgs e)
        {
            if (check4)
            {
                using (Pen pen = new Pen(Color.White, 3))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, panel_third.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, panel_third.Height - 3, panel_third.Width, panel_third.Height - 3);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, panel_third.Height - 3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, panel_third.Width - 3, 0, panel_third.Width - 3, panel_third.Height - 3);

                }
            }
            else if (!check4)
            {
                //using (Pen pen = new Pen(Color.Black, 3))
                //{
                //    // Верхня лінія
                //    e.Graphics.DrawLine(pen, 0, 0, panel_third.Width - 1, 0);
                //    //// Нижня лінія
                //    e.Graphics.DrawLine(pen, 0, panel_third.Height - 3, panel_third.Width, panel_third.Height - 3);
                //    //// Ліва лінія
                //    e.Graphics.DrawLine(pen, 0, 0, 0, panel_third.Height - 3);
                //    //// Права лінія                           
                //    e.Graphics.DrawLine(pen, panel_third.Width - 3, 0, panel_third.Width - 3, panel_third.Height - 3);

                //}
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, panel_third.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, panel_third.Height - 2, panel_third.Width, panel_third.Height - 2);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, panel_third.Height - 3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, panel_third.Width - 2, 0, panel_third.Width - 2, panel_third.Height - 2);

                }
            }
        }

        private void FiguresPanel_Paint(object sender, PaintEventArgs e)
        {
            if (check4)
            {
                using (Pen pen = new Pen(Color.White, 3))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, FiguresPanel.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, FiguresPanel.Height - 3, FiguresPanel.Width, FiguresPanel.Height - 3);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, FiguresPanel.Height - 3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, FiguresPanel.Width - 3, 0, FiguresPanel.Width - 3, FiguresPanel.Height - 3);

                }
            }
            else if (!check4)
            {
                //using (Pen pen = new Pen(Color.Black, 3))
                //{
                //    //Верхня лінія
                //    e.Graphics.DrawLine(pen, 0, 0, FiguresPanel.Width - 1, 0);
                //    //Нижня лінія
                //    e.Graphics.DrawLine(pen, 0, FiguresPanel.Height - 3, FiguresPanel.Width, FiguresPanel.Height - 3);
                //    //Ліва лінія
                //    e.Graphics.DrawLine(pen, 0, 0, 0, FiguresPanel.Height - 3);
                //    //Права лінія
                //    e.Graphics.DrawLine(pen, FiguresPanel.Width - 3, 0, FiguresPanel.Width - 3, FiguresPanel.Height - 3);

                //}
                using (Pen pen = new Pen(Color.Black, 2))
                {
                    // Верхня лінія
                    e.Graphics.DrawLine(pen, 0, 0, FiguresPanel.Width - 1, 0);
                    //// Нижня лінія
                    e.Graphics.DrawLine(pen, 0, FiguresPanel.Height - 2, FiguresPanel.Width, FiguresPanel.Height - 2);
                    //// Ліва лінія
                    e.Graphics.DrawLine(pen, 0, 0, 0, FiguresPanel.Height - 3);
                    //// Права лінія                           
                    e.Graphics.DrawLine(pen, FiguresPanel.Width - 2, 0, FiguresPanel.Width - 2, FiguresPanel.Height - 2);

                }
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            if (!checkSaveLocal && check1)
            {
                // Display a message box asking the user if they want to close the application
                DialogResult result = MessageBox.Show("Do you really want to leave?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Shut down the application if the user clicks "Yes"
                    Application.Exit();
                }

            }
            else
            {
                Application.Exit();
            }
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = false;
            isDrawingCircle = false;
            isDrawingLine = false;

            if (check2)
            {
                PenLineButton.BackColor = System.Drawing.Color.LightCyan;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void straightLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawingLine = true;
            isDrawingCircle = false;
            isDrawingRectangle = false;

            if (check2)
            {
                StraightLineButton.BackColor = System.Drawing.Color.LightCyan;
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = true;
            isDrawingCircle = false;
            isDrawingLine = false;

            if (check2)
            {
                RectangleButton.BackColor = System.Drawing.Color.LightCyan;
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void cleanCompletelyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                originalImage = new Bitmap(originalImage);
                pictureBox1.Image = originalImage;
                drawingImage = new Bitmap(originalImage); // Create a copy for drawing
                drawingGraphics = Graphics.FromImage(drawingImage);

                history.Clear();
                history.Push(pictureBox1.Image);
                if (checkbutton)
                    Clipboard.SetImage(pictureBox1.Image);
            }
        }

        private void removeLastDrawingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (history.Count > 1)
            {
                history.Pop();
                drawingImage = new Bitmap(history.Peek());
                drawingGraphics = Graphics.FromImage(drawingImage);

                pictureBox1.Image = drawingImage;
            }

            pictureBox1.Invalidate();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                drawingPen.Color = cd.Color;
                ColorChoosen.BackColor = drawingPen.Color;
                //highlighterBrush = new SolidBrush(System.Drawing.Color.FromArgb(64, cd.Color));
                clr = cd.Color;
                //drawingPen = new Pen(highlighterBrush, 2);
            }
        }
       
        //private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    fpsSettings = comboBox3.Text;
        //    string fpsNew = " ";

        //    foreach (char ch in fpsSettings)
        //        if (char.IsDigit(ch))
        //            fpsNew += ch;
        //    fps = Convert.ToInt32(fpsNew);
        //}

        private void ColorChoosen_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                drawingPen.Color = cd.Color;
                ColorChoosen.BackColor = drawingPen.Color;
                //highlighterBrush = new SolidBrush(System.Drawing.Color.FromArgb(64, cd.Color));
                clr = cd.Color;
                //drawingPen = new Pen(highlighterBrush, 2);
            }
        }

        private void RecordVideoButton_Click(object sender, EventArgs e)
        {
            StartRecording();
        }

        private void StopRecordButton_Click(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void AreaRecordButton_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            Thread.Sleep(1000);
            f.ShowDialog(); // form shows up as a modal dialog window
            this.Show();

            data = f.Data();
        }

        private void PenLineButton_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = false;
            isDrawingCircle = false;
            isDrawingLine = false;
            isTyping = false;
            if (check2)
            {
                PenLineButton.BackColor = System.Drawing.Color.LightCyan;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void StraightLineButton_Click(object sender, EventArgs e)
        {
            isDrawingLine = true;
            isDrawingCircle = false;
            isDrawingRectangle = false;
            isTyping = false;

            if (check2)
            {
                StraightLineButton.BackColor = System.Drawing.Color.LightCyan;
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = true;
            isDrawingCircle = false;
            isDrawingLine = false;
            isTyping = false;

            if (check2)
            {
                RectangleButton.BackColor = System.Drawing.Color.LightCyan;
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void CircleButton_Click(object sender, EventArgs e)
        {
            isDrawingCircle = true;
            isDrawingRectangle = false; // Ensure that rectangle drawing is disabled
            isDrawingLine = false;
            isTyping = false;

            if (check2)
            {
                CircleButton.BackColor = System.Drawing.Color.LightCyan;
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                TextButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
            isTyping = true;
            isDrawingRectangle = false;
            isDrawingCircle = false;
            isDrawingLine = false;
            if (check2)
            {
                TextButton.BackColor = System.Drawing.Color.LightCyan;
                CircleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                RectangleButton.BackColor = System.Drawing.Color.WhiteSmoke;
                StraightLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
                PenLineButton.BackColor = System.Drawing.Color.WhiteSmoke;
            }
        }

        private void TxtFntButton_Click(object sender, EventArgs e)
        {
            using (FontDialog fontDialog = new FontDialog())
            {
                // Set the initial font to the current font of the label

                // Show the dialog and check if the user clicked OK
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Apply the selected font to the label
                    typeFont = fontDialog.Font.FontFamily.Name.ToString();
                    typeSize = fontDialog.Font.Size;
                }
            }
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            //Image img = new Bitmap(history.Pop());
            if (history.Count > 1)
            {
                history.Pop();
                drawingImage = new Bitmap(history.Peek());
                drawingGraphics = Graphics.FromImage(drawingImage);

                pictureBox1.Image = drawingImage;
                
                if(checkbutton)
                    Clipboard.SetImage(pictureBox1.Image);
            }

            pictureBox1.Invalidate();
        }

        private void TabScreenButton_Click(object sender, EventArgs e)
        {
            if (comboBoxWindows.SelectedItem is WindowItem selectedWindow)
            {
                // Capture the window and save it with the chosen name, location, and extension
                this.Hide();
                Thread.Sleep(seconds * 1000);
                CaptureWindow(selectedWindow.Handle);
                this.Show();
                checkSaveLocal = false;
            }
            else
            {
                MessageBox.Show("Please select a window first.");
            }
        }

        private void FullScreenButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(seconds * 1000);

            screenshot = CaptureScreen();

            originalImage = screenshot;

            pictureBox1.Image = originalImage;
            history.Clear();
            history.Push(new Bitmap(pictureBox1.Image));
            drawingImage = new Bitmap(originalImage);
            drawingGraphics = Graphics.FromImage(drawingImage);
            previousPoint = Point.Empty;

            pictureBox1.Width = originalImage.Width;
            pictureBox1.Height = originalImage.Height;
            checkSaveLocal = false;
            this.Show();
        }

        private void ScreenAreaButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(seconds * 1000);
            frmCapture.ShowDialog(); // form shows up as a modal dialog window
            this.Show();
            if (Clipboard.ContainsImage())
            {
                originalImage = new Bitmap(Clipboard.GetImage());

                pictureBox1.Image = originalImage;

                history.Clear();
                history.Push(new Bitmap(pictureBox1.Image));

                pictureBox1.Width = originalImage.Width;
                pictureBox1.Height = originalImage.Height;
                drawingImage = new Bitmap(originalImage);
                drawingGraphics = Graphics.FromImage(drawingImage);
                previousPoint = Point.Empty;
                checkSaveLocal = false;
            }

            //history.Push(new Bitmap(pictureBox1.Image));

        }

        private void comboBoxTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer = comboBoxTimer.Text;
            string timerNew = " ";

            foreach (char ch in timer)
                if (char.IsDigit(ch))
                    timerNew += ch;
            seconds = Convert.ToInt32(timerNew);
        }

        private void comboBoxFPS_SelectedIndexChanged(object sender, EventArgs e)
        {
            fpsSettings = comboBoxFPS.Text;
            string fpsNew = " ";

            foreach (char ch in fpsSettings)
                if (char.IsDigit(ch))
                    fpsNew += ch;
            fps = Convert.ToInt32(fpsNew);
        }
        bool withAudio = false;
        private void comboBoxAudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAudio.Text == "with Audio")
                withAudio = true;
            else if (comboBoxAudio.Text == "without Audio")
                withAudio = false;
        }
    }
    public class WindowItem
    {
        public IntPtr Handle { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
