using GoldenShelf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenShelf
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            backclick();
        }

        void backclick()
        {
            back.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(async () =>
                {
                    await Navigation.PopAsync();

                })
            });
        }
        public void ShowPass(object sender, EventArgs args)
        {
            Password.IsPassword = Password.IsPassword ? false : true;
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new HomePage();
            UserViewModel userView = new UserViewModel();
            var app = Application.Current as App;
            User user;
            try
            {

                user = await userView.GetUserByEmail(email.Text);

                if (email.Text.Equals(user.email) && Password.Text.Equals(user.password))
                {
                    app.Email = email.Text;
                    app.LoggedIn = "true";
                    App.Current.MainPage = new HomePage();

                }
                else
                {
                    await DisplayAlert("Login Failed", "You entered incorrect email/password.Try Again ", "OK");
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Kullanıcı bulunamadı", ex.Message, "OK");
            }
        }
    }
}