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
    public partial class MessageDetailPage : ContentPage
    {

        public MessageDetailPage()
        {
            InitializeComponent();
            backclick();

        }

        public MessageDetailPage(string name, string sender, string imageurl, string bgcolor)
        {
            InitializeComponent();
            
            backclick();
            Name = name;
            this.BookName.Text = Name;

            Sender = sender;
            this.SenderName.Text = Sender;

            ImageUrl = imageurl;
            this.img.Source = ImageUrl;

            BGColor = bgcolor;
            this.BG.BackgroundColor = Color.FromHex(BGColor);

            this.LayoutBgColor.BackgroundColor = Color.FromHex(BGColor);


            var MessagesContent = new List<MessageContent>
            {   new MessageContent {Content="What do you think about changing with The Little Prince?",Location="0",ContentBackgroundColor="#CAC7B6" },
                new MessageContent {Content="Have you given it to somebody?",Location="1",ContentBackgroundColor="#EBCA28" },
                new MessageContent {Content="What do you think about changing with The Little Prince?",Location="0",ContentBackgroundColor="#CAC7B6" },
                new MessageContent {Content="Have you given it to somebody?",Location="1",ContentBackgroundColor="#EBCA28" },
                new MessageContent {Content="What do you think about changing with The Little Prince?",Location="0",ContentBackgroundColor="#CAC7B6" },
                new MessageContent {Content="Have you given it to somebody?",Location="1",ContentBackgroundColor="#EBCA28" },
                new MessageContent {Content="No I haven't?",Location="0",ContentBackgroundColor="#CAC7B6" },
                new MessageContent {Content="Do you want it?",Location="0",ContentBackgroundColor="#CAC7B6" },
                new MessageContent {Content="Yes I want to change it with The Little Prince?",Location="1",ContentBackgroundColor="#EBCA28" },
                new MessageContent {Content="Have you given it to somebody?",Location="1",ContentBackgroundColor="#EBCA28" },
                new MessageContent {Content="What do you think about changing with The Little Prince?",Location="0",ContentBackgroundColor="#CAC7B6" },
                new MessageContent {Content="Have you given it to somebody?",Location="1",ContentBackgroundColor="#EBCA28" },
                new MessageContent {Content="What do you think about changing with The Little Prince?",Location="0",ContentBackgroundColor="#CAC7B6" }
            };

            listview1.ItemsSource = MessagesContent;
            OnAppearing();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {

                myScroll.ScrollToAsync(0, 3000, true);
                return false;
            });
        }
       

        public string Name { get; }
        public string Sender { get; }
        public string ImageUrl { get; }
        public string BGColor { get; }

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
    }
}