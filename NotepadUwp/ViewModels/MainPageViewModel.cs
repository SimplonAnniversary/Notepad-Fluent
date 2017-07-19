using NotepadUwp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

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

        // Paste
        public async Task<bool> Paste(int selectionStart)
        {
            bool success = false;

            // Get the datapackage
            var dataPackage = Clipboard.GetContent();

            // Get cursor position in text
            //int index = Data.CursorIndex;
            int index = selectionStart;

            // Paste behind the cursor
            try
            {
                if (dataPackage.Contains(StandardDataFormats.Text))
                {
                    var text = await dataPackage.GetTextAsync();
                    Data.Text = Data.Text.Insert(index, text);

                    success = true;
                }
            }
            catch
            {
                Debug.WriteLine("MainPageViewModel - Paste from clipboard FAILED");
            }

            
            return success;
        }

        // Copy
        public bool Copy(string text)
        {
            bool success = false;

            // Create DataPackage
            DataPackage dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;

            // Fill it with the selected text
            dataPackage.SetText(text);

            // Send it to the clipboard
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
            success = true;

            return success;
        }

        //TODO: Add drag 'n drop support

    }
}
