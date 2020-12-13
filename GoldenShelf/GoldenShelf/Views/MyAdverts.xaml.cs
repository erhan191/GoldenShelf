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
                new Advert {BookName="1984", BookAuthor = "George Orwell", BookCategory="Distopic", ImageUrl="https://i.dr.com.tr/cache/600x600-0/originals/0000000105409-1.jpg", BGColor="#1B9101"},
                new Advert { BookName = "Animal Farm", BookAuthor = "George Orwell", BookCategory = "Distopic", ImageUrl = "https://i.dr.com.tr/cache/600x600-0/originals/0000000105409-1.jpg", BGColor="#1B9101" },
                new Advert { BookName = "Little Prince", BookAuthor = "George Orwell", BookCategory = "Distopic", ImageUrl = "https://i.dr.com.tr/cache/600x600-0/originals/0000000105409-1.jpg", BGColor="#1B9101" }
            };
            MyAdvertsListView.ItemsSource = Adverts;
        }

        private void MyAdvertsListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}