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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace train2
{
    public partial class updateAdmin : Form
    {
        public string currentEmail { get; set; }
        public string currentPassw { get; set; }

        public updateAdmin()
        {
            InitializeComponent();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }


        private void btnExit_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            btnSave.BackColor = Color.FromArgb(100, 0, 0, 0);
            string firstName = tbFname.Text;
            string lastName = tbLname.Text;
            string email = tbEmail.Text;
            string areaCode = tbAreaCode.Text;
            string phoneNumber = tbPhoneNumber.Text;
            string password = tbPass.Text;
            string gender = tbGender.Text;
            string currentEmaill= currentEmail;
            //string currentPassww= currentPassw.Trim();

            Form1 form = new Form1();
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=db;Integrated Security=True"))
                {
                    conn.Open();
                    string updateQuery = "UPDATE ADMIN SET FIRSTNAME = @FirstName, LASTNAME=@LastName," +
                        " EMAIL=@Email, PASSWORD=@Password, AREACODE=@AreaCode, NUMBER=@PhoneNumber, " +
                        "GENDER= @Gender Where EMAIL=@CurrentEmaill";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@FirstName", firstName);
                        updateCommand.Parameters.AddWithValue("@LastName", lastName);
                        updateCommand.Parameters.AddWithValue("@Email", email);
                        updateCommand.Parameters.AddWithValue("@Password", password);
                        updateCommand.Parameters.AddWithValue("@AreaCode", areaCode);
                        updateCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        updateCommand.Parameters.AddWithValue("@Gender", gender);
                        updateCommand.Parameters.AddWithValue("@CurrentEmaill", currentEmaill);
                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        // Check the number of rows affected
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("data is updated");
                            conn.Close();
                        }
                        


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void tbFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateAdmin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbDataSet.ADMIN' table. You can move, or remove it, as needed.
            this.aDMINTableAdapter.Fill(this.dbDataSet.ADMIN);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            string currentEmaill = currentEmail;
            //string currentPassww= currentPassw.Trim();

            Form1 form = new Form1();
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=db;Integrated Security=True"))
                {
                    conn.Open();
                    string deletequery = "DELETE FROM ADMIN WHERE EMAIL=@Email";
                    using (SqlCommand deletecommand = new SqlCommand(deletequery, conn))
                    {
                        deletecommand.Parameters.AddWithValue("@Email", currentEmaill);
                        int rowsAffected = deletecommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Delete successful");
                            this.Close();
                            Form1 Form = new Form1();
                            //Form.TopLevel = false;
                            Form.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }

        }
    }
}
