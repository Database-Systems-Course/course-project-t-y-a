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
    public partial class MSAddDel : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-7EL8EJFA;Initial Catalog=UniversityManagementSystem;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public MSAddDel(string s)
        {
            InitializeComponent();
            groupBox1.Enabled = false;

            try

            {
                con.Open();

                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person, ROStaff WHERE UserID = ROStaffID and UserID = '" + s + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                textBox47.Text = dt.Rows[0].ItemArray[0].ToString();
                textBox46.Text = dt.Rows[0].ItemArray[1].ToString();
                textBox3.Text = dt.Rows[0].ItemArray[2].ToString();
                textBox4.Text = dt.Rows[0].ItemArray[3].ToString();
                textBox5.Text = dt.Rows[0].ItemArray[4].ToString();
                textBox2.Text = dt.Rows[0].ItemArray[5].ToString();
                textBox1.Text = dt.Rows[0].ItemArray[7].ToString();
                textBox8.Text = dt.Rows[0].ItemArray[8].ToString();
                textBox51.Text = dt.Rows[0].ItemArray[10].ToString();
                textBox48.Text = dt.Rows[0].ItemArray[11].ToString();
                textBox50.Text = dt.Rows[0].ItemArray[12].ToString();
                textBox49.Text = dt.Rows[0].ItemArray[13].ToString();
            }
            catch
            {
                MessageBox.Show("Staff form connection failed");
            }


            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT CourseID FROM Course", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);

            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                comboBox3.Items.Add(dt3.Rows[i].ItemArray[0].ToString());
            }

            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT Name from Person join Faculty on Person.UserID = Faculty.FacultyID;", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                comboBox4.Items.Add(dt4.Rows[i].ItemArray[0].ToString());
                comboBox5.Items.Add(dt4.Rows[i].ItemArray[0].ToString());
            }


            con.Close();

            comboBox1.Items.Add("Student");
            comboBox1.Items.Add("Faculty");
            comboBox1.Items.Add("Course");
            comboBox1.Items.Add("Event");
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox46_TextChanged(object sender, EventArgs e)
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
    
        }



        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox61.Text != "" && textBox60.Text != "" && textBox59.Text != "" && textBox58.Text != "" && textBox57.Text != "" && textBox56.Text != "" && textBox55.Text != "" && textBox54.Text != "" && textBox23.Text != "" && textBox22.Text != "" && textBox21.Text != "" && textBox20.Text != "" )
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql1 = null;
                sql1 = "insert into Person(UserId, Name, Email, ContactNo, Sex,Nationality,UserPassword,Age,CNIC) values('" + textBox60.Text + "','" + textBox61.Text + "','" + textBox59.Text + " ','" + textBox58.Text + " ','" + textBox57.Text + " ','" + textBox56.Text + " ','" + textBox55.Text + " ','" + textBox54.Text + " ','" + textBox23.Text + " ') insert into Student(StudentID,DepartmentID,AdmissionDate,GraduationYear,CGPA) values('" + textBox60.Text + " ','" + textBox22.Text + " ','" + textBox21.Text + "','" + textBox20.Text + " ','" + textBox13.Text + "');";
                try
                {
                    con.Open();
                    adapter.InsertCommand = new SqlCommand(sql1, con);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Student Added.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                SqlDataAdapter adapter3 = new SqlDataAdapter();
                string sql3 = null;
                sql3 = "insert into StudentHasFaculty(DepartmentID,FacultyID,StudentID) values ('" + textBox22.Text + "',(Select UserID from Person where Name = '" + comboBox5.SelectedItem.ToString() + "'),'" + textBox60.Text + "');";
                try
                {
                    adapter3.InsertCommand = new SqlCommand(sql3, con);
                    adapter3.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Please enter data in all the boxes.");
            }
        }

        private void textBox61_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox35.Text != "" && textBox34.Text != "" && textBox33.Text != "" && textBox38.Text != "" && textBox37.Text != "" && textBox36.Text != "" && textBox43.Text != "" && textBox42.Text != "" && textBox41.Text != "" && textBox40.Text != "" && textBox14.Text != "" && textBox44.Text != "" && textBox45.Text != "")
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql1 = null;
                sql1 = "insert into Person(UserId, Name, Email, ContactNo, Sex,Nationality,UserPassword,Age,CNIC) values('" + textBox34.Text + "','" + textBox35.Text + "','" + textBox33.Text + " ','" + textBox38.Text + " ','" + textBox37.Text + " ','" + textBox36.Text + " ','" + textBox43.Text + " ','" + textBox42.Text + " ','" + textBox41.Text + " ') insert into Faculty(FacultyID,DepartmentID,SupervisedBy,SupervisorDepartmentID,JoiningDate,Designation,Salary) values('" + textBox34.Text + " ','" + textBox40.Text + " ',(Select FacultyID from Faculty where SupervisedBy is NULL and DepartmentID = '" + textBox40.Text + " '),'" + (textBox40.Text.Length == 0 ? null : textBox40.Text) + "','" + textBox14.Text + "','" + textBox44.Text + "','" + textBox45.Text + "');";
                try
                {
                    con.Open();
                    adapter.InsertCommand = new SqlCommand(sql1, con);
                    adapter.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Faculty Added.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                SqlDataAdapter sda5 = new SqlDataAdapter("SELECT Name from Person join Faculty on Person.UserID = Faculty.FacultyID;", con);
                DataTable dt5 = new DataTable();
                sda5.Fill(dt5);
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();
                for (int i = 0; i < dt5.Rows.Count; i++)
                {
                    comboBox4.Items.Add(dt5.Rows[i].ItemArray[0].ToString());
                    comboBox5.Items.Add(dt5.Rows[i].ItemArray[0].ToString());
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Please enter data in all the boxes.");
            }
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if(textBox17.Text == "" || textBox16.Text == "" || textBox10.Text == "" || textBox9.Text == "" || textBox12.Text == "" || textBox39.Text == "" || textBox11.Text == "" || textBox62.Text == "")
            {
                MessageBox.Show("Please enter data in all the boxes.");
                return;
            }

          
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Course WHERE CourseID = '" + textBox17.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                string prereq = "";
                if (string.IsNullOrEmpty(comboBox3.Text))
                {
                    prereq = "None";
                }
                else
                {
                    prereq = comboBox3.SelectedItem.ToString();
                }


                SqlDataAdapter adapter = new SqlDataAdapter();
                string sql1 = null;
                sql1 = "insert into Course (CourseID, Name, Prerequisite) values ('" + textBox17.Text + " ', '" + textBox16.Text + " ', '" + prereq + " ' );";
                try
                {
                    adapter.InsertCommand = new SqlCommand(sql1, con);
                    adapter.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }


            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * FROM Class WHERE CourseID = '" + textBox17.Text + "' and SectionNo = '" + textBox10.Text + "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows.Count == 0)
            {

                SqlDataAdapter adapter1 = new SqlDataAdapter();
                string sql2 = null;
                sql2 = "insert into Class (CourseID,SectionNo,Capacity,Timings,Days,RoomNo,Semester) values ('" + textBox17.Text + " ', '" + textBox10.Text + " ', '" + textBox9.Text + " ', '" + textBox12.Text + " ','" + textBox39.Text + " ','" + textBox11.Text + " ','" + textBox62.Text + " ');";
                try
                {
                    adapter1.InsertCommand = new SqlCommand(sql2, con);
                    adapter1.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                MessageBox.Show("This class has been successfully added.");
                SqlDataAdapter sda3 = new SqlDataAdapter("SELECT CourseID FROM Course", con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
                comboBox3.Items.Clear();
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    comboBox3.Items.Add(dt3.Rows[i].ItemArray[0].ToString());
                }


                SqlDataAdapter adapter3 = new SqlDataAdapter();
                string sql3 = null;
                sql3 = "insert into FacultyTeachesCourse(DepartmentID,CourseID,FacultyID) values ((Select DepartmentID from Faculty where FacultyID = (Select UserID from Person where Name = '" + comboBox4.SelectedItem.ToString() + "') ) ,'" + textBox17.Text + "',(Select UserID from Person where Name = '"+ comboBox4.SelectedItem.ToString() +"'));";
                try
                {
                    adapter3.InsertCommand = new SqlCommand(sql3, con);
                    adapter3.InsertCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
            else { MessageBox.Show("This class has already been added."); }




            con.Close();
         
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();

            if ( textBox26.Text == "" || textBox15.Text == "" || textBox18.Text == "" )
            {
                MessageBox.Show("Please enter data in all the boxes.");
                return;
            }


            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * FROM Event WHERE Name = '" + textBox26.Text +  "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows.Count == 0)
            {

                SqlDataAdapter adapter3 = new SqlDataAdapter();
                string sql3 = null;
                sql3 = "insert into Event(Name,StartDate,EndDate) values ('" + textBox26.Text + "','" + textBox15.Text + "','" + textBox18.Text + "')";
                try
                {
                    adapter3.InsertCommand = new SqlCommand(sql3, con);
                    adapter3.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Event successfully added.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else { MessageBox.Show("This event has already been added."); }

            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (textBox6.Text == "") { MessageBox.Show("Please enter ID/Name for deletion.");
                return;
            }
            SqlDataAdapter sda1 = new SqlDataAdapter("SELECT * FROM Person WHERE UserID = '" + textBox6.Text + "'", con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows.Count != 0 && comboBox1.SelectedItem.ToString() == "Student")
            {
                con.Open();
                SqlDataAdapter adapter3 = new SqlDataAdapter();
                string sql3 = null;
                sql3 = "Delete from Student where StudentID = '" + textBox6.Text + "';Delete from Person where UserID = '" + textBox6.Text + "' ;Delete from StudentHasFaculty where StudentID = '" + textBox6.Text + "';Delete from Fees where StudentID = '" + textBox6.Text + "';Delete from StudentParticipatesInEvent where StudentID = '" + textBox6.Text + "'Delete from StudentStudiesCourse where StudentID = '" + textBox6.Text + "'";
                try
                {
                    adapter3.InsertCommand = new SqlCommand(sql3, con);
                    adapter3.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted.");
                    con.Close();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


            SqlDataAdapter sda2 = new SqlDataAdapter("SELECT * FROM Person WHERE UserID = '" + textBox6.Text + "'", con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            if (dt2.Rows.Count != 0 && comboBox1.SelectedItem.ToString() == "Faculty")
            {
                con.Open();
                SqlDataAdapter adapter3 = new SqlDataAdapter();
                string sql3 = null;
                sql3 = "Delete from Faculty where FacultyID = '" + textBox6.Text + "';Delete from Person where UserID = '" + textBox6.Text + "' ;Delete from StudentHasFaculty where FacultyID = '" + textBox6.Text + "';Delete from FacultyParticipatesInEvent where FacultyID = '" + textBox6.Text + "'Delete from FacultyTeachesCourse where FacultyID = '" + textBox6.Text + "'";
                try
                {
                    adapter3.InsertCommand = new SqlCommand(sql3, con);
                    adapter3.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Faculty Deleted.");
                    con.Close();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            SqlDataAdapter sda3 = new SqlDataAdapter("SELECT * FROM Course WHERE CourseID = '" + textBox6.Text + "'", con);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows.Count != 0 && comboBox1.SelectedItem.ToString() == "Course")
            {
                con.Open();
                SqlDataAdapter adapter4 = new SqlDataAdapter();
                string sql4 = null;
                sql4 = "Delete from Course where CourseID = '" + textBox6.Text + "';Delete from Class where CourseID = '" + textBox6.Text + "' ;Delete from StudentStudiesCourse where CourseID = '" + textBox6.Text + "';Delete from FacultyTeachesCourse where CourseID = '" + textBox6.Text + "';";
                try
                {
                    adapter4.InsertCommand = new SqlCommand(sql4, con);
                    adapter4.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Course Deleted.");
                    con.Close();
                    return;
                    }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            SqlDataAdapter sda4 = new SqlDataAdapter("SELECT * FROM [Event] WHERE [Name] = '" + textBox6.Text + "'", con);
            DataTable dt4 = new DataTable();
            sda4.Fill(dt4);
            if (dt4.Rows.Count != 0 && comboBox1.SelectedItem.ToString() == "Event")
            {
                con.Open();
                SqlDataAdapter adapter4 = new SqlDataAdapter();
                string sql4 = null;
                sql4 = "Delete from [Event] where [Name] = '" + textBox6.Text + "';Delete from StudentParticipatesInEvent where EventID = (Select EventID from Event where Name = '" + textBox6.Text + "') ;Delete from FacultyParticipatesInEvent where EventID = (select EventID from Event where Name = '" + textBox6.Text + "')";
                try
                {
                    adapter4.InsertCommand = new SqlCommand(sql4, con);
                    adapter4.InsertCommand.ExecuteNonQuery();
                    MessageBox.Show("Event Deleted.");
                    con.Close();
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else { MessageBox.Show("No such ID/Name exists."); }

            con.Close(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            f1.Show();
            this.Close();
        }
    }
}
