using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuristAppV5.Model
{
    public class Kategori
    {
        private string _kategorinavn;
        private string _billede;

        public string Kategorinavn
        {
            get { return _kategorinavn; }
            set { _kategorinavn = value; }
        }
        public string Billede
        {
            get { return _billede; }
            set { _billede = value; }
        }

        public Kategori()
        {
            
        }
        public Kategori(string kategorinavn, string billede)
        {
            _kategorinavn = kategorinavn;
            _billede = billede;
        }
    }
}
