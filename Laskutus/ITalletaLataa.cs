using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    interface ITalleta
    {
        void Talleta(Tilaus ostoskori);
    }

    interface ILataa
    {
        void Lataa(ref Tilaus ostoskori);
    }
}
