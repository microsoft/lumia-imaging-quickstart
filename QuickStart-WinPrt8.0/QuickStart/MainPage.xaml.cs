using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using Microsoft.Xna.Framework.Media;
using Lumia.Imaging;
using Lumia.Imaging.Artistic;
using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using System.Windows.Media.Imaging;
using Windows.Storage.Streams;
using System.Reflection;

namespace QuickStart
{
    public partial class MainPage : PhoneApplicationPage
    {
        // FilterEffect instance is used to apply different filters to an image.
        // Here we will apply Cartoon filter to an image.
        private FilterEffect _cartoonEffect = null;
        
        // The following WriteableBitmap contains the filtered and thumbnail image.
        private WriteableBitmap _cartoonImageBitmap = null;
        private WriteableBitmap _thumbnailImageBitmap = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

			var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
			TitleBlock.Text = string.Format("QuickStart v{0}.{1} using Lumia Imaging SDK v{2}", assemblyVersion.Major, assemblyVersion.Minor, SdkInfo.Version.ToLongVersionString());

            // Initialize WriteableBitmaps to render the filtered and original image.
            _cartoonImageBitmap = new WriteableBitmap((int)CartoonImage.Width, (int)CartoonImage.Height);
            _thumbnailImageBitmap = new WriteableBitmap((int)OriginalImage.Width, (int)OriginalImage.Height);
        }

        private void PickImage_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = false;

            PhotoChooserTask chooser = new PhotoChooserTask();
            chooser.Completed += PickImageCallback;
            chooser.Show();
        }

        private async void PickImageCallback(object sender, PhotoResult e)
        {
            if (e.TaskResult != TaskResult.OK || e.ChosenPhoto == null)
                return;

            try
            {
                // Show thumbnail of original image.
                _thumbnailImageBitmap.SetSource(e.ChosenPhoto);
                OriginalImage.Source = _thumbnailImageBitmap;

                // Rewind stream to start.                     
                e.ChosenPhoto.Position = 0;
                                
                // A cartoon effect is initialized with selected image stream as source.
                var imageStream = new StreamImageSource(e.ChosenPhoto);
                _cartoonEffect = new FilterEffect(imageStream);

                // Add the cartoon filter as the only filter for the effect.
                var cartoonFilter = new CartoonFilter();
                _cartoonEffect.Filters = new[] { cartoonFilter };

                // Render the image to a WriteableBitmap.
                var renderer = new WriteableBitmapRenderer(_cartoonEffect, _cartoonImageBitmap);
                _cartoonImageBitmap = await renderer.RenderAsync();

                // Set the rendered image as source for the cartoon image control.
                CartoonImage.Source = _cartoonImageBitmap;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;
            }

            SaveButton.IsEnabled = true;
        }

        private async void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = false;

            if (_cartoonEffect == null)
                return;

            var jpegRenderer = new JpegRenderer(_cartoonEffect);
            
            // Jpeg renderer gives the raw buffer for the filtered image.
            IBuffer jpegOutput = await jpegRenderer.RenderAsync();

            // Save the image as a jpeg to the saved pictures album.
            MediaLibrary library = new MediaLibrary();
            string fileName = string.Format("CartoonImage_{0:G}", DateTime.Now);
            var picture = library.SavePicture(fileName, jpegOutput.AsStream());

            MessageBox.Show("Image saved!");

            SaveButton.IsEnabled = true;
        }
    }
}