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

        private static Kategori _selectedKategori;
        private static Kategoriliste _selectedKategoriliste;
        private SingletonViewmodel _singletonViewmodel = SingletonViewmodel.Instance;
        private TilfoejKommentarHandler _tilfoejKommentarHandler;
        private RelayCommand _tilfoejKommentarCommand;
        private RelayCommand _tilfoejToDoListeCommand;

        public MainViewmodel()
        {
            _tilfoejKommentarHandler = new TilfoejKommentarHandler(this);
            _tilfoejKommentarCommand = new RelayCommand(_tilfoejKommentarHandler.TilfoejKommentar);
            _tilfoejToDoListeCommand = new RelayCommand(_tilfoejKommentarHandler.TilfoejToDoListe);
            //_tilfoejKommentarHandler.SaveKategoriAsync();
            _tilfoejKommentarHandler.LoadKategoriAsync();
        }

        #region GetSet Metoder

        public ObservableCollection<Kategori> KategoriCollection
        {
            get { return _singletonViewmodel.KategoriCollection; }
            set { _singletonViewmodel.KategoriCollection = value; }
        }

        public ObservableCollection<Kategoriliste> MinProfilCollection
        {
            get { return _singletonViewmodel.MinProfilCollection; }
            set { _singletonViewmodel.MinProfilCollection = value; OnPropertyChanged("MinProfilCollection"); }
        }

        public ObservableCollection<Kategoriliste> EatOrangeCollection
        {
            get { return _singletonViewmodel.EatOrangeCollection; }
            set { _singletonViewmodel.EatOrangeCollection = value; OnPropertyChanged("EatOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> SeeOrangeCollection
        {
            get { return _singletonViewmodel.SeeOrangeCollection; }
            set { _singletonViewmodel.SeeOrangeCollection = value; OnPropertyChanged("SeeOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> ShopOrangeCollection
        {
            get { return _singletonViewmodel.ShopOrangeCollection; }
            set { _singletonViewmodel.ShopOrangeCollection = value; OnPropertyChanged("ShopOrangeCollection"); }
        }

        public ObservableCollection<Kategoriliste> FeelOrangeCollection
        {
            get { return _singletonViewmodel.FeelOrangeCollection; }
            set { _singletonViewmodel.FeelOrangeCollection = value; OnPropertyChanged("FeelOrangeCollection"); }
        }

        public ObservableCollection<ObservableCollection<Kategoriliste>> CollectionOfCollectionForJson
        {
            get { return _singletonViewmodel.CollectionOfCollectionForJson; }
            set
            {
                _singletonViewmodel.CollectionOfCollectionForJson = value; 
                OnPropertyChanged("CollectionOfCollectionForJson");
            }
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
        public static Kategoriliste SelectedKategoriliste
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

        public RelayCommand TilfoejToDoListeCommand
        {
            get { return _tilfoejToDoListeCommand; }
            set { _tilfoejToDoListeCommand = value; }
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
