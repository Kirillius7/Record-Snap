using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCatchProject
{
    public partial class HotKeys_List : Form
    {
        public HotKeys_List()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Hotkey", "Hotkey");
            dataGridView1.Columns.Add("Description", "Description");

            // Додаємо гарячі клавіші
            dataGridView1.Rows.Add("Ctrl + C", "Copy");
            dataGridView1.Rows.Add("Ctrl + S", "Save as");
            dataGridView1.Rows.Add("Ctrl + Z", "Undo");
            dataGridView1.Rows.Add("Ctrl + Q", "Drawing Line");
            dataGridView1.Rows.Add("Ctrl + W", "Straight Line");
            dataGridView1.Rows.Add("Ctrl + E", "Rectangle");
            dataGridView1.Rows.Add("Ctrl + R", "Circle");
            dataGridView1.Rows.Add("Ctrl + T", "Text");
            dataGridView1.Rows.Add("Ctrl + J", "Screen Area");
            dataGridView1.Rows.Add("Ctrl + K", "Full Screen");
            dataGridView1.Rows.Add("Ctrl + L", "Tab Screen");
            dataGridView1.Rows.Add("Ctrl + B", "Start Recording");
            dataGridView1.Rows.Add("Ctrl + N", "Stop Recording");
            dataGridView1.Rows.Add("Ctrl + M", "Area Recording");
            // Налаштування вигляду
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
