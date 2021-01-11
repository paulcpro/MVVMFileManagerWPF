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
    /// Logique d'interaction pour UserButton.xaml
    /// </summary>
    public partial class UserButton : UserControl
    {
        #region Properties

        public ImageSource ImageSource
        {
            get
            {
                return this.btnUser.ImageSource;
            }

            set
            {
                this.btnUser.ImageSource = value;
            }

        }

        public string Username
        {
            get
            {
                return this.txtUser.Text;
            }

            set
            {
                this.txtUser.Text = value;
            }

        }

        public string Status
        {
            get
            {
                return this.txtStatus.Text;
            }

            set
            {
                this.txtStatus.Text = value;
            }
        }

        #endregion //Properties

        #region Constructors

        public UserButton()
        {
            InitializeComponent();
        }

        #endregion //Constructors

    }

}
