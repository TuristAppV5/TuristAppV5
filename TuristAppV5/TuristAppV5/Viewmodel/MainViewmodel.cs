using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TuristAppV5.Annotations;
using TuristAppV5.Common;
using TuristAppV5.Model;

namespace TuristAppV5.Viewmodel
{
    public class MainViewmodel : INotifyPropertyChanged
    {
        private ObservableCollection<Kategori> _kategoriCollection;
        private ObservableCollection<Kategoriliste> _minProfilCollection;
        private ObservableCollection<Kategoriliste> _eatOrangeCollection;
        private ObservableCollection<Kategoriliste> _seeOrangeCollection;
        private ObservableCollection<Kategoriliste> _shopOrangeCollection;
        private ObservableCollection<Kategoriliste> _feelOrangeCollection;
        private Kategori _selectedKategori;
        private static Kategoriliste _selectedKategoriliste;
        private RelayCommand _tilfoejKommentarCommand;
        private TilfoejKommentarHandler _tilfoejKommentarHandler;
        private RelayCommand _tilfoejToDoListe;

        public MainViewmodel()
        {
            //Første kategori "Min Profil"
            _minProfilCollection = new ObservableCollection<Kategoriliste>();
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("test", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));
            _minProfilCollection.Add(new Kategoriliste("Prindsen", "12345678", "Book", "Laengdegrad", "Breddegrad","../Assets/restaurant.jpeg","Familien Rosted overtog Prindsen. Carl Christian Rosted døde i 1787 kun 46 år gammel. Hans enke Anne Marie besluttede at drive gæstgivergården videre. Hun var en arbejdsom kvinde, som samtidig med at hun opfostrede tre børn formåede at give Prindsen ry for at være et godt spisested. Madam Rosted overlevede alle sine tre børn, så i sine sidste år havde hun sin datters kusine Agathe Johanne Hansen i huset til oplæring som sin efterfølger. Agathe giftede sig med kaptajn Niels Christian Sveistrup, som i 1825 blev ejer af Prindsen efter Madam Rosteds død. Kaptajn Sveistrup var en prominent borger i Roskilde og havde adskillige tillidshverv. Han lod opføre en ny stor festsal hvor borgerne i det lille Roskilde, kunne få brudt ensformigheden med baller, spisegilder, koncerter og teater. Kaptajn Sveistrup døde i 1874 som æresborger i Roskilde.","Man-Fre: 15-22, Lør 12-18"));

            //Anden Kategori "Eat Orange" (Restauranter)
            _eatOrangeCollection = new ObservableCollection<Kategoriliste>();
            _eatOrangeCollection.Add(new Kategoriliste("Navn(Eat Orange)", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));

            //Tredje Kategori "See Orange" (Seværdigheder)
            _seeOrangeCollection = new ObservableCollection<Kategoriliste>();
            _seeOrangeCollection.Add(new Kategoriliste("Navn(See Orange)", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));

            //Anden Kategori "Eat Orange" (Restauranter)
            _eatOrangeCollection = new ObservableCollection<Kategoriliste>();
            _eatOrangeCollection.Add(new Kategoriliste("Navn(Eat Orange)", "12345678", "Book", "Laengdegrad", "Breddegrad", "Billede", "Beskrivelse", "Aabningstider"));

            //Tredje Kategori "See Orange" (Seværdigheder)
            _seeOrangeCollection = new ObservableCollection<Kategoriliste>();
            _seeOrangeCollection.Add(new Kategoriliste("Navn(See Orange)", "12345678", "Book", "Laengdegrad", "Breddegrad", "Billede", "Beskrivelse", "Aabningstider"));

            //Fjerde Kategori "Shop Orange" (Shops)
            _shopOrangeCollection = new ObservableCollection<Kategoriliste>();
            _shopOrangeCollection.Add(new Kategoriliste("Navn(Shop Orange)", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));

            //Femte Kategori "Feel Orange" (Aktiviteter)
            _feelOrangeCollection = new ObservableCollection<Kategoriliste>();
            _feelOrangeCollection.Add(new Kategoriliste("Navn(Feel Orange)", "12345678", "Book", "Laengdegrad", "Breddegrad", "../Assets/restaurant.jpeg", "Beskrivelse", "Aabningstider"));


            //Kategorilisten i toppen af MainPage
            _kategoriCollection = new ObservableCollection<Kategori>();
            _kategoriCollection.Add(new Kategori("Min profil", "../Assets/visitroskilde.png", _minProfilCollection));
            _kategoriCollection.Add(new Kategori("Eat Orange", "../Assets/visitroskilde.png", _eatOrangeCollection));
            _kategoriCollection.Add(new Kategori("See Orange", "../Assets/visitroskilde.png", _seeOrangeCollection));
            _kategoriCollection.Add(new Kategori("Shop Orange", "../Assets/visitroskilde.png", _shopOrangeCollection));
            _kategoriCollection.Add(new Kategori("Feel Orange", "../Assets/visitroskilde.png", _feelOrangeCollection));
           
            _tilfoejKommentarHandler = new TilfoejKommentarHandler(this);
            _tilfoejKommentarCommand = new RelayCommand(_tilfoejKommentarHandler.TilfoejKommentar);
            _tilfoejKommentarCommand = new RelayCommand(_tilfoejKommentarHandler.TilfoejToDoListe);
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

        public Kategori SelectedKategori
        {
            get { return _selectedKategori; }
            set
            {
                _selectedKategori = value; 
                OnPropertyChanged("SelectedKategori"); 
            }
        }
        public Kategoriliste SelectedKategoriliste
        {
            get { return _selectedKategoriliste; }
            set 
            {
                _selectedKategoriliste = value; 
            }
        }

        public RelayCommand TilfoejKommentarCommand
        {
            get { return _tilfoejKommentarCommand; }
            set { _tilfoejKommentarCommand = value; }
        }

        public TilfoejKommentarHandler TilfoejKommentarHandler
        {
            get { return _tilfoejKommentarHandler; }
            set { _tilfoejKommentarHandler = value; }
        }

        public RelayCommand TilfoejToDoListe
        {
            get { return _tilfoejToDoListe; }
            set { _tilfoejToDoListe = value; }
        }

        #endregion

        #region ProtertyChanged
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
