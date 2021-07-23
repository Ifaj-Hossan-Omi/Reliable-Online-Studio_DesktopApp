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
using Photographer.View.Panel_UI.Client;
using Photographer.View.Panel_UI.ForAll;
using Photographer.View.Panel_UI.Photographer;

namespace Photographer.View.Main_UI
{
    public partial class ClientForm : Form
    {

        Thread th;
        private static string userName;
        static ClientForm _obj;


        public static ClientForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new ClientForm();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }


        public ClientForm()
        {
            _obj = this;
            InitializeComponent();
        }
        public ClientForm(string uName)
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
                PhotographerProfile un = new PhotographerProfile(userName, "clientInfo");
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["PhotographerProfile"].BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("DeletAccount"))
            {
                DeletAccount un = new DeletAccount(userName, "clientInfo");
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["DeletAccount"].BringToFront();
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("ShowPhotographers"))
            {
                ShowPhotographers un = new ShowPhotographers(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["ShowPhotographers"].BringToFront();
            ShowPhotographers.Instance.Reset();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("Deliverd_Order"))
            {
                Deliverd_Order un = new Deliverd_Order(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            else
            {
                Deliverd_Order.Instance.Reset();
            }
            this.PnlContainer.Controls["Deliverd_Order"].BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("AllTask"))
            {
                AllTask un = new AllTask(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["AllTask"].BringToFront();
            AllTask.Instance.BindGridView();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("Report"))
            {
                Report un = new Report(userName, "clientInfo");
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["Report"].BringToFront();
            Report.Instance.Reset();
        }
    }
}
