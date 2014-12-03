using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuristAppV5.Model
{
        public class Kategoriliste
        {
            private string _navn;
            private string _telefon;
            private string _book;
            private string _længdegrad;
            private string _breddegrad;
            private string _billede;
            private string _beskrivelse;
            private string _åbningstider;

            public string Navn
            {
                get { return _navn; }
                set { _navn = value; }
            }

            public string Telefon
            {
                get { return _telefon; }
                set { _telefon = value; }
            }

            public string Book
            {
                get { return _book; }
                set { _book = value; }
            }

            public string Længdegrad
            {
                get { return _længdegrad; }
                set { _længdegrad = value; }
            }

            public string Breddegrad
            {
                get { return _breddegrad; }
                set { _breddegrad = value; }
            }

            public string Billede
            {
                get { return _billede; }
                set { _billede = value; }
            }

            public string Åbningstider
            {
                get { return _åbningstider; }
                set { _åbningstider = value; }
            }

            public string Beskrivelse
            {
                get { return _beskrivelse; }
                set { _beskrivelse = value; }
            }

            public Kategoriliste()
            {
                
            }
            public Kategoriliste(string navn, string telefon, string book, string længdegrad, string breddegrad, string billede, string beskrivelse, string åbningstider)
            {
                _navn = navn;
                _telefon = telefon;
                _book = book;
                _længdegrad = længdegrad;
                _breddegrad = breddegrad;
                _billede = billede;
                _beskrivelse = beskrivelse;
                _åbningstider = åbningstider;
            }
        }
}
