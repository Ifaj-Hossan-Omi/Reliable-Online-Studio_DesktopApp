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

namespace Photographer.View.Panel_UI.Client
{
    public partial class OrderPlacement : UserControl
    {
        private string clientUserN;
        private string photographerUserN;
        private string photographerName;
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        static OrderPlacement _obj;


        public static OrderPlacement Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new OrderPlacement();
                }
                return _obj;
            }
        }

        public OrderPlacement()
        {
            InitializeComponent();
        }

        public OrderPlacement(string clientUserN, string photographerUserN, string photographerName)
        {
            this.clientUserN = clientUserN;
            this.photographerUserN = photographerUserN;
            this.photographerName = photographerName;
            InitializeComponent();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
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
                pictureBox2.Image = new Bitmap(ofd.FileName);
            }
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "insert into task values (@clientUsername, @pic, @taskDetails, @TaskStatus, @photographerName, @photographerUsername, @rating)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@clientUsername", clientUserN);
            cmd.Parameters.AddWithValue("@pic", SavePhoto());
            cmd.Parameters.AddWithValue("@taskDetails", guna2TextBox2.Text);
            cmd.Parameters.AddWithValue("@TaskStatus", "Waiting for photographer response");
            cmd.Parameters.AddWithValue("@photographerName", photographerName);
            cmd.Parameters.AddWithValue("@photographerUsername", photographerUserN);
            cmd.Parameters.AddWithValue("@rating", -1);

            con.Open();
            int a = cmd.ExecuteNonQuery();//0 1
            if (a > 0)
            {
                MessageBox.Show("Data Inserted Successfully ! ");
                guna2TextBox2.Text = "";
                pictureBox2.Image = Properties.Resources.DefaultOrderPhoto;
                guna2TextBox2.Text = "";
                pictureBox2.Image = Properties.Resources.DefaultOrderPhoto;
                ClientForm.Instance.PnlContainer.Controls["ShowPhotographers"].BringToFront();
                ShowPhotographers.Instance.Reset();
            }
            else
            {
                MessageBox.Show("Data not Inserted ! ");
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox2.Image.Save(ms, pictureBox2.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Text = "";
            pictureBox2.Image = Properties.Resources.DefaultOrderPhoto;
            ClientForm.Instance.PnlContainer.Controls["ShowPhotographers"].BringToFront();
            ShowPhotographers.Instance.Reset();
        }
    }
}
