using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
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
using bankproject;

namespace bankproject_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MainWindow mainWindow;
        public LoginPage(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            
        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Bank.CreateBank();
            Bank b1 = Bank.ReadXML("MyBank.xml");
            string password = PasswordBox.Password;
            
            if(b1.FindEmpolyee(password))
            {
                mainWindow.MainFrame.Navigate(new AdminPage());
            }
            else if(b1.FindAccount(password) is not null)
            {
                mainWindow.LoggedInUser = b1.FindAccount(password);
                mainWindow.MainFrame.Navigate(new UserPage(mainWindow, b1));
            }
            else
            {
                NoAccountWindow noAccountWindow = new NoAccountWindow();
                noAccountWindow.ShowDialog();
            }
            
            
        }
        
    }
}
