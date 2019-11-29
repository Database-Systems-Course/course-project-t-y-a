using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabasePrototypeFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Course has been added");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student has been added");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Participation in the event has been confirmed");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Event has been added");
        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox5_Enter(object sender, EventArgs e)
        {

        }
    }
}
