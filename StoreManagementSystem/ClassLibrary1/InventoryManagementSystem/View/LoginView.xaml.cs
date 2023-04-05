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

namespace InventoryManagementSystem.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        Context context = new Context();
        User User { get; set; }
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            CheckCredential();
        }
        private void CheckCredential()
        {
            if (IsvalidUser(txtUser.Text, txtPass.Password))
            {

                MainWindow main = new MainWindow(User);
                main.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password try again!");
            }
        }
        private bool IsvalidUser(string userName, string password)
        {
            User user = context.Users.FirstOrDefault(user => (user.Namer ==  userName) && (user.Password == password));
            User = user;

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
