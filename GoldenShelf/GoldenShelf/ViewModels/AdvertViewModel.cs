using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoldenShelf.ViewModels
{
    class AdvertViewModel:BaseViewModel
    {
        static IMongoCollection<Advert> advertCollection;
        readonly static string dbName = "GoldenShelf";
        readonly static string collectionName = "Adverts";
        static MongoClient client;

        private List<Advert> _donationAdvertList;
        private string _bookName;
        private string _bookAuthor;
        private string _bookCategory;
        private string _shareType;
        private string _condition;
        private string _publisherEmail;
        private string _description;
        private byte[] _image;

        public AdvertViewModel()
        {
            SaveAdvertCommand = new Command(InsertAdvert);
            DeleteUserCommand = new Command(DeleteUser);
        }


        public string BookName
        {
            get { return _bookName; }
            set { SetValue(ref _bookName, value); }
        }

        public string BookAuthor
        {
            get { return _bookAuthor; }
            set { SetValue(ref _bookAuthor, value); }

        }
        public string BookCategory
        {
            get { return _bookCategory; }
            set { SetValue(ref _bookCategory, value); }
        }

        
        public string ShareType
        {
            get { return _shareType; }
            set { SetValue(ref _shareType, value); }
        }

        public byte[] Image
        {
            get { return _image; }
            set { SetValue(ref _image, value); }
        }

        public string Condition
        {
            get { return _condition; }
            set { SetValue(ref _condition, value); }
        }

        public string PublisherEmail
        {
            get { return _publisherEmail; }
            set { SetValue(ref _publisherEmail, value); }
        }

        public string Description
        {
            get { return _description; }
            set { SetValue(ref _description, value); }
        }
        public List<Advert> DonationAdvertList
        {
            get { return _donationAdvertList; }
            set { SetValue(ref _donationAdvertList, value);}

        }

        #region Get Functions
        public async Task<List<Advert>>GetAdverts()
        {
            try
            {
                var donationAdverts = await MongoConnection
                    .Find(new BsonDocument())
                    .ToListAsync();
                    return donationAdverts;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;

        }

        public async Task<List<Advert>> GetDonationAdverts()
        {
            try
            {
                var allAdverts = await MongoConnection
                    .Find(f => f.ShareType.Equals("Donate"))
                    .ToListAsync();
                return allAdverts;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public async Task<Advert> getAdvertViaPublisherEmail(String email)
        {
            var advert = await MongoConnection
                .Find(f => f.PublisherEmail.Equals(email))
                .FirstOrDefaultAsync();

            return advert;
        }


        public async Task<List<Advert>> GetExchangeAdverts()
        {
            try
            {
                var exchangeAdverts = await MongoConnection
                    .Find(f => f.ShareType.Equals("Exchange"))
                    .ToListAsync();
                return exchangeAdverts;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }



        #endregion

        #region Search Functions 

        #endregion

        #region Save/Delete Functions
        public async void InsertAdvert()
        {
            var newAdvert = new Advert
            {
              BookName=BookName,
              BookAuthor=BookAuthor,
              BookCategory=BookCategory,
              Image=Image,
              Condition=Condition,
              ShareType=ShareType,
              PublisherEmail=PublisherEmail,
              Description=Description

            };

            await MongoConnection.InsertOneAsync(newAdvert);
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async void InsertAdvert(Advert newAdvert)
        {
            await MongoConnection.InsertOneAsync(newAdvert);
            await Application.Current.MainPage.Navigation.PopAsync();
        }




        public async void DeleteUser(object obj)
        {
            var items = (Advert)obj;
            var result = await MongoConnection.DeleteOneAsync(tdi => tdi.AdvertID == items.AdvertID);


        }

        #endregion

        #region Command Functions

        public ICommand SaveAdvertCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }

        #endregion

        #region Connection
        public IMongoCollection<Advert> MongoConnection
        {
            get
            {
                if (client == null || advertCollection == null)
                {

                    var connectionString = "mongodb://User:9MKh9Sdt4X5Xkt5z@goldenshelf-shard-00-00.j5cx5.mongodb.net:27017,goldenshelf-shard-00-01.j5cx5.mongodb.net:27017,goldenshelf-shard-00-02.j5cx5.mongodb.net:27017/<dbname>?ssl=true&replicaSet=atlas-9097aj-shard-0&authSource=admin&retryWrites=true&w=majority";
                    MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };
                    client = new MongoClient(settings);
                    var db = client.GetDatabase(dbName);


                    var collectionSettings = new MongoCollectionSettings { ReadPreference = ReadPreference.Nearest };
                    advertCollection = db.GetCollection<Advert>(collectionName, collectionSettings);

                }
                return advertCollection;
            }
        }
        #endregion


    }
}

