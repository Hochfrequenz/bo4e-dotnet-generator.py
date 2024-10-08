// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var tarifzeit = Tarifzeit.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Zur Kennzeichnung verschiedener Tarifzeiten, beispielsweise zur Bepreisung oder zur
    /// Verbrauchsermittlung.
    /// </summary>
    public enum TarifzeitEnum { TzHt, TzNt, TzStandard };

    public class Tarifzeit
    {
        public static TarifzeitEnum FromJson(string json) => JsonConvert.DeserializeObject<TarifzeitEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TarifzeitEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TarifzeitEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TarifzeitEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TarifzeitEnum) || t == typeof(TarifzeitEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "TZ_HT":
                    return TarifzeitEnum.TzHt;
                case "TZ_NT":
                    return TarifzeitEnum.TzNt;
                case "TZ_STANDARD":
                    return TarifzeitEnum.TzStandard;
            }
            throw new Exception("Cannot unmarshal type TarifzeitEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TarifzeitEnum)untypedValue;
            switch (value)
            {
                case TarifzeitEnum.TzHt:
                    serializer.Serialize(writer, "TZ_HT");
                    return;
                case TarifzeitEnum.TzNt:
                    serializer.Serialize(writer, "TZ_NT");
                    return;
                case TarifzeitEnum.TzStandard:
                    serializer.Serialize(writer, "TZ_STANDARD");
                    return;
            }
            throw new Exception("Cannot marshal type TarifzeitEnum");
        }

        public static readonly TarifzeitEnumConverter Singleton = new TarifzeitEnumConverter();
    }
}
