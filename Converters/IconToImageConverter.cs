using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using MVVMFIleManagerWPF.Helpers;

namespace MVVMFIleManagerWPF.Converters
{
    class IconToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is Icon pIcon)
            {
                ImageSource lImageSource = pIcon.ToImageSource();
                pIcon.Dispose();

                return lImageSource;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
