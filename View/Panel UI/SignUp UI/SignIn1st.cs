using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Photographer.View.Main_UI;

namespace Photographer.View.Panel_UI.SignUp_UI
{
    public partial class SignIn1st : UserControl
    {
        public SignIn1st()
        {
            InitializeComponent();
        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {
            SignUpForm suf = new SignUpForm("photographerInfo");
            suf.Show();
        }

        private void guna2CircleButton4_Click(object sender, EventArgs e)
        {
            SignUpForm suf = new SignUpForm("clientInfo");
            suf.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            LogInForm.Instance.PnlContainer.Controls["LogInUI"].BringToFront();

        }
    }
}
