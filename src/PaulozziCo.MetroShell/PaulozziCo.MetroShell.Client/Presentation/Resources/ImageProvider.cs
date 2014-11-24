using System;
using System.Windows.Media.Imaging;
using PaulozziCo.MetroShell.Utilities;

namespace PaulozziCo.MetroShell.Presentation.Resources
{
    internal class ImageProvider
    {
        #region Constants

        private const string ImageResourcePath = "Presentation/Icons/";
        private const string STR_Addpng = "add.png";
        private const string STR_Addedrowpng = "addedrow.png";
        private const string STR_CloseCommandpng = "closeCommand.png";
        private const string STR_Currentrowpng = "currentrow.png";
        private const string STR_Deletepng = "delete.png";
        private const string STR_Deletedrowpng = "deletedrow.png";
        private const string STR_Editpng = "edit.png";
        private const string STR_Excelpng = "excel.png";
        private const string STR_Haschangespng = "haschanges.png";
        private const string STR_Modifiedrowpng = "modifiedrow.png";
        private const string STR_Placeholderpng = "placeholder.png";
        private const string STR_Placeholderrowpng = "placeholderrow.png";
        private const string STR_Refreshpng = "refresh.png";
        private const string STR_RefreshCommandpng = "refreshCommand.png";
        private const string STR_Removepng = "remove.png";
        private const string STR_Removedrowpng = "removedrow.png";
        private const string STR_SaveCommandpng = "saveCommand.png";
        private const string STR_Errorpng = "error.png";
        private const string STR_Informationpng = "information.png";
        private const string STR_Warningpng = "warning.png";

        #endregion

        #region Fields

        private static BitmapImage addedRow;

        private static BitmapImage add;

        private static BitmapImage closeCommand;

        private static BitmapImage currentRow;

        private static BitmapImage deletedRow;

        private static BitmapImage delete;

        private static BitmapImage edit;

        private static BitmapImage excel;

        private static BitmapImage hasChanges;

        private static BitmapImage modifiedRow;

        private static BitmapImage placeholder;

        private static BitmapImage placeholderRow;

        private static BitmapImage refresh;

        private static BitmapImage refreshCommand;

        private static BitmapImage remove;

        private static BitmapImage removedRow;

        private static BitmapImage saveCommand;

        private static BitmapImage validationError;

        private static BitmapImage validationInformation;

        private static BitmapImage validationWarning;

        #endregion

        #region Properties

        public static BitmapImage Add
        {
            get
            {
                if (add == null)
                {
                    add = CreateBitmap(STR_Addpng);
                }
                return add;
            }
        }

        public static BitmapImage AddedRow
        {
            get
            {
                if (addedRow == null)
                {
                    addedRow = CreateBitmap(STR_Addedrowpng);
                }
                return addedRow;
            }
        }

        public static BitmapImage CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = CreateBitmap(STR_CloseCommandpng);
                }
                return closeCommand;
            }
        }

        public static BitmapImage CurrentRow
        {
            get
            {
                if (currentRow == null)
                {
                    currentRow = CreateBitmap(STR_Currentrowpng);
                }
                return currentRow;
            }
        }

        public static BitmapImage Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = CreateBitmap(STR_Deletepng);
                }
                return delete;
            }
        }

        public static BitmapImage DeletedRow
        {
            get
            {
                if (deletedRow == null)
                {
                    deletedRow = CreateBitmap(STR_Deletedrowpng);
                }
                return deletedRow;
            }
        }

        public static BitmapImage Edit
        {
            get
            {
                if (edit == null)
                {
                    edit = CreateBitmap(STR_Editpng);
                }
                return edit;
            }
        }

        public static BitmapImage Excel
        {
            get
            {
                if (excel == null)
                {
                    excel = CreateBitmap(STR_Excelpng);
                }
                return excel;
            }
        }

        public static BitmapImage HasChanges
        {
            get
            {
                if (hasChanges == null)
                {
                    hasChanges = CreateBitmap(STR_Haschangespng);
                }
                return hasChanges;
            }
        }

        public static BitmapImage ModifiedRow
        {
            get
            {
                if (modifiedRow == null)
                {
                    modifiedRow = CreateBitmap(STR_Modifiedrowpng);
                }
                return modifiedRow;
            }
        }

        public static BitmapImage Placeholder
        {
            get
            {
                if (placeholder == null)
                {
                    placeholder = CreateBitmap(STR_Placeholderpng);
                }
                return placeholder;
            }
        }

        public static BitmapImage PlaceholderRow
        {
            get
            {
                if (placeholderRow == null)
                {
                    placeholderRow = CreateBitmap(STR_Placeholderrowpng);
                }
                return placeholderRow;
            }
        }

        public static BitmapImage Refresh
        {
            get
            {
                if (refresh == null)
                {
                    refresh = CreateBitmap(STR_Refreshpng);
                }
                return refresh;
            }
        }

        public static BitmapImage RefreshCommand
        {
            get
            {
                if (refreshCommand == null)
                {
                    refreshCommand = CreateBitmap(STR_RefreshCommandpng);
                }
                return refreshCommand;
            }
        }

        public static BitmapImage Remove
        {
            get
            {
                if (remove == null)
                {
                    remove = CreateBitmap(STR_Removepng);
                }
                return remove;
            }
        }

        public static BitmapImage RemovedRow
        {
            get
            {
                if (removedRow == null)
                {
                    removedRow = CreateBitmap(STR_Removedrowpng);
                }
                return removedRow;
            }
        }

        public static BitmapImage SaveCommand
        {
            get
            {
                if (saveCommand == null)
                {
                    saveCommand = CreateBitmap(STR_SaveCommandpng);
                }
                return saveCommand;
            }
        }

        public static BitmapImage ValidationError
        {
            get
            {
                if (validationError == null)
                {
                    validationError = CreateBitmap(STR_Errorpng);
                }
                return validationError;
            }
        }

        public static BitmapImage ValidationInformation
        {
            get
            {
                if (validationInformation == null)
                {
                    validationInformation = CreateBitmap(STR_Informationpng);
                }
                return validationInformation;
            }
        }

        public static BitmapImage ValidationWarning
        {
            get
            {
                if (validationWarning == null)
                {
                    validationWarning = CreateBitmap(STR_Warningpng);
                }
                return validationWarning;
            }
        }

        #endregion

        #region Private Methods

        private static BitmapImage CreateBitmap(string path)
        {
            BitmapImage image = new BitmapImage();
            image.SetSource(ResourceUtilities.GetStream(GetImageFullPath(path)));
            return image;
        }

        private static string GetImageFullPath(string endPath)
        {
            return String.Format("{0}{1}",ImageResourcePath, endPath);
        }

        #endregion

    }
}
