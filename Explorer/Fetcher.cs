using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMFIleManagerWPF.Model;
using MVVMFIleManagerWPF.Helpers;

namespace MVVMFIleManagerWPF.Explorer
{
    public class Fetcher
    {
        /// <summary>
        /// Add a FileModel made from DirectoryInfo and ShortcutHelper
        /// </summary>
        /// <param name="pPath">Path to the directory</param>
        /// <returns>A List of FileModel containing the Directories</returns>
        public static List<FileModel> GetDirectories(string pPath)
        {
            List<FileModel> lListFileModel = new List<FileModel>();

            /// Retrieve the directory info
            foreach(string lDirectory in Directory.GetDirectories(pPath))
            {
                DirectoryInfo lDirectoryInfo = new DirectoryInfo(lDirectory);

                FileModel lFileModel = new FileModel()
                {
                    Icon = IconToImageSource.GetIconFile(lDirectory, true, true),
                    Name = lDirectoryInfo.Name,
                    Path = lDirectoryInfo.FullName,
                    DateCreated = lDirectoryInfo.CreationTime,
                    DateModified = lDirectoryInfo.LastWriteTime,
                    Type = FileType.Folder,
                    Size = long.MaxValue                    
                };

                lListFileModel.Add(lFileModel);
            }

            /// Retrieve the shortcut directory 
            foreach (string lShortcut in Directory.GetFiles(pPath))
            {
                if(Path.GetExtension(lShortcut) == ".lnk")
                {
                    string lDirectoryPath = ExplorerHelper.GetShortcutTargetFolder(lShortcut);
                    FileInfo lFileInfo = new FileInfo(lDirectoryPath);

                    FileModel lFileModel = new FileModel()
                    {
                        Icon = IconToImageSource.GetIconFile(lDirectoryPath, true, true),
                        Name = lFileInfo.Name,
                        Path = lFileInfo.FullName,
                        DateCreated = lFileInfo.CreationTime,
                        DateModified = lFileInfo.LastWriteTime,
                        Type = FileType.Folder,
                        Size = 0
                    };

                    lListFileModel.Add(lFileModel);
                }

            }

            return lListFileModel;
        }

        /// <summary>
        /// Add a FileModel made from FileInfo
        /// </summary>
        /// <param name="pPath">Path to the file</param>
        /// <returns>A List of FileModel containing the Files</returns>
        public static List<FileModel> GetFiles(string pPath)
        {
            List<FileModel> lListFileModel = new List<FileModel>();

            foreach(string lFile in Directory.GetFiles(pPath))
            {
                FileInfo lFileInfo = new FileInfo(lFile);

                FileModel lFileModel = new FileModel()
                {
                    Icon = IconToImageSource.GetIconFile(lFile, true, true),
                    Name = lFileInfo.Name,
                    Path = lFileInfo.FullName,
                    DateCreated = lFileInfo.CreationTime,
                    DateModified = lFileInfo.LastWriteTime,
                    Type = FileType.File,
                    Size = lFileInfo.Length
                };

                lListFileModel.Add(lFileModel);
            }

            return lListFileModel;
        }

        /// <summary>
        /// Add a FileModel made from DriveInfo
        /// </summary>
        /// <param name="pPath">Path to the drives</param>
        /// <returns>A List of FileModel containing the Drives</returns>
        public static List<FileModel> GetDrives()
        {
            List<FileModel> lListFileModel = new List<FileModel>();


            foreach(string lDrive in Directory.GetLogicalDrives())
            {
                DriveInfo lDriveInfo = new DriveInfo(lDrive);

                FileModel lFileModel = new FileModel()
                {
                    Icon = IconToImageSource.GetIconFile(lDrive, true, true),
                    Name = lDriveInfo.Name,
                    Path = lDriveInfo.Name,
                    DateModified = DateTime.Now,
                    Type = FileType.Drive,
                    Size = lDriveInfo.TotalSize
                };

                lListFileModel.Add(lFileModel);
            }

            return lListFileModel;
        }

    }

}
