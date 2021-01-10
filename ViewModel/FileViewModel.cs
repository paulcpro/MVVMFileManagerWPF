using MVVMFIleManagerWPF.CustomControls;
using MVVMFIleManagerWPF.Model;
using System.Collections.ObjectModel;

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
        public void TryToNavigateToPath(FileModel pFileModel)
        {

        }

        /// <summary>
        /// Call our method to navigate through repository
        /// </summary>
        /// <param name="pFileModel"></param>
        public void NavigateToPath(FileModel pFileModel)
        {
            TryToNavigateToPath(pFileModel);
        }

        /// <summary>
        /// CreateFileControl from a FileModel when we go through a repository to display all folders/files
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
