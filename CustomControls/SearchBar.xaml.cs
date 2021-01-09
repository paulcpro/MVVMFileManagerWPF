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
    /// Logique d'interaction pour SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {

        #region Properties

        public string Text1
        {
            get
            {
                return this.txtText1.Text;
            }

            set
            {
                this.txtText1.Text = value;
            }

        }

        public ImageSource ImageSource
        {
            get
            {
                return this.imgSource.Source;
            }

            set
            {
                this.imgSource.Source = value;
            }

        }

        #endregion //Properties

        public SearchBar()
        {
            InitializeComponent();
        }

    }

}
