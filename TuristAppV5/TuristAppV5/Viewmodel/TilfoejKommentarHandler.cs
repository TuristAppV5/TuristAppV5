using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using TuristAppV5.Model;
using TuristAppV5.View;

namespace TuristAppV5.Viewmodel
{
    class TilfoejKommentarHandler
    {
        private DateTime _dato;
        private string _navn;
        private string _tekst;
        private MainViewmodel _mainViewmodel;

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
        }
    }
}
