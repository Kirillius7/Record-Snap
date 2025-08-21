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
    public partial class Form3 : Form
    {
        public Form3(bool chckbttn1, bool chckbttn2, bool chckbttn3, bool chckbttn4, bool chckbttn5)
        {
            InitializeComponent();
            checkBox4.Text = "Enable DarkMode";
            checkBox4.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            if (chckbttn1)
                checkBox1.Checked = true;
            else if(!chckbttn1)
                checkBox1.Checked = false;

            if (chckbttn2)
                checkBox2.Checked = true;
            else if (!chckbttn2)
                checkBox2.Checked = false;

            if (chckbttn3)
                checkBox3.Checked = true;
            else if (!chckbttn3)
                checkBox3.Checked = false;

            if (chckbttn4)
                checkBox4.Checked = true;
            else if (!chckbttn4)
                checkBox4.Checked = false;

            if (chckbttn5)
                checkBox5.Checked = true;
            else if (!chckbttn5)
                checkBox5.Checked = false;

            this.BackColor = Color.Gainsboro;
            checkBox1.ForeColor = Color.Black;
            checkBox2.ForeColor = Color.Black;
            checkBox3.ForeColor = Color.Black;
            checkBox4.ForeColor = Color.Black;
            checkBox5.ForeColor = Color.Black;

            checkBox1.BackColor = Color.Gainsboro;
            checkBox2.BackColor = Color.Gainsboro;
            checkBox3.BackColor = Color.Gainsboro;
            checkBox4.BackColor = Color.Gainsboro;
            checkBox5.BackColor = Color.Gainsboro;
        }
        bool check1 = true;
        public bool check1Provide() => check1;

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if(checkBox1.CheckState == CheckState.Checked)
                check1 = true;
            else
                check1 = false;

        }
        bool check2 = true;

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //check2 = false;
            if (checkBox2.CheckState == CheckState.Checked)
                check2 = true;
            else
                check2 = false;
        }
        bool check3 = true;
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.CheckState == CheckState.Checked)
                check3 = true;
            else
                check3 = false;
        }
        public bool check2Provide() => check2;
        public bool check3Provide() => check3;

        private void ShrtCutKey_Click(object sender, EventArgs e)
        {
            HotKeys_List hotKeys_List = new HotKeys_List();
            hotKeys_List.Show();
        }
        bool check4 = false;
        public bool check4Provide() => check4;
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.CheckState == CheckState.Checked)
            {
                check4 = true;
                checkBox4.Text = "Enable LightMode";
                this.BackColor = SystemColors.ControlDark;

                checkBox1.ForeColor = Color.White;
                checkBox2.ForeColor = Color.White;
                checkBox3.ForeColor = Color.White;
                checkBox4.ForeColor = Color.White;
                checkBox5.ForeColor = Color.White;

                checkBox1.BackColor = SystemColors.ControlDark;
                checkBox2.BackColor = SystemColors.ControlDark;
                checkBox3.BackColor = SystemColors.ControlDark;
                checkBox4.BackColor = SystemColors.ControlDark;
                checkBox5.BackColor = SystemColors.ControlDark;
            }
            else
            {
                check4 = false;
                checkBox4.Text = "Enable DarkMode";
                this.BackColor = Color.Gainsboro;
                checkBox1.ForeColor = Color.Black;
                checkBox2.ForeColor = Color.Black;
                checkBox3.ForeColor = Color.Black;
                checkBox4.ForeColor = Color.Black;
                checkBox5.ForeColor = Color.Black;

                checkBox1.BackColor = Color.Gainsboro;
                checkBox2.BackColor = Color.Gainsboro;
                checkBox3.BackColor = Color.Gainsboro;
                checkBox4.BackColor = Color.Gainsboro;
                checkBox5.BackColor = Color.Gainsboro;
            }
        }
        bool check5 = true;
        public bool check5Provide() => check5;
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.CheckState == CheckState.Checked)
                check5 = true;
            else
                check5 = false;
        }
    }
}
