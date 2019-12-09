using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{   /// <summary>
    /// Henkilo- luokka toimii parent-luokkana Ostaja ja Myyja luokille
    /// </summary>
    [Serializable]
    class Henkilo
    {
        private string _nimi;
        private string _osoite;
        public string Nimi { get => _nimi;
                             set => _nimi = value; }
        public string Osoite { get => _osoite;
                               set => _osoite = value; }
        /// <summary>
        /// Nimi ja osoitetietojen syöttäminen.
        /// </summary>
        protected void SyotaTiedot()
        {
            Console.Write("Anna nimi: ");
            Nimi = Console.ReadLine();
            
            Console.Write("Anna Osoite: ");
            Osoite = Console.ReadLine();
        }

        public void AnnaTiedot()
        {
            SyotaTiedot();
        }
    }
}
