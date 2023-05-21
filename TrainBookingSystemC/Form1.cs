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

namespace TrainBookingSystemC
{
    public partial class Form1 : Form
    {
        private SqlConnection conn; // Declare conn at the class level
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(@"Data Source=MEDO;Initial Catalog=TrainBooking;Integrated Security=True");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
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


        private void btnClear_Click(object sender, EventArgs e)
        {
            tbEmail.Clear();
            tbPassword.Clear();
            tbEmail.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.ShowDialog();
            this.Hide();
        }
    }
}
