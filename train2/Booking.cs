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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace train2
{

    public partial class Booking : Form
    {
        public string currentEmail { get; set; }
        public Booking()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'train_system_databaseDataSet.TRIP' table. You can move, or remove it, as needed.
            this.tRIPTableAdapter.Fill(this.train_system_databaseDataSet.TRIP);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    tRIPBindingSource.Filter = string.Empty;
                }
                else
                {
                    tRIPBindingSource.Filter = string.Format("{0}='{1}'", comboBox1.Text, textBox1.Text);
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
        
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string email = currentEmail;
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=db;Integrated Security=True"))
                {
                    conn.Open();
                    string currentDate = DateTime.Now.ToString("yyyy-MM-dd");

                    string status = "Active";
                    string query = "INSERT INTO BOOKING (BOOKINGDATE, BOOKINGSTATUS, NUMOFSEATS,TRIPID,CLASSN) " +
                                   "VALUES (@bookingdate, @bookingstatus, @numofseats,@tripid,@class)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@numofseats", textBox6.Text);
                        command.Parameters.AddWithValue("@bookingstatus", status);
                        command.Parameters.AddWithValue("@bookingdate", currentDate);
                        command.Parameters.AddWithValue("@tripid", textBox3.Text);
                        command.Parameters.AddWithValue("@class", comboBox2.Text);
                        command.ExecuteNonQuery();
                    }


                    string query2 = "UPDATE PASSENGER SET BOOKINGNUMBER = (SELECT TOP 1 BOOKINGNUMBER FROM BOOKING ORDER BY BOOKINGNUMBER DESC) WHERE EMAIL = @email;";
                    using (SqlCommand command2 = new SqlCommand(query2, conn))
                    {
                        command2.Parameters.AddWithValue("@email", email);
                        command2.ExecuteNonQuery();

                    }
                    MessageBox.Show("Booking Succesful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Clear();
                    textBox6.Clear();


                }

            }


            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, 0, 0, 0);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string email = currentEmail;
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=.;Initial Catalog=db;Integrated Security=True"))
                {
                    conn.Open();



                    string query = "UPDATE BOOKING SET BOOKINGSTATUS = 'Cancelled' WHERE BOOKINGNUMBER IN (SELECT BOOKINGNUMBER FROM PASSENGER WHERE EMAIL = @email);";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        command.ExecuteNonQuery();
                    }


                    string query2 = "UPDATE PASSENGER SET BOOKINGNUMBER = NULL WHERE PASSENGER.EMAIL = @email;";
                    using (SqlCommand command2 = new SqlCommand(query2, conn))
                    {
                        command2.Parameters.AddWithValue("@email", email);
                        command2.ExecuteNonQuery();

                    }
                    MessageBox.Show("Cancellation Succesful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }


            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }
    }
}

