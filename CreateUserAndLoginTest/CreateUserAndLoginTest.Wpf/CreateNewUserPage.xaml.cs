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
    /// Interaction logic for CreateNewUserPage.xaml
    /// </summary>
    public partial class CreateNewUserPage : Page
    {
        public CreateNewUserPage()
        {
            InitializeComponent();
        }

        private void lblCreate_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = txtUsername.Text.ToString();
            string newUserpassword = txtPassword.Text.ToString();



            User user = new User();
            user.CreateNewUser(newUsername,newUserpassword);
        }
    }
}
