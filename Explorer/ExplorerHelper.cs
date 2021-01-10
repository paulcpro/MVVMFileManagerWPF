using Shell32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFIleManagerWPF.Explorer
{
    public static class ExplorerHelper
    {

        #region Methods

        /// <summary>
        /// Check if the path is null or empty && if the file exists
        /// </summary>
        /// <param name="pPath">Path to check</param>
        /// <returns>If it's a file or not</returns>
        public static bool IsFile(this string pPath)
        {
            return !String.IsNullOrEmpty(pPath) && File.Exists(pPath);
        }

        /// <summary>
        /// Check if the path is null or empty && if the directory exists
        /// </summary>
        /// <param name="pPath">Path to check</param>
        /// <returns>If it's a drive or not</returns>
        public static bool IsDrive(this string pPath)
        {
            return !String.IsNullOrEmpty(pPath) && Directory.Exists(pPath);
        }

        /// <summary>
        /// Check if the path is null or empty && if the directory exists
        /// </summary>
        /// <param name="pPath">Path to check</param>
        /// <returns>If it's a drive or not</returns>
        public static bool IsDirectory(this string pPath)
        { 
            return !String.IsNullOrEmpty(pPath) && Directory.Exists(pPath);
        }

        /// <summary>
        /// Retrieve the file name from a Path
        /// </summary>
        /// <param name="pFullPath">Full path to get juste the file name</param>
        /// <returns>The FileName of a FullPath</returns>
        public static string GetFileName(this string pFullPath)
        {
            return Path.GetFileName(pFullPath);
        }

        /// <summary>
        /// Returns the directory path of the directory a file is located in
        /// (e.g, C:\f1\fold2\f3\helloworld.txt, returns C:\f1\fold2\f3)
        /// </summary>
        /// <param name="pFullPath">Full path to get juste the file name</param>
        /// <returns>The FileName of a FullPath</returns>
        public static string GetDirectory(this string pFullPath)
        {
            return Path.GetFileName(pFullPath);
        }
        
        /// <summary>
        /// Get if it's a file shortcut or not
        /// </summary>
        /// <param name="pPath">Path where is the shortcut</param>
        /// <returns>If it's a shorcut</returns>
        public static bool CheckPathIsShortcutFile(this string pPath)
        {
            return File.Exists(GetShortcutTargetFolder(pPath));
        }

        /// <summary>
        /// Get the link of the file shortcut
        /// </summary>
        /// <param name="pShortcutFileName">Path of the shortcut</param>
        /// <returns>Path of the shortcut</returns>
        public static string GetShortcutTargetFolder(string pShortcutFileName)
        {
            string pDirectoryName = pShortcutFileName.GetDirectory();
            string pFileName = pShortcutFileName.GetFileName();

            Shell lShell = new Shell();
            Folder lFolder = lShell.NameSpace(pDirectoryName);
            FolderItem lFolderItem = lFolder.ParseName(pFileName);

            if(lFolderItem != null)
            {
                ShellLinkObject lShellLink = lFolderItem.GetLink as ShellLinkObject;

                return lShellLink.Path;
            }

            return string.Empty;
        }

        #endregion //Methods

    }

}
