using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;

namespace NotepadUwp.Models
{
    public static class DataModel
    {

        // Save
        public static void Save(TextDataModel data)
        {

        }

        // Save As
        public static async Task<StorageFile> SaveAs(TextDataModel data)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.FileTypeChoices.Add("Text Documents", new List<string>() { ".txt" });
            if (data.DocumentTitle != "")
            {
                picker.SuggestedFileName = data.DocumentTitle;
                // TODO: Get original file here as well
            }
            else
            {
                picker.SuggestedFileName = "Untitled";
            }

            StorageFile file = await picker.PickSaveFileAsync();

            if (file != null)
            {
                // Prevent remote access to file until saving is done
                CachedFileManager.DeferUpdates(file);

                // Write the stuff to the file
                await FileIO.WriteTextAsync(file, data.Text);

                // Let Windows know stuff is done
                FileUpdateStatus status = await CachedFileManager.CompleteUpdatesAsync(file);

                // TODO; Let the user know stuff has been saved
            }


            return file;

        }

        // Load
        public static async Task<TextDataModel> Load()
        {
            TextDataModel data = new TextDataModel();

            FileOpenPicker picker = new FileOpenPicker();
            picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
            picker.ViewMode = PickerViewMode.List;
            picker.FileTypeFilter.Add("*");
            StorageFile file = await picker.PickSingleFileAsync();

            if (file != null)
            {
                try
                {
                    data.Text = await FileIO.ReadTextAsync(file);
                }
                catch { }
            }

            data.DocumentTitle = file.DisplayName + file.FileType;


            return data;
        }

    }
}
