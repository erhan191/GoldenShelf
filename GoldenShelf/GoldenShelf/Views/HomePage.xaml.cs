using GoldenShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenShelf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : Shell
    {
        public HomePage()
        {
            InitializeComponent();
            var app = Application.Current as App;
            DisplayAlert("", app.Email, "OK");
            
                     
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

            MessageListView.ItemsSource = Messages;
        }
        public async void MessageListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem;

            await Navigation.PushAsync(new MessageDetailPage());
        }
        private void Photo_Add(object sender, EventArgs e)
        {
            //Fotoğraf ekleme butonu
            DisplayAlert("Add Photo", "Click here add some photo from your gallery!", "OK");
        }

        private void Share_Clicked(object sender, EventArgs e)
        {
            //Kitap Paylaş butonu
        }

        private async void EditProfile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditProfilePage());
        }

        private async void FilterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FilterPage());
        }


        private async void Profile_Tab_AppearingAsync(object sender, EventArgs e)
        {
            
            UserViewModel userView = new UserViewModel();
            var app = Application.Current as App;
            User user;
            try
            {

                user = await userView.GetUserByEmail(app.Email);
                profileTabName.Text = user.name;
                profileTabLocation.Text = user.city + "/" + user.district;
                profileTabEmail.Text=user.email;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Kullanıcı bulunamadı",ex.Message,"OK");
            }


          
        }
    }
}