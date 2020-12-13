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
    public partial class EditProfilePage : ContentPage
    {
        public EditProfilePage()
        {
            InitializeComponent();
            var back_tap = new TapGestureRecognizer();
            back_tap.Tapped += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            back.GestureRecognizers.Add(back_tap);
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Registration", "You have registered", "OK");
            await Navigation.PopAsync();
        }
    }
}