using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;


namespace TimeManagementApp
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            UserLogin();
        }
        
        public async void UserLogin()
        {
            string Username = txbUsername.Text;
            string Password = PassHash.EncodePasswordToBase64(txbPassword.Password);

            if (txbUsername.Text == "" || txbPassword.Password == "")
            {
                MessageBox.Show("Fill in all the fields");
            }
            else
            {
                try
                {
                    User user = await db.Users.Where(u => u.Username.Equals(Username) && u.Password.Equals(Password)).FirstAsync();
                    MessageBox.Show("Logged in successfully !");
                    MainWindow window = new MainWindow(user.UserID);
                    this.Hide();
                    window.ShowDialog();
                    this.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid login credentials");
                }
            }
        }
        
        public async void UserRegistration()
        {
            if (txbUsername.Text != null || txbPassword.Password != null)
            {
                try
                {
                    User newUser = new User();
                    newUser.Username = txbUsername.Text;
                    newUser.Password = PassHash.EncodePasswordToBase64(txbPassword.Password);
                    db.Users.Add(newUser);
                    await db.SaveChangesAsync();
                    MessageBox.Show("\n successfully registered. You may login", "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields", "Error Message");
            }
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            UserRegistration();
        }
    }
}