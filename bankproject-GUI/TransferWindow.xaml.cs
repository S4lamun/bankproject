using bankproject;
using System;
using System.Windows;

namespace bankproject_GUI
{
    
    public partial class TransferWindow : Window
    {
        private Account user;
        private Bank bank; 

        public TransferWindow(Account user, Bank bank)
        {
            InitializeComponent();
            this.user = user;
            this.bank = bank;

            
            BalanceTextBox.Text = $"{user.Balance:C}";
        }

        private void TransferButton_Click(object sender, RoutedEventArgs e)
        {
            string recipientAccountNumberString = RecipientAccountTextBox.Text;

            
            if (!long.TryParse(recipientAccountNumberString, out long recipientAccountNumber))
            {
                MessageBox.Show("Invalid recipient account number. Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            if (!decimal.TryParse(TransferAmountTextBox.Text, out decimal transferAmount))
            {
                MessageBox.Show("Invalid amount. Please enter a valid number.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            if (transferAmount > user.Balance)
            {
                MessageBox.Show($"The amount: {transferAmount:C} exceeds your balance.", "Transaction Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                
                Account? recipientAccount = bank.FindAccount(recipientAccountNumber);

                if (recipientAccount == null)
                {
                    MessageBox.Show($"The account number {recipientAccountNumber} is invalid.", "Transaction Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                
                user.Transfer(recipientAccount, transferAmount);

                
                MessageBox.Show($"Successfully transferred {transferAmount:C} to account {recipientAccountNumber}.", "Transfer Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                
                BalanceTextBox.Text = $"{user.Balance:C}";

                
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
