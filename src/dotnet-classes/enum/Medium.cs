// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var medium = Medium.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Gibt ein physikalisches Medium an.
    /// </summary>
    public enum MediumEnum { Dampf, Gas, Strom, Wasser };

    public class Medium
    {
        public static MediumEnum FromJson(string json) => JsonConvert.DeserializeObject<MediumEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MediumEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MediumEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class MediumEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MediumEnum) || t == typeof(MediumEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "DAMPF":
                    return MediumEnum.Dampf;
                case "GAS":
                    return MediumEnum.Gas;
                case "STROM":
                    return MediumEnum.Strom;
                case "WASSER":
                    return MediumEnum.Wasser;
            }
            throw new Exception("Cannot unmarshal type MediumEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MediumEnum)untypedValue;
            switch (value)
            {
                case MediumEnum.Dampf:
                    serializer.Serialize(writer, "DAMPF");
                    return;
                case MediumEnum.Gas:
                    serializer.Serialize(writer, "GAS");
                    return;
                case MediumEnum.Strom:
                    serializer.Serialize(writer, "STROM");
                    return;
                case MediumEnum.Wasser:
                    serializer.Serialize(writer, "WASSER");
                    return;
            }
            throw new Exception("Cannot marshal type MediumEnum");
        }

        public static readonly MediumEnumConverter Singleton = new MediumEnumConverter();
    }
}
