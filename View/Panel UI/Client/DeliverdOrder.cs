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

namespace Photographer.View.Panel_UI.Client
{
    public partial class Deliverd_Order : UserControl
    {

        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        static Deliverd_Order _obj;
        private string userN;

        public static Deliverd_Order Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Deliverd_Order();
                }
                return _obj;
            }
        }

        public Deliverd_Order()
        {
            InitializeComponent();
        }

        public Deliverd_Order(string userN)
        {
            this.userN = userN;
            InitializeComponent();
            BindGridView();
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Photo, Task_Details, Task_Status, Photographer_Name, Photographer_Username, Feedback_Rating from task where Client_Username = '" + userN + "' and Task_Status = 'Delivered'";
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            guna2GradientButton1.Enabled = true;
        }

        public void Reset()
        {
            BindGridView();
            guna2GradientButton1.Enabled = false;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update task set Feedback_Rating = @rating where Task_Details = @task_details and Task_Status = @task_status and Photographer_Name = @photographer_name and Photographer_Username = @photographer_username and Client_Username = @client_username";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@rating", Convert.ToInt32(guna2TextBox2.Text));
            cmd.Parameters.AddWithValue("@task_details", dataGridView1.SelectedRows[0].Cells[1].Value);
            cmd.Parameters.AddWithValue("@task_status", dataGridView1.SelectedRows[0].Cells[2].Value);
            cmd.Parameters.AddWithValue("@photographer_name", dataGridView1.SelectedRows[0].Cells[3].Value);
            cmd.Parameters.AddWithValue("@Photographer_Username", dataGridView1.SelectedRows[0].Cells[4].Value);
            cmd.Parameters.AddWithValue("@client_username", userN);

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {

                MessageBox.Show("Submited!!");
                BindGridView();
            }
            else
            {
                MessageBox.Show("Data not Updated !");
            }
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BindGridView();

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_MouseEnter(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "Give Feedback Rating")
                guna2TextBox2.Clear();
        }

        private void guna2TextBox2_MouseLeave(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "")
                guna2TextBox2.Text = "Give Feedback Rating";
        }
    }
}
