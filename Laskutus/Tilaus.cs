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
    /// <summary>
    /// Tilaus luokka muodostaa tilauksen ja tuottaa siitä Finvoice XML- tiedoston.
    /// Finvoice luokka on generoitu XSD.EXE- työkalulla. Finvoice3_0.xsd:n pohjalta.
    /// </summary>
    class Tilaus
    {
        List<Tuote> tuoterivit = new List<Tuote>();
        InvoiceRowType[] XMLLaskuRivi;
        readonly SellerPartyDetailsType XMLMyyja = new SellerPartyDetailsType();
        readonly BuyerPartyDetailsType XMLOstaja = new BuyerPartyDetailsType();

        /// <summary>
        /// Konstruktori
        /// </summary>
        public Tilaus()
        {
            Console.WriteLine("Tilaus alustettu");
        }
        /// <summary>
        /// Tuotteen lisääminen tilaukseen parametreilla.
        /// </summary>
        /// <param name="pNimi">Tuotteen nimi.</param>
        /// <param name="pHinta">Tuotteen hinta.</param>
        public void LisaaTuote(string pNimi, decimal pHinta)
        {
            tuoterivit.Add(new Tuote(pNimi, pHinta));
        }
        /// <summary>
        /// Tuotteen lisääminen luokkaan komentorivisyötteellä.
        /// </summary>
        public void LisaaTuote()
        {
            Tuote uusiTuote = new Tuote();
            uusiTuote.AnnaTuote();
            tuoterivit.Add(uusiTuote);
        }
        /// <summary>
        /// Ostajan tietojen lisääminen.
        /// </summary>
        public void LisaaOstajanTiedot()
        {
            Ostaja ostaja = new Ostaja();
            ostaja.AnnaTiedot();
            XMLOstaja.BuyerOrganisationName = new string[] { ostaja.Nimi};
        }

        /// <summary>
        /// Myyjän tietojen lisääminen.
        /// </summary>
        public void LisaaMyyjanTiedot()
        {
            Myyja myyja = new Myyja();
            myyja.AnnaTiedot();
            XMLMyyja.SellerOrganisationName = new string[] { myyja.Nimi }; 
        }

        /// <summary>
        /// Lisätään tuoterivit Finvoice XML-rakenteeseen
        /// </summary>
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

        /// <summary>
        /// Serialisoidaan Finvoice- luokka XML-tiedostoon
        /// </summary>
        /// <param name="tiedostonimi"></param>
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

        /// <summary>
        /// Tulostetaan tilauksen tuoterivit konsoli-ikkunaan.
        /// </summary>
        public void TulostaTuotteet()
        {
            foreach (var ostos in tuoterivit)
            {
                ostos.Tulosta();
            }
        }

    }
}
