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

namespace Photographer.View.Panel_UI.Staff
{
    public partial class ManageComplain : UserControl
    {
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private string userN;
        public ManageComplain()
        {
            InitializeComponent();
            BindGridView();

        }

        public ManageComplain(string userN)
        {
            this.userN = userN;
            InitializeComponent();
            BindGridView();
            Reset();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Complain_By, Details, Complain_To, ComplainStatus from complain where ComplainStatus = 'Waiting for Response'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Image Column
            //DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            //dgv = (DataGridViewImageColumn)dataGridView1.Columns[3];
            //dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void ManageComplain_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update complain set ComplainStatus = 'Taking Action', hHandle_by =@userN , Reply = @reply where Complain_By = @complain_by and Details = @details and Complain_To = @complain_to and ComplainStatus = 'Waiting for Response'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userN", userN);
            cmd.Parameters.AddWithValue("@reply", textName.Text);
            cmd.Parameters.AddWithValue("@complain_by", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("@details", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("@complain_to", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());


            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully ! ");
                Reset();
            }
            else
            {
                MessageBox.Show("Data not Updated ! ");
                Reset();

            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update complain set ComplainStatus = 'Deny', hHandle_by =@userN , Reply = @reply where Complain_By = @complain_by and Details = @details and Complain_To = @complain_to and ComplainStatus = 'Waiting for Response'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userN", userN);
            cmd.Parameters.AddWithValue("@reply", textName.Text);
            cmd.Parameters.AddWithValue("@complain_by", dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cmd.Parameters.AddWithValue("@details", dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            cmd.Parameters.AddWithValue("@complain_to", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());


            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully ! ");
                Reset();
            }
            else
            {
                MessageBox.Show("Data not Updated ! ");
                Reset();
            }
        }
        public void Reset()
        {
            textName.Text = "";
            guna2GradientButton1.Enabled = false;
            guna2GradientButton3.Enabled = false;
            BindGridView();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            guna2GradientButton1.Enabled = true;
            guna2GradientButton3.Enabled = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}