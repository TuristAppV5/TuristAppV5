using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuristAppV5.Model
{
    class Kommentar
    {
        private DateTime _dato;
        private string _navn;
        private string _tekst;

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

        public Kommentar(DateTime dato, string navn, string tekst)
        {
            _dato = dato;
            _navn = navn;
            _tekst = tekst;
        }
        public void CheckKommentarName(string name)
        {
            if (name.Length < 1 || name.Length > 30)
            {
                throw new ArgumentException("Navnet skal indeholde tegn og må højst være 30 tegn");
            }
        }
        public void CheckKommentarTekst(string tekst)
        {
            if (tekst.Length < 1 || tekst.Length > 500)
            {
                throw new ArgumentException("Beskrivelsen skal indeholde tegn og må højst være 500 tegn");
            }
        }
        public void CheckKommentarDate()
        {

        }
    }
}
