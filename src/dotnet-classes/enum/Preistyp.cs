// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var preistyp = Preistyp.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Aufschlüsselung der Preistypen in Tarifen.
    /// </summary>
    public enum PreistypEnum { ArbeitspreisEintarif, ArbeitspreisHt, ArbeitspreisNt, EntgeltAblesung, EntgeltAbrechnung, EntgeltMsb, Grundpreis, Leistungspreis, Messpreis, Provision };

    public class Preistyp
    {
        public static PreistypEnum FromJson(string json) => JsonConvert.DeserializeObject<PreistypEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PreistypEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PreistypEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PreistypEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PreistypEnum) || t == typeof(PreistypEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ARBEITSPREIS_EINTARIF":
                    return PreistypEnum.ArbeitspreisEintarif;
                case "ARBEITSPREIS_HT":
                    return PreistypEnum.ArbeitspreisHt;
                case "ARBEITSPREIS_NT":
                    return PreistypEnum.ArbeitspreisNt;
                case "ENTGELT_ABLESUNG":
                    return PreistypEnum.EntgeltAblesung;
                case "ENTGELT_ABRECHNUNG":
                    return PreistypEnum.EntgeltAbrechnung;
                case "ENTGELT_MSB":
                    return PreistypEnum.EntgeltMsb;
                case "GRUNDPREIS":
                    return PreistypEnum.Grundpreis;
                case "LEISTUNGSPREIS":
                    return PreistypEnum.Leistungspreis;
                case "MESSPREIS":
                    return PreistypEnum.Messpreis;
                case "PROVISION":
                    return PreistypEnum.Provision;
            }
            throw new Exception("Cannot unmarshal type PreistypEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PreistypEnum)untypedValue;
            switch (value)
            {
                case PreistypEnum.ArbeitspreisEintarif:
                    serializer.Serialize(writer, "ARBEITSPREIS_EINTARIF");
                    return;
                case PreistypEnum.ArbeitspreisHt:
                    serializer.Serialize(writer, "ARBEITSPREIS_HT");
                    return;
                case PreistypEnum.ArbeitspreisNt:
                    serializer.Serialize(writer, "ARBEITSPREIS_NT");
                    return;
                case PreistypEnum.EntgeltAblesung:
                    serializer.Serialize(writer, "ENTGELT_ABLESUNG");
                    return;
                case PreistypEnum.EntgeltAbrechnung:
                    serializer.Serialize(writer, "ENTGELT_ABRECHNUNG");
                    return;
                case PreistypEnum.EntgeltMsb:
                    serializer.Serialize(writer, "ENTGELT_MSB");
                    return;
                case PreistypEnum.Grundpreis:
                    serializer.Serialize(writer, "GRUNDPREIS");
                    return;
                case PreistypEnum.Leistungspreis:
                    serializer.Serialize(writer, "LEISTUNGSPREIS");
                    return;
                case PreistypEnum.Messpreis:
                    serializer.Serialize(writer, "MESSPREIS");
                    return;
                case PreistypEnum.Provision:
                    serializer.Serialize(writer, "PROVISION");
                    return;
            }
            throw new Exception("Cannot marshal type PreistypEnum");
        }

        public static readonly PreistypEnumConverter Singleton = new PreistypEnumConverter();
    }
}
