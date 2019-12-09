using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{

    /// <summary>
    /// Myyjän tietojen hallinta
    /// </summary>
    [Serializable]
    class Myyja : Henkilo
    {
        public new void AnnaTiedot()
        {
            Console.WriteLine("\nUusi tilaus");
            Console.WriteLine("\nAnna myyjän tiedot");
            SyotaTiedot();
        }
    }
}
