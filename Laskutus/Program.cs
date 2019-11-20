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
            SellerPartyDetailsType myyja = new SellerPartyDetailsType();
            InvoiceRowType [] tuotteet = new InvoiceRowType[1];

            string[] ostajanNimi = new string[] { "Monosen hiihtoseura Ry" };
            ostaja.BuyerOrganisationName = ostajanNimi;

            string[] myyjaOrganisaatio = new string[] { "Suksikauppa Oy" };
            myyja.SellerOrganisationName = myyjaOrganisaatio;

            //Artikkeli[] ostoskori = new Artikkeli[3];
            //Suksi hiihdin = new Suksi();
            //InvoiceRowType[] ostoskori = new InvoiceRowType[3];

            //ostoskori[0] = new Suksi();
            //ostoskori[1] = new Sauva();
            //ostoskori[2] = new Mono();
            unitAmountUN hinta = new unitAmountUN();
            hinta.Value = "34.2";

            tuotteet[0] = new InvoiceRowType
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

            eLasku.SellerPartyDetails = myyja;
            eLasku.BuyerPartyDetails = ostaja;
            eLasku.InvoiceRow = tuotteet;


            serializer.Serialize(writer, eLasku);
            writer.Close();
        }
    }
}
