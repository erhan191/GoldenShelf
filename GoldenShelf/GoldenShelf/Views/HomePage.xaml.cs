using GoldenShelf.ViewModels;
using GoldenShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using System.Drawing;

namespace GoldenShelf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : Shell
    {
        public byte[] imagebyte;
        public ObservableCollection<Advert> DonationAdverts { get; set; }
        public ObservableCollection<Advert> ExchangeAdverts { get; set; }

        AdvertViewModel advertViewModel = new AdvertViewModel();


        public HomePage()
        {
            InitializeComponent();

            DonationAdverts = new ObservableCollection<Advert>();
            ExchangeAdverts = new ObservableCollection<Advert>();

            BindingContext = advertViewModel;

         
            var Messages = new List<Message>
            {
                new Message {Name="Animal Farm", Sender="John", MessageText="What dou you think about changin? ",ImageUrl="https://i.dr.com.tr/cache/600x600-0/originals/0000000105409-1.jpg",BGColor="#00B5B9" },
                new Message {Name="1984", Sender="Michael", MessageText="Have you given it to somebody?", ImageUrl="https://i.dr.com.tr/cache/500x400-0/originals/0000000064038-1.jpg",BGColor="#1B9101" },
                new Message {Name="Animal Farm", Sender="John", MessageText="What dou you think about changin? ",ImageUrl="https://i.dr.com.tr/cache/600x600-0/originals/0000000105409-1.jpg",BGColor="#00B5B9" },
                new Message {Name="1984", Sender="Michael", MessageText="Have you given it to somebody?", ImageUrl="https://i.dr.com.tr/cache/500x400-0/originals/0000000064038-1.jpg",BGColor="#1B9101" },
                new Message {Name="Animal Farm", Sender="John", MessageText="What dou you think about changin? ",ImageUrl="https://i.dr.com.tr/cache/600x600-0/originals/0000000105409-1.jpg",BGColor="#00B5B9" },
                new Message {Name="1984", Sender="Michael", MessageText="Have you given it to somebody?", ImageUrl="https://i.dr.com.tr/cache/500x400-0/originals/0000000064038-1.jpg",BGColor="#1B9101" },
                new Message {Name="Animal Farm", Sender="John", MessageText="What dou you think about changin? ",ImageUrl="https://i.dr.com.tr/cache/600x600-0/originals/0000000105409-1.jpg",BGColor="#00B5B9" },
                new Message {Name="1984", Sender="Michael", MessageText="Have you given it to somebody?", ImageUrl="https://i.dr.com.tr/cache/500x400-0/originals/0000000064038-1.jpg",BGColor="#1B9101" }
            };



            DonationsListView.ItemsSource = DonationAdverts;
            ExchangesListView.ItemsSource = ExchangeAdverts;
            MessageListView.ItemsSource = Messages;

        }

        



        public async void MessageListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedInstructor = e.Item as Message;
            await Navigation.PushAsync(new MessageDetailPage(selectedInstructor.Name, selectedInstructor.Sender, selectedInstructor.ImageUrl, selectedInstructor.BGColor));

        }
        public async void DonationListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem;

            await Navigation.PushAsync(new BookPage());
        }
        public async void ExchangeListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem;

            await Navigation.PushAsync(new BookPage());
        }
        private async void AddPhotoFromGallery(object sender, EventArgs e)
        {
           
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported||! CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Not supported", "Your device does not currently support this functionality", "OK");
                return;
            }

            var mediaOptions = new PickMediaOptions() {
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
            var selectedImageFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions{AllowCropping = true });
               

            if (selectedImage == null)
            {
                await DisplayAlert("Error", "Could not get the image , please try again.", "OK");
            }
            selectedImage.Source = ImageSource.FromStream(() => selectedImageFile.GetStream());
            imagebyte = GetImageStreamAsBytes(selectedImageFile.GetStream());
           

            //TODO :Add selection of multichocice

        }

        private void Share_Clicked(object sender, EventArgs e)
        {
            var app = Application.Current as App;
            Advert newAdvert = new Advert
            {
                BookAuthor = bookAuthor.Text,
                BookCategory = bookCategoryPicker.SelectedItem.ToString(),
                BookName = bookName.Text,
                Condition = bookConditionPicker.SelectedItem.ToString(),
                Description = description.Text,
                ShareType = shareTypePicker.SelectedItem.ToString(),
                PublisherEmail = app.Email,
                Image = imagebyte


            };
            advertViewModel.InsertAdvert(newAdvert);

            DisplayAlert("Successful", "You published a new advert succesfully", "OK");

            //Kitap Paylaş butonu
        }

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


        private async void EditProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage());
        }

        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterPage());
        }

        private async void MyAdvertsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyAdverts());
        }
        private async void HomePageAppears(object sender, EventArgs e)
        {
            //-------------- To show Donation Adverts on the main page
            var donationAdverts = await advertViewModel.GetDonationAdverts();

            foreach (var item in donationAdverts)
            {
                if (!DonationAdverts.Any((arg) => arg.AdvertID == item.AdvertID))
                    DonationAdverts.Add(item);
            }
            //------------------------------------------------------------------------
            //-------------- To show Donation Adverts on the main page
            var exchangeAdverts = await advertViewModel.GetExchangeAdverts();

            foreach (var item in exchangeAdverts)
            {
                if (!ExchangeAdverts.Any((arg) => arg.AdvertID == item.AdvertID))
                    ExchangeAdverts.Add(item);
            }

            //TODO: On Appering calısmıyor bu methodlar orada çalışmalı. 
            //------------------------------------------------------------------------

            
            //To show profile information to user using saved email 
            
            UserViewModel userView = new UserViewModel();
            var app = Application.Current as App;
            User user;
            try
            {

                user = await userView.GetUserByEmail(app.Email);
                profileTabName.Text = user.name;
                profileTabLocation.Text = user.city + "/" + user.district;
                profileTabEmail.Text = user.email;
                changeName.Text = user.name;
                changeEmail.Text = user.email;
                changeLocation.Text = user.city + "/" + user.district;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Kullanıcı bulunamadı", ex.Message, "OK");
            }

        }
    }
}