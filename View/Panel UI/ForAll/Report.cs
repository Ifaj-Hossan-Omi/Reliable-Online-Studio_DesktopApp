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
    public partial class Report : UserControl
    {

        static Report _obj;
        private string userN;
        private string tableName;

        public static Report Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Report();
                }
                return _obj;
            }
        }


        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public Report()
        {
            InitializeComponent();
        }

        public Report(string userN, string tableName)
        {
            this.userN = userN;
            this.tableName = tableName;
            InitializeComponent();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into complain (Complain_By, Details, ComplainStatus, Complain_To) values ( @complain_by, @details, @complainStatus, @complain_to)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@complain_by", userN);
            cmd.Parameters.AddWithValue("@details", guna2TextBox2.Text);
            cmd.Parameters.AddWithValue("@complainStatus", "Waiting for Response");
            cmd.Parameters.AddWithValue("@complain_to", textName.Text); //Savepht Self Written Code

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Complain submitted!! ");
                Reset();
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
                Reset();
            }
        }

        public void Reset()
        {
            textName.Text = "";
            guna2TextBox2.Text = "";
        }

        private void Report_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (tableName == "photographerInfo")
            {
                if (!PhotographerForm.Instance.PnlContainer.Controls.ContainsKey("PreviousComplains"))
                {
                    PreviousComplains upp = new PreviousComplains(userN, tableName);
                    upp.Dock = DockStyle.None;
                    PhotographerForm.Instance.PnlContainer.Controls.Add(upp);
                }
                PhotographerForm.Instance.PnlContainer.Controls["PreviousComplains"].BringToFront();
            }
            else if (tableName == "clientInfo")
            {
                if (!ClientForm.Instance.PnlContainer.Controls.ContainsKey("PreviousComplains"))
                {
                    PreviousComplains upp = new PreviousComplains(userN, tableName);
                    upp.Dock = DockStyle.None;
                    ClientForm.Instance.PnlContainer.Controls.Add(upp);
                }
                ClientForm.Instance.PnlContainer.Controls["PreviousComplains"].BringToFront();
            }
        }
    }
}
