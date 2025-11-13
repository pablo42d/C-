using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using PhoneBookApp.Database;


namespace PhoneBookApp
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source= DESKTOP-COV87SH\\SQLEXPRESS;Initial Catalog=phoneBook;Integrated Security=True");

        //Definicja zmiennej statycznej do przechowywania nazwy użytkownika
        public static string User;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void wyjdz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Click(object sender, EventArgs e)
        {

        }

        private void textLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textPassword.UseSystemPasswordChar = true;
            }
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void zaloguj_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT Username,PasswordHash FROM Employees WHERE Username=@username AND PasswordHash=@password", conn);
            cmd.Parameters.AddWithValue("username", textLogin.Text);
            cmd.Parameters.AddWithValue("password", textPassword.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                // Successful login
                int resultpass = String.Compare(textPassword.Text, reader.GetValue(1).ToString());


                if (resultpass == 0)
                {
                    User = reader["Username"].ToString();
                    AccesUser accesUser = new AccesUser();
                    accesUser.Show();
                    this.Hide();
                    conn.Close();


                else
                {

                    // Invalid credentials
                    conn.Close();
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }




            else
            {

                    // Invalid credentials
                    //conn.Close();
                    reader.Close();
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                conn.Close();


            }
        }


    }
}



        ///// <summary>
        ///// Sprawdza, czy login istnieje w bazie (Username).
        ///// </summary>
        //private bool LoginExists(string username, SqlConnection connection)
        //{
        //    string checkQuery = "SELECT COUNT(*) FROM Employees WHERE Username = @Username";
        //    using (SqlCommand cmd = new SqlCommand(checkQuery, connection))
        //    {
        //        cmd.Parameters.AddWithValue("@Username", username);
        //        int count = (int)cmd.ExecuteScalar();
        //        return count > 0;
        //    }
        //}




    
