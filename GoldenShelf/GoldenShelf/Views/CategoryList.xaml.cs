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
    public partial class CategoryList : ContentPage
    {
        public CategoryList()
        {
            InitializeComponent();
            var back_tap = new TapGestureRecognizer();
            back_tap.Tapped += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            back.GestureRecognizers.Add(back_tap);

            var Donations = new List<Advert>
            {
                new Advert {BookName="1984", BookAuthor = "George Orwell", BookCategory="Distopic"},
                new Advert { BookName = "Animal Farm", BookAuthor = "George Orwell", BookCategory = "Distopic"},
                new Advert { BookName = "Little Prince", BookAuthor = "George Orwell", BookCategory = "Distopic" }
            };
            var Exchanges = new List<Advert>
            {
                new Advert {BookName="1984", BookAuthor = "George Orwell", BookCategory="Distopic"},
                new Advert { BookName = "Animal Farm", BookAuthor = "George Orwell", BookCategory = "Distopic" },
                new Advert { BookName = "Little Prince", BookAuthor = "George Orwell", BookCategory = "Distopic" }
            };
            DonationsListView.ItemsSource = Donations;
            ExchangesListView.ItemsSource = Exchanges;
        }
        public string CName { get; }
        public string CImage { get; }
        public CategoryList(string cname)
        {
            InitializeComponent();
            var back_tap = new TapGestureRecognizer();
            back_tap.Tapped += async (s, e) =>
            {
                await Navigation.PopAsync();
            };
            back.GestureRecognizers.Add(back_tap);

            var Donations = new List<Advert>
            {
                new Advert {BookName="1984", BookAuthor = "George Orwell", BookCategory="Distopic"},
                new Advert { BookName = "Animal Farm", BookAuthor = "George Orwell", BookCategory = "Distopic" },
                new Advert { BookName = "Little Prince", BookAuthor = "George Orwell", BookCategory = "Distopic" }
            };
            var Exchanges = new List<Advert>
            {
                new Advert {BookName="1984", BookAuthor = "George Orwell", BookCategory="Distopic"},
                new Advert { BookName = "Animal Farm", BookAuthor = "George Orwell", BookCategory = "Distopic" },
                new Advert { BookName = "Little Prince", BookAuthor = "George Orwell", BookCategory = "Distopic" }
            };
            DonationsListView.ItemsSource = Donations;
            ExchangesListView.ItemsSource = Exchanges;

            CName = cname;
            this.CategoryName.Text = CName;

            OnAppearing();
        }
        public async void DonationListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem as Advert;

            await Navigation.PushAsync(new BookPage(myItem.BookName, myItem.BookAuthor, myItem.BookCategory, myItem.Condition, myItem.ShareType, myItem.Description, myItem.PublisherEmail, myItem.Image));

        }
        public async void ExchangeListview_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var myListView = (ListView)sender;
            var myItem = myListView.SelectedItem as Advert;

            await Navigation.PushAsync(new BookPage(myItem.BookName, myItem.BookAuthor, myItem.BookCategory, myItem.Condition, myItem.ShareType, myItem.Description, myItem.PublisherEmail, myItem.Image));
        }
    }
}