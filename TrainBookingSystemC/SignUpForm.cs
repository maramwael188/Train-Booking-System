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
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbID.Clear();
            tbFname.Clear();
            tbLname.Clear();
            tbEmail.Clear();
            tbAreaCode.Clear();
            tbPhoneNumber.Clear();
            tbPass.Clear();
            tbGender.ResetText();
            tbID.Focus();
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
            string id = tbID.Text;
            string firstName = tbFname.Text;
            string lastName = tbLname.Text;
            string email = tbEmail.Text;
            string areaCode = tbAreaCode.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string password = tbPass.Text;
            string gender = tbGender.Text;

            try
            {                                                   
                using (SqlConnection conn = new SqlConnection(@"Data Source=MEDO;Initial Catalog=TrainBooking;Integrated Security=True"))
                {
                    conn.Open();


                    string query = "INSERT INTO PASSENGER (FIRSTNAME, LASTNAME, EMAIL, ARIACODE, NUMBER, PASSWORD, GENDER) " +
                                   "VALUES (@FirstName, @LastName, @Email, @AreaCode, @PhoneNumber, @Password, @Gender)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ID", id);
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

                tbID.Clear();
                tbFname.Clear();
                tbLname.Clear();
                tbEmail.Clear();
                tbAreaCode.Clear();
                tbPhoneNumber.Clear();
                tbPass.Clear();
                tbGender.ResetText();
                tbID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 LogIn = new Form1();
            LogIn.ShowDialog();
            this.Hide();
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
            string id = tbID.Text;
            string firstName = tbFname.Text;
            string lastName = tbLname.Text;
            string email = tbEmail.Text;
            string areaCode = tbAreaCode.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string password = tbPass.Text;
            string gender = tbGender.Text;

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=MEDO;Initial Catalog=TrainBooking;Integrated Security=True"))
                {
                    conn.Open();

                    string query = "INSERT INTO ADMIN (FIRSTNAME, LASTNAME, EMAIL, AREACODE, NUMBER, PASSWORD, GENDER) " +
                                   "VALUES (@FirstName, @LastName, @Email, @AreaCode, @PhoneNumber, @Password, @Gender)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@ID", id);
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

                tbID.Clear();
                tbFname.Clear();
                tbLname.Clear();
                tbEmail.Clear();
                tbAreaCode.Clear();
                tbPhoneNumber.Clear();
                tbPass.Clear();
                tbGender.ResetText();
                tbID.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void tbGender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
