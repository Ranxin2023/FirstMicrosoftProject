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
using System.Windows.Forms.VisualStyles;
namespace LoginApplication
{
    public partial class SignUp : Form
    {
        public string LoginUser;
        public string LoginPassword;
        public SignUp(string Username, string Password, string ReentryPassword)
        {
            InitializeComponent();
            this.textBox1.Text = Username;
            this.textBox2.Text = Password;
            this.textBox3.Text = ReentryPassword;
        }
        private void SignUpUser(object sender, EventArgs e)
        {
            String Username=this.textBox1.Text.Trim();
            String Password=this.textBox2.Text.Trim();
            String ReenterPassword = this.textBox3.Text.Trim();
            if (string.IsNullOrWhiteSpace(Username)||string.IsNullOrWhiteSpace(Password)||string.IsNullOrWhiteSpace(ReenterPassword))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Password!=ReenterPassword)
            {
                MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string FilePath=  "./username_password.txt";
            try
            {
                List<string> Lines = File.ReadAllLines(FilePath).ToList();
                foreach (string Line in Lines)
                {
                    var parts=Line.Split(' ');
                    if (parts.Length == 2 && parts[0].Equals(Username))
                    {
                        MessageBox.Show("User exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                Lines.Add($"{Username} {Password}");
                Lines.Sort((x, y) => string.Compare(x, y, StringComparison.OrdinalIgnoreCase));
                File.WriteAllLines(FilePath, Lines);
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Show the login form again
                Login loginForm = new Login("", "")
                {
                    SignupUsername="",
                    SignupPassword="",
                    SignupReentryPassword=""
                };
                loginForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginClick(object sender, EventArgs e)
        {
            this.Hide(); // Hide the login form
            string Username=this.textBox1.Text.Trim();
            string Password=this.textBox2.Text.Trim();
            string ReentryPassword=this.textBox3.Text.Trim();
            Login loginForm = new Login(this.LoginUser, this.LoginPassword)
            {
                SignupUsername= Username,
                SignupPassword = Password,
                SignupReentryPassword = ReentryPassword
            };
            loginForm.Show(); // Show the signup form

            // Optionally, handle the FormClosed event of the signup form to close the application
            loginForm.FormClosed += (s, args) => this.Close();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
