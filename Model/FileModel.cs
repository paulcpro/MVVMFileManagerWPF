using System;
using System.Drawing;

namespace MVVMFIleManagerWPF.Model
{
    public class FileModel
    {
        #region Fields

        private string mName;

        private Icon mIcon;

        private string mPath;

        private DateTime mDateCreated;

        private DateTime mDateModified;

        private long mSize;

        private string mExtension;

        private FileType mType;

        #endregion //Fields

        #region Properties

        /// <summary>
        /// Gets & Sets de notre mType
        /// </summary>
        public FileType Type
        {
            get
            {
                return this.mType;
            }

            set
            {
                this.mType = value;
            }

        }

        public DateTime DateCreated
        {
            get
            {
                return this.mDateCreated;
            }

            set
            {
                this.mDateCreated = value;
            }

        }

        public DateTime DateModified
        {
            get
            {
                return this.mDateModified;
            }

            set
            {
                this.mDateModified = value;
            }

        }

        public string Extension
        {
            get
            {
                return this.mExtension;
            }

            set
            {
                this.mExtension = value;
            }

        }

        public string Name
        {
            get
            {
                return this.mName;
            }

            set
            {
                this.mName = value;
            }
        }

        public string Path
        {
            get
            {
                return this.mPath;
            }

            set
            {
                this.mPath = value;
            }

        }

        public long Size
        {
            get
            {
                return this.mSize;
            }

            set
            {
                this.mSize = value;
            }

        }

        public Icon Icon
        {
            get
            {
                return this.mIcon;
            }

            set
            {
                this.mIcon = value;
            }

        }

        #endregion //Properties

    }

}
