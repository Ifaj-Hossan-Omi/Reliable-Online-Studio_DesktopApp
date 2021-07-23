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
using Photographer.View.Main_UI;

namespace Photographer.View.Panel_UI.Photographer
{
    public partial class UpdatePhotographerProfile : UserControl
    {
        private string tableName;
        private string userN;

        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public UpdatePhotographerProfile()
        {
            InitializeComponent();
            Reset();
        }

        public UpdatePhotographerProfile(string userN, string tableName)
        {
            this.userN = userN;
            this.tableName = tableName;
            InitializeComponent();
            Reset();
        }

        private Image GetPhoto(byte[] photo)
        {
            MemoryStream ms = new MemoryStream(photo);
            return Image.FromStream(ms);
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
                    textName.Text = dr["Name"].ToString();
                    textUsername.Text = dr["Username"].ToString();
                    textPassword.Text = "";
                    textEmail.Text = dr["Email"].ToString();
                    textNID.Text = dr["Nid"].ToString();
                    textDOB.Text = dr["DOB"].ToString();
                    textAddress.Text = dr["PresentAddress"].ToString();
                    guna2CirclePictureBox1.Image = GetPhoto((byte[])dr["Picture"]);
                }
            }

            con.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(cs);
            string query = "update " + tableName + " set name = @name, email = @email, nid = @nid, picture = @picture, username = @username, pass = @password, dob = @dob, presentAddress = @presentAddress where username = @userN";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@userN", userN);
            cmd.Parameters.AddWithValue("@name", textName.Text);
            cmd.Parameters.AddWithValue("@email", textEmail.Text);
            cmd.Parameters.AddWithValue("@nid", textNID.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());
            cmd.Parameters.AddWithValue("@username", textUsername.Text);
            if (textPassword.Text == "")
            {
                SqlConnection con2 = new SqlConnection(cs);
                string query2 = "select * from " + tableName + " where username=@user";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@user", userN);

                con2.Open();

                using (SqlDataReader dr = cmd2.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        cmd.Parameters.AddWithValue("@password", dr["Pass"].ToString());

                    }
                }

                con2.Close();

            }
            else
            {
                cmd.Parameters.AddWithValue("@password", textPassword.Text);

            }
            cmd.Parameters.AddWithValue("@dob", textDOB.Text);
            cmd.Parameters.AddWithValue("@presentAddress", textAddress.Text);

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                PhotographerProfile.PInstance.userN = textUsername.Text;
                MessageBox.Show("Data Updated Successfully ! ");
                Reset();
                PhotographerProfile.PInstance.Reset();
                if (tableName == "photographerInfo")
                {
                    PhotographerForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
                }
                else if (tableName == "clientInfo")
                {
                    ClientForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
                }
                else if (tableName == "staffInfo")
                {
                    StaffForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
                }
            }
            else
            {
                MessageBox.Show("Data not Updated ! ");
            }

        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox1.Image.Save(ms, guna2CirclePictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdatePhotographerProfile_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Image File (All files) *.* | *.*";
            //ofd.ShowDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                guna2CirclePictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (tableName == "photographerInfo")
            {
                PhotographerForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
            }
            else if (tableName == "clientInfo")
            {
                ClientForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
            }
            else if (tableName == "staffInfo")
            {
                StaffForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
            }
        }
    }
    
}
