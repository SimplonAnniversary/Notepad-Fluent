using NotepadUwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NotepadUwp.ViewModels
{
    public class MainPageViewModel : NotificationBase
    {
        // Constructor
        public MainPageViewModel()
        {
            Data.DocumentTitle = "Untitled";
        }

        // Properties
        private TextDataViewModel _Data = new TextDataViewModel();
        public TextDataViewModel Data
        {
            get { return _Data; }
            set { SetProperty(ref _Data, value); }
        }

        //private string _DocumentTitle = "Untitled document";
        //public string DocumentTitle
        //{
        //    get { return _DocumentTitle; }
        //    set { SetProperty(ref _DocumentTitle, value); }
        //}

        private StorageFile _File;
        public StorageFile File
        {
            get { return _File; }
            set { SetProperty(ref _File, value); }
        }


        // Methods

        // Save

        // Save As
        public async Task<bool> SaveAs()
        {
            StorageFile file = await DataModel.SaveAs(_Data);

            // TODO - Set the StorageFile somewhere here to make saving later easier
            // TODO - Expose the proper check here for the UI to react to
            if (file != null)
            {
                File = file;
                Data.DocumentTitle = File.DisplayName + File.FileType;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Load
        public async Task<bool> Load()
        {
            TextDataModel data = await DataModel.Load();
            Data = new TextDataViewModel(data);

            //DocumentTitle = File.DisplayName + File.DisplayType;
            return true;
        }

    }
}
