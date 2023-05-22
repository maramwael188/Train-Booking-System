using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainBookingSystemC;

namespace train2
{
    public partial class Form1 : Form
    {
       
        private SqlConnection conn; // Declare conn at the class level
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=LAPTOP-KRRE5CF7\SQLEXPRESS;Initial Catalog=db;Integrated Security=True");
        }

        //private void reg_btn_Click(object sender, EventArgs e)
        //{
        //    update r=new update();
        //    r.ShowDialog();
        //    this.Close();
        //}

        private void panel1_Paint(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, 0, 0,0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(100, 0, 0, 0);
            this.Controls.Clear();
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.TopLevel = false;
            this.Controls.Add(signUpForm);
            signUpForm.Show();
            //this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label1.BackColor = Color.FromArgb(80, 0, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btLogin.BackColor = Color.FromArgb(100, 0, 0, 0);
            string username = tbEmail.Text;
            string password = tbPassword.Text;

            try
            {
                string query = "SELECT * FROM PASSENGER WHERE EMAIL = @Email AND PASSWORD = @Password";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@Email", username);
                    command.Parameters.AddWithValue("@Password", password);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Passenger Logged in successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // navigate to the next screen : booking or whatever
                        this.Controls.Clear();
                        updatePassenger update = new updatePassenger();
                        update.currentEmail = tbEmail.Text;
                        update.currentPassw = tbPassword.Text;
                        update.TopLevel = false;
                        //general page should be here
                        this.Controls.Add(update);
                        update.Show();

                    }
                    else
                    {
                        reader.Close();
                        
                        query = "SELECT * FROM ADMIN WHERE EMAIL = @Email AND PASSWORD = @Password";
                        command.CommandText = query;
                        reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                           
                            MessageBox.Show("Admin logged in successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Controls.Clear();
                            updateAdmin update = new updateAdmin();
                            update.currentEmail = tbEmail.Text;
                            update.currentPassw = tbPassword.Text;
                            update.TopLevel = false;
                            this.Controls.Add(update);
                            update.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbEmail.Clear();
                            tbPassword.Clear();
                            tbEmail.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    

        private void button3_Click(object sender, EventArgs e)
        {
            btnClear.BackColor = Color.FromArgb(100, 0, 0, 0);
            tbEmail.Clear();
            tbPassword.Clear();
            tbEmail.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(100, 0, 0, 0);

            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
            this.Close();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }
        //

    }
}

