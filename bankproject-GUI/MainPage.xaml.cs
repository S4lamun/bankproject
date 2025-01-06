using bankproject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using bankproject;
namespace bankproject_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Bank b1 = new("myBank");
        
        private MainWindow mainWindow;
        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            
            this.mainWindow = mainWindow;
            BankNameBox.Text = b1.name;
        }
        private void Pytas_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("pytas a wiesz", ".", MessageBoxButton.OK, MessageBoxImage.Question);
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindow == null)
            {
                MessageBox.Show("MainWindow reference is null!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            mainWindow.MainFrame.Navigate(new LoginPage(mainWindow, b1));
        }
        private void AboutUsButton_Click(Object sender, RoutedEventArgs e)
        {
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AboutUs", "AboutUs.pdf");
            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Nie odnaleziono pliku!");
            }

        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
