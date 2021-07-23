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
using Photographer.View.Panel_UI.Photographer;

namespace Photographer.View.Main_UI
{
    public partial class SignUpForm : Form
    {
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        private string tableName;
        public SignUpForm()
        {
            InitializeComponent();
        }

        public SignUpForm(string type)
        {
            this.tableName = type;
            InitializeComponent();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        { 
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into " + tableName + " (Name, Email, Nid, Picture, Username, Pass, DOB, PresentAddress) values(@name, @email, @nid, @picture, @username, @password, @dob, @presentAddress)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@name", textName.Text);
            cmd.Parameters.AddWithValue("@email", textEmail.Text);
            cmd.Parameters.AddWithValue("@nid", textNID.Text);
            cmd.Parameters.AddWithValue("@picture", SavePhoto());
            cmd.Parameters.AddWithValue("@username", textUsername.Text);
            cmd.Parameters.AddWithValue("@password", textPassword.Text);
            cmd.Parameters.AddWithValue("@dob", textDOB.Text);
            cmd.Parameters.AddWithValue("@presentAddress", textAddress.Text);

        con.Open();
        int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                con.Close();
                if (tableName == "staffInfo")
                {
                    MessageBox.Show("Stuff Created!!");
                    if (!StaffForm.Instance.PnlContainer.Controls.ContainsKey("PhotographerProfile"))
                    {
                        PhotographerProfile un = new PhotographerProfile(textUsername.Text, "clientInfo");
                        un.Dock = DockStyle.Fill;
                        StaffForm.Instance.PnlContainer.Controls.Add(un);
                    }
                    StaffForm.Instance.PnlContainer.Controls["PhotographerProfile"].BringToFront();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Now you are a part of our ROS family. Best of luck.");
                    LogInForm.Instance.PnlContainer.Controls["LogInUI"].BringToFront();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            } 
            con.Close();

        }
        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            guna2CirclePictureBox2.Image.Save(ms, guna2CirclePictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
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
                guna2CirclePictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }
    }
}
