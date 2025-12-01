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
    public partial class AdminPanel : Form
    {
        private Employee _loggedUser;

        public AdminPanel(Employee emp)
        {
            InitializeComponent();
            _loggedUser = emp;
        }


        //public AdminPanel()
        //{
        //    InitializeComponent();
        //}

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}
