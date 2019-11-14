using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_Project
{
    public partial class Faculty : Form
    {
        public Faculty()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BasicInfo f2 = new BasicInfo();
            f2.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Current_Courses f4 = new Current_Courses();
            f4.Show();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            CoursesTaught f3 = new CoursesTaught();
            f3.Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Events f5 = new Events();
            f5.Show();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Events_Registration f6 = new Events_Registration();
            f6.Show();
        }
    }
}
