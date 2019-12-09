using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    /// <summary>
    /// Ostajan tietojen hallinta
    /// </summary>
    [Serializable]
    class Ostaja : Henkilo
    {
       
        public new void AnnaTiedot()
        {
            Console.WriteLine("\nAnna ostajan tiedot");
            SyotaTiedot(); 
        }
    }
}
