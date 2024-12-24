using bankproject;
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

namespace bankproject_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {

        Account user;
        MainWindow mainWindow;
        private Bank bank;
        public UserPage(MainWindow mainWindow, Bank bank)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = mainWindow.LoggedInUser;
            this.bank = bank;
            NameBox.Text = $"{user.Owner.name} {user.Owner.surname}";
            BalanceBox.Text = $"{user.Balance:C}";
        }

        private void WithdrawButton_Click(object sender, RoutedEventArgs e)
        {
            WithdrawWindow withdrawWindow = new WithdrawWindow(user);
            bool? result = withdrawWindow.ShowDialog();

            
            if (result == true) 
            {
                BalanceBox.Text = $"{user.Balance:C}";
            }
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            DonateWindow donateWindow = new DonateWindow(user);
            bool? result = donateWindow.ShowDialog();

            if (result == true)
            {
                BalanceBox.Text = $"{user.Balance:C}";
            }


        }

        private void TransferButton_Click(Object sender, RoutedEventArgs e)
        {
            TransferWindow transferWindow = new TransferWindow(user, bank);
            bool? result = transferWindow.ShowDialog();

            if (result == true)
            {
                BalanceBox.Text = $"{user.Balance:C}";
            }
        }

        
        private void LogoutButton_Click(Object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Navigate( new LoginPage(mainWindow));
            bank.SaveXml("../../../../MyBank.xml"); 

        }
        
        







    }
}


