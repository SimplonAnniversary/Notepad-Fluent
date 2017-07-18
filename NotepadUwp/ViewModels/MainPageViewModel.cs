using NotepadUwp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotepadUwp.ViewModels
{
    public class MainPageViewModel : NotificationBase
    {
        // Constructor
        public MainPageViewModel()
        {

        }

        // Properties
        private TextDataViewModel _Data = new TextDataViewModel();
        public TextDataViewModel Data
        {
            get { return _Data; }
            set { SetProperty(ref _Data, value); }
        }


        // Methods

        // Load
        public async Task<bool> Load()
        {
            TextDataModel data = await DataModel.Load();
            Data = new TextDataViewModel(data);
            return true;
        }

    }
}
