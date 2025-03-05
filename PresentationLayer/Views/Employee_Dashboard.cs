using DomainLayer.Models.User;
using ServicesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    
    public partial class Employee_Dashboard : Form
    {
        private IUserModel _currentUser;
        private IServicesManager _servicesManager;
        public Employee_Dashboard(IUserModel currentUser, IServicesManager servicesManager)
        {
            _currentUser = currentUser;
            _servicesManager = servicesManager;
            InitializeComponent();
        }

      
    }
}
