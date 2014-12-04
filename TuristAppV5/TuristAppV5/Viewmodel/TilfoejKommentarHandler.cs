using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using TuristAppV5.Model;
using TuristAppV5.View;
using TuristAppV5.Viewmodel;

namespace TuristAppV5.Viewmodel
{
    class TilfoejKommentarHandler
    {
        private DateTime _dato;
        private string _navn;
        private string _tekst;
        private MainViewmodel _mainViewmodel;


        public void TilfoejToDoListe()
        {
            _mainViewmodel.MinProfilCollection.Add(_mainViewmodel.SelectedKategoriliste);
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

                foreach (var kategoriliste in _kategorilisteCollection)
                {
                    _mainViewmodel.MinProfilCollection.Add(kategoriliste);
                }
            }
        }


        public void TilfoejKommentar()
        {
            MessageDialog val = new MessageDialog("", "Fejl");
            try
            {
                Kommentar.CheckKommentarName(_navn);
            }
            catch (ArgumentException ex)
            {
                val.Content += ex.Message + "\n";
            }

            try
            {
                Kommentar.CheckKommentarTekst(_tekst);
            }
            catch (ArgumentException ex)
            {
                val.Content += ex.Message + "\n";
            }
            try
            {
                Kommentar.CheckKommentarDate();
            }
            catch (ArgumentException ex)
            {
                val.Content += ex.Message + "\n";
            }
            if (val.Content == "")
            {
                Kommentar k = new Kommentar(_dato, _navn, _tekst);
                _mainViewmodel.SelectedKategoriliste.KommentarList.Add(k);

                
                
            }


                val.Title = "";
                val.Content = "Kommentaren blev tilføjet";

            }
            val.ShowAsync();

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


        public TilfoejKommentarHandler(DateTime dato, string navn, string tekst)
        {
            _dato = dato;
            _navn = navn;
            _tekst = tekst;

        public TilfoejKommentarHandler(MainViewmodel mainViewmodel)
        {
            _mainViewmodel = mainViewmodel;
        }
    }
}
