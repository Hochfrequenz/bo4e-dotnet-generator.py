// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var lokationstyp = Lokationstyp.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Gibt an, ob es sich um eine Markt- oder Messlokation handelt.
    /// </summary>
    public enum LokationstypEnum { Malo, Melo };

    public class Lokationstyp
    {
        public static LokationstypEnum FromJson(string json) => JsonConvert.DeserializeObject<LokationstypEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this LokationstypEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                LokationstypEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class LokationstypEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(LokationstypEnum) || t == typeof(LokationstypEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "MALO":
                    return LokationstypEnum.Malo;
                case "MELO":
                    return LokationstypEnum.Melo;
            }
            throw new Exception("Cannot unmarshal type LokationstypEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (LokationstypEnum)untypedValue;
            switch (value)
            {
                case LokationstypEnum.Malo:
                    serializer.Serialize(writer, "MALO");
                    return;
                case LokationstypEnum.Melo:
                    serializer.Serialize(writer, "MELO");
                    return;
            }
            throw new Exception("Cannot marshal type LokationstypEnum");
        }

        public static readonly LokationstypEnumConverter Singleton = new LokationstypEnumConverter();
    }
}
