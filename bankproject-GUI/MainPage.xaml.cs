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
using System.Media;
namespace bankproject_GUI
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        Bank b1 = new("myBank");
        private MediaPlayer m_MediaPlayer;
        private MainWindow mainWindow;
        public MainPage(MainWindow mainWindow)
        {
            InitializeComponent();
            
            this.mainWindow = mainWindow;
            BankNameBox.Text = b1.name;


            m_MediaPlayer = new MediaPlayer();
            string soundPath = @"C:\Users\ajasi\source\repos\bankproject\Images\button.mp3";

            if (File.Exists(soundPath))
            {
                m_MediaPlayer.Open(new Uri(soundPath));
            }
            else
            {
                MessageBox.Show("Nie znaleziono pliku dźwiękowego!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void PlayClickSound()
        {
            if (m_MediaPlayer.Source != null)
            {
                m_MediaPlayer.Position = TimeSpan.Zero; 
                m_MediaPlayer.Play();
            }
        }
        

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            PlayClickSound();
            if (mainWindow == null)
            {
                MessageBox.Show("MainWindow reference is null!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            mainWindow.MainFrame.Navigate(new LoginPage(mainWindow, b1));
        }
        private void AboutUsButton_Click(Object sender, RoutedEventArgs e)
        {
            PlayClickSound();
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
            PlayClickSound();
            Application.Current.Shutdown();
        }

    }
}
