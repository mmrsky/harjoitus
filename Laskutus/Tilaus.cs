﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laskutus
{
    class Tilaus
    {
        List<Tuote> ostoskori = new List<Tuote>();
        public Tilaus()
        {
            Console.WriteLine("Tilaus alustettu");
        }
        public void LisaaTuote(string pNimi, decimal pHinta)
        {
            ostoskori.Add(new Tuote(pNimi, pHinta));
        }
        public void LisaaOstajanTiedot()
        {
            Console.WriteLine("Anna ostajan nimi");
            string nimi = Console.ReadLine();

        }

        public void LisaaMyyjanTiedot()
        {

        }

        public void TulostaTuotteet()
        {
            foreach (var ostos in ostoskori)
            {
                ostos.Tulosta();
            }
        }

    }
}
