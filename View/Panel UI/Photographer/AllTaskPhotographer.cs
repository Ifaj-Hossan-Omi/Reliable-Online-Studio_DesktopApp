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
    public partial class AllTaskPhotographer : UserControl
    {

        static AllTaskPhotographer _obj;
        private string userN;

        public static AllTaskPhotographer Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new AllTaskPhotographer();
                }
                return _obj;
            }
        }
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        public AllTaskPhotographer()
        {
            InitializeComponent();
            BindGridView();
        }

        public AllTaskPhotographer(string userN)
        {
            this.userN = userN;
            InitializeComponent();
            BindGridView();
        }

        public void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select Photo, Task_Details, Task_Status, Client_Username, Feedback_Rating from task where Photographer_Username = '" + userN + "'";
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }
    }
}
