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
    /// Logique d'interaction pour SmallButtonMenu.xaml
    /// </summary>
    public partial class SmallButtonMenu : UserControl
    {

        #region Constructors

        /// <summary>
        /// Initialize a SmallButtonMenu Component
        /// </summary>
        public SmallButtonMenu()
        {
            InitializeComponent();
        }

        #endregion //Constructors

        /// <summary>
        /// Image to display before our string
        /// </summary>
        public ImageSource ImageSource
        {
            get
            {
                return this.btnImageSource.Source;
            }

            set
            {
                this.btnImageSource.Source = value;
            }

        }

        /// <summary>
        /// String to display our text following the image
        /// </summary>
        public string Text
        {
            get
            {
                return this.btnText.Text;
            }

            set
            {
                this.btnText.Text = value;
            }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left && e.ClickCount == 2 && e.ButtonState == MouseButtonState.Pressed)
            {
                //Complete ...
            }

        }

    }

}
