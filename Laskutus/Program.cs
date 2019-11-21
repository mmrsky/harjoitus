using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Laskutus
{
    class Program
    {
        static void Main(string[] args)
        {
            string tiedostonimi = "lasku.xml";
            TeeXMLLasku(tiedostonimi);

            Tilaus tilaus = new Tilaus();
            tilaus.LisaaTuote("Suksi", (decimal)23.12);
            tilaus.TulostaTuotteet();
            Console.ReadKey();
        }
        static private void TeeXMLLasku(string tiedostonimi)
        {

            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            XmlSerializer serializer =
            new XmlSerializer(typeof(Finvoice));
            TextWriter writer = new StreamWriter(tiedostonimi);

            // Luo finvoice lasku
            Finvoice eLasku = new Finvoice();

            BuyerPartyDetailsType ostaja = new BuyerPartyDetailsType();
            string[] ostajanNimi = new string[] { "Monosen hiihtoseura Ry" };
            ostaja.BuyerOrganisationName = ostajanNimi;

            SellerPartyDetailsType myyja = new SellerPartyDetailsType();
            string[] myyjaOrganisaatio = new string[] { "Suksikauppa Oy" };
            myyja.SellerOrganisationName = myyjaOrganisaatio;


            InvoiceRowType[] ostoskori = new InvoiceRowType[2];
            //Suksi ostos1 = new Suksi();
            //InvoiceRowType[] ostoskori = new InvoiceRowType[3];

            //ostoskori[0] = new Suksi();
            //ostoskori[1] = new Sauva();
            //ostoskori[2] = new Mono();
            unitAmountUN hinta = new unitAmountUN {
                Value = "34.2"
            };

            ostoskori[0] = new InvoiceRowType
            {
                Items = new object[]
                {
                    "Suksi",
                    hinta,
                },

                ItemsElementName = new[]
                {
                ItemsChoiceType.ArticleName,
                ItemsChoiceType.UnitPriceAmount,
                }
            };

            hinta.Value = "29.38";
            ostoskori[1] = new InvoiceRowType
            {
                Items = new object[]
                {
                    "Mono",
                    hinta,
                },

                ItemsElementName = new[]
                {
                ItemsChoiceType.ArticleName,
                ItemsChoiceType.UnitPriceAmount,
                }
            };



            eLasku.SellerPartyDetails = myyja;
            eLasku.BuyerPartyDetails = ostaja;
            eLasku.InvoiceRow = ostoskori;


            serializer.Serialize(writer, eLasku);
            writer.Close();
        }
    }
}
