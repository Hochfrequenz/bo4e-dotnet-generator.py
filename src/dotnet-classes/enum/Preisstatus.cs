// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var preisstatus = Preisstatus.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Statusinformation für Preise
    /// </summary>
    public enum PreisstatusEnum { Endgueltig, Vorlaeufig };

    public class Preisstatus
    {
        public static PreisstatusEnum FromJson(string json) => JsonConvert.DeserializeObject<PreisstatusEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PreisstatusEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PreisstatusEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PreisstatusEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PreisstatusEnum) || t == typeof(PreisstatusEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ENDGUELTIG":
                    return PreisstatusEnum.Endgueltig;
                case "VORLAEUFIG":
                    return PreisstatusEnum.Vorlaeufig;
            }
            throw new Exception("Cannot unmarshal type PreisstatusEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PreisstatusEnum)untypedValue;
            switch (value)
            {
                case PreisstatusEnum.Endgueltig:
                    serializer.Serialize(writer, "ENDGUELTIG");
                    return;
                case PreisstatusEnum.Vorlaeufig:
                    serializer.Serialize(writer, "VORLAEUFIG");
                    return;
            }
            throw new Exception("Cannot marshal type PreisstatusEnum");
        }

        public static readonly PreisstatusEnumConverter Singleton = new PreisstatusEnumConverter();
    }
}
