using PhoneBookApp.Data;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            // Otwórz formularz zmiany hasła
            ChangePasswordForm cpf = new ChangePasswordForm(_loggedUser);
            cpf.ShowDialog();

        }
        // 1. Dodaj deklarację repozytorium (na początku klasy UserPanel)
        private readonly BillingRepository _billingRepo = new BillingRepository();

        // 2. Implementacja ładowania bilingów (na zakładce "Billing")
        private void tabBilling_Click(object sender, EventArgs e)
        {            

        }
        
        private void dgvBilling_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Sprawdzenie, czy kliknięto w wiersz danych, a nie nagłówek
            if (e.RowIndex < 0 || e.RowIndex >= dgvBilling.Rows.Count) return;

            // Przykładowe użycie: wyświetlenie identyfikatora wybranego bilingu
            // var billingId = dgvBilling.Rows[e.RowIndex].Cells["BillingID"].Value;
            // MessageBox.Show($"Wybrano biling o ID: {billingId}");
        }
        
        // 5. Obsługa przycisku "Show Billing" (btnShowBilling_Click)
       
        private void btnShowBilling_Click(object sender, EventArgs e)
        {
            // Wywołanie metody ładującej dane bilingowe
            LoadEmployeeBilling();

        }

        private void LoadEmployeeBilling()
        {
            try
            {
                // Sprawdzamy, czy zalogowany użytkownik istnieje
                if (_loggedUser == null)
                {
                    MessageBox.Show("Brak danych zalogowanego użytkownika.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Wywołanie metody z BillingRepository.cs
                // Używamy EmployeeID zalogowanego użytkownika
                dgvBilling.DataSource = _billingRepo.GetBillingByEmployeeId(_loggedUser.EmployeeID);

                // Opcjonalne formatowanie
                if (dgvBilling.Columns.Contains("CallCost"))
                {
                    // Formatowanie na walutę (C2)
                    dgvBilling.Columns["CallCost"].DefaultCellStyle.Format = "C2";
                }

                if (dgvBilling.Rows.Count == 0)
                {
                    MessageBox.Show("Nie znaleziono żadnych rekordów bilingowych dla tego pracownika.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas ładowania bilingów: " + ex.Message, "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //try
            //{
            //    // 1. Sprawdź, czy mamy zalogowanego użytkownika
            //    if (_loggedUser == null) return;
            //    // 2. Pobierz bilingi dla zalogowanego EmployeeID
            //    // Zakładam, że pole dla bilingów to dgvBilling (zgodnie z nazwą dgvBilling_CellContentClick)
            //    dgvBilling.DataSource = _billingRepo.GetBillingByEmployeeId(_loggedUser.EmployeeID);
            //    // 3. Opcjonalnie: formatowanie kolumn, jeśli potrzebne
            //    dgvBilling.Columns["CallCost"].DefaultCellStyle.Format = "C"; 
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error loading billing data: " + ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //// Metoda wywoływana przy kliknięciu zakładki "Billing"
            ////LoadEmployeeBilling();
        }

        // 3. Implementacja eksportu do CSV (btnDwlBilling_Click)
        private void btnDwlBilling_Click(object sender, EventArgs e)
        {
            // Sprawdzenie, czy są dane do eksportu
            if (dgvBilling.Rows.Count == 0 || dgvBilling.DataSource == null)
            {
                MessageBox.Show("No data to export.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = $"Billing_{_loggedUser.EmployeeID}_{DateTime.Now:yyyyMMdd}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Wywołanie metody pomocniczej do eksportu DataGridView do CSV
                        ExportToCsv(dgvBilling, sfd.FileName);
                        MessageBox.Show("Billing successfully exported to CSV.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting data: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // 4. Metoda pomocnicza do eksportu (dodaj ją w UserPanel.cs)
        private void ExportToCsv(DataGridView dgv, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Nagłówki kolumn
            IEnumerable<string> columnNames = dgv.Columns.Cast<DataGridViewColumn>().Select(column => column.HeaderText);
            sb.AppendLine(string.Join(";", columnNames));

            // Wiersze danych
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Upewnij się, że nie eksportujemy pustego wiersza na końcu (jeśli AllowUserToAddRows = true)
                if (row.IsNewRow) continue;

                IEnumerable<string> fields = row.Cells.Cast<DataGridViewCell>()
                    .Select(cell => cell.Value?.ToString().Replace(";", ",") ?? ""); // Zamień średniki na przecinki w danych

                sb.AppendLine(string.Join(";", fields));
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
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
