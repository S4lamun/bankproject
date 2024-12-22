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
        
        private Account user;
        private Bank bank;
        public UserPage(Account user, Bank bank)
        {
            InitializeComponent();
            this.user = user;
            this.bank = bank;
            NameBox.Text = $"{user.Owner.name} {user.Owner.surrname}";
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


        
      
        


    }
}


