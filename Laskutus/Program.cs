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
            //tilaus.LisaaTuote("Suksi", (decimal)23.12);
            tilaus.LisaaMyyjanTiedot();
            tilaus.LisaaOstajanTiedot();

            do
            {
                tilaus.LisaaTuote();
                Console.WriteLine("Paina Enter syöttääksesi uuden tuotteen");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);


            tilaus.TulostaTuotteet();
            tilaus.LisaaTuotteetXMLTiedostoon();
            tilaus.KirjoitaLaskuTiedostoon(tiedostonimi);
            Console.ReadKey();
        }
    }
}
