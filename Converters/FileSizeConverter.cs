using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Data;

namespace MVVMFIleManagerWPF.Converters
{
    public class FileSizeConverter : IValueConverter
    {
        #region Fields

        [DllImport("Shlwapi.dll", CharSet = CharSet.Auto)]
        /// Get the Byte Size from a string
        public static extern long StrFormatByteSize(long fileSize, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder buffer, int bufferSize);

        #endregion //Fields

        #region Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if(value is long size)
            {
                if(size == long.MaxValue)
                {
                    return "-";
                }

                StringBuilder lVolume = new StringBuilder(20);
                StrFormatByteSize(size, lVolume, 20);

                return lVolume.ToString();
            }

            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (long)1;
        }

        #endregion //Methods

    }

}
