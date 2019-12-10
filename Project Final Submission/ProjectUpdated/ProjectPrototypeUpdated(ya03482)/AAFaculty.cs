using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjectPrototypeUpdated_ya03482_
{
    public partial class AAFaculty : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-7EL8EJFA;Initial Catalog=UniversityManagementSystem;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public string ID = "";
        public AAFaculty(string s)
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            textBox22.Enabled = false;
            textBox18.Enabled = false;
            textBox17.Enabled = false;

            ID = s;
            try

            {
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person,Faculty WHERE UserID = FacultyID and UserID = '" + s + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                
                textBox26.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox25.Text = dt.Rows[0].ItemArray[1].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[2].ToString();
                textBox4.Text = dt.Rows[0].ItemArray[3].ToString();
                textBox5.Text = dt.Rows[0].ItemArray[4].ToString();
                textBox6.Text = dt.Rows[0].ItemArray[5].ToString();
                textBox7.Text = dt.Rows[0].ItemArray[7].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[8].ToString();
                textBox1.Text = dt.Rows[0].ItemArray[9].ToString();
                textBox37.Text = dt.Rows[0].ItemArray[11].ToString();
                textBox29.Text = dt.Rows[0].ItemArray[13].ToString();
                textBox28.Text = dt.Rows[0].ItemArray[14].ToString();
                textBox27.Text = dt.Rows[0].ItemArray[15].ToString();

                sda = new SqlDataAdapter("select Name from Event;", con);

                dt = new DataTable();
                //textBox1.Text = s;
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox4.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
                sda = new SqlDataAdapter("select Course.CourseID, [Name], Prerequisite from FacultyTeachesCourse,Course where Course.CourseID = FacultyTeachesCourse.CourseID and FacultyID = '" + ID + "';", con);

                DataSet ds = new DataSet();
                sda.Fill(ds, "Current Courses");
                sda.Fill(dt);
                dataGridView1.DataSource = ds.Tables["Current Courses"].DefaultView;
                sda = new SqlDataAdapter("select [Name], DepartmentID, Role from FacultyParticipatesInEvent,Event where Event.EventID = FacultyParticipatesInEvent.EventID and FacultyID = '" + ID +"';", con);

                ds = new DataSet();
                sda.Fill(ds, "Current Events");
                sda.Fill(dt);
                dataGridView2.DataSource = ds.Tables["Current Events"].DefaultView;

                sda = new SqlDataAdapter("select CourseID from FacultyTeachesCourse where FacultyID = '" + ID + "';", con);

                dt = new DataTable();
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox2.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    comboBox7.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
            }




            catch

            {

                MessageBox.Show("Faculty form connection failed");

            }
            finally
            {
                con.Close();
            }


        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT EventID, StartDate ,EndDate from Event where Name = '" + comboBox4.SelectedItem.ToString() + "';", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            textBox22.Text = dt4.Rows[0].ItemArray[0].ToString();
            textBox18.Text = dt4.Rows[0].ItemArray[1].ToString();
            textBox17.Text = dt4.Rows[0].ItemArray[2].ToString();
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                MessageBox.Show("Please Enter Your Preferred Role.");
                return;
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql1 = null;
            sql1 = "insert into FacultyParticipatesInEvent(EventID, DepartmentID, FacultyID,Role) values('" + textBox22.Text + "' , (Select DepartmentID from Faculty where FacultyID = '" + ID + "'), '" + ID + "', '" + textBox16.Text + "');";
            try
            {
                con.Open();
                adapter.InsertCommand = new SqlCommand(sql1, con);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Registered for Event Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select StudentID from StudentStudiesCourse where CourseID = '" + comboBox2.SelectedItem.ToString() + "';", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox5.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            con.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox21.Text == "")
            {
                MessageBox.Show("Please Enter Updated Attendance.");
                return;
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql1 = null;
            sql1 = "update StudentStudiesCourse set AttendancePercentage = '" + textBox21.Text + "' where StudentID = '" + comboBox5.SelectedItem.ToString() + "';";
            try
            {
                con.Open();
                adapter.InsertCommand = new SqlCommand(sql1, con);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Attendance Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select StudentID from StudentStudiesCourse where CourseID = '" + comboBox7.SelectedItem.ToString() + "';", con);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox6.Items.Add(dt.Rows[i].ItemArray[0].ToString());
            }
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox23.Text == "")
            {
                MessageBox.Show("Please Enter Updated Grade.");
                return;
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql1 = null;
            sql1 = "update StudentStudiesCourse set  CurrentGrade = '" + textBox23.Text + "' where StudentID = '" + comboBox6.SelectedItem.ToString() + "';";
            try
            {
                con.Open();
                adapter.InsertCommand = new SqlCommand(sql1, con);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Grade Updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();
        }
    }
}
