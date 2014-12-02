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
    }
}
