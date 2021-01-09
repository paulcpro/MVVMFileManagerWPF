using System.Windows;
using MVVMFIleManagerWPF.ViewModel;

namespace MVVMFIleManagerWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public FileViewModel FileItems
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
        }
    }
}
