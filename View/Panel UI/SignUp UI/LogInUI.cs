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

namespace Photographer.View.Panel_UI.SignUp_UI
{
    public partial class LogInUI : UserControl
    {
        public string among;
        public string clientFix;
        private string userN;
        Thread th;
        private string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public LogInUI()
        {
            InitializeComponent();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                among = guna2TextBox1.Text;
                string query = "select * from photographerInfo where username=@user and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", among);
                cmd.Parameters.AddWithValue("@pass", guna2TextBox2.Text);
                userN = guna2TextBox1.Text.ToString();


                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    con.Close();

                    LogInForm.Instance.Close();
                    th = new Thread(opennewphotographerForm);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }

                con.Close();
                query = "select * from clientInfo where username=@user and pass = @pass";
                clientFix = guna2TextBox1.Text;
                SqlCommand cmd2 = new SqlCommand(query, con);
                cmd2.Parameters.AddWithValue("@user", clientFix);
                cmd2.Parameters.AddWithValue("@pass", guna2TextBox2.Text);
                userN = guna2TextBox1.Text.ToString();

                con.Open();
                SqlDataReader dr2 = cmd2.ExecuteReader();
                if (dr2.HasRows == true)
                {
                    con.Close();

                    LogInForm.Instance.Close();
                    th = new Thread(opennewClientForm);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }

                con.Close();
                query = "select * from staffInfo where username=@user and pass = @pass";
                SqlCommand cmd3 = new SqlCommand(query, con);
                cmd3.Parameters.AddWithValue("@user", guna2TextBox1.Text);
                cmd3.Parameters.AddWithValue("@pass", guna2TextBox2.Text);
                userN = guna2TextBox1.Text.ToString();

                con.Open();
                SqlDataReader dr3 = cmd3.ExecuteReader();
                if (dr3.HasRows == true)
                {
                    con.Close();

                    LogInForm.Instance.Close();
                    th = new Thread(opennewStaffForm);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }

                else
                {
                    MessageBox.Show("Loing Failed");
                }
                con.Close();

            }
            else
            {
                MessageBox.Show("Enter login informations please!");
            }
        }

        public void opennewphotographerForm(object obj)
        {
            Application.Run(new PhotographerForm(among));
        }

        public void opennewClientForm(object obj)
        {
            Application.Run(new ClientForm(clientFix));
        }
        public void opennewStaffForm(object obj)
        {
            Application.Run(new StaffForm(userN));
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (!LogInForm.Instance.PnlContainer.Controls.ContainsKey("SignIn1st"))
            {
                SignIn1st un = new SignIn1st();
                un.Dock = DockStyle.Fill;
                LogInForm.Instance.PnlContainer.Controls.Add(un);
            }
            LogInForm.Instance.PnlContainer.Controls["SignIn1st"].BringToFront();
        }

        private void guna2TextBox1_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "Username")
                guna2TextBox1.Clear();
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text == "")
                guna2TextBox1.Text = "Username";
        }

        private void guna2TextBox2_Enter(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "Password")
            {
                guna2TextBox2.Clear();
                guna2TextBox2.UseSystemPasswordChar = true;
            }
        }

        private void guna2TextBox2_Leave(object sender, EventArgs e)
        {
            if (guna2TextBox2.Text == "")
            {
                guna2TextBox2.UseSystemPasswordChar = false;
                guna2TextBox2.Text = "Password";
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
