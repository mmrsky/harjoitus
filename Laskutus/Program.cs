using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    class Program
    {
        static void Main(string[] args)
        {
            string tiedostonimi = "lasku.xml";
            Tilaus tilaus = new Tilaus();
            TalletaLataa tallentaja = new TalletaLataa();

            Console.WriteLine("Haluatko ladata tallennetun tilauksen (k/e)?");
            if (Console.ReadKey().Key == ConsoleKey.K)
            {
                tallentaja.Lataa(ref tilaus);
                tilaus.TulostaTilaus();
            }
            else
            {
                tilaus.LisaaMyyjanTiedot();
                tilaus.LisaaOstajanTiedot();
            }


            do
            {
                tilaus.LisaaTuote();
                Console.WriteLine("Paina Enter syöttääksesi uuden tuotteen");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

            tilaus.TulostaTilaus();
            tilaus.LisaaTuotteetXMLTiedostoon();
            tilaus.KirjoitaLaskuTiedostoon(tiedostonimi);

            tallentaja.Talleta(tilaus);
            Console.ReadKey();

        }
    }
}
