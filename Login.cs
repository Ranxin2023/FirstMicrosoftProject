using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace LoginApplication
{
    public partial class Login : Form
    {
        public string SignupUsername;
        public string SignupPassword;
        public string SignupReentryPassword;
        public Login(string Username, string Password)
        {
            InitializeComponent();
            this.textBox1.Text = Username;
            this.textBox2.Text = Password;
        }

        private void LoginClick(object sender, EventArgs e)
        {
            string FilePath = "./username_password.txt";
            try
            {
                string [] Lines = File.ReadAllLines(FilePath);
                bool isAuthenticated = false;
                foreach(var Line in Lines)
                {
                    string[] Parts = Line.Split(' ');
                    string username = Parts[0];
                    string password = Parts[1];
                    if (this.textBox1.Text==username&&this.textBox2.Text==password)
                    {
                        isAuthenticated = true;
                        break;
                    }
                }
                if (isAuthenticated)
                {
                    MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FileNotFoundException)
            {
                    MessageBox.Show("Credentials file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SignupClick(object sender, EventArgs e)
        {
            string Username = this.textBox1.Text;
            string Password = this.textBox2.Text;
            this.Hide(); // Hide the login form
            SignUp signupForm = new SignUp
                (this.SignupUsername, this.SignupPassword, this.SignupReentryPassword)
            {
                LoginUser=Username, 
                LoginPassword=Password
            };
            signupForm.Show(); // Show the signup form

            // Optionally, handle the FormClosed event of the signup form to close the application
            signupForm.FormClosed += (s, args) => this.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
