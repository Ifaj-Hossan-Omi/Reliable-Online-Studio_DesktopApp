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
using Guna.UI2.WinForms;
using Photographer.View.Panel_UI.SignUp_UI;

namespace Photographer.View.Main_UI
{
    public partial class LogInForm : Form
    {

        static LogInForm _obj;

        public static LogInForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new LogInForm();
                }
                return _obj;
            }
        }

        public Guna2CustomGradientPanel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }


        public LogInForm()
        {
            InitializeComponent();
        }

        

        private void LogInForm_Load(object sender, EventArgs e)
        {
            _obj = this;

            LogInUI uc = new LogInUI();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panelContainer.Controls["LogInUi"].BringToFront();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }



        //start

        //private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;




        //private void guna2TextBox1_Enter(object sender, EventArgs e)
        //{
        //    if (guna2TextBox1.Text == "Username")
        //        guna2TextBox1.Clear();
        //}

        //private void guna2TextBox1_Leave(object sender, EventArgs e)
        //{
        //    if (guna2TextBox1.Text == "")
        //        guna2TextBox1.Text = "Username";
        //}

        //private void guna2TextBox2_Enter(object sender, EventArgs e)
        //{
        //    if (guna2TextBox2.Text == "Password")
        //    {
        //        guna2TextBox2.Clear();
        //        guna2TextBox2.UseSystemPasswordChar = true;
        //    }
        //}

        //private void guna2TextBox2_Leave(object sender, EventArgs e)
        //{
        //    if (guna2TextBox2.Text == "")
        //    {
        //        guna2TextBox2.UseSystemPasswordChar = false;
        //        guna2TextBox2.Text = "Password";
        //    }
        //}

        //private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void guna2GradientButton1_Click(object sender, EventArgs e)
        //{
        //    if (guna2TextBox1.Text != "" && guna2ControlBox2.Text != "")
        //    {
        //        SqlConnection con = new SqlConnection(cs);
        //        string query = "select * from photographerInfo where username=@user and pass = @pass";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        cmd.Parameters.AddWithValue("@user", guna2TextBox1.Text);
        //        cmd.Parameters.AddWithValue("@pass", guna2TextBox2.Text);

        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows == true)
        //        {
        //            this.Hide();
        //            PhotographerForm pf = new PhotographerForm(guna2ControlBox1.Text);
        //            pf.Show();

        //        }
        //        else
        //        {
        //            MessageBox.Show("Loing Failed");
        //        }
        //        con.Close();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Enter login informations please!");
        //    }
        //}

        //private void label2_Click(object sender, EventArgs e)
        //{

        //}

        //private void guna2CircleButton1_Click(object sender, EventArgs e)
        //{

        //}

        //private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        //{

        //}


        //Finish
    }
}
