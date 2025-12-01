using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBookApp.Forms
{
    public partial class UserPanel : Form
    {
        private Employee _loggedUser;

        public UserPanel(Employee emp)
        {
            InitializeComponent();
            _loggedUser = emp;
        }

        //public UserPanel()
        //{
        //    InitializeComponent();
        //}

        private void UserPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
