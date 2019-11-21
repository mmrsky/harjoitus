using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    class Tuote
    {
        string nimi;
        decimal hinta;
        public Tuote(string pNimi, decimal pHinta)
        {
            nimi = pNimi;
            hinta = pHinta;
        }

        public void LisaaXmlLaskulle()
        {

        }

        public void Tulosta()
        {
            Console.WriteLine(nimi + "  " + hinta);
        }
    }
}
