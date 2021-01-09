using MVVMFIleManagerWPF.Model;
using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace MVVMFIleManagerWPF.CustomControls
{
    /// <summary>
    /// Logique d'interaction pour FileControl.xaml
    /// </summary>
    public partial class FileControl : UserControl
    {


        #region Fields

            

        #endregion //Fields

        #region Properties

        /// <summary>
        /// Initialize a FileModel from his DataContext to access to his properties
        /// </summary>
        public FileModel FileModel
        {
            get
            {
                return this.DataContext as FileModel;
            }

            set
            {
                this.DataContext = value;
            }

        }

        #endregion //Properties


        #region Constructors

        /// <summary>
        /// Initialize a FileControl Component (Illustrate and formate a file in our UI)
        /// </summary>
        public FileControl()
        {
            InitializeComponent();
            FileModel = new FileModel();
        }

        /// <summary>
        /// Initialize a FileControl with a specific FileModel
        /// </summary>
        public FileControl(FileModel pFileModel)
        {
            InitializeComponent();
            FileModel = pFileModel;
        }

        #endregion //Constructors

        /// <summary>
        /// Used to put an image options button
        /// </summary>
        public ImageSource ImageOptions
        {
            get
            {
                return this.btnImageOptions.Source;
            }

            set
            {
                this.btnImageOptions.Source = value;
            }

        }

        /// <summary>
        /// Used to put an add image button
        /// </summary>
        public ImageSource ImageAdd
        {
            get
            {
                return this.btnImageAdd.Source;
            }

            set
            {
                this.btnImageAdd.Source = value;
            }

        }

        /// <summary>
        /// Used to put an image sharing button
        /// </summary>
        public ImageSource ImageShare
        {
            get
            {
                return this.btnImageShare.Source;
            }

            set
            {
                this.btnImageShare.Source = value;
            }

        }

        /// <summary>
        /// File Number
        /// </summary>
        public string Text
        {
            get
            {
                return this.txtFileNumber.Text;
            }

            set
            {
                this.txtFileNumber.Text = value;
            }

        }

    }

}
