using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Photographer.View.Main_UI;

namespace Photographer.View.Panel_UI.Photographer
{
    public partial class PhotographerProfile : UserControl
    {
        static PhotographerProfile _obj;
        public string userN;
        private string tableName;

        public static PhotographerProfile PInstance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new PhotographerProfile();
                }

                return _obj;
            }
        }



        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public PhotographerProfile()
        {
            
            InitializeComponent();
            _obj = this;
        }
        public PhotographerProfile(string userN, string tableName)
        {
            this.userN = userN;
            this.tableName = tableName;
            InitializeComponent();
            _obj = this;
        }

        private void PhotographerProfile_Load(object sender, EventArgs e)
        {
            Reset();
        }

        public void Reset()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from " + tableName + " where username=@user";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", userN);

            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    name.Text = dr["Name"].ToString();
                    userName.Text = dr["Username"].ToString();
                    email.Text = dr["Email"].ToString();
                    nid.Text = dr["Nid"].ToString();
                    dob.Text = dr["DOB"].ToString();
                    address.Text = dr["PresentAddress"].ToString();
                    guna2CirclePictureBox1.Image = GetPhoto((byte[])dr["Picture"]);
                }
            }

            con.Close();
        }
        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (tableName == "photographerInfo")
            {
                if (!PhotographerForm.Instance.PnlContainer.Controls.ContainsKey("UpdatePhotographerProfile"))
                {
                    UpdatePhotographerProfile upp = new UpdatePhotographerProfile(userN, tableName);
                    upp.Dock = DockStyle.None;
                    PhotographerForm.Instance.PnlContainer.Controls.Add(upp);
                }
                PhotographerForm.Instance.PnlContainer.Controls["UpdatePhotographerProfile"].BringToFront();
            }
            else if (tableName == "clientInfo")
            {
                if (!ClientForm.Instance.PnlContainer.Controls.ContainsKey("UpdatePhotographerProfile"))
                {
                    UpdatePhotographerProfile upp = new UpdatePhotographerProfile(userN, tableName);
                    upp.Dock = DockStyle.None;
                    ClientForm.Instance.PnlContainer.Controls.Add(upp);
                }
                ClientForm.Instance.PnlContainer.Controls["UpdatePhotographerProfile"].BringToFront();
            }

            else if (tableName == "staffInfo")
            {
                if (!StaffForm.Instance.PnlContainer.Controls.ContainsKey("UpdatePhotographerProfile"))
                {
                    UpdatePhotographerProfile upp = new UpdatePhotographerProfile(userN, tableName);
                    upp.Dock = DockStyle.None;
                    StaffForm.Instance.PnlContainer.Controls.Add(upp);
                }
                StaffForm.Instance.PnlContainer.Controls["UpdatePhotographerProfile"].BringToFront();
            }

        }
    }
}
