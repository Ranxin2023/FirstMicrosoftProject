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
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FilePath = "./username_password.txt";
            try
            {
                String [] Lines = File.ReadAllLines(FilePath);
                bool isAuthenticated = false;
                foreach(var Line in Lines)
                {
                    String[] Parts = Line.Split(' ');
                    String username = Parts[0];
                    String password = Parts[1];
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
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the login form
            SignUp signupForm = new SignUp();
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
