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
    /// <summary>
    /// Logika interakcji dla klasy WithdrawWindow.xaml
    /// </summary>
    public partial class DonateWindow : Window
    {
        private Account user;

        public DonateWindow(Account user)
        {
            InitializeComponent();
            this.user = user;
            BalanceTextBox.Text = $"{user.Balance:C}"; // Wyświetlenie salda w formacie walutowym
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(DonateAmountTextBox.Text, out decimal donateAmount))
            {
                
                
                    user.Donate(donateAmount); // Wywołanie funkcji Withdraw
                    BalanceTextBox.Text = $"{user.Balance:C}"; // Zaktualizowanie salda
                    MessageBox.Show($"Successfully donated {donateAmount:C}.", "Transaction Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Ustawienie DialogResult na true po udanej transakcji
                    this.DialogResult = true;
                    this.Close(); // Zamknięcie okna po sukcesie
               
               
               
            }
            else
            {
                MessageBox.Show("Invalid amount. Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Ustawienie DialogResult na false przy anulowaniu
            this.DialogResult = false;
            this.Close(); // Zamknięcie okna
        }
    }
}
