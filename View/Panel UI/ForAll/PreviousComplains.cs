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
using Photographer.View.Main_UI;

namespace Photographer.View.Panel_UI.ForAll
{
    public partial class PreviousComplains : UserControl
    {
        private string userN;
        private string tableName;
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public PreviousComplains()
        {
            InitializeComponent();
            BindGridView();

        }


        public PreviousComplains(string userN, string tableName)
        {
            this.userN = userN;
            this.tableName = tableName;
            InitializeComponent();
            BindGridView();
        }

        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Complain_To, Details, ComplainStatus, Reply, hHandle_by from complain where Complain_By = '"+ userN + "'";
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

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void PreviousComplains_Load(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (tableName == "clientInfo")
            {
                ClientForm.Instance.PnlContainer.Controls["Report"].BringToFront();

            }
            else if (tableName == "photographerInfo")
            {
                PhotographerForm.Instance.PnlContainer.Controls["Report"].BringToFront();

            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}
