using System.Windows;
using MVVMFIleManagerWPF.ViewModel;

namespace MVVMFIleManagerWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Used to access at our Model
        /// </summary>
        public FileViewModel FileViewModel
        {
            get
            {
                return this.DataContext as FileViewModel;
            }

            set
            {
                this.DataContext = value;
            }

        }

        public MainWindow()
        {
            InitializeComponent();
            FileViewModel.TryToNavigateToPath(@"F:\testfolder");
        }

    }
}
