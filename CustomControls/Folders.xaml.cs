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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMFIleManagerWPF.CustomControls
{
    /// <summary>
    /// Logique d'interaction pour Folders.xaml
    /// </summary>
    public partial class Folders : UserControl
    {
        #region Properties

        public string FolderName
        {
            get
            {
                return this.txtFolder.Text;
            }

            set
            {
                this.txtFolder.Text = value;
            }

        }

        #endregion //Properties

        public Folders()
        {
            InitializeComponent();
        }
    }
}
