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
    /// Logika interakcji dla klasy ChangeBankNameWindow.xaml
    /// </summary>
    public partial class ChangeBankNameWindow : Window
    {
        private Bank bank;
        public ChangeBankNameWindow(Bank bank)
        {
            InitializeComponent();
            this.bank = bank;
            
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string newName = SetNewBankName.Text;
            if (string.IsNullOrEmpty(newName)) 
                {
                    MessageBox.Show("Please fill all customer fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            bank.name = newName;
            this.Close();
        }
    }
}
