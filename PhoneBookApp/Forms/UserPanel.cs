using PhoneBookApp.Models;
using PhoneBookApp.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace PhoneBookApp.Forms
{
    public partial class UserPanel : Form
    {
        private readonly Employee _loggedUser;
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly DepartmentRepository _departmentRepo = new DepartmentRepository();

        public UserPanel(Employee emp)
        {
            InitializeComponent();
            _loggedUser = emp;
        }

        private void UserPanel_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {_loggedUser.FirstName} {_loggedUser.LastName}";
            LoadDepartments();

            // Załaduj zdjęcie użytkownika
            if (_loggedUser.Photo != null)
            {
                using (var ms = new System.IO.MemoryStream(_loggedUser.Photo))
                {
                    picUserPhoto.Image = System.Drawing.Image.FromStream(ms);
                }
            }
        }

        private void LoadDepartments()
        {
            var list = _departmentRepo.GetAllDepartments();
            cmbDepartments.DataSource = list;
            cmbDepartments.DisplayMember = "Name";
            cmbDepartments.ValueMember = "DepartmentId";
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            string lastName = txtSearchLastName.Text.Trim();
            string phone = txtSearchPhone.Text.Trim();

            DataTable results = _employeeRepo.SearchEmployees(lastName, phone);
            dgvResults.DataSource = results;
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartments.SelectedValue is int depId)
            {
                DataTable results = _departmentRepo.GetEmployeesByDepartment(depId);
                tabDepartments.DataSource = results;
            }
        }

        private void btnDownloadBilling_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkcja pobierania billingu dodamy na etapie eksportu CSV/XLS.");
        }

        private void tabUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearchByName_Click_1(object sender, EventArgs e)
        {

        }

        private void txtSearchLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblSearchLastName_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbDepartments_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnDownloadBilling_Click_1(object sender, EventArgs e)
        {

        }
    }
}







/*
 * Oryginal file: Forms/UserPanel.cs
 * 
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
*/
