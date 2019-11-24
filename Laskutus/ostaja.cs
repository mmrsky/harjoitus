using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    class Ostaja : Henkilo
    {
        public new void AnnaTiedot()
        {
            Console.WriteLine("Anna ostajan tiedot");
            SyotaTiedot(); 
        }
    }
}
