using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Photographer.View.Panel_UI.Photographer;
using Photographer.View.Panel_UI.Staff;

namespace Photographer.View.Main_UI
{
    public partial class StaffForm : Form
    {
        Thread th;
        private static string userName;
        static StaffForm _obj;


        public static StaffForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new StaffForm();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }


        public StaffForm()
        {
            _obj = this;
            InitializeComponent();
        }
        public StaffForm(string uName)
        {
            _obj = this;
            userName = uName;
            InitializeComponent();
            label1.Text = uName;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("PhotographerProfile"))
            {
                PhotographerProfile un = new PhotographerProfile(userName, "staffInfo");
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["PhotographerProfile"].BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SignUpForm suf = new SignUpForm("staffInfo");
            suf.Show();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("ShowPhotographers"))
            {
                ShowPhotographers un = new ShowPhotographers();
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["ShowPhotographers"].BringToFront();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("ShowClients"))
            {
                ShowClients un = new ShowClients();
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["ShowClients"].BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("ManageComplain"))
            {
                ManageComplain un = new ManageComplain(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["ManageComplain"].BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public void opennewform(object obj)
        {
            Application.Run(new LogInForm());
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("AllReplies"))
            {
                AllReplies un = new AllReplies(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["AllReplies"].BringToFront();
        }
    }
}
