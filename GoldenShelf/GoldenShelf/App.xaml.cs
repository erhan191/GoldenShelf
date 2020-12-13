using GoldenShelf.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenShelf
{
    public partial class App : Application
    {
        public const string emailKey = "email";
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new intro3());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        //Defines a key for email
        public string Email
        {
            get
            {
                if (Properties.ContainsKey(emailKey))
                {
                    SavePropertiesAsync();
                    return Properties[emailKey].ToString();
                }

                return "";
            }
            set
            {
                Properties[emailKey] = value;
            }
        }

    }
}
