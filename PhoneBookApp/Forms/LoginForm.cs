// Dodano w celu obsługi logowania użytkownika w aplikacji PhoneBookApp.
using PhoneBookApp.Data;
using PhoneBookApp.Models;
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PhoneBookApp.Forms
{
    public partial class LoginForm : Form
    {
        // Inicjalizacja repozytorium pracowników i bazy danych jako pola klasy
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly Database _db = new Database();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = ""; // czyścimy błędy

            // 1. Walidacja pól sprawdzamy czy pola nie są puste
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblError.Text = "Enter username.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Enter password.";
                return;
            }

            // 2. Sprawdzam połączenie do bazy
            if (!_db.TestConnection())
            {
                lblError.Text = "Cannot connect to database!";
                return;

            }
            // 3. Pobram użytkownika z bazy
            Employee emp = _employeeRepo.GetEmployeeByUsername(txtUsername.Text);

            if (emp == null)
            {
                lblError.Text = "Invalid username or password.";
                return;
            }

            // 4. Sprawdzam hasło
            // PasswordHash jest zapisane w bazie jako zwykły tekst
            // (dopiero później zrobimy hashing)

            if (emp.PasswordHash != txtPassword.Text)
            {
                lblError.Text = "Invalid username or password.";
                return;
            }

            // 5. Logowanie OK → przekierowanie wg roli
            lblError.Text = "Login successful.";

            if (emp.Role.ToLower() == "admin")
            {
                AdminPanel admin = new AdminPanel(emp);
                admin.Show();
                this.Hide();
            }
            else
            {
                UserPanel user = new UserPanel(emp);
                user.Show();
                this.Hide();
            }
        }
    }
}
