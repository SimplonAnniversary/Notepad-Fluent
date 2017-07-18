using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace NotepadUwp.Models
{
    public static class DataModel
    {

        // Save
        public static void Save(TextDataModel data)
        {

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

            return data;
        }

    }
}
