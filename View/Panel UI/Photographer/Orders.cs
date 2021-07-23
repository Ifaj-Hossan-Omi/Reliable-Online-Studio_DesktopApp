using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photographer.View.Panel_UI.Photographer
{
    public partial class Orders : UserControl
    {
        private string userN;
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public Orders()
        {
            InitializeComponent();
            BindGridView();
        }
        public Orders(string userN)
        {
            this.userN = userN;
            InitializeComponent();
            BindGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Orders_Load(object sender, EventArgs e)
        {
            BindGridView();
        }
        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Photo, Task_Details, Task_Status, Client_Username from task where Task_Status = 'Waiting for photographer response' and Photographer_Username = '" + userN + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[0];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update task set Task_Status = 'Received' where Task_Details = @task_details and Task_Status = @task_status and Client_Username = @client_username";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@task_details", dataGridView1.SelectedRows[0].Cells[1].Value);
            cmd.Parameters.AddWithValue("@task_status", dataGridView1.SelectedRows[0].Cells[2].Value);
            cmd.Parameters.AddWithValue("@client_username", dataGridView1.SelectedRows[0].Cells[3].Value);

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                
                MessageBox.Show("Approved!!");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data not Updated !");
            }
            con.Close();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update task set Task_Status = 'Deny' where Task_Details = @task_details and Task_Status = @task_status and Client_Username = @client_username";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@task_details", dataGridView1.SelectedRows[0].Cells[1].Value);
            cmd.Parameters.AddWithValue("@task_status", dataGridView1.SelectedRows[0].Cells[2].Value);
            cmd.Parameters.AddWithValue("@client_username", dataGridView1.SelectedRows[0].Cells[3].Value);

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {

                MessageBox.Show("Deny!!");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data not Updated !");
            }
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            guna2GradientButton1.Enabled = true;
            guna2GradientButton2.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}
