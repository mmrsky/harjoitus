using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Laskutus
{
    class Tilaus
    {
        List<Tuote> tuoterivit = new List<Tuote>();
        InvoiceRowType[] XMLLaskuRivi;
        readonly SellerPartyDetailsType XMLMyyja = new SellerPartyDetailsType();
        readonly BuyerPartyDetailsType XMLOstaja = new BuyerPartyDetailsType();


        public Tilaus()
        {
            Console.WriteLine("Tilaus alustettu");
        }
        public void LisaaTuote(string pNimi, decimal pHinta)
        {
            tuoterivit.Add(new Tuote(pNimi, pHinta));
        }
        public void LisaaTuote()
        {
            Tuote uusiTuote = new Tuote();
            uusiTuote.AnnaTuote();
            tuoterivit.Add(uusiTuote);
        }
        public void LisaaOstajanTiedot()
        {
            Ostaja ostaja = new Ostaja();
            ostaja.AnnaTiedot();
            XMLOstaja.BuyerOrganisationName = new string[] { ostaja.Nimi};
        }

        public void LisaaMyyjanTiedot()
        {
            Myyja myyja = new Myyja();
            myyja.AnnaTiedot();
            XMLMyyja.SellerOrganisationName = new string[] { myyja.Nimi }; 
        }

        public void LisaaTuotteetXMLTiedostoon()
        {
            int itemCount = tuoterivit.Count();
            XMLLaskuRivi = new InvoiceRowType[tuoterivit.Count()];
            for (int i = 0; i < itemCount ; i++)
            {
                unitAmountUN hinta = new unitAmountUN
                {
                    Value = tuoterivit[i].Hinta.ToString(CultureInfo.InvariantCulture)
                };

                XMLLaskuRivi[i] = new InvoiceRowType()
                {
                    Items = new object[]
                    {
                        tuoterivit[i].Nimi,
                        hinta
                    },

                    ItemsElementName = new[]
                    {
                        ItemsChoiceType.ArticleName,
                        ItemsChoiceType.UnitPriceAmount,
                    }
                };
            }
        }


        public void KirjoitaLaskuTiedostoon(string tiedostonimi)
        {
            XmlSerializer serializer =
            new XmlSerializer(typeof(Finvoice));
            TextWriter writer = new StreamWriter(tiedostonimi);

            // Luo finvoice lasku
            Finvoice eLasku = new Finvoice();

            eLasku.SellerPartyDetails = XMLMyyja;
            eLasku.BuyerPartyDetails = XMLOstaja;
            eLasku.InvoiceRow = XMLLaskuRivi;

            serializer.Serialize(writer, eLasku);
            writer.Close();
        }


        public void TulostaTuotteet()
        {
            foreach (var ostos in tuoterivit)
            {
                ostos.Tulosta();
            }
        }

    }
}
