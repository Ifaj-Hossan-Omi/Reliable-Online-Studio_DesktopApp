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
    public partial class AllReplies : UserControl
    {
        private string userN;
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public AllReplies()
        {
            InitializeComponent();
            BindGridView();
        }

        public AllReplies(string userN)
        {
            this.userN = userN;
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Complain_By, Details, ComplainStatus, Complain_To, Reply from complain where hHandle_by = '"+ userN + "'";
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}
