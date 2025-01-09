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
using System.Media;
using System.IO;
using System.Windows.Media.Imaging;
namespace bankproject_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MediaPlayer m_MediaPlayer;
        private MediaPlayer e_MediaPlayer;
        private MainWindow mainWindow;
        private Bank b1;
        public LoginPage(MainWindow mainWindow, Bank bank)
        {
            m_MediaPlayer = new MediaPlayer();
            e_MediaPlayer = new MediaPlayer();
            string soundPath = System.IO.Path.GetFullPath(@"..\..\..\..\Images\button.mp3");
            string errorPath = System.IO.Path.GetFullPath(@"..\..\..\..\Images\error.mp3");
            if (File.Exists(soundPath))
            {
                m_MediaPlayer.Open(new Uri(soundPath));
            }
            else
            {
                MessageBox.Show("Nie znaleziono pliku dźwiękowego!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (File.Exists(errorPath))
            {
                e_MediaPlayer.Open(new Uri(errorPath));
            }
            else
            {
                MessageBox.Show("Nie znaleziono pliku dźwiękowego!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            InitializeComponent();
            this.b1 = bank;
            this.mainWindow = mainWindow;
            BankNameBox.Text = b1.name;

        }
        private void PlayClickSound()
        {
            if (m_MediaPlayer.Source != null)
            {
                m_MediaPlayer.Position = TimeSpan.Zero;
                m_MediaPlayer.Play();
            }
        }
        private void PlayClickSound2()
        {
            if (e_MediaPlayer.Source != null)
            {
                e_MediaPlayer.Position = TimeSpan.Zero;
                e_MediaPlayer.Play();
            }
        }
        private async void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            
            b1.ReadXml("../../../../MyBank.xml");
            string password = PasswordBox.Password;
            
            if(b1.FindEmployee(password) is not null)
            {
                LoadingGif.Visibility = Visibility.Visible;

                await Task.Delay(2000);

                LoadingGif.Visibility = Visibility.Hidden;
                PlayClickSound();
                mainWindow.MainFrame.Navigate(new AdminPage(mainWindow, b1));
                mainWindow.LoggedInBankEmployee = b1.FindEmployee(password);
            }
            else if(b1.FindAccount(password) is not null)
            {
                LoadingGif.Visibility = Visibility.Visible;

                await Task.Delay(2000);
                LoadingGif.Visibility = Visibility.Hidden;
                PlayClickSound();
                mainWindow.LoggedInUser = b1.FindAccount(password);
                mainWindow.MainFrame.Navigate(new UserPage(mainWindow, b1));
            }
            else
            {
                PlayClickSound2();
                NoAccountWindow noAccountWindow = new NoAccountWindow();
                noAccountWindow.ShowDialog();
                b1.accounts.Clear();
                b1.bankEmployees.Clear();
                b1.accountsForXML.Clear();
                b1.employeesForXML.Clear();

            }


        }
        
    }
}
