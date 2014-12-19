using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;

namespace QuickStart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : IFileOpenPickerContinuable, IFileSavePickerContinuable
    {
        private void PickImage(FileOpenPicker openPicker)
        {
            openPicker.PickSingleFileAndContinue();
        }

        private void SaveImage(FileSavePicker savePicker)
        {
            savePicker.PickSaveFileAndContinue();
        }

        public async void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            var file = args.Files.FirstOrDefault();
            if (file == null)
                return;

            if (!await ApplyFilterAsync(file))
                return;

            SaveButton.IsEnabled = true;
        }

        public async void ContinueFileSavePicker(FileSavePickerContinuationEventArgs args)
        {
            if (args.File == null)
                return;

            if (!await SaveImageAsync(args.File))
                return;

            SaveButton.IsEnabled = true;
        }
    }
}
