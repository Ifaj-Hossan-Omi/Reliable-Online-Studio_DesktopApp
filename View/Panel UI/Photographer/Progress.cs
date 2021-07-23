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
    public partial class Progress : UserControl
    {
        static Progress _obj;
        private string userN;
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;


        public static Progress Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new Progress();
                }
                return _obj;
            }
        }
        public Progress()
        {
            InitializeComponent();
        }

        public Progress(string userN)
        {
            this.userN = userN;
            InitializeComponent();
            Reset();
        }

        public void Reset()
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from photographerInfo where username=@user";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", userN);

            con.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    label3.Text = dr["Rating"].ToString() + "%";
                    label4.Text = dr["GOR"].ToString() + "%";
                }
            }

            con.Close();
        }

        private void Progress_Load(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
