using bankproject;
using System;
using System.Windows;

namespace bankproject_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy TransferWindow.xaml
    /// </summary>
    public partial class TransferWindow : Window
    {
        private Account user;
        private Bank bank; // Bank zarządza kontami

        public TransferWindow(Account user, Bank bank)
        {
            InitializeComponent();
            this.user = user;
            this.bank = bank;

            // Wyświetlenie bieżącego salda
            BalanceTextBox.Text = $"{user.Balance:C}";
        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            string recipientAccountNumberString = RecipientAccountTextBox.Text;

            // Sprawdź, czy numer konta jest poprawny
            if (!long.TryParse(recipientAccountNumberString, out long recipientAccountNumber))
            {
                MessageBox.Show("Invalid recipient account number. Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Sprawdź, czy kwota jest poprawna
            if (!decimal.TryParse(TransferAmountTextBox.Text, out decimal transferAmount))
            {
                MessageBox.Show("Invalid amount. Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Sprawdź, czy saldo jest wystarczające
            if (transferAmount > user.Balance)
            {
                MessageBox.Show($"The amount: {transferAmount:C} exceeds your balance.", "Transaction Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Znajdź odbiorcę po numerze konta
                Account? recipientAccount = bank.FindAccount(recipientAccountNumber);

                if (recipientAccount == null)
                {
                    MessageBox.Show($"The account number {recipientAccountNumber} is invalid.", "Transaction Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Wykonaj przelew
                user.Transfer(recipientAccount, transferAmount);

                // Informacja o udanym przelewie
                MessageBox.Show($"Successfully transferred {transferAmount:C} to account {recipientAccountNumber}.", "Transfer Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                // Aktualizacja salda w polu tekstowym
                BalanceTextBox.Text = $"{user.Balance:C}";

                // Zakończenie okna
                this.DialogResult = true;
                this.Close();
            }
            catch (WrongAccountException ex)
            {
                MessageBox.Show(ex.Message, "Transaction Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (WrongAmountException ex)
            {
                MessageBox.Show(ex.Message, "Transaction Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
