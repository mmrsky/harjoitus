using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    class Tuote
    {
        private string _nimi;
        private decimal _hinta;
        public string Nimi { get => _nimi;
                             set => _nimi = value; }
        public decimal Hinta { get => _hinta;
                               set => _hinta = value; }

        public Tuote()
        {
        }
        public Tuote(string pNimi, decimal pHinta)
        {
            Nimi = pNimi;
            Hinta = pHinta;
        }

        
        public void Tulosta()
        {
            Console.WriteLine(Nimi + "  " + Hinta);
        }

        public void AnnaTuote()
        {
            Console.Write("Anna tuotteen nimi: ");
            Nimi = Console.ReadLine();

            Console.Write("Anna tuotteen hinta: ");
            Hinta = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
    }
}
