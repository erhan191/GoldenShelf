using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoldenShelf.ViewModels;
using System.IO;

namespace GoldenShelf.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        public BookPage(String BookName,String BookAuthor,String BookCategory,String Condition ,String ShareType, String Description ,String PublisherEmail,byte[]image)
        {
            InitializeComponent();
            BindingContext = new AdvertViewModel();
            var back_tap = new TapGestureRecognizer();
            back_tap.Tapped += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            back.GestureRecognizers.Add(back_tap);

            bookName.Text = BookName;
            bookAuthor.Text = BookAuthor;
            bookCategory.Text = BookCategory;
            condition.Text = Condition;
            shareType.Text = ShareType;
            description.Text = Description;
            adImage.Source = ImageSource.FromStream(() => new MemoryStream(image));
            getPublisherInfo(PublisherEmail);
            
        }
        
        private async void getPublisherInfo(String email)
        {
            UserViewModel userView = new UserViewModel();
            User user = await userView.GetUserByEmail(email);
            userName.Text = user.name;
            location.Text = user.city + "/" + user.district;

        }


        private void SendButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}