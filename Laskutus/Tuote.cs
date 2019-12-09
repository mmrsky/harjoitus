using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    /// <summary>
    /// Tuote luokka
    /// </summary>
    [Serializable]
    class Tuote
    {
        private string _nimi;
        private decimal _hinta;
        public string Nimi { get => _nimi;
                             set => _nimi = value; }
        public decimal Hinta { get => _hinta;
                               set => _hinta = value; }

        /// <summary>
        /// Constructor ilman parametreja
        /// </summary>
        public Tuote()
        {
        }

        /// <summary>
        /// Constructor, jolla voidaan luoda uusi tuote antamalla nimi ja hinta parametreina.
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
            Console.Write("\nAnna tuotteen nimi: ");
            Nimi = Console.ReadLine();
            decimal hinta = 0;

            do
            {
                Console.Write("Anna tuotteen hinta: ");
                if (decimal.TryParse(Console.ReadLine(), out hinta))
                {
                    Hinta = hinta;
                }
                else
                {
                    Console.WriteLine("Hinta ei ole kelvollinen lukuarvo!");
                }
            } while (hinta == 0);
        }
    }
}
