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
        private Bank b1;
        public LoginPage(MainWindow mainWindow, Bank bank)
        {
            InitializeComponent();
            this.b1 = bank;
            this.mainWindow = mainWindow;
            BankNameBox.Text = b1.name;

        }
        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            
            b1.ReadXml("../../../../MyBank.xml");
            string password = PasswordBox.Password;
            
            if(b1.FindEmployee(password) is not null)
            {
                mainWindow.MainFrame.Navigate(new AdminPage(mainWindow, b1));
                mainWindow.LoggedInBankEmployee = b1.FindEmployee(password);
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
