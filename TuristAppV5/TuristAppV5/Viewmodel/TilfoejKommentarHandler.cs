using System;
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
            _mainViewmodel.MinProfilCollection.Add(_mainViewmodel.SelectedKategoriliste);
            MessageDialog kval = new MessageDialog("Tilføjet til To-Do liste");
            kval.ShowAsync();
            SaveKategorilisteAsync();
        }

        public async void SaveKategorilisteAsync()
        {
            PersistenceFacade.SaveKategorilisteAsJsonAsync(_mainViewmodel.MinProfilCollection);
        }
        public async void LoadKategorilisteAsync()
        {

            ObservableCollection<Kategoriliste> _kategorilisteCollection =
                await PersistenceFacade.LoadKategorilisteFromJsonAsync();

            if (_kategorilisteCollection != null)
            {
                _mainViewmodel.MinProfilCollection.Clear();

                foreach (Kategoriliste kategoriliste in _kategorilisteCollection)
                {
                    _mainViewmodel.MinProfilCollection.Add(kategoriliste);
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
            catch (ArgumentException ex)
            {
                TestNavnText = "*";
            }

            try
            {
                Kommentar.CheckKommentarTekst(_tekst);
            }
            catch (ArgumentException ex)
            {
                TestBeskrivelseText = "*";
            }
            if (TestBeskrivelseText == "" & TestNavnText == "")
            {
                Kommentar k = new Kommentar(_dato, _navn, _tekst);
                _mainViewmodel.SelectedKategoriliste.KommentarList.Add(k);
                SaveKategorilisteAsync();
                SuccesText = "Kommentaren blev tilføjet";

            }
        }
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

        public TilfoejKommentarHandler(MainViewmodel mainViewmodel)
        {
            _mainViewmodel = mainViewmodel;
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
