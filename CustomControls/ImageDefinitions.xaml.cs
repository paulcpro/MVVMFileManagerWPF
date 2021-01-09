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
    /// Logique d'interaction pour ImageDefinitions.xaml
    /// </summary>
    public partial class ImageDefinitions : UserControl
    {
        public ImageSource ImageSource
        {
            get
            {
                return this.btnImage.Source;
            }

            set
            {
                this.btnImage.Source = value;
            }

        }

        public string FirstText
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

        public string SecondText
        {
            get
            {
                return this.txtText2.Text;
            }

            set
            {
                this.txtText2.Text = value;
            }

        }

        public ImageDefinitions()
        {
            InitializeComponent();
        }

    }

}
