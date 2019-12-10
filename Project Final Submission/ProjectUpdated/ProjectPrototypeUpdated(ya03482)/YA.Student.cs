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
    public partial class Form1 : Form
    {
        public string ID = "";
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-7EL8EJFA;Initial Catalog=UniversityManagementSystem;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public Form1(string s)
        {
            
            InitializeComponent();
            groupBox1.Enabled = false;

            textBox22.Enabled = false;
            textBox25.Enabled = false;
            textBox26.Enabled = false;
            textBox34.Enabled = false;
            textBox35.Enabled = false;
            textBox36.Enabled = false;
            
            textBox27.Enabled = false;
            textBox28.Enabled = false;
            textBox10.Enabled = false;
            textBox30.Enabled = false;
            textBox31.Enabled = false;
            textBox32.Enabled = false;
            textBox33.Enabled = false;
            textBox42.Enabled = false;


            ID = s;
            
            try

            {
                con.Open();

                SqlDataAdapter sda4 = new SqlDataAdapter("SELECT Course.CourseID,SectionNo from Course join Class on Course.CourseID = Class.CourseID;", con);
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    comboBox5.Items.Add(dt4.Rows[i].ItemArray[0].ToString());
                }
                con.Close();

                con.Open();
                
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person,Student WHERE UserID = StudentID and UserID = '" + s + "'", con);
                
                DataTable dt = new DataTable();
                //textBox1.Text = s;
                sda.Fill(dt);
                
                textBox1.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[1].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[2].ToString();
                textBox4.Text = dt.Rows[0].ItemArray[3].ToString();
                textBox5.Text = dt.Rows[0].ItemArray[4].ToString();
                textBox6.Text = dt.Rows[0].ItemArray[5].ToString();
                textBox7.Text = dt.Rows[0].ItemArray[7].ToString();
                textBox8.Text = dt.Rows[0].ItemArray[8].ToString();
                textBox9.Text = dt.Rows[0].ItemArray[10].ToString();
                textBox40.Text = dt.Rows[0].ItemArray[11].ToString();
                textBox39.Text = dt.Rows[0].ItemArray[12].ToString();
                textBox38.Text = dt.Rows[0].ItemArray[13].ToString();


                sda = new SqlDataAdapter("select * from Fees,Student where Student.StudentID = '" + s + "' and Fees.StudentID = '" + s + "';", con);

                dt = new DataTable();
                //textBox1.Text = s;
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox6.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }

                sda = new SqlDataAdapter("Select Name from Person where UserID = (select FacultyID from StudentHasFaculty where StudentID = '" + s + "');",con);

                dt = new DataTable();
                //textBox1.Text = s;
                sda.Fill(dt);
                
                textBox41.Text = dt.Rows[0].ItemArray[0].ToString();
                sda = new SqlDataAdapter("select Name from Event;", con);

                dt = new DataTable();
                //textBox1.Text = s;
                sda.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBox2.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                }
              
                sda = new SqlDataAdapter("select Name, DepartmentID, Role from Event,StudentParticipatesInEvent where StudentParticipatesInEvent.EventID = Event.EventID;", con);

                DataSet ds = new DataSet();
                sda.Fill(ds, "Event History");
                sda.Fill(dt);
                dataGridView1.DataSource = ds.Tables["Event History"].DefaultView;

                sda = new SqlDataAdapter("SELECT [Name], DepartmentID, AttendancePercentage, CurrentGrade from Course,StudentStudiesCourse where Course.CourseID = StudentStudiesCourse.CourseID and StudentID = '" + ID + "';", con);

                ds = new DataSet();
                sda.Fill(ds, "Current Courses");
                sda.Fill(dt);
                dataGridView2.DataSource = ds.Tables["Current Courses"].DefaultView;



            }

            catch (Exception ex)

            {

                MessageBox.Show(ex.ToString());

            }
            finally
            {
                con.Close();
            }


        


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select Amount,Convert(date,DueDate),FeesPaid from Fees where StudentID = '" + ID + "' and ChallanID = '" + comboBox6.SelectedItem.ToString() + "';", con);

            DataTable dt = new DataTable();
            //textBox1.Text = s;
            sda.Fill(dt);
            textBox34.Text = dt.Rows[0].ItemArray[0].ToString();
            textBox35.Text = dt.Rows[0].ItemArray[1].ToString();
            textBox36.Text = dt.Rows[0].ItemArray[2].ToString();
        }

        private void textBox34_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT SectionNo from Class where CourseID = '"+comboBox5.SelectedItem.ToString()+"';", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                comboBox7.Items.Add(dt4.Rows[i].ItemArray[0].ToString());
            }
            con.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT * from Course,Class where Course.CourseID = '" + comboBox5.SelectedItem.ToString() + "' and SectionNo = '" + comboBox7.SelectedItem.ToString() + "';", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            textBox27.Text = dt4.Rows[0].ItemArray[1].ToString();
            textBox28.Text = dt4.Rows[0].ItemArray[2].ToString();
            textBox10.Text = dt4.Rows[0].ItemArray[5].ToString();
            textBox30.Text = dt4.Rows[0].ItemArray[6].ToString();
            textBox31.Text = dt4.Rows[0].ItemArray[7].ToString();
            textBox32.Text = dt4.Rows[0].ItemArray[8].ToString();
            textBox33.Text = dt4.Rows[0].ItemArray[9].ToString();
            


            SqlDataAdapter sda = new SqlDataAdapter("SELECT Name FROM Person,FacultyTeachesCourse,Class where UserID = FacultyID and FacultyTeachesCourse.CourseID = Class.CourseID and Class.CourseID = '" + comboBox5.SelectedItem.ToString() + "' and SectionNo = '" + comboBox7.SelectedItem.ToString() + "'", con);

            DataTable dt = new DataTable();
            //textBox1.Text = s;
            sda.Fill(dt);
            textBox42.Text = dt.Rows[0].ItemArray[0].ToString();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT * from StudentStudiesCourse where CourseID= '" + comboBox5.SelectedItem.ToString() + "' and StudentID = '" + ID + "';", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            if (dt4.Rows.Count != 0)
            {
                MessageBox.Show("You have already registered for this Course.");
                return;
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql1 = null;
            sql1 = "insert into StudentStudiesCourse(CourseID, DepartmentID, StudentID) values('" + comboBox5.SelectedItem.ToString() + "' , (Select DepartmentID from Student where StudentID = '" + ID + "'), '" + ID + "');" ;
            try
            {
                con.Open();
                adapter.InsertCommand = new SqlCommand(sql1, con);
                adapter.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Course Registered Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            con.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT EventID, StartDate ,EndDate from Event where Name = '" + comboBox2.SelectedItem.ToString() + "';", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            textBox22.Text = dt4.Rows[0].ItemArray[0].ToString();
            textBox25.Text = dt4.Rows[0].ItemArray[1].ToString();
            textBox26.Text = dt4.Rows[0].ItemArray[2].ToString();
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                MessageBox.Show("Please Enter Your Preferred Role.");
                return;
            }
            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT * from StudentParticipatesInEvent where EventID = (select EventID from Event where Name = '" + comboBox2.SelectedItem.ToString() + "') and StudentID = '" + ID + "';", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            if (dt4.Rows.Count != 0)
            {
                MessageBox.Show("You have already registered for this event.");
                return;
            }
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql1 = null;


            sql1 = "insert into StudentParticipatesInEvent(EventID, DepartmentID, StudentID,Role) values('" + textBox22.Text + "' , (Select DepartmentID from Student where StudentID = '" + ID + "'), '" + ID + "', '" + textBox11.Text + "');";
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
