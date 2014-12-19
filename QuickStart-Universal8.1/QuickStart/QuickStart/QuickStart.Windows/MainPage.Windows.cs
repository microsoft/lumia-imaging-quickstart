using Lumia.Imaging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace QuickStart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        private async void PickImage(FileOpenPicker openPicker)
        {
            // Open the file picker.
            StorageFile file = await openPicker.PickSingleFileAsync();

            // file is null if user cancels the file picker.
            if (file != null)
            {
                if (!(await ApplyFilterAsync(file)))
                    return;

                SaveButton.IsEnabled = true;
            }
        }

        private async void SaveImage(FileSavePicker savePicker)
        {
            var file = await savePicker.PickSaveFileAsync();
            if (file != null)
            {
                await SaveImageAsync(file);
            }

            SaveButton.IsEnabled = true;
        }
    }
}
