﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using train2;

namespace TrainBookingSystemC
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
            //this.BackColor = Color.Transparent;
            //this.TransparencyKey = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(100, 0, 0, 0);
            tbFname.Clear();
            tbLname.Clear();
            tbEmail.Clear();
            tbAreaCode.Clear();
            tbPhoneNumber.Clear();
            tbPass.Clear();
            tbGender.ResetText();
            tbFname.Focus();
        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbLname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbAreaCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbGender_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(100, 0, 0, 0);
            string firstName = tbFname.Text;
            string lastName = tbLname.Text;
            string email = tbEmail.Text;
            string areaCode = tbAreaCode.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string password = tbPass.Text;
            string gender = tbGender.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-KRRE5CF7\SQLEXPRESS;Initial Catalog=db;Integrated Security=True"))
                {
                    conn.Open();

                    // Check if email already exists in the PASSENGER or ADMIN table
                    string checkQuery = "SELECT COUNT(*) FROM PASSENGER WHERE EMAIL = @Email";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    checkQuery = "SELECT COUNT(*) FROM ADMIN WHERE EMAIL = @Email";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    string query = "INSERT INTO PASSENGER (FIRSTNAME, LASTNAME, EMAIL, ARIACODE, NUMBER, PASSWORD, GENDER) " +
                                   "VALUES (@FirstName, @LastName, @Email, @AreaCode, @PhoneNumber, @Password, @Gender)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@AreaCode", areaCode);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Gender", gender);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Passenger registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbFname.Clear();
                tbLname.Clear();
                tbEmail.Clear();
                tbAreaCode.Clear();
                tbPhoneNumber.Clear();
                tbPass.Clear();
                tbGender.ResetText();
                tbFname.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

       

        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(100, 0, 0, 0);
            string firstName = tbFname.Text;
            string lastName = tbLname.Text;
            string email = tbEmail.Text;
            string areaCode = tbAreaCode.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string password = tbPass.Text;
            string gender = tbGender.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-KRRE5CF7\SQLEXPRESS;Initial Catalog=db;Integrated Security=True"))
                {
                    conn.Open();

                    // Check if email already exists in the ADMIN or PASSENGER table
                    string checkQuery = "SELECT COUNT(*) FROM ADMIN WHERE EMAIL = @Email";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit the event handler without performing the registration
                        }
                    }

                    checkQuery = "SELECT COUNT(*) FROM PASSENGER WHERE EMAIL = @Email";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, conn))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Email already exists. Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Exit the event handler without performing the registration
                        }
                    }

                    string query = "INSERT INTO ADMIN (FIRSTNAME, LASTNAME, EMAIL, AREACODE, NUMBER, PASSWORD, GENDER) " +
                                   "VALUES (@FirstName, @LastName, @Email, @AreaCode, @PhoneNumber, @Password, @Gender)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@AreaCode", areaCode);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@Gender", gender);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Admin registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbFname.Clear();
                tbLname.Clear();
                tbEmail.Clear();
                tbAreaCode.Clear();
                tbPhoneNumber.Clear();
                tbPass.Clear();
                tbGender.ResetText();
                tbFname.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(100, 0, 0, 0);
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

        private void tbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            
        }

        private void tbFname_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            btnlogin.BackColor = Color.FromArgb(100, 0, 0, 0);
            this.Controls.Clear();
            Form1 Form = new Form1();
            Form.TopLevel = false;
            Form.FormBorderStyle = FormBorderStyle.None;
            this.Controls.Add(Form);
            Form.Show();
        }
    }
}
