using MVVMFIleManagerWPF.CustomControls;
using MVVMFIleManagerWPF.Model;
using MVVMFIleManagerWPF.Explorer;
using System.Collections.ObjectModel;
using System.Windows;

namespace MVVMFIleManagerWPF.ViewModel
{

    public class FileViewModel
    {
        #region Fields

        private ObservableCollection<FileControl> mFileItems;

        #endregion //Fields

        #region Properties

        /// <summary>
        /// ObservableCollection used to add a Custom Control
        /// </summary>
        public ObservableCollection<FileControl> FileItems
        {
            get
            {
                return this.mFileItems;
            }

            set
            {
                this.mFileItems = value;
            }

        }

        #endregion //Properties

        #region Constructors

        public FileViewModel()
        {
            FileItems = new ObservableCollection<FileControl>();
        }

        #endregion //Constructors

        #region Methods

        /// <summary>
        /// Add a FileControl to our ObservableCollection<FileControl> List
        /// </summary>
        public void AddFileControl(FileControl pFileControl)
        {
            FileItems.Add(pFileControl);
        }

        /// <summary>
        /// Remove a FileControl to our ObservableCollection<FileControl> List
        /// </summary>
        /// <param name="pFileControl"></param>
        public void RemoveFileControl(FileControl pFileControl)
        {
            FileItems.Remove(pFileControl);
        }

        /// <summary>
        /// Clear our ObservableCollection<FileControl> List
        /// </summary>
        public void ClearFileControl()
        {
            FileItems.Clear();
        }

        /// <summary>
        /// Check depending if it's a folder or a file we execute the file or we open the folder
        /// </summary>
        /// <param name="pFileModel"></param>
        public void TryToNavigateToPath(string pPath)
        {
            ///If no path it's a drive
            if(pPath == string.Empty)
            {
                ClearFileControl();
                ///Its a Drive
                foreach(FileModel lFileModel in Fetcher.GetDrives())
                {
                    AddFileControl(CreateFileControl(lFileModel));
                }

            }
            
            /// ExplorerHelper static IsDirectory(this string pPath); that why we don't need to redefine our string
            else if(pPath.IsDirectory())
            {
                ClearFileControl();
                ///Open our directory
                foreach(FileModel lFileModel in Fetcher.GetDirectories(pPath))
                {
                    AddFileControl(CreateFileControl(lFileModel));
                }

                foreach(FileModel lFileModel in Fetcher.GetFiles(pPath))
                {
                    AddFileControl(CreateFileControl(lFileModel));
                }

            }

            else if(pPath.IsFile())
            {
                MessageBox.Show($"Openning {pPath}");
            }

            else
            {
                /// Something bad happens
            }
            
        }

        /// <summary>
        /// Call our method to navigate through repository
        /// </summary>
        /// <param name="pFileModel"></param>
        public void NavigateToPath(FileModel pFileModel)
        {
            TryToNavigateToPath(pFileModel.Path);
        }

        /// <summary>
        /// CreateFileControl from a FileModel when we go through a repository to display all folders/files "Action<FileModel>"
        /// </summary>
        /// <param name="pFileModel"></param>
        public FileControl CreateFileControl(FileModel pFileModel)
        {
            FileControl lFc = new FileControl(pFileModel);
            SetupFileControlCallBacks(lFc);
            return lFc;
        }

        /// <summary>
        /// Call the Action<FileModel> defined in FileControl to 
        /// </summary>
        /// <param name="pFileControl"></param>
        public void SetupFileControlCallBacks(FileControl pFileControl)
        {
            pFileControl.NavigateToPath = NavigateToPath;
        }

        #endregion //Methods

    }

}
