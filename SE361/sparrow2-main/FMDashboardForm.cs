using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoginForm
{
    public partial class FMDashboardForm : Form
    {
        private clsUser objUser;
        private HomePage hPage;
        private clsClaims objClaim;

        SettingsForm settings;
        MessagesForm messages;
        CalcEstimate calc;
        DocumentsForm documents;
        ScheduleForm schedule;
        ViewClients carousel;

        public FMDashboardForm()
        {
            InitializeComponent();
        }

        public FMDashboardForm(clsUser user, HomePage h)
        {
            objUser = user;
            hPage = h;
            InitializeComponent();
            user.getProfileInformation();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settings = new SettingsForm(objUser, hPage);
            hPage.loadMainDisplay(settings);
        }

        private void btnClaims_Click(object sender, EventArgs e)
        {
            calc = new CalcEstimate(objUser, objClaim, hPage);
            hPage.loadMainDisplay(calc);
        }

        private void btnDocuments_Click(object sender, EventArgs e)
        {
            documents = new DocumentsForm(objUser, hPage);
            hPage.loadMainDisplay(documents);
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            schedule = new ScheduleForm(objUser, hPage);
            hPage.loadMainDisplay(schedule);
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            messages = new MessagesForm(objUser, hPage);
            hPage.loadMainDisplay(messages);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            carousel = new ViewClients(objUser, hPage);
            hPage.loadMainDisplay(carousel);
        }

        private void FMDashboardForm_Load(object sender, EventArgs e)
        {
            lblName.Text = objUser.firstName + " " + objUser.lastName;

            switch (objUser.Role)
            {
                case "CL":
                    lblRole.Text = "Client";
                    break;
                case "CM":
                    lblRole.Text = "Claim Manager";
                    break;
                case "FM":
                    lblRole.Text = "Finance Manager";
                    break;
                case "AD":
                    lblRole.Text = "Admin";
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
