// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var rechnungstyp = Rechnungstyp.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Abbildung verschiedener Rechnungstypen zur Kennzeichnung von Rechnungen
    /// </summary>
    public enum RechnungstypEnum { Ausgleichsenergierechnung, Beschaffungsrechnung, Endkundenrechnung, Mehrmindermengenrechnung, Messstellenbetriebsrechnung, Netznutzungsrechnung };

    public class Rechnungstyp
    {
        public static RechnungstypEnum FromJson(string json) => JsonConvert.DeserializeObject<RechnungstypEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RechnungstypEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                RechnungstypEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class RechnungstypEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(RechnungstypEnum) || t == typeof(RechnungstypEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AUSGLEICHSENERGIERECHNUNG":
                    return RechnungstypEnum.Ausgleichsenergierechnung;
                case "BESCHAFFUNGSRECHNUNG":
                    return RechnungstypEnum.Beschaffungsrechnung;
                case "ENDKUNDENRECHNUNG":
                    return RechnungstypEnum.Endkundenrechnung;
                case "MEHRMINDERMENGENRECHNUNG":
                    return RechnungstypEnum.Mehrmindermengenrechnung;
                case "MESSSTELLENBETRIEBSRECHNUNG":
                    return RechnungstypEnum.Messstellenbetriebsrechnung;
                case "NETZNUTZUNGSRECHNUNG":
                    return RechnungstypEnum.Netznutzungsrechnung;
            }
            throw new Exception("Cannot unmarshal type RechnungstypEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (RechnungstypEnum)untypedValue;
            switch (value)
            {
                case RechnungstypEnum.Ausgleichsenergierechnung:
                    serializer.Serialize(writer, "AUSGLEICHSENERGIERECHNUNG");
                    return;
                case RechnungstypEnum.Beschaffungsrechnung:
                    serializer.Serialize(writer, "BESCHAFFUNGSRECHNUNG");
                    return;
                case RechnungstypEnum.Endkundenrechnung:
                    serializer.Serialize(writer, "ENDKUNDENRECHNUNG");
                    return;
                case RechnungstypEnum.Mehrmindermengenrechnung:
                    serializer.Serialize(writer, "MEHRMINDERMENGENRECHNUNG");
                    return;
                case RechnungstypEnum.Messstellenbetriebsrechnung:
                    serializer.Serialize(writer, "MESSSTELLENBETRIEBSRECHNUNG");
                    return;
                case RechnungstypEnum.Netznutzungsrechnung:
                    serializer.Serialize(writer, "NETZNUTZUNGSRECHNUNG");
                    return;
            }
            throw new Exception("Cannot marshal type RechnungstypEnum");
        }

        public static readonly RechnungstypEnumConverter Singleton = new RechnungstypEnumConverter();
    }
}