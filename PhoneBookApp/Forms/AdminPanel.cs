/* AdminPanel.cs
    Panel administracyjny do zarządzania pracownikami, działami i urządzeniami.
    Umożliwia dodawanie, edytowanie i usuwanie rekordów oraz import danych rozliczeniowych.
*/


// --- Wymagane referencje do klas systemowych i klas projektu ---
using PhoneBookApp.Data;   // Zapewnia dostęp do klas: EmployeeRepository, DepartmentRepository, DeviceRepository, BillingImporter
// 
using PhoneBookApp.Models; // Zapewnia dostęp do klas: Employee, Department, Device
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// -------------------------------------------------------------------


namespace PhoneBookApp.Forms
{
    // Usunięto fikcyjne definicje klas. Klasa dziedziczy z Form.
    public partial class AdminPanel : Form
    {
        // Tutaj powinny się znajdować rzeczywiste repozytoria
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly DepartmentRepository _departmentRepo = new DepartmentRepository();
        private readonly DeviceRepository _deviceRepo = new DeviceRepository();

        private int _selectedEmployeeId = -1;
        private byte[] _employeePhotoBytes = null;
        private readonly Employee _loggedUser;

        private int _selectedDepartmentId = -1;
        private int _selectedDeviceId = -1;


        public AdminPanel(Employee emp)
        {
            InitializeComponent();
            _loggedUser = emp;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDepartmentsForEmployeesCombo();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during AdminPanel load: " + ex.Message);
            }
        }

        // --- Utility ---

        private object SafeGetCellValue(DataGridViewRow row, string columnName)
        {
            if (row == null || string.IsNullOrEmpty(columnName)) return null;
            if (!dgvEmployees.Columns.Contains(columnName)) return null;
            var val = row.Cells[columnName].Value;
            if (val == null || val == DBNull.Value) return null;
            return val;
        }

