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
    public partial class RemoveAccountWindow : Window
    {
        private Bank bank;

        public RemoveAccountWindow(Bank bank)
        {
            InitializeComponent();
            this.bank = bank;
        }

        private void RemoveAccountButton_Click(object sender, RoutedEventArgs e)
        {
            string pesel = PeselTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(pesel) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both PESEL and password!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Próbujemy znaleźć konto na podstawie PESEL i hasła w liście accountsForXML
            Account accountToRemove = bank.accountsForXML
                .FirstOrDefault(a => a.Owner.Pesel == pesel && a.Password == password);

            if (accountToRemove != null)
            {
                try
                {
                    // Usuwamy konto z banku
                    bank.RemoveAccount(accountToRemove);
                    MessageBox.Show("Account removed successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Zamykamy okno
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing account: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Account not found with the provided PESEL and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}