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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreateUserAndLoginTest.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string _username = txtUsername.Text;
            string _password = txtPassword.Text;

            User user = new User();

            if (user.Login(_username, _password))
            {
                lblError.Content = "";
                MessageBox.Show("You succesfully loged in!");
            }
            else
            {
                lblError.Content = "Username and/or password wrong.";
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateNewUserPage createNewUserPage = new CreateNewUserPage();
            this.Content = createNewUserPage;
        }
    }
}
