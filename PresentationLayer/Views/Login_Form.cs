using DomainLayer.Models.User;
using ServicesLayer;
using ServicesLayer.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class Login_Form : Form
    {
        private IServicesManager _servicesManager;
        public Login_Form(IServicesManager servicesManager)
        {
            _servicesManager = servicesManager;
            InitializeComponent();
        }

        private void Login_Form_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var userModel = await _servicesManager.UserServices
                .Login(Login_Username.Text, Login_Pass.Text);
            var dashboard = new Employee_Dashboard(userModel, _servicesManager);
            this.Hide();
            dashboard.Show();
        }
    }
}
