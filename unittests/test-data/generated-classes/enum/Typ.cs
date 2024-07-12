// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var typ = Typ.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Auflistung sämtlicher existierender Geschäftsobjekte.
    /// </summary>
    public enum TypEnum { Angebot, Ausschreibung, Buendelvertrag, Energiemenge, Fremdkosten, Geraet, Geschaeftsobjekt, Geschaeftspartner, Kosten, Lastgang, Marktlokation, Marktteilnehmer, Messlokation, Netznutzungsrechnung, Person, Preisblatt, Preisblattdienstleistung, Preisblatthardware, Preisblattkonzessionsabgabe, Preisblattmessung, Preisblattnetznutzung, Preisblattumlagen, Rechnung, Region, Regionaltarif, Standorteigenschaften, Tarif, Tarifinfo, Tarifkosten, Tarifpreisblatt, Vertrag, Zaehler, Zeitreihe };

    public class Typ
    {
        public static TypEnum FromJson(string json) => JsonConvert.DeserializeObject<TypEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TypEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypEnum) || t == typeof(TypEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ANGEBOT":
                    return TypEnum.Angebot;
                case "AUSSCHREIBUNG":
                    return TypEnum.Ausschreibung;
                case "BUENDELVERTRAG":
                    return TypEnum.Buendelvertrag;
                case "ENERGIEMENGE":
                    return TypEnum.Energiemenge;
                case "FREMDKOSTEN":
                    return TypEnum.Fremdkosten;
                case "GERAET":
                    return TypEnum.Geraet;
                case "GESCHAEFTSOBJEKT":
                    return TypEnum.Geschaeftsobjekt;
                case "GESCHAEFTSPARTNER":
                    return TypEnum.Geschaeftspartner;
                case "KOSTEN":
                    return TypEnum.Kosten;
                case "LASTGANG":
                    return TypEnum.Lastgang;
                case "MARKTLOKATION":
                    return TypEnum.Marktlokation;
                case "MARKTTEILNEHMER":
                    return TypEnum.Marktteilnehmer;
                case "MESSLOKATION":
                    return TypEnum.Messlokation;
                case "NETZNUTZUNGSRECHNUNG":
                    return TypEnum.Netznutzungsrechnung;
                case "PERSON":
                    return TypEnum.Person;
                case "PREISBLATT":
                    return TypEnum.Preisblatt;
                case "PREISBLATTDIENSTLEISTUNG":
                    return TypEnum.Preisblattdienstleistung;
                case "PREISBLATTHARDWARE":
                    return TypEnum.Preisblatthardware;
                case "PREISBLATTKONZESSIONSABGABE":
                    return TypEnum.Preisblattkonzessionsabgabe;
                case "PREISBLATTMESSUNG":
                    return TypEnum.Preisblattmessung;
                case "PREISBLATTNETZNUTZUNG":
                    return TypEnum.Preisblattnetznutzung;
                case "PREISBLATTUMLAGEN":
                    return TypEnum.Preisblattumlagen;
                case "RECHNUNG":
                    return TypEnum.Rechnung;
                case "REGION":
                    return TypEnum.Region;
                case "REGIONALTARIF":
                    return TypEnum.Regionaltarif;
                case "STANDORTEIGENSCHAFTEN":
                    return TypEnum.Standorteigenschaften;
                case "TARIF":
                    return TypEnum.Tarif;
                case "TARIFINFO":
                    return TypEnum.Tarifinfo;
                case "TARIFKOSTEN":
                    return TypEnum.Tarifkosten;
                case "TARIFPREISBLATT":
                    return TypEnum.Tarifpreisblatt;
                case "VERTRAG":
                    return TypEnum.Vertrag;
                case "ZAEHLER":
                    return TypEnum.Zaehler;
                case "ZEITREIHE":
                    return TypEnum.Zeitreihe;
            }
            throw new Exception("Cannot unmarshal type TypEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypEnum)untypedValue;
            switch (value)
            {
                case TypEnum.Angebot:
                    serializer.Serialize(writer, "ANGEBOT");
                    return;
                case TypEnum.Ausschreibung:
                    serializer.Serialize(writer, "AUSSCHREIBUNG");
                    return;
                case TypEnum.Buendelvertrag:
                    serializer.Serialize(writer, "BUENDELVERTRAG");
                    return;
                case TypEnum.Energiemenge:
                    serializer.Serialize(writer, "ENERGIEMENGE");
                    return;
                case TypEnum.Fremdkosten:
                    serializer.Serialize(writer, "FREMDKOSTEN");
                    return;
                case TypEnum.Geraet:
                    serializer.Serialize(writer, "GERAET");
                    return;
                case TypEnum.Geschaeftsobjekt:
                    serializer.Serialize(writer, "GESCHAEFTSOBJEKT");
                    return;
                case TypEnum.Geschaeftspartner:
                    serializer.Serialize(writer, "GESCHAEFTSPARTNER");
                    return;
                case TypEnum.Kosten:
                    serializer.Serialize(writer, "KOSTEN");
                    return;
                case TypEnum.Lastgang:
                    serializer.Serialize(writer, "LASTGANG");
                    return;
                case TypEnum.Marktlokation:
                    serializer.Serialize(writer, "MARKTLOKATION");
                    return;
                case TypEnum.Marktteilnehmer:
                    serializer.Serialize(writer, "MARKTTEILNEHMER");
                    return;
                case TypEnum.Messlokation:
                    serializer.Serialize(writer, "MESSLOKATION");
                    return;
                case TypEnum.Netznutzungsrechnung:
                    serializer.Serialize(writer, "NETZNUTZUNGSRECHNUNG");
                    return;
                case TypEnum.Person:
                    serializer.Serialize(writer, "PERSON");
                    return;
                case TypEnum.Preisblatt:
                    serializer.Serialize(writer, "PREISBLATT");
                    return;
                case TypEnum.Preisblattdienstleistung:
                    serializer.Serialize(writer, "PREISBLATTDIENSTLEISTUNG");
                    return;
                case TypEnum.Preisblatthardware:
                    serializer.Serialize(writer, "PREISBLATTHARDWARE");
                    return;
                case TypEnum.Preisblattkonzessionsabgabe:
                    serializer.Serialize(writer, "PREISBLATTKONZESSIONSABGABE");
                    return;
                case TypEnum.Preisblattmessung:
                    serializer.Serialize(writer, "PREISBLATTMESSUNG");
                    return;
                case TypEnum.Preisblattnetznutzung:
                    serializer.Serialize(writer, "PREISBLATTNETZNUTZUNG");
                    return;
                case TypEnum.Preisblattumlagen:
                    serializer.Serialize(writer, "PREISBLATTUMLAGEN");
                    return;
                case TypEnum.Rechnung:
                    serializer.Serialize(writer, "RECHNUNG");
                    return;
                case TypEnum.Region:
                    serializer.Serialize(writer, "REGION");
                    return;
                case TypEnum.Regionaltarif:
                    serializer.Serialize(writer, "REGIONALTARIF");
                    return;
                case TypEnum.Standorteigenschaften:
                    serializer.Serialize(writer, "STANDORTEIGENSCHAFTEN");
                    return;
                case TypEnum.Tarif:
                    serializer.Serialize(writer, "TARIF");
                    return;
                case TypEnum.Tarifinfo:
                    serializer.Serialize(writer, "TARIFINFO");
                    return;
                case TypEnum.Tarifkosten:
                    serializer.Serialize(writer, "TARIFKOSTEN");
                    return;
                case TypEnum.Tarifpreisblatt:
                    serializer.Serialize(writer, "TARIFPREISBLATT");
                    return;
                case TypEnum.Vertrag:
                    serializer.Serialize(writer, "VERTRAG");
                    return;
                case TypEnum.Zaehler:
                    serializer.Serialize(writer, "ZAEHLER");
                    return;
                case TypEnum.Zeitreihe:
                    serializer.Serialize(writer, "ZEITREIHE");
                    return;
            }
            throw new Exception("Cannot marshal type TypEnum");
        }

        public static readonly TypEnumConverter Singleton = new TypEnumConverter();
    }
}