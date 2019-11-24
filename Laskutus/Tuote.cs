using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{   /// <summary>
    /// Tuote luokka
    /// </summary>
    class Tuote
    {
        private string _nimi;
        private decimal _hinta;
        public string Nimi { get => _nimi;
                             set => _nimi = value; }
        public decimal Hinta { get => _hinta;
                               set => _hinta = value; }
        /// <summary>
        /// Konstructori ilman parametreja
        /// </summary>
        public Tuote()
        {
        }
        /// <summary>
        /// Konstruktori, jolla voidaan luoda uusi tuote antamalla nimi ja hinta parametreina.
        /// </summary>
        /// <param name="pNimi"></param>
        /// <param name="pHinta"></param>
        public Tuote(string pNimi, decimal pHinta)
        {
            Nimi = pNimi;
            Hinta = pHinta;
        }

        /// <summary>
        /// Tulostaa tuoterivin konsolille.
        /// </summary>
        public void Tulosta()
        {
            Console.WriteLine(Nimi + "  " + Hinta);
        }
        /// <summary>
        /// AnnaTuote metodilla voidaan syöttää tuotteelle nimi ja hinta.
        /// </summary>
        public void AnnaTuote()
        {
            Console.Write("Anna tuotteen nimi: ");
            Nimi = Console.ReadLine();

            Console.Write("Anna tuotteen hinta: ");
            Hinta = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
        }
    }
}
