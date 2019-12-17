using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laskutus
{
    /// <summary>
    /// Poista luokka hoitaa tilauksesta tallennetun binääritiedoston poistamisen, TalletaLataa luokka perii tämän
    /// </summary>
    class Poista
    {
        /// <summary>
        /// Poistetaan tallennustiedosto
        /// </summary>
        /// <param name="tiedostonimi"></param>
        public void PoistaTallennus(string tiedostonimi)
        {
            Console.WriteLine("Poistetaan tilaustallennus!");
            try
            {
                File.Delete(tiedostonimi);
            }

            catch (IOException deleteError)
            {
                Console.WriteLine(deleteError.Message);
            }

        }
    }
}
