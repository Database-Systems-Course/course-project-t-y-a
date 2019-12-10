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
    public partial class Login : Form
    {
        public SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-7EL8EJFA;Initial Catalog=UniversityManagementSystem;Integrated Security=True");
        public SqlCommand cmd = new SqlCommand();
        public Login()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            this.BackgroundImage = Properties.Resources.Habib_Pic;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string user_id = textBox1.Text;
            string password = textBox2.Text;
           
            try

            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Person WHERE UserID ='" + textBox1.Text + "' AND UserPassword ='" + textBox2.Text + "'", con);
                DataTable dt = new DataTable(); 
                sda.Fill(dt);
                if (dt.Rows.Count==1)
                {
                    if ((dt.Rows[0].ItemArray[0].ToString())[7] == 's')
                    {
                        Form1 f1 = new Form1(dt.Rows[0].ItemArray[0].ToString());
                        this.Hide();
                        f1.Show();
                    }
                    else if ((dt.Rows[0].ItemArray[0].ToString())[7] == 'f')
                    {
                        AAFaculty f1 = new AAFaculty(dt.Rows[0].ItemArray[0].ToString());
                        this.Hide();
                        f1.Show();
                    }
                    else if ((dt.Rows[0].ItemArray[0].ToString())[7] == 'r')
                    {
                        MSAddDel f1 = new MSAddDel(dt.Rows[0].ItemArray[0].ToString());
                        this.Hide();
                        f1.Show();
                    }

                }
                else
                    MessageBox.Show("Invalid username or password");


            }

            catch

            {

                MessageBox.Show("Connection failed");

            }
            finally
            {
                con.Close();
            }

            


        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
