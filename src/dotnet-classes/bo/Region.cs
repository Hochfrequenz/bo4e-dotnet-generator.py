// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var region = Region.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Modellierung einer Region als Menge von Kriterien, die eine Region beschreiben
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/bo/Region.svg" type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Region JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/bo/Region.json>`_
    /// </summary>
    public partial class Region
    {
        /// <summary>
        /// Hier können IDs anderer Systeme hinterlegt werden (z.B. eine SAP-GP-Nummer oder eine GUID)
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Bezeichnung der Region
        /// </summary>
        [JsonProperty("_typ")]
        public Typ? Typ { get; set; }

        /// <summary>
        /// Version der BO-Struktur aka "fachliche Versionierung"
        /// </summary>
        [JsonProperty("_version")]
        public string Version { get; set; }

        /// <summary>
        /// Bezeichnung der Region
        /// </summary>
        [JsonProperty("bezeichnung")]
        public string Bezeichnung { get; set; }

        /// <summary>
        /// Negativliste der Kriterien zur Definition der Region
        /// </summary>
        [JsonProperty("negativListe")]
        public Regionskriterium[] NegativListe { get; set; }

        /// <summary>
        /// Positivliste der Kriterien zur Definition der Region
        /// </summary>
        [JsonProperty("positivListe")]
        public Regionskriterium[] PositivListe { get; set; }

        [JsonProperty("zusatzAttribute")]
        public ZusatzAttribut[] ZusatzAttribute { get; set; }
    }


    /// <summary>
    /// Viele Datenobjekte weisen in unterschiedlichen Systemen eine eindeutige ID (Kundennummer,
    /// GP-Nummer etc.) auf.
    /// Beim Austausch von Datenobjekten zwischen verschiedenen Systemen ist es daher hilfreich,
    /// sich die eindeutigen IDs der anzubindenden Systeme zu merken.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/ZusatzAttribut.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `ZusatzAttribut JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/ZusatzAttribut.json>`_
    /// </summary>
    public partial class ZusatzAttribut
    {
        /// <summary>
        /// Bezeichnung der externen Referenz (z.B. "microservice xyz" oder "SAP CRM GP-Nummer")
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Bezeichnung der externen Referenz (z.B. "microservice xyz" oder "SAP CRM GP-Nummer")
        /// </summary>
        [JsonProperty("wert")]
        public object Wert { get; set; }
    }

    /// <summary>
    /// Übersicht der verschiedenen Gültigkeiten zur Umsetzung von Positiv- bzw. Negativlisten.
    /// </summary>
    public enum Gueltigkeitstyp { NichtIn, NurIn, NurInKombinationMit };

    /// <summary>
    /// Klassifizierung der Kriterien für eine regionale Eingrenzung.
    /// </summary>
    public enum Regionskriteriumtyp { BilanzierungsGebietNummer, BundeslandName, Bundeslandkennziffer, Bundesweit, EinwohnerzahlGemeinde, EinwohnerzahlOrt, GemeindeName, Gemeindekennziffer, GrundversorgerNameGas, GrundversorgerNameStrom, GrundversorgerNummerGas, GrundversorgerNummerStrom, KmUmkreis, KreisName, Kreiskennziffer, MarktgebietName, MarktgebietNummer, MsbName, MsbNummer, NetzGas, NetzStrom, NetzbetreiberNameGas, NetzbetreiberNameStrom, NetzbetreiberNummerGas, NetzbetreiberNummerStrom, Ort, PlzBereich, Postleitzahl, Postort, RegelgebietName, RegelgebietNummer, VersorgerName, VersorgerNummer };

    /// <summary>
    /// Auflistung sämtlicher existierender Geschäftsobjekte.
    /// </summary>
    public enum Typ { Angebot, Ausschreibung, Buendelvertrag, Energiemenge, Fremdkosten, Geraet, Geschaeftsobjekt, Geschaeftspartner, Kosten, Lastgang, Marktlokation, Marktteilnehmer, Messlokation, Netznutzungsrechnung, Person, Preisblatt, Preisblattdienstleistung, Preisblatthardware, Preisblattkonzessionsabgabe, Preisblattmessung, Preisblattnetznutzung, Preisblattumlagen, Rechnung, Region, Regionaltarif, Standorteigenschaften, Tarif, Tarifinfo, Tarifkosten, Tarifpreisblatt, Vertrag, Zaehler, Zeitreihe };

    public partial class Region
    {
        public static Region FromJson(string json) => JsonConvert.DeserializeObject<Region>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Region self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypConverter.Singleton,
                GueltigkeitstypConverter.Singleton,
                RegionskriteriumtypConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Typ) || t == typeof(Typ?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ANGEBOT":
                    return Typ.Angebot;
                case "AUSSCHREIBUNG":
                    return Typ.Ausschreibung;
                case "BUENDELVERTRAG":
                    return Typ.Buendelvertrag;
                case "ENERGIEMENGE":
                    return Typ.Energiemenge;
                case "FREMDKOSTEN":
                    return Typ.Fremdkosten;
                case "GERAET":
                    return Typ.Geraet;
                case "GESCHAEFTSOBJEKT":
                    return Typ.Geschaeftsobjekt;
                case "GESCHAEFTSPARTNER":
                    return Typ.Geschaeftspartner;
                case "KOSTEN":
                    return Typ.Kosten;
                case "LASTGANG":
                    return Typ.Lastgang;
                case "MARKTLOKATION":
                    return Typ.Marktlokation;
                case "MARKTTEILNEHMER":
                    return Typ.Marktteilnehmer;
                case "MESSLOKATION":
                    return Typ.Messlokation;
                case "NETZNUTZUNGSRECHNUNG":
                    return Typ.Netznutzungsrechnung;
                case "PERSON":
                    return Typ.Person;
                case "PREISBLATT":
                    return Typ.Preisblatt;
                case "PREISBLATTDIENSTLEISTUNG":
                    return Typ.Preisblattdienstleistung;
                case "PREISBLATTHARDWARE":
                    return Typ.Preisblatthardware;
                case "PREISBLATTKONZESSIONSABGABE":
                    return Typ.Preisblattkonzessionsabgabe;
                case "PREISBLATTMESSUNG":
                    return Typ.Preisblattmessung;
                case "PREISBLATTNETZNUTZUNG":
                    return Typ.Preisblattnetznutzung;
                case "PREISBLATTUMLAGEN":
                    return Typ.Preisblattumlagen;
                case "RECHNUNG":
                    return Typ.Rechnung;
                case "REGION":
                    return Typ.Region;
                case "REGIONALTARIF":
                    return Typ.Regionaltarif;
                case "STANDORTEIGENSCHAFTEN":
                    return Typ.Standorteigenschaften;
                case "TARIF":
                    return Typ.Tarif;
                case "TARIFINFO":
                    return Typ.Tarifinfo;
                case "TARIFKOSTEN":
                    return Typ.Tarifkosten;
                case "TARIFPREISBLATT":
                    return Typ.Tarifpreisblatt;
                case "VERTRAG":
                    return Typ.Vertrag;
                case "ZAEHLER":
                    return Typ.Zaehler;
                case "ZEITREIHE":
                    return Typ.Zeitreihe;
            }
            throw new Exception("Cannot unmarshal type Typ");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Typ)untypedValue;
            switch (value)
            {
                case Typ.Angebot:
                    serializer.Serialize(writer, "ANGEBOT");
                    return;
                case Typ.Ausschreibung:
                    serializer.Serialize(writer, "AUSSCHREIBUNG");
                    return;
                case Typ.Buendelvertrag:
                    serializer.Serialize(writer, "BUENDELVERTRAG");
                    return;
                case Typ.Energiemenge:
                    serializer.Serialize(writer, "ENERGIEMENGE");
                    return;
                case Typ.Fremdkosten:
                    serializer.Serialize(writer, "FREMDKOSTEN");
                    return;
                case Typ.Geraet:
                    serializer.Serialize(writer, "GERAET");
                    return;
                case Typ.Geschaeftsobjekt:
                    serializer.Serialize(writer, "GESCHAEFTSOBJEKT");
                    return;
                case Typ.Geschaeftspartner:
                    serializer.Serialize(writer, "GESCHAEFTSPARTNER");
                    return;
                case Typ.Kosten:
                    serializer.Serialize(writer, "KOSTEN");
                    return;
                case Typ.Lastgang:
                    serializer.Serialize(writer, "LASTGANG");
                    return;
                case Typ.Marktlokation:
                    serializer.Serialize(writer, "MARKTLOKATION");
                    return;
                case Typ.Marktteilnehmer:
                    serializer.Serialize(writer, "MARKTTEILNEHMER");
                    return;
                case Typ.Messlokation:
                    serializer.Serialize(writer, "MESSLOKATION");
                    return;
                case Typ.Netznutzungsrechnung:
                    serializer.Serialize(writer, "NETZNUTZUNGSRECHNUNG");
                    return;
                case Typ.Person:
                    serializer.Serialize(writer, "PERSON");
                    return;
                case Typ.Preisblatt:
                    serializer.Serialize(writer, "PREISBLATT");
                    return;
                case Typ.Preisblattdienstleistung:
                    serializer.Serialize(writer, "PREISBLATTDIENSTLEISTUNG");
                    return;
                case Typ.Preisblatthardware:
                    serializer.Serialize(writer, "PREISBLATTHARDWARE");
                    return;
                case Typ.Preisblattkonzessionsabgabe:
                    serializer.Serialize(writer, "PREISBLATTKONZESSIONSABGABE");
                    return;
                case Typ.Preisblattmessung:
                    serializer.Serialize(writer, "PREISBLATTMESSUNG");
                    return;
                case Typ.Preisblattnetznutzung:
                    serializer.Serialize(writer, "PREISBLATTNETZNUTZUNG");
                    return;
                case Typ.Preisblattumlagen:
                    serializer.Serialize(writer, "PREISBLATTUMLAGEN");
                    return;
                case Typ.Rechnung:
                    serializer.Serialize(writer, "RECHNUNG");
                    return;
                case Typ.Region:
                    serializer.Serialize(writer, "REGION");
                    return;
                case Typ.Regionaltarif:
                    serializer.Serialize(writer, "REGIONALTARIF");
                    return;
                case Typ.Standorteigenschaften:
                    serializer.Serialize(writer, "STANDORTEIGENSCHAFTEN");
                    return;
                case Typ.Tarif:
                    serializer.Serialize(writer, "TARIF");
                    return;
                case Typ.Tarifinfo:
                    serializer.Serialize(writer, "TARIFINFO");
                    return;
                case Typ.Tarifkosten:
                    serializer.Serialize(writer, "TARIFKOSTEN");
                    return;
                case Typ.Tarifpreisblatt:
                    serializer.Serialize(writer, "TARIFPREISBLATT");
                    return;
                case Typ.Vertrag:
                    serializer.Serialize(writer, "VERTRAG");
                    return;
                case Typ.Zaehler:
                    serializer.Serialize(writer, "ZAEHLER");
                    return;
                case Typ.Zeitreihe:
                    serializer.Serialize(writer, "ZEITREIHE");
                    return;
            }
            throw new Exception("Cannot marshal type Typ");
        }

        public static readonly TypConverter Singleton = new TypConverter();
    }

    internal class GueltigkeitstypConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gueltigkeitstyp) || t == typeof(Gueltigkeitstyp?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "NICHT_IN":
                    return Gueltigkeitstyp.NichtIn;
                case "NUR_IN":
                    return Gueltigkeitstyp.NurIn;
                case "NUR_IN_KOMBINATION_MIT":
                    return Gueltigkeitstyp.NurInKombinationMit;
            }
            throw new Exception("Cannot unmarshal type Gueltigkeitstyp");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gueltigkeitstyp)untypedValue;
            switch (value)
            {
                case Gueltigkeitstyp.NichtIn:
                    serializer.Serialize(writer, "NICHT_IN");
                    return;
                case Gueltigkeitstyp.NurIn:
                    serializer.Serialize(writer, "NUR_IN");
                    return;
                case Gueltigkeitstyp.NurInKombinationMit:
                    serializer.Serialize(writer, "NUR_IN_KOMBINATION_MIT");
                    return;
            }
            throw new Exception("Cannot marshal type Gueltigkeitstyp");
        }

        public static readonly GueltigkeitstypConverter Singleton = new GueltigkeitstypConverter();
    }

    internal class RegionskriteriumtypConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Regionskriteriumtyp) || t == typeof(Regionskriteriumtyp?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BILANZIERUNGS_GEBIET_NUMMER":
                    return Regionskriteriumtyp.BilanzierungsGebietNummer;
                case "BUNDESLANDKENNZIFFER":
                    return Regionskriteriumtyp.Bundeslandkennziffer;
                case "BUNDESLAND_NAME":
                    return Regionskriteriumtyp.BundeslandName;
                case "BUNDESWEIT":
                    return Regionskriteriumtyp.Bundesweit;
                case "EINWOHNERZAHL_GEMEINDE":
                    return Regionskriteriumtyp.EinwohnerzahlGemeinde;
                case "EINWOHNERZAHL_ORT":
                    return Regionskriteriumtyp.EinwohnerzahlOrt;
                case "GEMEINDEKENNZIFFER":
                    return Regionskriteriumtyp.Gemeindekennziffer;
                case "GEMEINDE_NAME":
                    return Regionskriteriumtyp.GemeindeName;
                case "GRUNDVERSORGER_NAME_GAS":
                    return Regionskriteriumtyp.GrundversorgerNameGas;
                case "GRUNDVERSORGER_NAME_STROM":
                    return Regionskriteriumtyp.GrundversorgerNameStrom;
                case "GRUNDVERSORGER_NUMMER_GAS":
                    return Regionskriteriumtyp.GrundversorgerNummerGas;
                case "GRUNDVERSORGER_NUMMER_STROM":
                    return Regionskriteriumtyp.GrundversorgerNummerStrom;
                case "KM_UMKREIS":
                    return Regionskriteriumtyp.KmUmkreis;
                case "KREISKENNZIFFER":
                    return Regionskriteriumtyp.Kreiskennziffer;
                case "KREIS_NAME":
                    return Regionskriteriumtyp.KreisName;
                case "MARKTGEBIET_NAME":
                    return Regionskriteriumtyp.MarktgebietName;
                case "MARKTGEBIET_NUMMER":
                    return Regionskriteriumtyp.MarktgebietNummer;
                case "MSB_NAME":
                    return Regionskriteriumtyp.MsbName;
                case "MSB_NUMMER":
                    return Regionskriteriumtyp.MsbNummer;
                case "NETZBETREIBER_NAME_GAS":
                    return Regionskriteriumtyp.NetzbetreiberNameGas;
                case "NETZBETREIBER_NAME_STROM":
                    return Regionskriteriumtyp.NetzbetreiberNameStrom;
                case "NETZBETREIBER_NUMMER_GAS":
                    return Regionskriteriumtyp.NetzbetreiberNummerGas;
                case "NETZBETREIBER_NUMMER_STROM":
                    return Regionskriteriumtyp.NetzbetreiberNummerStrom;
                case "NETZ_GAS":
                    return Regionskriteriumtyp.NetzGas;
                case "NETZ_STROM":
                    return Regionskriteriumtyp.NetzStrom;
                case "ORT":
                    return Regionskriteriumtyp.Ort;
                case "PLZ_BEREICH":
                    return Regionskriteriumtyp.PlzBereich;
                case "POSTLEITZAHL":
                    return Regionskriteriumtyp.Postleitzahl;
                case "POSTORT":
                    return Regionskriteriumtyp.Postort;
                case "REGELGEBIET_NAME":
                    return Regionskriteriumtyp.RegelgebietName;
                case "REGELGEBIET_NUMMER":
                    return Regionskriteriumtyp.RegelgebietNummer;
                case "VERSORGER_NAME":
                    return Regionskriteriumtyp.VersorgerName;
                case "VERSORGER_NUMMER":
                    return Regionskriteriumtyp.VersorgerNummer;
            }
            throw new Exception("Cannot unmarshal type Regionskriteriumtyp");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Regionskriteriumtyp)untypedValue;
            switch (value)
            {
                case Regionskriteriumtyp.BilanzierungsGebietNummer:
                    serializer.Serialize(writer, "BILANZIERUNGS_GEBIET_NUMMER");
                    return;
                case Regionskriteriumtyp.Bundeslandkennziffer:
                    serializer.Serialize(writer, "BUNDESLANDKENNZIFFER");
                    return;
                case Regionskriteriumtyp.BundeslandName:
                    serializer.Serialize(writer, "BUNDESLAND_NAME");
                    return;
                case Regionskriteriumtyp.Bundesweit:
                    serializer.Serialize(writer, "BUNDESWEIT");
                    return;
                case Regionskriteriumtyp.EinwohnerzahlGemeinde:
                    serializer.Serialize(writer, "EINWOHNERZAHL_GEMEINDE");
                    return;
                case Regionskriteriumtyp.EinwohnerzahlOrt:
                    serializer.Serialize(writer, "EINWOHNERZAHL_ORT");
                    return;
                case Regionskriteriumtyp.Gemeindekennziffer:
                    serializer.Serialize(writer, "GEMEINDEKENNZIFFER");
                    return;
                case Regionskriteriumtyp.GemeindeName:
                    serializer.Serialize(writer, "GEMEINDE_NAME");
                    return;
                case Regionskriteriumtyp.GrundversorgerNameGas:
                    serializer.Serialize(writer, "GRUNDVERSORGER_NAME_GAS");
                    return;
                case Regionskriteriumtyp.GrundversorgerNameStrom:
                    serializer.Serialize(writer, "GRUNDVERSORGER_NAME_STROM");
                    return;
                case Regionskriteriumtyp.GrundversorgerNummerGas:
                    serializer.Serialize(writer, "GRUNDVERSORGER_NUMMER_GAS");
                    return;
                case Regionskriteriumtyp.GrundversorgerNummerStrom:
                    serializer.Serialize(writer, "GRUNDVERSORGER_NUMMER_STROM");
                    return;
                case Regionskriteriumtyp.KmUmkreis:
                    serializer.Serialize(writer, "KM_UMKREIS");
                    return;
                case Regionskriteriumtyp.Kreiskennziffer:
                    serializer.Serialize(writer, "KREISKENNZIFFER");
                    return;
                case Regionskriteriumtyp.KreisName:
                    serializer.Serialize(writer, "KREIS_NAME");
                    return;
                case Regionskriteriumtyp.MarktgebietName:
                    serializer.Serialize(writer, "MARKTGEBIET_NAME");
                    return;
                case Regionskriteriumtyp.MarktgebietNummer:
                    serializer.Serialize(writer, "MARKTGEBIET_NUMMER");
                    return;
                case Regionskriteriumtyp.MsbName:
                    serializer.Serialize(writer, "MSB_NAME");
                    return;
                case Regionskriteriumtyp.MsbNummer:
                    serializer.Serialize(writer, "MSB_NUMMER");
                    return;
                case Regionskriteriumtyp.NetzbetreiberNameGas:
                    serializer.Serialize(writer, "NETZBETREIBER_NAME_GAS");
                    return;
                case Regionskriteriumtyp.NetzbetreiberNameStrom:
                    serializer.Serialize(writer, "NETZBETREIBER_NAME_STROM");
                    return;
                case Regionskriteriumtyp.NetzbetreiberNummerGas:
                    serializer.Serialize(writer, "NETZBETREIBER_NUMMER_GAS");
                    return;
                case Regionskriteriumtyp.NetzbetreiberNummerStrom:
                    serializer.Serialize(writer, "NETZBETREIBER_NUMMER_STROM");
                    return;
                case Regionskriteriumtyp.NetzGas:
                    serializer.Serialize(writer, "NETZ_GAS");
                    return;
                case Regionskriteriumtyp.NetzStrom:
                    serializer.Serialize(writer, "NETZ_STROM");
                    return;
                case Regionskriteriumtyp.Ort:
                    serializer.Serialize(writer, "ORT");
                    return;
                case Regionskriteriumtyp.PlzBereich:
                    serializer.Serialize(writer, "PLZ_BEREICH");
                    return;
                case Regionskriteriumtyp.Postleitzahl:
                    serializer.Serialize(writer, "POSTLEITZAHL");
                    return;
                case Regionskriteriumtyp.Postort:
                    serializer.Serialize(writer, "POSTORT");
                    return;
                case Regionskriteriumtyp.RegelgebietName:
                    serializer.Serialize(writer, "REGELGEBIET_NAME");
                    return;
                case Regionskriteriumtyp.RegelgebietNummer:
                    serializer.Serialize(writer, "REGELGEBIET_NUMMER");
                    return;
                case Regionskriteriumtyp.VersorgerName:
                    serializer.Serialize(writer, "VERSORGER_NAME");
                    return;
                case Regionskriteriumtyp.VersorgerNummer:
                    serializer.Serialize(writer, "VERSORGER_NUMMER");
                    return;
            }
            throw new Exception("Cannot marshal type Regionskriteriumtyp");
        }

        public static readonly RegionskriteriumtypConverter Singleton = new RegionskriteriumtypConverter();
    }
}
