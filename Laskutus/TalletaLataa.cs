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
    class TalletaLataa : ITalleta, ILataa
    {
        public void Lataa(ref Tilaus ostoskori)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("savestate.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            Tilaus obj = (Tilaus)formatter.Deserialize(stream);
            ostoskori = obj;
            stream.Close();
        }

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
