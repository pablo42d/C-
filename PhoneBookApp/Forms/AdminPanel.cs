/* AdminPanel.cs
   Panel administracyjny do zarządzania pracownikami i działami w aplikacji książki telefonicznej.
   Umożliwia dodawanie, edytowanie i usuwanie pracowników oraz przeglądanie informacji o nich.
*/

using PhoneBookApp.Models;
using PhoneBookApp.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PhoneBookApp.Forms
{
    public partial class AdminPanel : Form
    {
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly DepartmentRepository _departmentRepo = new DepartmentRepository();

        private int _selectedEmployeeId = -1;
        private byte[] _employeePhotoBytes = null;
        private readonly Employee _loggedUser;

        public AdminPanel(Employee emp)
        {
            InitializeComponent();
            _loggedUser = emp;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDepartments();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during AdminPanel load: " + ex.Message);
            }
        }

        // -------------------------
        // Utility: safe cell reader
        // -------------------------
        private object SafeGetCellValue(DataGridViewRow row, string columnName)
        {
            if (row == null || string.IsNullOrEmpty(columnName)) return null;
            if (!dgvEmployees.Columns.Contains(columnName)) return null;
            var val = row.Cells[columnName].Value;
            if (val == null || val == DBNull.Value) return null;
            return val;
        }

        // -------------------------
        // Load departments to combo
        // -------------------------
        private void LoadDepartments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                departments = _departmentRepo.GetAllDepartments() ?? new List<Department>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load departments: " + ex.Message);
            }

            cmbEmpDepartment.DataSource = null;
            cmbEmpDepartment.DataSource = departments;
            cmbEmpDepartment.DisplayMember = "DepartmentName";
            cmbEmpDepartment.ValueMember = "DepartmentID";
        }

        // -------------------------
        // Load employees into grid
        // -------------------------
        private void LoadEmployees()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                employees = _employeeRepo.GetAllEmployees() ?? new List<Employee>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load employees: " + ex.Message);
            }

            dgvEmployees.DataSource = null;
            dgvEmployees.DataSource = employees;

            // hide binary/password fields if present
            if (dgvEmployees.Columns.Contains("Photo"))
                dgvEmployees.Columns["Photo"].Visible = false;
            if (dgvEmployees.Columns.Contains("PasswordHash"))
                dgvEmployees.Columns["PasswordHash"].Visible = false;

            dgvEmployees.ClearSelection();
            _selectedEmployeeId = -1;
            ClearEmployeeForm();
        }

        // -------------------------
        // Clear details area
        // -------------------------
        private void ClearEmployeeForm()
        {
            txtEmpFirstName.Text = "";
            txtEmpLastName.Text = "";
            txtEmpEmail.Text = "";
            txtEmpPhone.Text = "";
            txtEmpMobile.Text = "";
            picEmpPhoto.Image = null;
            _employeePhotoBytes = null;
            if (cmbEmpDepartment.Items.Count > 0)
                cmbEmpDepartment.SelectedIndex = 0;
            _selectedEmployeeId = -1;
        }

        // -------------------------
        // DataGridView click (wired as CellContentClick in Designer)
        // -------------------------
        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure valid row index
            if (e.RowIndex < 0 || e.RowIndex >= dgvEmployees.Rows.Count) return;

            DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];

            // read EmployeeID safely
            var idObj = SafeGetCellValue(row, "EmployeeID");
            if (idObj == null)
            {
                _selectedEmployeeId = -1;
            }
            else
            {
                _selectedEmployeeId = Convert.ToInt32(idObj);
            }

            // populate form fields, using SafeGetCellValue
            txtEmpFirstName.Text = SafeGetCellValue(row, "FirstName")?.ToString() ?? "";
            txtEmpLastName.Text = SafeGetCellValue(row, "LastName")?.ToString() ?? "";
            txtEmpEmail.Text = SafeGetCellValue(row, "Email")?.ToString() ?? "";
            txtEmpPhone.Text = SafeGetCellValue(row, "PhoneNumber")?.ToString() ?? "";
            txtEmpMobile.Text = SafeGetCellValue(row, "MobileNumber")?.ToString() ?? "";

            var deptVal = SafeGetCellValue(row, "DepartmentID");
            if (deptVal != null)
            {
                try
                {
                    cmbEmpDepartment.SelectedValue = Convert.ToInt32(deptVal);
                }
                catch
                {
                    // ignore if selection fails
                }
            }

            // load photo if exists
            var photoObj = SafeGetCellValue(row, "Photo");
            if (photoObj != null && photoObj is byte[] bytes)
            {
                _employeePhotoBytes = bytes;
                try
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        picEmpPhoto.Image = Image.FromStream(ms);
                    }
                }
                catch
                {
                    picEmpPhoto.Image = null;
                }
            }
            else
            {
                picEmpPhoto.Image = null;
                _employeePhotoBytes = null;
            }
        }

        // -------------------------
        // Upload photo button
        // -------------------------
        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picEmpPhoto.Image = Image.FromFile(ofd.FileName);
                        _employeePhotoBytes = File.ReadAllBytes(ofd.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to load image: " + ex.Message);
                    }
                }
            }
        }


        // -------------------------
        // Add employee
        // -------------------------
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeForm()) return;

            var emp = new Employee
            {
                FirstName = txtEmpFirstName.Text.Trim(),
                LastName = txtEmpLastName.Text.Trim(),
                Email = txtEmpEmail.Text.Trim(),
                PhoneNumber = txtEmpPhone.Text.Trim(),
                MobileNumber = txtEmpMobile.Text.Trim(),
                DepartmentID = cmbEmpDepartment.SelectedValue != null ? Convert.ToInt32(cmbEmpDepartment.SelectedValue) : 0,
                Photo = _employeePhotoBytes,
                Username = txtEmpEmail.Text.Trim(),
                PasswordHash = "changeme", // default temporary password
                Role = "Employee"
            };

            try
            {
                int newId = _employeeRepo.AddEmployee(emp);
                if (newId > 0)
                {
                    LoadEmployees();
                    MessageBox.Show("Employee added.");
                }
                else
                {
                    MessageBox.Show("Employee added (no id returned).");
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message);
            }
        }

        // -------------------------
        // Edit employee
        // -------------------------
        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (_selectedEmployeeId == -1)
            {
                MessageBox.Show("Select an employee first.");
                return;
            }

            if (!ValidateEmployeeForm()) return;

            var emp = new Employee
            {
                EmployeeID = _selectedEmployeeId,
                FirstName = txtEmpFirstName.Text.Trim(),
                LastName = txtEmpLastName.Text.Trim(),
                Email = txtEmpEmail.Text.Trim(),
                PhoneNumber = txtEmpPhone.Text.Trim(),
                MobileNumber = txtEmpMobile.Text.Trim(),
                DepartmentID = cmbEmpDepartment.SelectedValue != null ? Convert.ToInt32(cmbEmpDepartment.SelectedValue) : 0,
                Photo = _employeePhotoBytes
            };

            try
            {
                _employeeRepo.UpdateEmployee(emp);
                LoadEmployees();
                MessageBox.Show("Employee updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating employee: " + ex.Message);
            }
        }

        // -------------------------
        // Delete employee
        // -------------------------
        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            if (_selectedEmployeeId == -1)
            {
                MessageBox.Show("Select an employee first.");
                return;
            }

            var result = MessageBox.Show("Delete this employee?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                _employeeRepo.DeleteEmployee(_selectedEmployeeId);
                LoadEmployees();
                MessageBox.Show("Employee deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee: " + ex.Message);
            }
        }

        // -------------------------
        // Simple validation
        // -------------------------
        private bool ValidateEmployeeForm()
        {
            if (string.IsNullOrWhiteSpace(txtEmpFirstName.Text) || txtEmpFirstName.Text.Trim().Length < 2)
            {
                MessageBox.Show("First name is too short.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmpLastName.Text) || txtEmpLastName.Text.Trim().Length < 2)
            {
                MessageBox.Show("Last name is too short.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmpEmail.Text) || !txtEmpEmail.Text.Contains("@"))
            {
                MessageBox.Show("Enter a valid email address.");
                return false;
            }
            return true;
        }

        // -------------------------
        // Empty handlers (wired in Designer)
        // -------------------------
        private void txtEmpFirstName_TextChanged(object sender, EventArgs e) { }
        private void txtEmpLastName_TextChanged(object sender, EventArgs e) { }
        private void txtEmpEmail_TextChanged(object sender, EventArgs e) { }
        private void txtEmpPhone_TextChanged(object sender, EventArgs e) { }
        private void txtEmpMobile_TextChanged(object sender, EventArgs e) { }
        private void cmbEmpDepartment_SelectedIndexChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void panelEmployeeDetails_Paint(object sender, PaintEventArgs e) { }
        private void tabEmployees_Click(object sender, EventArgs e) { }
    }
}








/*
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
using PhoneBookApp.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


namespace PhoneBookApp.Forms
{
    public partial class AdminPanel : Form
    {
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly DepartmentRepository _departmentRepo = new DepartmentRepository();

        private int _selectedEmployeeId = -1;   // Przechowuje ID zaznaczonego pracownika
        private byte[] _employeePhotoBytes = null;  // Przechowuje zdjęcie pracownika w formie bajtów

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
            LoadDepartments();
            LoadEmployees();

        }

        private void tabAdmin_Click(object sender, EventArgs e)
        {

        }

        private void tabEmployees_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {

        }

        private void txtEmpFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {

        }

        private void cmbEmpDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panelEmployeeDetails_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
*/
