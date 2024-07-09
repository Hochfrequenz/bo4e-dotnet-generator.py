// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var verbrauchsart = Verbrauchsart.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Verbrauchsart einer Marktlokation.
    /// </summary>
    public enum VerbrauchsartEnum { Kl, Klw, Klws, W, Ws };

    public class Verbrauchsart
    {
        public static VerbrauchsartEnum FromJson(string json) => JsonConvert.DeserializeObject<VerbrauchsartEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this VerbrauchsartEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                VerbrauchsartEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class VerbrauchsartEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VerbrauchsartEnum) || t == typeof(VerbrauchsartEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "KL":
                    return VerbrauchsartEnum.Kl;
                case "KLW":
                    return VerbrauchsartEnum.Klw;
                case "KLWS":
                    return VerbrauchsartEnum.Klws;
                case "W":
                    return VerbrauchsartEnum.W;
                case "WS":
                    return VerbrauchsartEnum.Ws;
            }
            throw new Exception("Cannot unmarshal type VerbrauchsartEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (VerbrauchsartEnum)untypedValue;
            switch (value)
            {
                case VerbrauchsartEnum.Kl:
                    serializer.Serialize(writer, "KL");
                    return;
                case VerbrauchsartEnum.Klw:
                    serializer.Serialize(writer, "KLW");
                    return;
                case VerbrauchsartEnum.Klws:
                    serializer.Serialize(writer, "KLWS");
                    return;
                case VerbrauchsartEnum.W:
                    serializer.Serialize(writer, "W");
                    return;
                case VerbrauchsartEnum.Ws:
                    serializer.Serialize(writer, "WS");
                    return;
            }
            throw new Exception("Cannot marshal type VerbrauchsartEnum");
        }

        public static readonly VerbrauchsartEnumConverter Singleton = new VerbrauchsartEnumConverter();
    }
}
