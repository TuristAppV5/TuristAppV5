﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using TuristAppV5.Annotations;
using TuristAppV5.Model;
using TuristAppV5.View;
using TuristAppV5.Viewmodel;

namespace TuristAppV5.Viewmodel
{
    public class TilfoejKommentarHandler : INotifyPropertyChanged
    {
        private DateTime _dato;
        private string _navn;
        private string _tekst;
        private MainViewmodel _mainViewmodel;
        private string _testNavnText = "";
        private string _testKategori = "";
        private string _testBeskrivelseText = "";
        private string _succesText = "";


        public void TilfoejToDoListe()
        {
            _mainViewmodel.MinProfilCollection.Add(MainViewmodel.SelectedKategoriliste);
            MessageDialog kval = new MessageDialog("Tilføjet til To-Do liste");
            kval.ShowAsync();
            SaveKategoriAsync();
        }
        public async void SaveKategoriAsync()
        {
            PersistenceFacade.SaveKategorilisteAsJsonAsync(_mainViewmodel.CollectionOfCollectionForJson);
        }
        public async void LoadKategoriAsync()
        {

            ObservableCollection<ObservableCollection<Kategoriliste>> _kategorilisteCollection = await PersistenceFacade.LoadKategorilisteFromJsonAsync();

            if (_kategorilisteCollection != null)
            {
                #region Clear();
                _mainViewmodel.MinProfilCollection.Clear();
                _mainViewmodel.EatOrangeCollection.Clear();
                _mainViewmodel.SeeOrangeCollection.Clear();
                _mainViewmodel.ShopOrangeCollection.Clear();
                _mainViewmodel.FeelOrangeCollection.Clear();
                #endregion
                #region CollectionAssignment
                ObservableCollection<Kategoriliste> _minProfilCollection = _kategorilisteCollection[0];
                ObservableCollection<Kategoriliste> _eatOrangeCollection = _kategorilisteCollection[1];
                ObservableCollection<Kategoriliste> _seeOrangeCollection = _kategorilisteCollection[2];
                ObservableCollection<Kategoriliste> _shopOrangeCollection = _kategorilisteCollection[3];
                ObservableCollection<Kategoriliste> _feelOrangeCollection = _kategorilisteCollection[4];
                #endregion

                foreach (Kategoriliste kategoriliste in _minProfilCollection)
                {
                    _mainViewmodel.MinProfilCollection.Add(kategoriliste);
                }

                foreach (Kategoriliste kategoriliste in _eatOrangeCollection)
                {
                    _mainViewmodel.EatOrangeCollection.Add(kategoriliste);
                }

                foreach (Kategoriliste kategoriliste in _seeOrangeCollection)
                {
                    _mainViewmodel.SeeOrangeCollection.Add(kategoriliste);
                }

                foreach (Kategoriliste kategoriliste in _shopOrangeCollection)
                {
                    _mainViewmodel.ShopOrangeCollection.Add(kategoriliste);
                }

                foreach (Kategoriliste kategoriliste in _feelOrangeCollection)
                {
                    _mainViewmodel.FeelOrangeCollection.Add(kategoriliste);
                }
            }
        }
        public void TilfoejKommentar()
        {
            TestNavnText = "";
            TestBeskrivelseText = "";
            TestKategori = "";
            SuccesText = "";
            try
            {
                Kommentar.CheckKommentarName(_navn);
            }
            catch (ArgumentException)
            {
                TestNavnText = "*";
            }

            try
            {
                Kommentar.CheckKommentarTekst(_tekst);
            }
            catch (ArgumentException)
            {
                TestBeskrivelseText = "*";
            }
            if (TestBeskrivelseText == "" & TestNavnText == "")
            {
                Kommentar k = new Kommentar(_dato, _navn, _tekst);
                MainViewmodel.SelectedKategoriliste.KommentarList.Add(k);
                SaveKategoriAsync();
                SuccesText = "Kommentaren blev tilføjet";


            }
        }

        #region GetSet Metoder
        public DateTime Dato
        {
            get { return _dato; }
            set { _dato = value; }
        }

        public string Navn
        {
            get { return _navn; }
            set { _navn = value; }
        }

        public string Tekst
        {
            get { return _tekst; }
            set { _tekst = value; }
        }
        public string TestNavnText
        {
            get { return _testNavnText; }
            set
            {
                _testNavnText = value;
                OnPropertyChanged("TestNavnText");
            }
        }

        public string TestKategori
        {
            get { return _testKategori; }
            set
            {
                _testKategori = value;
                OnPropertyChanged("TestKategori");
            }
        }

        public string TestBeskrivelseText
        {
            get { return _testBeskrivelseText; }
            set
            {
                _testBeskrivelseText = value;
                OnPropertyChanged("TestBeskrivelseText");
            }
        }

        public string SuccesText
        {
            get { return _succesText; }
            set { _succesText = value; OnPropertyChanged("SuccesText"); }
        }
        #endregion
        public TilfoejKommentarHandler(MainViewmodel mainViewmodel)
        {
            _mainViewmodel = mainViewmodel;
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
