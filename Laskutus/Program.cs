using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    /// <summary>
    /// Ohjelma tilauksen tekemiseen. Ohjelma kysyy myyjän ja ostajan tiedot ja sen jälkeen tilausrivit
    /// Kun tilaus on valmis muodostetaan siitä XML-muotoinen finvoice - lasku ja tilaus talletetaan 
    /// levylle jotta siihen voidaan niin halutessaan lisätä uusia tilausrivejä.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string tiedostonimi = "lasku.xml";
            string binTiedostonimi = "savestate.bin";
            Tilaus tilaus = new Tilaus();
            TalletaLataa poistaja = new TalletaLataa();

            ITalleta tallentaja = new TalletaLataa(); 
            ILataa lataaja = new TalletaLataa();

            Console.WriteLine("Haluatko ladata tallennetun tilauksen (k/e)?");
            Console.WriteLine("Voit poistaa tallennuksen painamalla p - näppäintä.");
            ConsoleKey pressedKey = Console.ReadKey().Key;
            if (pressedKey == ConsoleKey.K) // Ladataan talletettu tilaus
            {
                lataaja.Lataa(ref tilaus);
                tilaus.TulostaTilaus();
            }

            else if (pressedKey == ConsoleKey.P) // Poistetaan talletettu tilaus
            {
                poistaja.PoistaTallennus(binTiedostonimi);
            }
            
            if (pressedKey != ConsoleKey.K) // Jatketaan uuden tilauksen tekemistä
            {
                tilaus.LisaaMyyjanTiedot();
                tilaus.LisaaOstajanTiedot();
            }

            do // Lisätään tuotteita tilaukseen, niin kauan kunnes käyttäjä painaa muuta kuin Enter- näppäintä
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
