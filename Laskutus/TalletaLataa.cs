using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Laskutus
{
    /// <summary>
    /// Tilauksen talletus ja lataus luokka. Tämä luokka perii Poista - luokan ja toteuttaa rajapinnat
    /// Italleta ja Ilataa
    /// </summary>
    class TalletaLataa : Poista, ITalleta, ILataa
    {
        /// <summary>
        /// Ladataan binäärimuodossa tallennettu tilaus
        /// </summary>
        /// <param name="ostoskori"></param>
        public void Lataa(ref Tilaus ostoskori)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("savestate.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Tilaus obj = (Tilaus)formatter.Deserialize(stream);
            ostoskori = obj;
            stream.Close();
        }

        /// <summary>
        /// Tallennetaan tilaus binäärimuodossa
        /// </summary>
        /// <param name="ostoskori"></param>
        public void Talleta(Tilaus ostoskori)
        {
            if  (ostoskori != null)
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("savestate.bin", FileMode.Create, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, ostoskori);
                stream.Close();
            }
        }
    }
}
