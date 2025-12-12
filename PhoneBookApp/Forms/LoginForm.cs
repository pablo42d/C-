using System;
using PhoneBookApp.Data;
using PhoneBookApp.Models;
using System.Configuration;
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
            lblError.Text = ""; // czyścimy błędy

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // 1. Walidacja pól
            if (string.IsNullOrWhiteSpace(username))
            {
                lblError.Text = "Enter username.";
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                lblError.Text = "Enter password.";
                return;
            }

            // 2. Test połączenia do bazy
            // ZAWSZE testuj połączenie PRZED próbą logowania
            try
            {
                if (!_db.TestConnection())
                {
                    lblError.Text = "Cannot connect to database!";
                    return;
                }
            }
            catch (Exception ex)
            {
                // Jeśli TestConnection wyrzuci wyjątek (np. błąd SQL), złap go
                lblError.Text = "Database connection error: " + ex.Message;
                return;
            }


            // 3. Uwierzytelnienie użytkownika za pomocą dedykowanej metody
            // Metoda AuthenticateUser zwraca obiekt Employee tylko, jeśli hasło pasuje (haszowane lub czysty tekst)
            Employee loggedUser = _employeeRepo.AuthenticateUser(username, password);


            // 4. Sprawdzenie wyniku uwierzytelnienia
            if (loggedUser == null)
            {
                // Błąd uwierzytelnienia (niepoprawny login lub hasło)
                lblError.Text = "Invalid username or password.";
                return;
            }

            // 5. Logowanie OK → przekierowanie wg roli
            lblError.Text = "Login successful.";

            if (loggedUser.Role != null && loggedUser.Role.ToLower() == "admin")
            {
                AdminPanel admin = new AdminPanel(loggedUser);
                admin.Show();
                this.Hide();
            }
            else
            {
                UserPanel user = new UserPanel(loggedUser);
                user.Show();
                this.Hide();
            }

            //lblError.Text = ""; // czyścimy błędy

            //// 1. Walidacja pól
            //if (string.IsNullOrWhiteSpace(txtUsername.Text))
            //{
            //    lblError.Text = "Enter username.";
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(txtPassword.Text))
            //{
            //    lblError.Text = "Enter password.";
            //    return;
            //}

            //// 2. Test połączenia do bazy
            //if (!_db.TestConnection())
            //{
            //    lblError.Text = "Cannot connect to database!";
            //    return;
            //}

            //// 3. Pobranie użytkownika z bazy
            //Employee emp = _employeeRepo.GetEmployeeByUsername(txtUsername.Text);

            //if (emp == null)
            //{
            //    lblError.Text = "Invalid username or password.";
            //    return;
            //}

            //// 4. Sprawdzenie hasła
            //// U Ciebie PasswordHash jest zapisane w bazie jako zwykły tekst
            //// (dopiero później zrobimy hashing)

            //if (emp.PasswordHash != txtPassword.Text)
            //{
            //    lblError.Text = "Invalid username or password.";
            //    return;
            //}

            //// 5. Logowanie OK → przekierowanie wg roli
            //lblError.Text = "Login successful.";

            //if (emp.Role.ToLower() == "admin")
            //{
            //    AdminPanel admin = new AdminPanel(emp);
            //    admin.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    UserPanel user = new UserPanel(emp);
            //    user.Show();
            //    this.Hide();
            //}

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
