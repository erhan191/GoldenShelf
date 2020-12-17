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
    public partial class RegisterPage : ContentPage
    {
      

        public RegisterPage()
        {
            InitializeComponent();
            

            BindingContext = new UserViewModel();
           
            
            var back_tap = new TapGestureRecognizer();
            back_tap.Tapped += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            back.GestureRecognizers.Add(back_tap);


        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Registration", "You have registered", "OK");
           

        }
         protected override void OnDisappearing()
        {
            base.OnDisappearing();
           
        }
    }
}