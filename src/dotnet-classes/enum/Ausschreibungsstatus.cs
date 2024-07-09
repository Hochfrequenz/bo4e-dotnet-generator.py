// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var ausschreibungsstatus = Ausschreibungsstatus.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Bezeichnungen für die Ausschreibungsphasen
    /// </summary>
    public enum AusschreibungsstatusEnum { Phase1, Phase2, Phase3, Phase4 };

    public class Ausschreibungsstatus
    {
        public static AusschreibungsstatusEnum FromJson(string json) => JsonConvert.DeserializeObject<AusschreibungsstatusEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AusschreibungsstatusEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AusschreibungsstatusEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AusschreibungsstatusEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AusschreibungsstatusEnum) || t == typeof(AusschreibungsstatusEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "PHASE1":
                    return AusschreibungsstatusEnum.Phase1;
                case "PHASE2":
                    return AusschreibungsstatusEnum.Phase2;
                case "PHASE3":
                    return AusschreibungsstatusEnum.Phase3;
                case "PHASE4":
                    return AusschreibungsstatusEnum.Phase4;
            }
            throw new Exception("Cannot unmarshal type AusschreibungsstatusEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AusschreibungsstatusEnum)untypedValue;
            switch (value)
            {
                case AusschreibungsstatusEnum.Phase1:
                    serializer.Serialize(writer, "PHASE1");
                    return;
                case AusschreibungsstatusEnum.Phase2:
                    serializer.Serialize(writer, "PHASE2");
                    return;
                case AusschreibungsstatusEnum.Phase3:
                    serializer.Serialize(writer, "PHASE3");
                    return;
                case AusschreibungsstatusEnum.Phase4:
                    serializer.Serialize(writer, "PHASE4");
                    return;
            }
            throw new Exception("Cannot marshal type AusschreibungsstatusEnum");
        }

        public static readonly AusschreibungsstatusEnumConverter Singleton = new AusschreibungsstatusEnumConverter();
    }
}