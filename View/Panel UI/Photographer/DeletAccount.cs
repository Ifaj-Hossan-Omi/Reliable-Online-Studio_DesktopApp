using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Photographer.View.Main_UI;

namespace Photographer.View.Panel_UI.Photographer
{
    public partial class DeletAccount : UserControl
    {
        Thread th;
        private string userN;
        private string tableName;
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public DeletAccount()
        {
            InitializeComponent();
        }

        public DeletAccount(string userN, string tableName)
        {
            this.userN = userN;
            this.tableName = tableName;
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (tableName == "clientInfo")
            {
                if (!ClientForm.Instance.PnlContainer.Controls.ContainsKey("PhotographerProfile"))
                {
                    PhotographerProfile un = new PhotographerProfile(userN, tableName);
                    un.Dock = DockStyle.Fill;
                    ClientForm.Instance.PnlContainer.Controls.Add(un);
                }
                ClientForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
            }
            else if(tableName == "photographerInfo")
            {
                if (!PhotographerForm.Instance.PnlContainer.Controls.ContainsKey("PhotographerProfile"))
                {
                    PhotographerProfile un = new PhotographerProfile(userN, tableName);
                    un.Dock = DockStyle.Fill;
                    PhotographerForm.Instance.PnlContainer.Controls.Add(un);
                }
                PhotographerForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
            }
            else if (tableName == "staffInfo")
            {
                if (!StaffForm.Instance.PnlContainer.Controls.ContainsKey("PhotographerProfile"))
                {
                    PhotographerProfile un = new PhotographerProfile(userN, tableName);
                    un.Dock = DockStyle.Fill;
                    PhotographerForm.Instance.PnlContainer.Controls.Add(un);
                }
                StaffForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "delete from " + tableName + " where username=@username";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", this.userN);
            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a >= 0)
            {
                MessageBox.Show("Data Deleted Successfully ! ");

                if (tableName == "photographerInfo")
                {
                    PhotographerForm.Instance.Close();
                    th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }
                else if (tableName == "clientInfo")
                {
                    ClientForm.Instance.Close();
                    th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else if (tableName == "staffInfo")
                {
                    StaffForm.Instance.Close();
                    th = new Thread(opennewform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                
                //th = new Thread(opennewform);
                //th.SetApartmentState(ApartmentState.STA);
                //th.Start();
            }
            else
            {
                MessageBox.Show("Data not Deleted ! ");
            }
        }

        public void opennewform(object obj)
        {
            Application.Run(new LogInForm());
        }
    }
}
