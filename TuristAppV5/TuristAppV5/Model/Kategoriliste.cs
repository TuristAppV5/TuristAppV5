﻿using System;
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
            private double _breddegrad;
            private double _laengdegrad;
            private string _billede;
            private string _beskrivelse;
            private string _aabningstider;
            private List<Kommentar> _kommentarList;

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

            public double Laengdegrad
            {
                get { return _laengdegrad; }
                set { _laengdegrad = value; }
            }

            public double Breddegrad
            {
                get { return _breddegrad; }
                set { _breddegrad = value; }
            }

            public string Billede
            {
                get { return _billede; }
                set { _billede = value; }
            }

            public string Aabningstider
            {
                get { return _aabningstider; }
                set { _aabningstider = value; }
            }

            public string Beskrivelse
            {
                get { return _beskrivelse; }
                set { _beskrivelse = value; }
            }

            public List<Kommentar> KommentarList
            {
                get { return _kommentarList; }
                set { _kommentarList = value; }
            }

            public override string ToString()
            {
                return _navn;
            }
            public Kategoriliste(string navn, string telefon, string book, double breddegrad, double laengdegrad, string billede, string beskrivelse, string aabningstider)
            {
                _navn = navn;
                _telefon = telefon;
                _book = book;
                _breddegrad = breddegrad;
                _laengdegrad = laengdegrad;
                _billede = billede;
                _beskrivelse = beskrivelse;
                _aabningstider = aabningstider;
                _kommentarList = new List<Kommentar>();
                _kommentarList.Add(new Kommentar(new DateTime(2014, 9, 10), "Daniel Winther", "Dette er en kommentartekssdjfnsdkfnskjfnksjdfnsdsdkfsdt"));
            }

        }
}
