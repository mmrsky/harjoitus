using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    class Henkilo
    {
        private string _nimi;
        private string _osoite;
        public string Nimi { get => _nimi;
                             set => _nimi = value; }
        public string Osoite { get => _osoite;
                               set => _osoite = value; }

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
