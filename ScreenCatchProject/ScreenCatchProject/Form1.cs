using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ScreenCatchProject
{
    public partial class Form1 : Form
    {
        private Bitmap screenshot;

        private Bitmap originalImage;

        private Bitmap drawingImage;
        private Graphics drawingGraphics;
        private Point previousPoint;

        private static Brush highlighterBrush = new SolidBrush(System.Drawing.Color.FromArgb(64, System.Drawing.Color.Yellow));
        //private Pen drawingPen = new Pen(System.Drawing.Color.Black, 2);
        private Pen drawingPen = new Pen(highlighterBrush, 2);


        private string timer;
        private int seconds = 1;
        private string regime = "FullScreen Picture";

        private string drawingShape = ""; // Track the shape to draw ("Rectangle" or "Circle")
        private Point shapeStartPoint = Point.Empty;

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

        public Form1()
        {
            InitializeComponent();
            drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.AutoScroll = true;
            this.HorizontalScroll.Visible = false;
            this.HorizontalScroll.Value = 0;
            ColorChoosen.BackColor = drawingPen.Color;
            pictureBox1.Paint += pictureBox1_Paint;

            // Subscribe to the PictureBox's MouseClick event
            //pictureBox1.MouseClick += pictureBox1_MouseClick;
        }

        private Bitmap CaptureScreen()
        {
            // Create a bitmap of the screen
            Rectangle bounds = Screen.PrimaryScreen.Bounds;

            if(regime == "ActiveWindow Picture")
                bounds.Height = bounds.Height - 40;

            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
            }
            return bitmap;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left && previousPoint != Point.Empty && drawingGraphics != null)
            //{
            //   drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
            //   pictureBox1.Image = drawingImage;
            //   previousPoint = e.Location;
            //}

            //if (e.Button == MouseButtons.Left && previousPoint != Point.Empty && drawingGraphics != null)
            //{
            //    if (isDrawingRectangle || isDrawingCircle)
            //    {
            //        return; // Prevent drawing lines while preparing to draw rectangle or circle
            //    }

            //    drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
            //    pictureBox1.Image = drawingImage;
            //    previousPoint = e.Location;
            //}

            //if (e.Button == MouseButtons.Left && previousPoint != Point.Empty && drawingGraphics != null)
            //{
            //    if (isDrawingRectangle)
            //    {
            //        UpdateRectangle(e.Location);
            //    }

            //    else
            //    {
            //        drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
            //        pictureBox1.Image = drawingImage;
            //        previousPoint = e.Location;
            //    }
            //}

            //if (e.Button == MouseButtons.Left && previousPoint != Point.Empty && drawingGraphics != null)
            //{
            //    if (isDrawingRectangle)
            //    {
            //        UpdateRectangle(e.Location);
            //    }

            //    else
            //    {
            //        drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
            //        pictureBox1.Image = drawingImage;
            //        previousPoint = e.Location;
            //    }
            //}

            //if (e.Button == MouseButtons.Left && drawingGraphics != null)
            //{
            //    if (currentRectangle != null)
            //    {
            //        // Calculate the new width and height based on the current mouse position
            //        int width = e.X - previousPoint.X;
            //        int height = e.Y - previousPoint.Y;
            //        // Update the size of the rectangle
            //        currentRectangle.Size = new Size(previousPoint.X + width, previousPoint.Y + height);

            //        // Repaint the picture box to show the current rectangle
            //        pictureBox1.Invalidate();
            //    }
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
                else
                {
                    drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
                    pictureBox1.Image = drawingImage;
                    previousPoint = e.Location;
                }
            }

            
            //if (e.Button == MouseButtons.Left && previousPoint != Point.Empty && drawingGraphics != null)
            //{
            //   drawingGraphics.DrawLine(drawingPen, previousPoint, e.Location);
            //   pictureBox1.Image = drawingImage;
            //   previousPoint = e.Location;
            //}
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    previousPoint = Point.Empty;
            //}

            //if (e.Button == MouseButtons.Left)
            //{
            //    if (isDrawingRectangle && startPoint != Point.Empty)
            //    {
            //        Draw_Rectangle(startPoint, e.Location);
            //        isDrawingRectangle = false;
            //    }
            //    //else if (isDrawingCircle && startPoint != Point.Empty)
            //    //{
            //    //    DrawCircle(startPoint, e.Location);
            //    //    isDrawingCircle = false;
            //    //}
            //    else
            //    {
            //        previousPoint = Point.Empty;
            //    }
            //}

            //if (e.Button == MouseButtons.Left)
            //{
            //    if (isDrawingRectangle)
            //    {
            //        Draw_Rectangle(startPoint, e.Location);
            //        isDrawingRectangle = false;
            //    }

            //    else
            //    {
            //        previousPoint = Point.Empty;
            //    }
            //}

            //if (e.Button == MouseButtons.Left)
            //{
            //    if (drawingGraphics != null && currentRectangle != null)
            //    {
            //        // Draw the final rectangle on the drawing surface
            //        drawingGraphics.DrawRectangle(drawingPen, currentRectangle);
            //        pictureBox1.Image = drawingImage;

            //        // Reset the rectangle
            //        currentRectangle = Rectangle.Empty;
            //    }
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
                previousPoint = Point.Empty;
            }


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    previousPoint = e.Location;
            //}

            //if (e.Button == MouseButtons.Left)
            //{
            //    if (isDrawingRectangle || isDrawingCircle)
            //    {
            //        startPoint = e.Location;
            //    }
            //    else
            //    {
            //        previousPoint = e.Location;
            //    }
            //}

            //if (e.Button == MouseButtons.Left)
            //{
            //    if (isDrawingRectangle || isDrawingCircle)
            //    {
            //        startPoint = e.Location;
            //        currentRectangle = Rectangle.Empty;
            //        currentCircle = Rectangle.Empty;
            //    }
            //    else
            //    {
            //        previousPoint = e.Location;
            //    }
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
            else
            {
                previousPoint = e.Location;
            }
        }
        private void SavePicture_Click(object sender, EventArgs e)
        {   
            try
            {   if (pictureBox1.Image != null)
                { 
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JPEG Image|*.jpg|PNG Image|*.png";
                    saveFileDialog.FileName = "Untitled";

                    if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                        return;

                    pictureBox1.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
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

        frmCapture frmCapture = new frmCapture();

        private void CatchAreaPicture_Click(object sender, EventArgs e)
        {
            //CatchArea ca = new CatchArea();
            //ca.Show();
            //this.Hide();

            this.Hide();
            Thread.Sleep(seconds * 1000);
            frmCapture.ShowDialog(); // form shows up as a modal dialog window
            this.Show();
            originalImage = new Bitmap(Clipboard.GetImage());

            pictureBox1.Image = originalImage;
            pictureBox1.Width = originalImage.Width;
            pictureBox1.Height = originalImage.Height;
            drawingImage = new Bitmap(originalImage);
            drawingGraphics = Graphics.FromImage(drawingImage);
            previousPoint = Point.Empty;

        }

        private void CleanCanvas_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                originalImage = new Bitmap(originalImage);
                pictureBox1.Image = originalImage;
                drawingImage = new Bitmap(originalImage); // Create a copy for drawing
                drawingGraphics = Graphics.FromImage(drawingImage);
            }
        }

        private void CopyClipboard_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Clipboard.SetImage(pictureBox1.Image);
                MessageBox.Show("Successfully copied to a Clipboard!");
            }
            else
                MessageBox.Show("Nothing to copy to a Clipboard!");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            drawingPen.Width = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null)
                pictureBox1.Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer = comboBox1.Text;
            string timerNew = " ";

            foreach (char ch in timer)
                if (char.IsDigit(ch))
                    timerNew += ch;
            seconds = Convert.ToInt32(timerNew);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            drawingPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            drawingPen.StartCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            drawingPen.EndCap = System.Drawing.Drawing2D.LineCap.DiamondAnchor;
            drawingPen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            regime = comboBox2.Text;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            this.Hide();
            Thread.Sleep(seconds * 1000);

            screenshot = CaptureScreen();

            originalImage = screenshot;

            pictureBox1.Image = originalImage;
            drawingImage = new Bitmap(originalImage);
            drawingGraphics = Graphics.FromImage(drawingImage);
            previousPoint = Point.Empty;

            pictureBox1.Width = originalImage.Width;
            pictureBox1.Height = originalImage.Height;

            this.Show();

        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                drawingPen.Color = cd.Color;
                ColorChoosen.BackColor = drawingPen.Color;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DrawRectangle_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = true;
            isDrawingCircle = false;
            isDrawingLine = false;
            DrawRectangle.BackColor = System.Drawing.Color.Black;
            DrawLine.BackColor = System.Drawing.Color.WhiteSmoke;
            Circle.BackColor = System.Drawing.Color.WhiteSmoke;
            drLine.BackColor = System.Drawing.Color.WhiteSmoke;
            caption.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void DrawLine_Click(object sender, EventArgs e)
        {
            isDrawingRectangle = false;
            isDrawingCircle = false;
            isDrawingLine = false;
            DrawLine.BackColor = System.Drawing.Color.Black;
            Circle.BackColor = System.Drawing.Color.WhiteSmoke;
            drLine.BackColor = System.Drawing.Color.WhiteSmoke;
            DrawRectangle.BackColor = System.Drawing.Color.WhiteSmoke;
            caption.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //if (currentRectangle != null && !currentRectangle.Size.IsEmpty)
            //{
            //    // Draw the current rectangle on the PictureBox
            //    e.Graphics.DrawRectangle(drawingPen, currentRectangle);
            //}
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

        private void Circle_Click(object sender, EventArgs e)
        {
            isDrawingCircle = true;
            isDrawingRectangle = false; // Ensure that rectangle drawing is disabled
            isDrawingLine = false;
            Circle.BackColor = System.Drawing.Color.Black;
            drLine.BackColor = System.Drawing.Color.WhiteSmoke;
            DrawLine.BackColor = System.Drawing.Color.WhiteSmoke;
            DrawRectangle.BackColor = System.Drawing.Color.WhiteSmoke;
            caption.BackColor = System.Drawing.Color.WhiteSmoke;
        }


        private void caption_Click(object sender, EventArgs e)
        {
            isTyping = true;
            caption.BackColor = System.Drawing.Color.Black;
            drLine.BackColor = System.Drawing.Color.WhiteSmoke;
            DrawLine.BackColor = System.Drawing.Color.WhiteSmoke;
            Circle.BackColor = System.Drawing.Color.WhiteSmoke;
            DrawRectangle.BackColor = System.Drawing.Color.WhiteSmoke;
        }
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

        private string typeFont = "Arial";
        private float typeSize = 14;
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
                    isTyping = false;
                }
            }
        }

        private void Font_Click(object sender, EventArgs e)
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

        private void drLine_Click(object sender, EventArgs e)
        {
            isDrawingLine = true;
            isDrawingCircle = false;
            isDrawingRectangle = false;
            drLine.BackColor = System.Drawing.Color.Black;
            DrawLine.BackColor = System.Drawing.Color.WhiteSmoke;
            Circle.BackColor = System.Drawing.Color.WhiteSmoke;
            DrawRectangle.BackColor = System.Drawing.Color.WhiteSmoke;
            caption.BackColor = System.Drawing.Color.WhiteSmoke;

        }

    }
}
