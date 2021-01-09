using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MVVMFIleManagerWPF.Helpers
{
    public static class IconToImageSource
    {
        #region Fields
        [DllImport("gdi32.dll", SetLastError = true)]
        /// Récupération de la méthode DeleteObject dans la dll GDI, vérifie présence HBitmap (si le pointeur alloué ou non)
        private static extern bool DeleteObject(IntPtr hObjetc);

        [DllImport("shell32")]
        /// Retrieves information about an object in the file system, such as a file, folder, directory, or drive root.
        private static extern int SHGetFileInfo(string pszPath, uint dwFileAttributes, out SHFILEINFO psfi, uint cbFileInfo, uint flags);

        #endregion //Fields

        /// <summary>
        /// Flags permettant de récupérer les offsets des icons Windows
        /// et ainsi d'utiliser ces dernières dans notre programme
        /// </summary>
        #region Flags

        private const uint FILE_ATTRIBUTE_READONLY = 0x00000001;
        private const uint FILE_ATTRIBUTE_HIDDEN = 0x00000002;
        private const uint FILE_ATTRIBUTE_SYSTEM = 0x00000004;
        private const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        private const uint FILE_ATTRIBUTE_ARCHIVE = 0x00000020;
        private const uint FILE_ATTRIBUTE_DEVICE = 0x00000040;
        private const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        private const uint FILE_ATTRIBUTE_TEMPORARY = 0x00000100;
        private const uint FILE_ATTRIBUTE_SPARSE_FILE = 0x00000200;
        private const uint FILE_ATTRIBUTE_REPARSE_POINT = 0x00000400;
        private const uint FILE_ATTRIBUTE_COMPRESSED = 0x00000800;
        private const uint FILE_ATTRIBUTE_OFFLINE = 0x00001000;
        private const uint FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000;
        private const uint FILE_ATTRIBUTE_ENCRYPTED = 0x00004000;
        private const uint FILE_ATTRIBUTE_VIRTUAL = 0x00010000;

        private const uint SHGFI_ICON = 0x000000100;     // get icon
        private const uint SHGFI_DISPLAYNAME = 0x000000200;     // get display name
        private const uint SHGFI_TYPENAME = 0x000000400;     // get type name
        private const uint SHGFI_ATTRIBUTES = 0x000000800;     // get attributes
        private const uint SHGFI_ICONLOCATION = 0x000001000;     // get icon location
        private const uint SHGFI_EXETYPE = 0x000002000;     // return exe type
        private const uint SHGFI_SYSICONINDEX = 0x000004000;     // get system icon index
        private const uint SHGFI_LINKOVERLAY = 0x000008000;     // put a link overlay on icon
        private const uint SHGFI_SELECTED = 0x000010000;     // show icon in selected state
        private const uint SHGFI_ATTR_SPECIFIED = 0x000020000;     // get only specified attributes
        private const uint SHGFI_LARGEICON = 0x000000000;     // get large icon
        private const uint SHGFI_SMALLICON = 0x000000001;     // get small icon
        private const uint SHGFI_OPENICON = 0x000000002;     // get open icon
        private const uint SHGFI_SHELLICONSIZE = 0x000000004;     // get shell size icon
        private const uint SHGFI_PIDL = 0x000000008;     // pszPath is a pidl
        private const uint SHGFI_USEFILEATTRIBUTES = 0x000000010;     // use passed dwFileAttribute

        #endregion //Flags

        #region Structs

        /// Création d'une classe contenant les informations mémoires d'une icon
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        #endregion //Structs

        #region Methods

        /// <summary>
        /// Convert an icon to imagesource using CreateBitmapSourceFromHBitmap function from Imaging class
        /// </summary>
        /// <param name="pIcon">Icon to converter</param>
        /// <returns>The Icon in ImageSource</returns>
        public static ImageSource ToImageSource(this Icon pIcon)
        {
            Bitmap lIconBitmap = pIcon.ToBitmap();
            IntPtr lHBitmap = lIconBitmap.GetHbitmap();

            ImageSource lImageSource = Imaging.CreateBitmapSourceFromHBitmap(lHBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            ///Check if the IntPtr still allocated
            if (!DeleteObject(lHBitmap))
            {
                MessageBox.Show("Failed to delete unused bitmap object");
            }

            return lImageSource;
        }

        /// <summary>
        /// Get the icon from windows
        /// </summary>
        /// <param name="pPath"></param>
        /// <param name="pSmallIcon"></param>
        /// <param name="pIsDirectoryOrDrive"></param>
        /// <returns></returns>
        public static Icon GetIconFile(string pPath, bool pSmallIcon, bool pIsDirectoryOrDrive)
        {
            uint lFlags = SHGFI_ICON | SHGFI_USEFILEATTRIBUTES;
            if (pSmallIcon)
            {
                lFlags |= SHGFI_SMALLICON;
            }

            uint lAttributes = FILE_ATTRIBUTE_NORMAL;
            if (pIsDirectoryOrDrive)
            {
                lAttributes |= FILE_ATTRIBUTE_DIRECTORY;
            }

            /// Verifiy if we retrieved successfully the object in the windows system
            int lSuccess = SHGetFileInfo(pPath, lAttributes, out SHFILEINFO pShfi, (uint)Marshal.SizeOf(typeof(SHFILEINFO)), lFlags);

            /// Si on a pas réussi à récupérer l'icon on renvoie rien
            if (lSuccess == 0)
            {
                return null;
            }

            return Icon.FromHandle(pShfi.hIcon);
        }

        #endregion //Methods

    }

}
