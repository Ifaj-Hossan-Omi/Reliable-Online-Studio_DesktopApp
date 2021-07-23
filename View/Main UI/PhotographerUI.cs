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
using Photographer.View.Main_UI;
using Photographer.View.Panel_UI.Photographer;
using Photographer.View.Panel_UI.SignUp_UI;
using System.Threading;
using Photographer.View.Panel_UI.ForAll;

//using Photographer.View.Panel_UI.Photographer;

namespace Photographer
{
    
    public partial class PhotographerForm : Form
    {
        Thread th;
        private string userName;
        static PhotographerForm _obj;
        

        public static PhotographerForm Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new PhotographerForm();
                }
                return _obj;
            }
        }

        public Panel PnlContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }
        public PhotographerForm()
        {
            _obj = this;
            InitializeComponent();
        }
        public PhotographerForm(string uName)
        {
            _obj = this;
            userName = uName;
            InitializeComponent();
            label1.Text = uName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = userName;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("Orders"))
            {
                Orders un = new Orders(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["Orders"].BringToFront();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("PhotographerProfile"))
            {
                PhotographerProfile un = new PhotographerProfile(userName, "photographerInfo");
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["PhotographerProfile"].BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("DeletAccount"))
            {
                DeletAccount un = new DeletAccount(userName, "photographerInfo");
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("Progress"))
            {
                Progress un = new Progress(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["Progress"].BringToFront();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("AllTaskPhotographer"))
            {
                AllTaskPhotographer un = new AllTaskPhotographer(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["AllTaskPhotographer"].BringToFront();
            AllTaskPhotographer.Instance.BindGridView();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("DeliverTask"))
            {
                DeliverTask un = new DeliverTask(userName);
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["DeliverTask"].BringToFront();
            DeliverTask.Instance.BindGridView();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            if (!this.PnlContainer.Controls.ContainsKey("Report"))
            {
                Report un = new Report(userName, "photographerInfo");
                un.Dock = DockStyle.Fill;
                this.PnlContainer.Controls.Add(un);
            }
            this.PnlContainer.Controls["Report"].BringToFront();
            Report.Instance.Reset();
        }
    }
}
