// Dodano w celu obsługi logowania użytkownika w aplikacji PhoneBookApp.
using PhoneBookApp.Data;
using PhoneBookApp.Models;
using System.Configuration;

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
    public partial class LoginForm : Form
    {
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();
        private readonly Database _db = new Database();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = ""; // czyścimy komunikaty

            // 1. Walidacja pustych pól
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                lblError.Text = "Please enter your username.";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please enter your password.";
                return;
            }

            // 2. Test połączenia do bazy SQL
            if (!_db.TestConnection())
            {
                lblError.Text = "Cannot connect to SQL Server database!";
                return;
            }

            // 3. Pobierz użytkownika po loginie
            Employee emp = _employeeRepo.GetEmployeeByUsername(txtUsername.Text);

            if (emp == null)
            {
                lblError.Text = "Invalid username or password.";
                return;
            }

            // 4. Sprawdzenie hasła (na razie plaintext – później zrobimy SHA256)
            if (emp.PasswordHash != txtPassword.Text)
            {
                lblError.Text = "Invalid username or password.";
                return;
            }

            // 5. Logowanie poprawne → otwieramy odpowiedni panel
            lblError.Text = "Login successful.";

            // Admin?
            if (emp.Role != null && emp.Role.ToLower() == "admin")
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

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // opcjonalnie: fokus na username
            txtUsername.Focus();
        }
    }
}
