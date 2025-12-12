using PhoneBookApp.Data;
using PhoneBookApp.Models;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Drawing;


namespace PhoneBookApp.Forms
{
    public partial class UserPanel : Form
    {
        private readonly Employee _loggedUser;
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly DepartmentRepository _departmentRepo = new DepartmentRepository();
        private DataGridView dgvSearchResults;
        private TextBox txtSearchName;

        public UserPanel(Employee emp)
        {
            InitializeComponent();
            dgvSearchResults = dgvResults; // temporary mapping if you prefer keeping the old name
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
            var deps = _departmentRepo.GetAllDepartments();
            cmbSearchDepartment.SelectedIndexChanged -= cmbSearchDepartment_SelectedIndexChanged_1;
            cmbSearchDepartment.DisplayMember = "DepartmentName";
            cmbSearchDepartment.ValueMember = "DepartmentID";
            cmbSearchDepartment.DataSource = deps;
            cmbSearchDepartment.SelectedIndex = -1;
            cmbSearchDepartment.SelectedIndexChanged += cmbSearchDepartment_SelectedIndexChanged_1;
        }

        //private void btnSearchByName_Click(object sender, EventArgs e)
        //{
        //    string lastName = txtSearchLastName.Text.Trim();
        //    string phone = txtSearchPhone.Text.Trim();

        //    DataTable results = _employeeRepo.SearchEmployees(lastName, phone);
        //    dgvResults.DataSource = results;
        //}

        private void btnSearchByName_Click_1(object sender, EventArgs e)
        {
            string text = txtSearchLastName.Text.Trim();    // use designer name
            string phone = txtSearchPhone.Text.Trim();

            var results = _employeeRepo.Search(text, phone);
            dgvResults.DataSource = results;
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    string text = txtSearchName.Text.Trim();
        //    string phone = txtSearchPhone.Text.Trim();

        //    var results = _employeeRepo.Search(text, phone);
        //    dgvSearchResults.DataSource = results;
        //}

        //private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //if (cmbDepartments.SelectedValue is int depId)
        //{
        //    DataTable results = _departmentRepo.GetEmployeesByDepartment(depId);
        //    tabDepartments.DataSource = results;
        //}            
        //}

        //private void cmbSearchDepartment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmbSearchDepartment.SelectedIndex < 0) return;

        //    int depId = (int)cmbSearchDepartment.SelectedValue;
        //    dgvSearchResults.DataSource = _employeeRepo.GetEmployeesByDepartment(depId);
        //}


        private void btnDownloadBilling_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funkcja pobierania billingu dodamy na etapie eksportu CSV/XLS.");
        }

        private void tabUser_TextChanged(object sender, EventArgs e)
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

        private void btnDownloadBilling_Click_1(object sender, EventArgs e)
        {

        }
        private void LoadUserPhoto()
        {
            if (_loggedUser.Photo != null)
            {
                using (MemoryStream ms = new MemoryStream(_loggedUser.Photo))
                {
                    picUserPhoto.Image = Image.FromStream(ms);
                }
            }
        }

        // Zmień zdjęcie użytkownika po wyborze nowego pliku
        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.jpg;*.png;*.jpeg;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = File.ReadAllBytes(ofd.FileName);
                _employeeRepo.UpdatePhoto(_loggedUser.EmployeeID, bytes);

                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    picUserPhoto.Image = Image.FromStream(ms);
                }

                MessageBox.Show("Photo updated.");
            }
        }

        private void cmbSearchDepartment_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbSearchDepartment.SelectedIndex < 0) return;

            object val = cmbSearchDepartment.SelectedValue;
            if (val == null) return;

            int depId;
            if (val is int i) depId = i;
            else if (val is PhoneBookApp.Models.Department d) depId = d.DepartmentID;
            else if (!int.TryParse(val.ToString(), out depId)) return;

            var results = _employeeRepo.GetEmployeesWithPhonesByDepartment(depId);
            dgvResults.DataSource = results;
        }

        private void tabSearch_Click(object sender, EventArgs e)
        {

        }

        private void dgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void picUserPhoto_Click(object sender, EventArgs e)
        {

        }

        private void btnDwlBilling_Click(object sender, EventArgs e)
        {

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Otwórz formularz zmiany hasła
            ChangePasswordForm cpf = new ChangePasswordForm(_loggedUser);
            cpf.ShowDialog();

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
