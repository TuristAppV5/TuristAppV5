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
        private static SingletonViewmodel instance;
        private ObservableCollection<Kategori> _kategoriCollection;
        private ObservableCollection<Kategoriliste> _minProfilCollection;
        private ObservableCollection<Kategoriliste> _eatOrangeCollection;
        private ObservableCollection<Kategoriliste> _seeOrangeCollection;
        private ObservableCollection<Kategoriliste> _shopOrangeCollection;
        private ObservableCollection<Kategoriliste> _feelOrangeCollection;

         private const string Beskrivelse = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur dui sapien, ullamcorper vel volutpat ac, elementum vitae erat. Nam in est eu erat ornare pulvinar. Suspendisse potenti. \n\n Nam et rhoncus diam. Aliquam pretium nibh ut rutrum dictum. Aliquam quis fringilla nulla. Integer a magna tempor, eleifend nunc ut, blandit eros. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. In viverra venenatis nibh at placerat.";

        protected SingletonViewmodel()
        {
            //Første kategori "Min Profil"
            _minProfilCollection = new ObservableCollection<Kategoriliste>();
            //_minProfilCollection.Add(new Kategoriliste("Prindsen", "12345678", "Hjemmeside", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Familien Rosted overtog Prindsen. de hun sin datters ku", "17:30-73:92"));

            //Anden Kategori "Eat Orange" (Restauranter)
            _eatOrangeCollection = new ObservableCollection<Kategoriliste>();
            for (int eat = 0; eat < 8; eat++)
            {
                _eatOrangeCollection.Add(new Kategoriliste("Restaurant Vigen", "46755008", "http://www.vigen.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00"));
                _eatOrangeCollection.Add(new Kategoriliste("Restaurant Herthadalen", "46480157", "http://herthadalen.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00"));
            }
           
            //Tredje Kategori "See Orange" (Seværdigheder)
            _seeOrangeCollection = new ObservableCollection<Kategoriliste>();
            for (int see = 0; see < 4; see++)
            {
                _seeOrangeCollection.Add(new Kategoriliste("Roskilde Kloster", "46350219", "http://www.roskildekloster.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00"));
                _seeOrangeCollection.Add(new Kategoriliste("Roskilde Museum", "46316529", "http://www.roskildemuseum.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00"));
            }
            
            //Fjerde Kategori "Shop Orange" (Shops)
            _shopOrangeCollection = new ObservableCollection<Kategoriliste>();
            for (int shop = 0; shop < 7; shop++)
            {
                _shopOrangeCollection.Add(new Kategoriliste("Ro's Torv", "46380680", "http://www.rostorv.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00"));
                _shopOrangeCollection.Add(new Kategoriliste("Elgiganten", "46380697", "http://www.elgiganten.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00"));
            }
            

            //Femte Kategori "Feel Orange" (Aktiviteter)
            _feelOrangeCollection = new ObservableCollection<Kategoriliste>();
            for (int feel = 0; feel < 15; feel++)
            {
                _feelOrangeCollection.Add(new Kategoriliste("Vikingeskibsmuseet", "46300200", "http://www.vikingeskibsmuseet.dk/", 55.641910, 12.087845, "../Assets/restaurant.jpeg", Beskrivelse, "9:30-21:00"));
            }
           

            //Kategorilisten i toppen af MainPage
            _kategoriCollection = new ObservableCollection<Kategori>();
            _kategoriCollection.Add(new Kategori("Min profil", "../Assets/visitroskilde.png", _minProfilCollection));
            _kategoriCollection.Add(new Kategori("Eat Orange", "../Assets/visitroskilde.png", _eatOrangeCollection));
            _kategoriCollection.Add(new Kategori("See Orange", "../Assets/visitroskilde.png", _seeOrangeCollection));
            _kategoriCollection.Add(new Kategori("Shop Orange", "../Assets/visitroskilde.png", _shopOrangeCollection));
            _kategoriCollection.Add(new Kategori("Feel Orange", "../Assets/visitroskilde.png", _feelOrangeCollection));




        }
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

        public static SingletonViewmodel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonViewmodel();
                }
                return instance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
