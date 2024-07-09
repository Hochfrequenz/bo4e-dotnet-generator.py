// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var themengebiet = Themengebiet.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Über dieses ENUM kann eine thematische Zuordnung, beispielsweise eines Ansprechpartners,
    /// vorgenommen werden.
    /// </summary>
    public enum ThemengebietEnum { AllgemeinerInformationsaustausch, Alocat, AnUndAbmeldung, AnsprechpartnerAllgemein, AnsprechpartnerBdewDvgw, AnsprechpartnerItTechnik, Aperak, Bewegungsdaten, Bilanzierung, Bilanzkreiskoordinator, Bilanzkreisverantwortlicher, Contrl, DatenformateZertifikateVerschluesselungen, Debitorenmanagement, DemandSideManagement, EdiVereinbarung, Edifact, Einspeisung, Energiedatenmanagement, Fahrplanmanagement, Gabi, Geli, Geraeterueckgabe, Geraetewechsel, Gpke, Inbetriebnahme, Invoic, Kapazitaetsmanagement, Klaerfaelle, LastgaengeRlm, Lieferantenrahmenvertrag, Lieferantenwechsel, Mabis, Mahnwesen, Marktgebietsverantwortlicher, Marktkommunikation, MehrMindermengen, MsbMdl, Mscons, Netzabrechnung, Netzentgelte, Netzmanagement, Orders, Ordersp, Recht, Regulierungsmanagement, Reklamationen, Remadv, SperrenEntsperrenInkasso, Stammdaten, Stoerungsfaelle, TechnischeFragen, UmstellungInvoic, Utilmd, VerschluesselungSignatur, Vertragsmanagement, Vertrieb, Wim, ZaehlerstaendeSlp, Zahlungsverkehr, Zuordnungsvereinbarung };

    public class Themengebiet
    {
        public static ThemengebietEnum FromJson(string json) => JsonConvert.DeserializeObject<ThemengebietEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ThemengebietEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ThemengebietEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ThemengebietEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ThemengebietEnum) || t == typeof(ThemengebietEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ALLGEMEINER_INFORMATIONSAUSTAUSCH":
                    return ThemengebietEnum.AllgemeinerInformationsaustausch;
                case "ALOCAT":
                    return ThemengebietEnum.Alocat;
                case "ANSPRECHPARTNER_ALLGEMEIN":
                    return ThemengebietEnum.AnsprechpartnerAllgemein;
                case "ANSPRECHPARTNER_BDEW_DVGW":
                    return ThemengebietEnum.AnsprechpartnerBdewDvgw;
                case "ANSPRECHPARTNER_IT_TECHNIK":
                    return ThemengebietEnum.AnsprechpartnerItTechnik;
                case "AN_UND_ABMELDUNG":
                    return ThemengebietEnum.AnUndAbmeldung;
                case "APERAK":
                    return ThemengebietEnum.Aperak;
                case "BEWEGUNGSDATEN":
                    return ThemengebietEnum.Bewegungsdaten;
                case "BILANZIERUNG":
                    return ThemengebietEnum.Bilanzierung;
                case "BILANZKREISKOORDINATOR":
                    return ThemengebietEnum.Bilanzkreiskoordinator;
                case "BILANZKREISVERANTWORTLICHER":
                    return ThemengebietEnum.Bilanzkreisverantwortlicher;
                case "CONTRL":
                    return ThemengebietEnum.Contrl;
                case "DATENFORMATE_ZERTIFIKATE_VERSCHLUESSELUNGEN":
                    return ThemengebietEnum.DatenformateZertifikateVerschluesselungen;
                case "DEBITORENMANAGEMENT":
                    return ThemengebietEnum.Debitorenmanagement;
                case "DEMAND_SIDE_MANAGEMENT":
                    return ThemengebietEnum.DemandSideManagement;
                case "EDIFACT":
                    return ThemengebietEnum.Edifact;
                case "EDI_VEREINBARUNG":
                    return ThemengebietEnum.EdiVereinbarung;
                case "EINSPEISUNG":
                    return ThemengebietEnum.Einspeisung;
                case "ENERGIEDATENMANAGEMENT":
                    return ThemengebietEnum.Energiedatenmanagement;
                case "FAHRPLANMANAGEMENT":
                    return ThemengebietEnum.Fahrplanmanagement;
                case "GABI":
                    return ThemengebietEnum.Gabi;
                case "GELI":
                    return ThemengebietEnum.Geli;
                case "GERAETERUECKGABE":
                    return ThemengebietEnum.Geraeterueckgabe;
                case "GERAETEWECHSEL":
                    return ThemengebietEnum.Geraetewechsel;
                case "GPKE":
                    return ThemengebietEnum.Gpke;
                case "INBETRIEBNAHME":
                    return ThemengebietEnum.Inbetriebnahme;
                case "INVOIC":
                    return ThemengebietEnum.Invoic;
                case "KAPAZITAETSMANAGEMENT":
                    return ThemengebietEnum.Kapazitaetsmanagement;
                case "KLAERFAELLE":
                    return ThemengebietEnum.Klaerfaelle;
                case "LASTGAENGE_RLM":
                    return ThemengebietEnum.LastgaengeRlm;
                case "LIEFERANTENRAHMENVERTRAG":
                    return ThemengebietEnum.Lieferantenrahmenvertrag;
                case "LIEFERANTENWECHSEL":
                    return ThemengebietEnum.Lieferantenwechsel;
                case "MABIS":
                    return ThemengebietEnum.Mabis;
                case "MAHNWESEN":
                    return ThemengebietEnum.Mahnwesen;
                case "MARKTGEBIETSVERANTWORTLICHER":
                    return ThemengebietEnum.Marktgebietsverantwortlicher;
                case "MARKTKOMMUNIKATION":
                    return ThemengebietEnum.Marktkommunikation;
                case "MEHR_MINDERMENGEN":
                    return ThemengebietEnum.MehrMindermengen;
                case "MSB_MDL":
                    return ThemengebietEnum.MsbMdl;
                case "MSCONS":
                    return ThemengebietEnum.Mscons;
                case "NETZABRECHNUNG":
                    return ThemengebietEnum.Netzabrechnung;
                case "NETZENTGELTE":
                    return ThemengebietEnum.Netzentgelte;
                case "NETZMANAGEMENT":
                    return ThemengebietEnum.Netzmanagement;
                case "ORDERS":
                    return ThemengebietEnum.Orders;
                case "ORDERSP":
                    return ThemengebietEnum.Ordersp;
                case "RECHT":
                    return ThemengebietEnum.Recht;
                case "REGULIERUNGSMANAGEMENT":
                    return ThemengebietEnum.Regulierungsmanagement;
                case "REKLAMATIONEN":
                    return ThemengebietEnum.Reklamationen;
                case "REMADV":
                    return ThemengebietEnum.Remadv;
                case "SPERREN_ENTSPERREN_INKASSO":
                    return ThemengebietEnum.SperrenEntsperrenInkasso;
                case "STAMMDATEN":
                    return ThemengebietEnum.Stammdaten;
                case "STOERUNGSFAELLE":
                    return ThemengebietEnum.Stoerungsfaelle;
                case "TECHNISCHE_FRAGEN":
                    return ThemengebietEnum.TechnischeFragen;
                case "UMSTELLUNG_INVOIC":
                    return ThemengebietEnum.UmstellungInvoic;
                case "UTILMD":
                    return ThemengebietEnum.Utilmd;
                case "VERSCHLUESSELUNG_SIGNATUR":
                    return ThemengebietEnum.VerschluesselungSignatur;
                case "VERTRAGSMANAGEMENT":
                    return ThemengebietEnum.Vertragsmanagement;
                case "VERTRIEB":
                    return ThemengebietEnum.Vertrieb;
                case "WIM":
                    return ThemengebietEnum.Wim;
                case "ZAEHLERSTAENDE_SLP":
                    return ThemengebietEnum.ZaehlerstaendeSlp;
                case "ZAHLUNGSVERKEHR":
                    return ThemengebietEnum.Zahlungsverkehr;
                case "ZUORDNUNGSVEREINBARUNG":
                    return ThemengebietEnum.Zuordnungsvereinbarung;
            }
            throw new Exception("Cannot unmarshal type ThemengebietEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ThemengebietEnum)untypedValue;
            switch (value)
            {
                case ThemengebietEnum.AllgemeinerInformationsaustausch:
                    serializer.Serialize(writer, "ALLGEMEINER_INFORMATIONSAUSTAUSCH");
                    return;
                case ThemengebietEnum.Alocat:
                    serializer.Serialize(writer, "ALOCAT");
                    return;
                case ThemengebietEnum.AnsprechpartnerAllgemein:
                    serializer.Serialize(writer, "ANSPRECHPARTNER_ALLGEMEIN");
                    return;
                case ThemengebietEnum.AnsprechpartnerBdewDvgw:
                    serializer.Serialize(writer, "ANSPRECHPARTNER_BDEW_DVGW");
                    return;
                case ThemengebietEnum.AnsprechpartnerItTechnik:
                    serializer.Serialize(writer, "ANSPRECHPARTNER_IT_TECHNIK");
                    return;
                case ThemengebietEnum.AnUndAbmeldung:
                    serializer.Serialize(writer, "AN_UND_ABMELDUNG");
                    return;
                case ThemengebietEnum.Aperak:
                    serializer.Serialize(writer, "APERAK");
                    return;
                case ThemengebietEnum.Bewegungsdaten:
                    serializer.Serialize(writer, "BEWEGUNGSDATEN");
                    return;
                case ThemengebietEnum.Bilanzierung:
                    serializer.Serialize(writer, "BILANZIERUNG");
                    return;
                case ThemengebietEnum.Bilanzkreiskoordinator:
                    serializer.Serialize(writer, "BILANZKREISKOORDINATOR");
                    return;
                case ThemengebietEnum.Bilanzkreisverantwortlicher:
                    serializer.Serialize(writer, "BILANZKREISVERANTWORTLICHER");
                    return;
                case ThemengebietEnum.Contrl:
                    serializer.Serialize(writer, "CONTRL");
                    return;
                case ThemengebietEnum.DatenformateZertifikateVerschluesselungen:
                    serializer.Serialize(writer, "DATENFORMATE_ZERTIFIKATE_VERSCHLUESSELUNGEN");
                    return;
                case ThemengebietEnum.Debitorenmanagement:
                    serializer.Serialize(writer, "DEBITORENMANAGEMENT");
                    return;
                case ThemengebietEnum.DemandSideManagement:
                    serializer.Serialize(writer, "DEMAND_SIDE_MANAGEMENT");
                    return;
                case ThemengebietEnum.Edifact:
                    serializer.Serialize(writer, "EDIFACT");
                    return;
                case ThemengebietEnum.EdiVereinbarung:
                    serializer.Serialize(writer, "EDI_VEREINBARUNG");
                    return;
                case ThemengebietEnum.Einspeisung:
                    serializer.Serialize(writer, "EINSPEISUNG");
                    return;
                case ThemengebietEnum.Energiedatenmanagement:
                    serializer.Serialize(writer, "ENERGIEDATENMANAGEMENT");
                    return;
                case ThemengebietEnum.Fahrplanmanagement:
                    serializer.Serialize(writer, "FAHRPLANMANAGEMENT");
                    return;
                case ThemengebietEnum.Gabi:
                    serializer.Serialize(writer, "GABI");
                    return;
                case ThemengebietEnum.Geli:
                    serializer.Serialize(writer, "GELI");
                    return;
                case ThemengebietEnum.Geraeterueckgabe:
                    serializer.Serialize(writer, "GERAETERUECKGABE");
                    return;
                case ThemengebietEnum.Geraetewechsel:
                    serializer.Serialize(writer, "GERAETEWECHSEL");
                    return;
                case ThemengebietEnum.Gpke:
                    serializer.Serialize(writer, "GPKE");
                    return;
                case ThemengebietEnum.Inbetriebnahme:
                    serializer.Serialize(writer, "INBETRIEBNAHME");
                    return;
                case ThemengebietEnum.Invoic:
                    serializer.Serialize(writer, "INVOIC");
                    return;
                case ThemengebietEnum.Kapazitaetsmanagement:
                    serializer.Serialize(writer, "KAPAZITAETSMANAGEMENT");
                    return;
                case ThemengebietEnum.Klaerfaelle:
                    serializer.Serialize(writer, "KLAERFAELLE");
                    return;
                case ThemengebietEnum.LastgaengeRlm:
                    serializer.Serialize(writer, "LASTGAENGE_RLM");
                    return;
                case ThemengebietEnum.Lieferantenrahmenvertrag:
                    serializer.Serialize(writer, "LIEFERANTENRAHMENVERTRAG");
                    return;
                case ThemengebietEnum.Lieferantenwechsel:
                    serializer.Serialize(writer, "LIEFERANTENWECHSEL");
                    return;
                case ThemengebietEnum.Mabis:
                    serializer.Serialize(writer, "MABIS");
                    return;
                case ThemengebietEnum.Mahnwesen:
                    serializer.Serialize(writer, "MAHNWESEN");
                    return;
                case ThemengebietEnum.Marktgebietsverantwortlicher:
                    serializer.Serialize(writer, "MARKTGEBIETSVERANTWORTLICHER");
                    return;
                case ThemengebietEnum.Marktkommunikation:
                    serializer.Serialize(writer, "MARKTKOMMUNIKATION");
                    return;
                case ThemengebietEnum.MehrMindermengen:
                    serializer.Serialize(writer, "MEHR_MINDERMENGEN");
                    return;
                case ThemengebietEnum.MsbMdl:
                    serializer.Serialize(writer, "MSB_MDL");
                    return;
                case ThemengebietEnum.Mscons:
                    serializer.Serialize(writer, "MSCONS");
                    return;
                case ThemengebietEnum.Netzabrechnung:
                    serializer.Serialize(writer, "NETZABRECHNUNG");
                    return;
                case ThemengebietEnum.Netzentgelte:
                    serializer.Serialize(writer, "NETZENTGELTE");
                    return;
                case ThemengebietEnum.Netzmanagement:
                    serializer.Serialize(writer, "NETZMANAGEMENT");
                    return;
                case ThemengebietEnum.Orders:
                    serializer.Serialize(writer, "ORDERS");
                    return;
                case ThemengebietEnum.Ordersp:
                    serializer.Serialize(writer, "ORDERSP");
                    return;
                case ThemengebietEnum.Recht:
                    serializer.Serialize(writer, "RECHT");
                    return;
                case ThemengebietEnum.Regulierungsmanagement:
                    serializer.Serialize(writer, "REGULIERUNGSMANAGEMENT");
                    return;
                case ThemengebietEnum.Reklamationen:
                    serializer.Serialize(writer, "REKLAMATIONEN");
                    return;
                case ThemengebietEnum.Remadv:
                    serializer.Serialize(writer, "REMADV");
                    return;
                case ThemengebietEnum.SperrenEntsperrenInkasso:
                    serializer.Serialize(writer, "SPERREN_ENTSPERREN_INKASSO");
                    return;
                case ThemengebietEnum.Stammdaten:
                    serializer.Serialize(writer, "STAMMDATEN");
                    return;
                case ThemengebietEnum.Stoerungsfaelle:
                    serializer.Serialize(writer, "STOERUNGSFAELLE");
                    return;
                case ThemengebietEnum.TechnischeFragen:
                    serializer.Serialize(writer, "TECHNISCHE_FRAGEN");
                    return;
                case ThemengebietEnum.UmstellungInvoic:
                    serializer.Serialize(writer, "UMSTELLUNG_INVOIC");
                    return;
                case ThemengebietEnum.Utilmd:
                    serializer.Serialize(writer, "UTILMD");
                    return;
                case ThemengebietEnum.VerschluesselungSignatur:
                    serializer.Serialize(writer, "VERSCHLUESSELUNG_SIGNATUR");
                    return;
                case ThemengebietEnum.Vertragsmanagement:
                    serializer.Serialize(writer, "VERTRAGSMANAGEMENT");
                    return;
                case ThemengebietEnum.Vertrieb:
                    serializer.Serialize(writer, "VERTRIEB");
                    return;
                case ThemengebietEnum.Wim:
                    serializer.Serialize(writer, "WIM");
                    return;
                case ThemengebietEnum.ZaehlerstaendeSlp:
                    serializer.Serialize(writer, "ZAEHLERSTAENDE_SLP");
                    return;
                case ThemengebietEnum.Zahlungsverkehr:
                    serializer.Serialize(writer, "ZAHLUNGSVERKEHR");
                    return;
                case ThemengebietEnum.Zuordnungsvereinbarung:
                    serializer.Serialize(writer, "ZUORDNUNGSVEREINBARUNG");
                    return;
            }
            throw new Exception("Cannot marshal type ThemengebietEnum");
        }

        public static readonly ThemengebietEnumConverter Singleton = new ThemengebietEnumConverter();
    }
}
