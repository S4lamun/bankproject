using bankproject;
using System.Text;
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
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Account? LoggedInUser { get; set; }
		public BankEmployee? LoggedInBankEmployee { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            MainFrame.Navigate(new MainPage(this));


        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}