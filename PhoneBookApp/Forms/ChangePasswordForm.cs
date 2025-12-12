using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhoneBookApp.Models;
using PhoneBookApp.Data; // Wymagane dla EmployeeRepository
using System.Security.Cryptography; // Wymagane do hashowania (zalecane)

namespace PhoneBookApp.Forms
{
    public partial class ChangePasswordForm : Form
    {
        private readonly Employee _loggedUser;
        private readonly EmployeeRepository _employeeRepo = new EmployeeRepository();

        // Konstruktor przyjmujący zalogowanego użytkownika
        public ChangePasswordForm(Employee user)
        {
            InitializeComponent();
            _loggedUser = user;
            // Dodatkowe ustawienia bezpieczeństwa
            this.txtOldPassword.UseSystemPasswordChar = true;
            this.txtNewPassword.UseSystemPasswordChar = true;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            // Można tu dodać etykiety z wymaganiami co do hasła
        }

        // --- Logika Walidacji Hasła ---
        private bool ValidatePassword(string password)
        {
            if (password.Length < 7)
            {
                MessageBox.Show("Hasło musi mieć co najmniej 7 znaków.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                MessageBox.Show("Hasło musi zawierać co najmniej jedną wielką literę.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!password.Any(char.IsDigit))
            {
                MessageBox.Show("Hasło musi zawierać co najmniej jedną cyfrę.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //private void btnSavePassword_Click(object sender, EventArgs e)
        //{
        //    string oldPass = txtOldPassword.Text;
        //    string newPass = txtNewPassword.Text;
        //    string confirmPass = txtConfirmPassword.Text;

        //    if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
        //    {
        //        MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // 1. Walidacja zgodności nowego hasła
        //    if (newPass != confirmPass)
        //    {
        //        MessageBox.Show("Nowe hasło i potwierdzenie nie są identyczne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // 2. Walidacja reguł nowego hasła
        //    if (!ValidatePassword(newPass))
        //    {
        //        return; // Walidacja wyświetliła już błąd
        //    }

        //    try
        //    {
        //        // 3. Weryfikacja starego hasła (Musisz mieć metodę w EmployeeRepository)
        //        // Zakładamy, że EmployeeRepository ma metodę VerifyPassword(int userId, string password)
        //        if (!_employeeRepo.VerifyPassword(_loggedUser.EmployeeID, oldPass))
        //        {
        //            MessageBox.Show("Stare hasło jest niepoprawne.", "Błąd Weryfikacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        // 4. Aktualizacja hasła
        //        // Zakładamy, że UpdatePassword hashuje hasło wewnątrz repozytorium
        //        _employeeRepo.UpdatePassword(_loggedUser.EmployeeID, newPass);

        //        MessageBox.Show("Hasło zostało pomyślnie zmienione.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Wystąpił błąd podczas zmiany hasła: " + ex.Message, "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //private void btnCancel_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}

        private void btnSavePassword_Click_1(object sender, EventArgs e)
        {
            string oldPass = txtOldPassword.Text;
            string newPass = txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirmPass))
            {
                MessageBox.Show("Wszystkie pola są wymagane.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Walidacja zgodności nowego hasła
            if (newPass != confirmPass)
            {
                MessageBox.Show("Nowe hasło i potwierdzenie nie są identyczne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Walidacja reguł nowego hasła
            if (!ValidatePassword(newPass))
            {
                return; // Walidacja wyświetliła już błąd
            }

            try
            {
                // 3. Weryfikacja starego hasła (Musisz mieć metodę w EmployeeRepository)
                // Zakładamy, że EmployeeRepository ma metodę VerifyPassword(int userId, string password)
                if (!_employeeRepo.VerifyPassword(_loggedUser.EmployeeID, oldPass))
                {
                    MessageBox.Show("Stare hasło jest niepoprawne.", "Błąd Weryfikacji", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 4. Aktualizacja hasła
                // Zakładamy, że UpdatePassword hashuje hasło wewnątrz repozytorium
                _employeeRepo.UpdatePassword(_loggedUser.EmployeeID, newPass);

                MessageBox.Show("Hasło zostało pomyślnie zmienione.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas zmiany hasła: " + ex.Message, "Błąd Bazy Danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            // zzamyka opno i wychodzi z panelu zmiany hasła

            this.Close();

        }

        // Pamiętaj, aby dodać obsługę zdarzeń dla tych przycisków w Designerze (Krok 1)
    }
}








/*
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBookApp.Forms
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
*/