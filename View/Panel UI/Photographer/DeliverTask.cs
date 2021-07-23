using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Photographer.View.Panel_UI.Photographer
{
    public partial class DeliverTask : UserControl
    {
        static DeliverTask _obj;
        private string userN;

        public static DeliverTask Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new DeliverTask();
                }
                return _obj;
            }
        }
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public DeliverTask()
        {
            InitializeComponent();
            BindGridView();
        }

        public DeliverTask(string userN)
        {
            this.userN = userN;
            InitializeComponent();
            BindGridView();
        }


        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Photo, Task_Details, Task_Status, Client_Username from task where Task_Status = 'Received' and Photographer_Username = '" + userN + "'";
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            //ofd.Filter = "PNG File (*.png) | *.png";
            //ofd.Filter = "JPG File (*.jpg) | *.jpg";
            //ofd.Filter = "Image File (*.png;*.jpg) | *.png; *.jpg";
            ofd.Filter = "Image File (All files) *.* | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.Image = new Bitmap(ofd.FileName);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "update task set Photo = @photo, Task_Status = 'Delivered' where Photographer_Username = @username and Task_Details = @task_details and Client_Username = @client_username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@photo", SavePhoto());
            cmd.Parameters.AddWithValue("@username", userN);
            cmd.Parameters.AddWithValue("@task_details", dataGridView1.SelectedRows[0].Cells[1].Value);
            cmd.Parameters.AddWithValue("@client_username", dataGridView1.SelectedRows[0].Cells[3].Value);

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Updated Successfully ! ");
                BindGridView();
                guna2GradientButton1.Enabled = false;
                pictureBox3.Image = Properties.Resources.DefaultOrderPhoto;
            }
            else
            {
                MessageBox.Show("Data not Updated ! ");
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox3.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BindGridView();
            pictureBox3.Image = Properties.Resources.DefaultOrderPhoto;
            guna2GradientButton1.Enabled = false;
        }
    }
}
