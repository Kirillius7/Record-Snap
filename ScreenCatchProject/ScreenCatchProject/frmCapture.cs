using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;


namespace ScreenCatchProject
{
    public partial class frmCapture : Form
    {
        int startX;
        int startY;
        int currentX;
        int currentY;

        Bitmap printScreen;
        //
        private Bitmap darkScreen;
        //
        //this.KeyPreview = true; // Дозволяє формі обробляти натискання клавіш
        //this.KeyDown += frmCapture_KeyDown; // Додаємо обробку клавіш
        bool start = false;
        public frmCapture()
        {
            InitializeComponent();
            this.Location = new Point(0, 0);
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;

            //
            this.TopMost = true;
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
            this.Opacity = 0.6; // Затемнення екрану
            //


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //if (start)
            //{
            //    int width = Math.Abs(currentX - startX);
            //    int height = Math.Abs(currentY - startY);
            //    int x = Math.Min(startX, currentX);
            //    int y = Math.Min(startY, currentY);

            //    Rectangle selection = new Rectangle(x, y, width, height);

            //    using (Pen dashedPen = new Pen(Color.Red, 5))
            //    {
            //        dashedPen.DashStyle = DashStyle.DashDotDot;
            //        e.Graphics.DrawRectangle(dashedPen, selection);
            //    }
            //}

            if (start)
            {
                int width = Math.Abs(currentX - startX);
                int height = Math.Abs(currentY - startY);
                int x = Math.Min(startX, currentX);
                int y = Math.Min(startY, currentY);

                using (SolidBrush semiTransparentBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                {
                    e.Graphics.FillRectangle(semiTransparentBrush, this.ClientRectangle);
                }

                Rectangle selection = new Rectangle(x, y, width, height);

                e.Graphics.DrawImage(printScreen, selection, selection, GraphicsUnit.Pixel);
                using (Pen dashedPen = new Pen(Color.Red, 4))
                {
                    dashedPen.DashStyle = DashStyle.Solid;
                    e.Graphics.DrawRectangle(dashedPen, selection);
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startX = e.X;
                startY = e.Y;
                currentX = e.X;
                currentY = e.Y;
                start = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    start = false;
            //    int width = Math.Abs(currentX - startX);
            //    int height = Math.Abs(currentY - startY);
            //    int x = Math.Min(startX, currentX);
            //    int y = Math.Min(startY, currentY);

            //    if (width > 0 && height > 0)
            //    {
            //        Rectangle selection = new Rectangle(x, y, width, height);
            //        Bitmap selectedArea = new Bitmap(selection.Width, selection.Height);

            //        using (Graphics g = Graphics.FromImage(selectedArea))
            //        {
            //            g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, selectedArea.Width, selectedArea.Height), selection, GraphicsUnit.Pixel);
            //        }

            //        Clipboard.SetImage(selectedArea);
            //    }

            //    this.Close();
            //}


            if (e.Button == MouseButtons.Left)
            {
                start = false;
                int width = Math.Abs(currentX - startX);
                int height = Math.Abs(currentY - startY);
                int x = Math.Min(startX, currentX);
                int y = Math.Min(startY, currentY);

                if (width > 0 && height > 0)
                {
                    Rectangle selection = new Rectangle(x, y, width, height);
                    Bitmap selectedArea = new Bitmap(selection.Width, selection.Height);

                    using (Graphics g = Graphics.FromImage(selectedArea))
                    {
                        g.DrawImage(printScreen, new Rectangle(0, 0, selectedArea.Width, selectedArea.Height), selection, GraphicsUnit.Pixel);
                    }

                    Clipboard.SetImage(selectedArea);
                }

                this.Close();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (start)
            {
                currentX = e.X;
                currentY = e.Y;
                pictureBox1.Invalidate(); // Redraw the picture box
            }
        }

        private void frmCapture_Load(object sender, EventArgs e)
        {
            //this.Hide();
            //printScreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            //Graphics graphics = Graphics.FromImage(printScreen as Image);

            //graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);

            //using (MemoryStream s = new MemoryStream())
            //{
            //    printScreen.Save(s, ImageFormat.Bmp);
            //    pictureBox1.Size = new System.Drawing.Size(this.Width, this.Height);
            //    pictureBox1.Image = Image.FromStream(s);
            //}

            //this.Show();
            //Cursor = Cursors.Cross;

            this.Hide();

            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            printScreen = new Bitmap(screenWidth, screenHeight);
            darkScreen = new Bitmap(screenWidth, screenHeight);

            using (Graphics graphics = Graphics.FromImage(printScreen))
            {
                graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);
            }

            // Створюємо затемнену копію екрану
            using (Graphics g = Graphics.FromImage(darkScreen))
            {
                g.DrawImage(printScreen, 0, 0);
                using (SolidBrush semiTransparentBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                {
                    g.FillRectangle(semiTransparentBrush, 0, 0, screenWidth, screenHeight);
                }
            }

            this.Show();
        }

        private void frmCapture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Закриваємо форму, якщо натиснуто Esc
            }
        }
    }
}