        private void tabAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabAdmin.SelectedTab == tabDepartments)
            {
                LoadDepartments();
            }
            else if (tabAdmin.SelectedTab == tabDevices)
            {
                LoadDevices();
                LoadEmployeesForDevicesCombo();
            }
        }

        // --- EMPLOYEES Tab ---

        private void LoadDepartmentsForEmployeesCombo()
        {
            List<Department> departments = new List<Department>();
            try
            {
                departments = _departmentRepo.GetAllDepartments() ?? new List<Department>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load departments for combo: " + ex.Message);
            }

            departments.Insert(0, new Department { DepartmentID = 0, DepartmentName = "-- Select Department --" });

            cmbEmpDepartment.DataSource = null;
            cmbEmpDepartment.DataSource = departments;
            cmbEmpDepartment.DisplayMember = "DepartmentName";
            cmbEmpDepartment.ValueMember = "DepartmentID";
        }


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

            if (dgvEmployees.Columns.Contains("Photo"))
                dgvEmployees.Columns["Photo"].Visible = false;
            if (dgvEmployees.Columns.Contains("PasswordHash"))
                dgvEmployees.Columns["PasswordHash"].Visible = false;

            dgvEmployees.ClearSelection();
            _selectedEmployeeId = -1;
            ClearEmployeeForm();
        }

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
                cmbEmpDepartment.SelectedValue = 0;
            _selectedEmployeeId = -1;
        }

        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvEmployees.Rows.Count) return;

            DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];

            var idObj = SafeGetCellValue(row, "EmployeeID");
            if (idObj == null)
            {
                _selectedEmployeeId = -1;
            }
            else
            {
                _selectedEmployeeId = Convert.ToInt32(idObj);
            }

            txtEmpFirstName.Text = SafeGetCellValue(row, "FirstName")?.ToString() ?? "";
            txtEmpLastName.Text = SafeGetCellValue(row, "LastName")?.ToString() ?? "";
            txtEmpEmail.Text = SafeGetCellValue(row, "Email")?.ToString() ?? "";
            txtEmpPhone.Text = SafeGetCellValue(row, "PhoneNumber")?.ToString() ?? "";
            txtEmpMobile.Text = SafeGetCellValue(row, "MobileNumber")?.ToString() ?? "";

            var deptVal = SafeGetCellValue(row, "DepartmentID");
            if (deptVal != null && Convert.ToInt32(deptVal) > 0)
            {
                try
                {
                    cmbEmpDepartment.SelectedValue = Convert.ToInt32(deptVal);
                }
                catch { cmbEmpDepartment.SelectedValue = 0; }
            }
            else
            {
                cmbEmpDepartment.SelectedValue = 0;
            }

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
                DepartmentID = cmbEmpDepartment.SelectedValue != null && Convert.ToInt32(cmbEmpDepartment.SelectedValue) > 0 ? Convert.ToInt32(cmbEmpDepartment.SelectedValue) : 0,
                Photo = _employeePhotoBytes,
                Username = txtEmpEmail.Text.Trim(),
                PasswordHash = "Welcome",
                Role = "Employee"
            };

            try
            {
                int newId = _employeeRepo.AddEmployee(emp);
                LoadEmployees();
                MessageBox.Show("Employee added (ID: " + newId + ").");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message);
            }
        }

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
                DepartmentID = cmbEmpDepartment.SelectedValue != null && Convert.ToInt32(cmbEmpDepartment.SelectedValue) > 0 ? Convert.ToInt32(cmbEmpDepartment.SelectedValue) : 0,
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

        // --- DEPARTMENTS Tab ---

        private void LoadDepartments()
        {
            try
            {
                var list = _departmentRepo.GetAllDepartments() ?? new List<Department>();
                dgvDepartments.DataSource = list;
                dgvDepartments.ClearSelection();
                ClearDepartmentForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void ClearDepartmentForm()
        {
            txtDeptName.Text = "";
            txtDeptDescription.Text = "";
            _selectedDepartmentId = -1;
        }

        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDepartments.Rows.Count) return;

            DataGridViewRow row = dgvDepartments.Rows[e.RowIndex];

            if (row.Cells["DepartmentID"].Value != null)
            {
                _selectedDepartmentId = Convert.ToInt32(row.Cells["DepartmentID"].Value);
                txtDeptName.Text = row.Cells["DepartmentName"].Value?.ToString() ?? "";
                txtDeptDescription.Text = row.Cells["Description"].Value?.ToString() ?? "";
            }
            else
            {
                ClearDepartmentForm();
            }
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("Department name is required.");
                return;
            }

            Department dep = new Department
            {
                DepartmentName = txtDeptName.Text.Trim(),
                Description = txtDeptDescription.Text.Trim()
            };

            try
            {
                _departmentRepo.AddDepartment(dep);
                LoadDepartments();
                LoadDepartmentsForEmployeesCombo();
                MessageBox.Show("Department added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding department: " + ex.Message);
            }
        }

        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            if (_selectedDepartmentId == -1)
            {
                MessageBox.Show("Select a department first.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDeptName.Text))
            {
                MessageBox.Show("Department name is required.");
                return;
            }

            Department dep = new Department
            {
                DepartmentID = _selectedDepartmentId,
                DepartmentName = txtDeptName.Text.Trim(),
                Description = txtDeptDescription.Text.Trim()
            };

            try
            {
                _departmentRepo.UpdateDepartment(dep);
                LoadDepartments();
                LoadDepartmentsForEmployeesCombo();
                MessageBox.Show("Department updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating department: " + ex.Message);
            }
        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (_selectedDepartmentId == -1)
            {
                MessageBox.Show("Select a department first.");
                return;
            }

            var result = MessageBox.Show("Delete this department? (Employees in this department might be affected)", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                _departmentRepo.DeleteDepartment(_selectedDepartmentId);
                LoadDepartments();
                LoadDepartmentsForEmployeesCombo();
                MessageBox.Show("Department deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting department: " + ex.Message);
            }
        }

        // --- DEVICES Tab ---

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void LoadEmployeesForDevicesCombo()
        {
            List<Employee> employees = new List<Employee>();
            try
            {
                // Musimy mieć pewność, że GetAllEmployees zwraca listę, którą możemy rzutować/używać
                employees = _employeeRepo.GetAllEmployees() ?? new List<Employee>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load employees for device combo: " + ex.Message);
                return;
            }

            // Mapowanie na obiekt anonimowy do wyświetlania pełnego imienia i nazwiska
            var empList = employees
                .Select(e => new
                {
                    EmployeeID = e.EmployeeID,
                    FullName = $"{e.FirstName} {e.LastName}"
                })
                .ToList();

            // Dodaj pusty element na początek
            empList.Insert(0, new { EmployeeID = -1, FullName = "-- Unassigned --" });


            cmbDevEmployee.DataSource = null;
            cmbDevEmployee.DataSource = empList;
            cmbDevEmployee.DisplayMember = "FullName";
            cmbDevEmployee.ValueMember = "EmployeeID";
        }

        private void LoadDevices()
        {
            try
            {
                dgvDevices.DataSource = _deviceRepo.GetAllDevices();
                dgvDevices.ClearSelection();
                ClearDeviceForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading devices: " + ex.Message);
            }
        }

        private void ClearDeviceForm()
        {
            txtDevSerial.Text = "";
            txtDevInventory.Text = "";
            txtDevModel.Text = "";
            txtDevIMEI.Text = "";
            txtDevMAC.Text = "";
            txtDevLocation.Text = "";
            txtDevNotes.Text = "";
            cmbDevType.SelectedIndex = -1;
            cmbDevStatus.SelectedIndex = -1;
            cmbDevEmployee.SelectedValue = -1;
            dtpDevIssue.Value = DateTime.Now;
            dtpDevReplace.Value = DateTime.Now;
            chkDevMDM.Checked = false;
            _selectedDeviceId = -1;
        }

        private void dgvDevices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDevices.Rows.Count) return;
            DataGridViewRow row = dgvDevices.Rows[e.RowIndex];

            if (row.Cells["DeviceID"].Value != null)
            {
                _selectedDeviceId = Convert.ToInt32(row.Cells["DeviceID"].Value);
                txtDevSerial.Text = row.Cells["SerialNumber"].Value?.ToString() ?? "";
                txtDevInventory.Text = row.Cells["InventoryNumber"].Value?.ToString() ?? "";
                txtDevModel.Text = row.Cells["Model"].Value?.ToString() ?? "";
                txtDevIMEI.Text = row.Cells["IMEI"].Value?.ToString() ?? "";
                txtDevMAC.Text = row.Cells["MACAddress"].Value?.ToString() ?? "";
                txtDevLocation.Text = row.Cells["Location"].Value?.ToString() ?? "";
                txtDevNotes.Text = row.Cells["Notes"].Value?.ToString() ?? "";

                cmbDevType.Text = row.Cells["DeviceType"].Value?.ToString();
                cmbDevStatus.Text = row.Cells["DeviceStatus"].Value?.ToString();

                var empId = row.Cells["EmployeeID"].Value;
                cmbDevEmployee.SelectedValue = (empId != null && empId != DBNull.Value) ? Convert.ToInt32(empId) : -1;

                // Użycie DateTime? (Nullable DateTime) dla pól IssueDate i ReplacementDate
                if (row.Cells["IssueDate"].Value is DateTime issueDate)
                    dtpDevIssue.Value = issueDate;
                else
                    dtpDevIssue.Value = DateTime.Now; // Ustaw domyślnie, jeśli DBNull

                if (row.Cells["ReplacementDate"].Value is DateTime replaceDate)
                    dtpDevReplace.Value = replaceDate;
                else
                    dtpDevReplace.Value = DateTime.Now; // Ustaw domyślnie, jeśli DBNull

                if (row.Cells["HasMDM"].Value is bool hasMdm)
                    chkDevMDM.Checked = hasMdm;
                else
                    chkDevMDM.Checked = false;

            }
            else
            {
                ClearDeviceForm();
            }
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDevSerial.Text) || string.IsNullOrWhiteSpace(cmbDevType.Text))
            {
                MessageBox.Show("Serial Number and Device Type are required.");
                return;
            }

            int? employeeId = (cmbDevEmployee.SelectedValue != null && Convert.ToInt32(cmbDevEmployee.SelectedValue) != -1)
                ? Convert.ToInt32(cmbDevEmployee.SelectedValue)
                : (int?)null;

            // Użycie wartości null dla dat, jeśli są ustawione na domyślne (DateTime.Min, DateTime.Now)
            DateTime? issueDate = (dtpDevIssue.Checked) ? (DateTime?)dtpDevIssue.Value : null;
            DateTime? replaceDate = (dtpDevReplace.Checked) ? (DateTime?)dtpDevReplace.Value : null;


            Device dev = new Device
            {
                SerialNumber = txtDevSerial.Text.Trim(),
                InventoryNumber = txtDevInventory.Text.Trim(),
                EmployeeID = employeeId,
                DeviceType = cmbDevType.Text,
                Model = txtDevModel.Text,
                IMEI = txtDevIMEI.Text,
                MACAddress = txtDevMAC.Text,
                // Poprawka: przekazujemy DateTime? (Nullable) do repozytorium
                IssueDate = dtpDevIssue.Value,
                ReplacementDate = dtpDevReplace.Value,
                HasMDM = chkDevMDM.Checked,
                DeviceStatus = cmbDevStatus.Text,
                Notes = txtDevNotes.Text
            };

            try
            {
                _deviceRepo.AddDevice(dev); // Lini 653, błąd CS1503 - już naprawiony w repozytorium (DeviceRepository)
                LoadDevices();
                MessageBox.Show("Device added.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding device: " + ex.Message);
            }
        }

        private void btnEditDevice_Click(object sender, EventArgs e)
        {
            if (_selectedDeviceId == -1)
            {
                MessageBox.Show("Select a device first.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDevSerial.Text) || string.IsNullOrWhiteSpace(cmbDevType.Text))
            {
                MessageBox.Show("Serial Number and Device Type are required.");
                return;
            }

            int? employeeId = (cmbDevEmployee.SelectedValue != null && Convert.ToInt32(cmbDevEmployee.SelectedValue) != -1)
                ? Convert.ToInt32(cmbDevEmployee.SelectedValue)
                : (int?)null;

            // Użycie DateTime? (Nullable) dla dat
            DateTime? issueDate = (dtpDevIssue.Checked) ? (DateTime?)dtpDevIssue.Value : null;
            DateTime? replaceDate = (dtpDevReplace.Checked) ? (DateTime?)dtpDevReplace.Value : null;

            Device dev = new Device
            {
                DeviceID = _selectedDeviceId,
                SerialNumber = txtDevSerial.Text.Trim(),
                InventoryNumber = txtDevInventory.Text.Trim(),
                EmployeeID = employeeId,
                DeviceType = cmbDevType.Text,
                Model = txtDevModel.Text,
                IMEI = txtDevIMEI.Text,
                MACAddress = txtDevMAC.Text,
                // Poprawka: przekazujemy DateTime? (Nullable) do repozytorium
                IssueDate = dtpDevIssue.Value,
                ReplacementDate = dtpDevReplace.Value,
                HasMDM = chkDevMDM.Checked,
                DeviceStatus = cmbDevStatus.Text,
                Notes = txtDevNotes.Text
            };

            try
            {
                _deviceRepo.UpdateDevice(dev);
                LoadDevices();
                MessageBox.Show("Device updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating device: " + ex.Message);
            }
        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (_selectedDeviceId == -1)
            {
                MessageBox.Show("Select a device first.");
                return;
            }

            var result = MessageBox.Show("Delete this device?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != DialogResult.Yes) return;

            try
            {
                _deviceRepo.DeleteDevice(_selectedDeviceId);
                LoadDevices();
                MessageBox.Show("Device deleted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting device: " + ex.Message);
            }
        }

        // --- BILLING Tab ---

        private void btnBillingBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Billing Files|*.01X;*.01Y;*.csv|All Files|*.*";
                ofd.Title = "Select Billing File";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtBillingFile.Text = ofd.FileName;
                }
            }
        }

        private void btnImportBilling_Click(object sender, EventArgs e)
        {
            string file = txtBillingFile.Text;
            if (!File.Exists(file))
            {
                MessageBox.Show("Select a valid file first.");
                return;
            }

            try
            {
                BillingImporter importer = new BillingImporter();
                importer.Import(file);
                MessageBox.Show("Billing imported successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing billing: " + ex.Message);
            }
        }
        // dodaj deklarację repozytorium:
        private readonly BillingRepository _billingRepo = new BillingRepository(); // Dodaj lub upewnij się, że istnieje

        // Metoda do ładowania danych bilingowych w zadanym zakresie
        private void btnLoadBilling_Click(object sender, EventArgs e)
        {
            // Weryfikacja dat
            if (dtpBillingFrom.Value.Date > dtpBillingTo.Value.Date)
            {
                MessageBox.Show("Start date cannot be later than end date.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Pobierz dane dla wszystkich pracowników w zakresie
                DataTable dt = _billingRepo.GetBillingByDateRange(dtpBillingFrom.Value, dtpBillingTo.Value);

                dgvAllBilling.DataSource = dt;

                if (dgvAllBilling.Columns.Contains("CallCost"))
                {
                    // Formatowanie na walutę (C2), aby koszt wyglądał czytelniej
                    dgvAllBilling.Columns["CallCost"].DefaultCellStyle.Format = "C2";
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No billing data found in the selected range.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading billing data: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Metoda eksportu danych z DataGridView do CSV (możesz użyć tej samej metody co w UserPanel.cs)
        private void btnExportBilling_Click(object sender, EventArgs e)
        {
            if (dgvAllBilling.Rows.Count == 0 || dgvAllBilling.DataSource == null)
            {
                MessageBox.Show("No data loaded to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"Billing_Report_{dtpBillingFrom.Value:yyyyMMdd}_to_{dtpBillingTo.Value:yyyyMMdd}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Wywołanie metody pomocniczej do eksportu DataGridView do CSV
                        ExportToCsv(dgvAllBilling, sfd.FileName);
                        MessageBox.Show("Billing report successfully exported to CSV.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Metoda pomocnicza ExportToCsv (jeśli jeszcze jej nie masz w AdminPanel.cs)
        private void ExportToCsv(DataGridView dgv, string filePath)
        {
            // Upewnij się, że masz using System.Text; i using System.IO; na początku pliku
            StringBuilder sb = new StringBuilder();

            // Nagłówki kolumn
            IEnumerable<string> columnNames = dgv.Columns.Cast<DataGridViewColumn>().Select(column => column.HeaderText);
            sb.AppendLine(string.Join(";", columnNames));

            // Wiersze danych
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                IEnumerable<string> fields = row.Cells.Cast<DataGridViewCell>()
                    .Select(cell => cell.Value?.ToString().Replace(";", ",") ?? "");

                sb.AppendLine(string.Join(";", fields));
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }


        // --- Empty/Designer Handlers ---

        private void txtEmpFirstName_TextChanged(object sender, EventArgs e) { }
        private void txtEmpLastName_TextChanged(object sender, EventArgs e) { }
        private void txtEmpEmail_TextChanged(object sender, EventArgs e) { }
        private void txtEmpPhone_TextChanged(object sender, EventArgs e) { }
        private void txtEmpMobile_TextChanged(object sender, EventArgs e) { }
        private void cmbEmpDepartment_SelectedIndexChanged(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { } // picEmpPhoto_Click
        private void panelEmployeeDetails_Paint(object sender, PaintEventArgs e) { }
        private void tabEmployees_Click(object sender, EventArgs e) { }

        private void tabBilling_Click(object sender, EventArgs e)
        {

        }

        private void lblBillingRange_Click(object sender, EventArgs e)
        {

        }

        private void dtpBillingFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpBillingTo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}





//--------------------------------------------------------------------------------------------------
/*
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
        private const string V = "Human Resources";
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly DepartmentRepository _departmentRepo = new DepartmentRepository();

        private int _selectedEmployeeId = -1;
        private byte[] _employeePhotoBytes = null;
        private readonly Employee _loggedUser;
        private readonly DeviceRepository _deviceRepo = new DeviceRepository();


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

        // Znajduje kontrolkę typu T po nazwie wewnątrz formularza (rekursywnie)
        private T FindControl<T>(string name) where T : Control
        {
            var ctrls = this.Controls.Find(name, true);
            if (ctrls != null && ctrls.Length > 0)
                return ctrls[0] as T;
            return null;
        }


        // -------------------------
        // Load departments to combo
        // -------------------------
        //private void LoadDepartments()
        //{
        //    List<Department> departments = new List<Department>();
        //    try
        //    {
        //        departments = _departmentRepo.GetAllDepartments() ?? new List<Department>();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Failed to load departments: " + ex.Message);
        //    }

        //    cmbEmpDepartment.DataSource = null;
        //    cmbEmpDepartment.DataSource = departments;
        //    cmbEmpDepartment.DisplayMember = "DepartmentName";
        //    cmbEmpDepartment.ValueMember = "DepartmentID";
        //}

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
                PasswordHash = "Welcome", // default temporary password changeme
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
        private void tabAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabAdmin.SelectedTab == tabDepartments)
            {
                LoadDepartments();
            }
            else if (tabAdmin.SelectedTab == tabDevices)
            {
                LoadDevices();
            }
        }


        private void LoadDepartments()
        {
            var dgv = FindControl<DataGridView>("dgvDepartments");
            if (dgv == null)
            {
                // Designer jeszcze nie ma dgvDepartments — nic nie rób (ale nie wywołuj błędu)
                return;
            }

            try
            {
                var list = _department_repo_safe();
                dgv.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        // helper that returns departments or empty list (keeps original repo usage)
        private List<Department> _department_repo_safe()
        {
            try
            {
                return _departmentRepo.GetAllDepartments() ?? new List<Department>();
            }
            catch
            {
                return new List<Department>();
            }
        }


        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a department first.");
                return;
            }
            int deptId = Convert.ToInt32(dgvDepartments.SelectedRows[0].Cells["DepartmentID"].Value);
            Department dep = new Department
            {
                DepartmentID = deptId,
                DepartmentName = txtDeptName.Text.Trim(),
                Description = txtDeptDescription.Text.Trim()
            };
            _departmentRepo.UpdateDepartment(dep);
            LoadDepartments();

        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (dgvDepartments.SelectedRows.Count == 0) return;

            int id = (int)dgvDepartments.SelectedRows[0].Cells["DepartmentID"].Value;

            _departmentRepo.DeleteDepartment(id);
            LoadDepartments();

        }

        private void LoadDevices()
        {
            dgvDevices.DataSource = _deviceRepo.GetAllDevices();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            Device dev = new Device
            {
                SerialNumber = txtDevSerial.Text.Trim(),
                InventoryNumber = txtDevInventory.Text.Trim(),
                EmployeeID = (int?)cmbDevEmployee.SelectedValue,
                DeviceType = cmbDevType.Text,
                Model = txtDevModel.Text,
                IMEI = txtDevIMEI.Text,
                MACAddress = txtDevMAC.Text,
                IssueDate = dtpDevIssue.Value,
                ReplacementDate = dtpDevReplace.Value,
                HasMDM = chkDevMDM.Checked,
                DeviceStatus = cmbDevStatus.Text,
                Notes = txtDevNotes.Text
            };

            _deviceRepo.AddDevice(dev);
            LoadDevices();
        }

        private void btnBillingBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Billing Files|*.01X;*.01Y;*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBillingFile.Text = ofd.FileName;
            }
        }

        private void btnImportBilling_Click(object sender, EventArgs e)
        {
            string file = txtBillingFile.Text;
            if (!File.Exists(file))
            {
                MessageBox.Show("Select valid file.");
                return;
            }

            BillingImporter importer = new BillingImporter();
            importer.Import(file);

            MessageBox.Show("Billing imported successfully.");
        }
    }
}
*/
//--------------------------------------------------------------------------------------------------





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


// Inna wersja pliku AdminPanel.cs, która jest nowsza.
