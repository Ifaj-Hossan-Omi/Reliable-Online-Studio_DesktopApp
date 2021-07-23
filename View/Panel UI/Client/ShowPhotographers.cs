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

namespace Photographer.View.Panel_UI.Client
{
    public partial class ShowPhotographers : UserControl
    {
        static ShowPhotographers _obj;
        private string clientUserN;
        private string photographerUserN;


        public static ShowPhotographers Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new ShowPhotographers();
                }
                return _obj;
            }
        }


        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public ShowPhotographers()
        {
            InitializeComponent();
            BindGridView();
        }

        public ShowPhotographers(string userN)
        {
            this.clientUserN = userN;
            InitializeComponent();
            BindGridView();
        }


        void BindGridView()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select picture, name, username, email, rating, gor from photographerInfo";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;

            // Image Column
            DataGridViewImageColumn dgv = new DataGridViewImageColumn();
            dgv = (DataGridViewImageColumn)dataGridView1.Columns[0];
            dgv.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Descending);

            //AUTOSIZE
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //Image Height
            dataGridView1.RowTemplate.Height = 50;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (!ClientForm.Instance.PnlContainer.Controls.ContainsKey("OrderPlacement"))
            {
                OrderPlacement upp = new OrderPlacement(clientUserN, photographerUserN, photographerName.Text);
                upp.Dock = DockStyle.None;
                ClientForm.Instance.PnlContainer.Controls.Add(upp);
            }
            ClientForm.Instance.PnlContainer.Controls["OrderPlacement"].BringToFront();
        }

        private void guna2DataGridView3_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            photographerName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            photographerUserN = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            guna2GradientButton1.Enabled = true;
        }

        public void Reset()
        {
            photographerName.Text = "";
            guna2GradientButton1.Enabled = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
