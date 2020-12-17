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
    public partial class MyAdverts : ContentPage
    {
        public MyAdverts()
        {
            InitializeComponent();
           
            var back_tap = new TapGestureRecognizer();
            back_tap.Tapped += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            back.GestureRecognizers.Add(back_tap);
            var Adverts = new List<Advert>
            {
              
            };
            MyAdvertsListView.ItemsSource = Adverts;
        }

        private void MyAdvertsListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}