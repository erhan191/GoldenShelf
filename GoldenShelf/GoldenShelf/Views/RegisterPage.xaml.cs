using GoldenShelf.ViewModels;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenShelf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {

        byte[] imagebyte;
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new LocationViewModel();

            UserViewModel user = new UserViewModel();
           
            
            var back_tap = new TapGestureRecognizer();
            back_tap.Tapped += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            back.GestureRecognizers.Add(back_tap);


        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            UserViewModel viewModel = new UserViewModel();
            var user = new User
            {
                name = name.Text,
                email = email.Text,
                city = cityPicker.SelectedItem.ToString(),
                district = districtPicker.SelectedItem.ToString(),
                password=password.Text,
                image=imagebyte
            };
            viewModel.InsertUser(user);
            


            await DisplayAlert("Registration", "You have registered", "OK");
           
        }
         protected override void OnDisappearing()
        {
            base.OnDisappearing();
           
        }

        private async void AddPhotoFromGallery(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device does not currently support this functionality", "OK");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (selectedImage == null)
            {
                await DisplayAlert("Error", "Could not get the image , please try again.", "OK");
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            imagebyte = GetImageStreamAsBytes(selectedImageFile.GetStream());

            //TODO :Add selection of multichocice

        }
        private async void TakePhoto(object sender, EventArgs e)
        {

            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device does not currently support this functionality", "OK");
                return;
            }

            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var selectedImageFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { AllowCropping = true, SaveToAlbum = true });


            if (selectedImage == null)
            {
                await DisplayAlert("Error", "Could not get the image , please try again.", "OK");
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            imagebyte = GetImageStreamAsBytes(selectedImageFile.GetStream());

            //TODO :Add selection of multichocice

        }
        // Image to Byte Converter
        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }


    }
}