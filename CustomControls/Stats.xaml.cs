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
    /// Logique d'interaction pour Stats.xaml
    /// </summary>
    public partial class Stats : UserControl
    {

        #region Properties

        /// <summary>
        /// Left Text displaying the headline
        /// </summary>
        public string FirstText
        {
            get
            {
                return this.txtFirst.Text;
            }

            set
            {
                this.txtFirst.Text = value;
            }

        }

        /// <summary>
        /// Displayed Number of quantity retrieved
        /// </summary>
        public string Number
        {
            get
            {
                return this.txtNumber.Text;
            }

            set
            {
                this.txtNumber.Text = value;
            }

        }

        /// <summary>
        /// Right Text displaying the caption
        /// </summary>
        public string SecondText
        {
            get
            {
                return this.txtSecond.Text;
            }

            set
            {
                this.txtSecond.Text = value;
            }

        }

        #endregion //Properties

        #region Constructors

        public Stats()
        {
            InitializeComponent();
        }

        #endregion //Constructors

    }

}
