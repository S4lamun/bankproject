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
using System.Windows.Shapes;

namespace bankproject_GUI
{
    
    public partial class DonateWindow : Window
    {
        private Account user;

        public DonateWindow(Account user)
        {
            InitializeComponent();
            this.user = user;
            BalanceTextBox.Text = $"{user.Balance:C}"; 
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(DonateAmountTextBox.Text, out decimal donateAmount))
            {
                
                
                    user.Donate(donateAmount); 
                    BalanceTextBox.Text = $"{user.Balance:C}"; 
                    MessageBox.Show($"Successfully donated {donateAmount:C}.", "Transaction Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                    
                    this.DialogResult = true;
                    this.Close(); 
               
               
               
            }
            else
            {
                MessageBox.Show("Invalid amount. Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = false;
            this.Close(); 
        }
    }
}
