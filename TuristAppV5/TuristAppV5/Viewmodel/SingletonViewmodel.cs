using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TuristAppV5.Annotations;
using TuristAppV5.Model;

namespace TuristAppV5.Viewmodel
{
     public class SingletonViewmodel : INotifyPropertyChanged
    {
        private static SingletonViewmodel _instance;
        private ObservableCollection<Kategori> _kategoriCollection;
        private ObservableCollection<Kategoriliste> _minProfilCollection;
        private ObservableCollection<Kategoriliste> _eatOrangeCollection;
        private ObservableCollection<Kategoriliste> _seeOrangeCollection;
        private ObservableCollection<Kategoriliste> _shopOrangeCollection;
        private ObservableCollection<Kategoriliste> _feelOrangeCollection;
        private ObservableCollection<ObservableCollection<Kategoriliste>> _collectionOfCollectionForJson;
        private Kategoriliste _restaurantVigen;
        private Kategoriliste _restaurantHerthadalen;
        private Kategoriliste _roskildeKloster;
        private Kategoriliste _roskildeMuseum;
        private Kategoriliste _rosTorv;
        private Kategoriliste _elgiganten;
        private Kategoriliste _vikingeskibsMuseet;
        private const string Beskrivelse = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur dui sapien, ullamcorper vel volutpat ac, elementum vitae erat. Nam in est eu erat ornare pulvinar. Suspendisse potenti. \n\n Nam et rhoncus diam. Aliquam pretium nibh ut rutrum dictum. Aliquam quis fringilla nulla. Integer a magna tempor, eleifend nunc ut, blandit eros. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In viverra venenatis nibh at placerat.";

        protected SingletonViewmodel()
        {
            //Første kategori "Min Profil"
            _minProfilCollection = new ObservableCollection<Kategoriliste>();
            //_minProfilCollection.Add(new Kategoriliste("Prindsen", "12345678", "Hjemmeside", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Familien Rosted overtog Prindsen. de hun sin datters ku", "17:30-73:92"));

            //Anden Kategori "Eat Orange" (Restauranter)
            _eatOrangeCollection = new ObservableCollection<Kategoriliste>();
            _restaurantVigen = new Kategoriliste("Restaurant Vigen", "46755008", "http://www.vigen.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00");
            _restaurantHerthadalen = new Kategoriliste("Restaurant Herthadalen", "46480157", "http://herthadalen.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00");
            //for (int eat = 0; eat < 2; eat++)
            {
                _eatOrangeCollection.Add(_restaurantVigen);
                _eatOrangeCollection.Add(_restaurantHerthadalen);
            }
           
            //Tredje Kategori "See Orange" (Seværdigheder)
            _seeOrangeCollection = new ObservableCollection<Kategoriliste>();
            _roskildeKloster = new Kategoriliste("Roskilde Kloster", "46350219", "http://www.roskildekloster.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00");
            _roskildeMuseum = new Kategoriliste("Roskilde Museum", "46316529", "http://www.roskildemuseum.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00");
           // for (int see = 0; see < 2; see++)
            {
                _seeOrangeCollection.Add(_roskildeKloster);
                _seeOrangeCollection.Add(_roskildeMuseum);
            }
            
            //Fjerde Kategori "Shop Orange" (Shops)
            _shopOrangeCollection = new ObservableCollection<Kategoriliste>();
            _rosTorv = new Kategoriliste("Ro's Torv", "46380680", "http://www.rostorv.dk/", 55.641910, 12.087845,"../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00");
            _elgiganten = new Kategoriliste("Elgiganten", "46380697", "http://www.elgiganten.dk/", 55.641910, 12.087845,"../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00");
           // for (int shop = 0; shop < 2; shop++)
            {
                _shopOrangeCollection.Add(_rosTorv);
                _shopOrangeCollection.Add(_elgiganten);
            }
            

            //Femte Kategori "Feel Orange" (Aktiviteter)
            _feelOrangeCollection = new ObservableCollection<Kategoriliste>();
            _vikingeskibsMuseet = new Kategoriliste("Vikingeskibsmuseet", "46300200","http://www.vikingeskibsmuseet.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse,"9:30-21:00");
           // for (int feel = 0; feel < 4; feel++)
            {
                _feelOrangeCollection.Add(_vikingeskibsMuseet);
            }

            //Kategorilisten i toppen af MainPage
            _kategoriCollection = new ObservableCollection<Kategori>();
            _kategoriCollection.Add(new Kategori("Min profil", "../Assets/profile.png", _minProfilCollection));
            _kategoriCollection.Add(new Kategori("Eat Orange", "../Assets/eat.png", _eatOrangeCollection));
            _kategoriCollection.Add(new Kategori("See Orange", "../Assets/see.png", _seeOrangeCollection));
            _kategoriCollection.Add(new Kategori("Shop Orange", "../Assets/shop.png", _shopOrangeCollection));
            _kategoriCollection.Add(new Kategori("Feel Orange", "../Assets/feel.png", _feelOrangeCollection));

            // Collection til Json filen
            _collectionOfCollectionForJson = new ObservableCollection<ObservableCollection<Kategoriliste>>();
            _collectionOfCollectionForJson.Add(_minProfilCollection);
            _collectionOfCollectionForJson.Add(_eatOrangeCollection);
            _collectionOfCollectionForJson.Add(_seeOrangeCollection);
            _collectionOfCollectionForJson.Add(_shopOrangeCollection);
            _collectionOfCollectionForJson.Add(_feelOrangeCollection);
        }

        #region GetSet Metoder
        public ObservableCollection<Kategori> KategoriCollection
        {
            get { return _kategoriCollection; }
            set { _kategoriCollection = value; }
        }

        public ObservableCollection<Kategoriliste> MinProfilCollection
        {
            get { return _minProfilCollection; }
            set { _minProfilCollection = value; OnPropertyChanged("MinProfilCollection"); }
        }

        public ObservableCollection<Kategoriliste> EatOrangeCollection
        {
            get { return _eatOrangeCollection; }
            set { _eatOrangeCollection = value; OnPropertyChanged("EatOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> SeeOrangeCollection
        {
            get { return _seeOrangeCollection; }
            set { _seeOrangeCollection = value; OnPropertyChanged("SeeOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> ShopOrangeCollection
        {
            get { return _shopOrangeCollection; }
            set { _shopOrangeCollection = value; OnPropertyChanged("ShopOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> FeelOrangeCollection
        {
            get { return _feelOrangeCollection; }
            set { _feelOrangeCollection = value; OnPropertyChanged("FeelOrangeCollection"); }
        }

         public ObservableCollection<ObservableCollection<Kategoriliste>> CollectionOfCollectionForJson
         {
             get { return _collectionOfCollectionForJson; }
             set { _collectionOfCollectionForJson = value; }
         }
        #endregion
         public static SingletonViewmodel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SingletonViewmodel();
                }
                return _instance;
            }
        }
         
         #region OnPropertyChanged();

         public event PropertyChangedEventHandler PropertyChanged;

         [NotifyPropertyChangedInvocator]
         protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
         {
             PropertyChangedEventHandler handler = PropertyChanged;
             if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
         }

         #endregion

    }
}
