// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var angebotsstatus = Angebotsstatus.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Gibt den Status eines Angebotes an.
    /// </summary>
    public enum AngebotsstatusEnum { Abgelehnt, Ausstehend, Beauftragt, Erledigt, Konzeption, Nachgefasst, Ungueltig, Unverbindlich, Verbindlich };

    public class Angebotsstatus
    {
        public static AngebotsstatusEnum FromJson(string json) => JsonConvert.DeserializeObject<AngebotsstatusEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AngebotsstatusEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AngebotsstatusEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AngebotsstatusEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AngebotsstatusEnum) || t == typeof(AngebotsstatusEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ABGELEHNT":
                    return AngebotsstatusEnum.Abgelehnt;
                case "AUSSTEHEND":
                    return AngebotsstatusEnum.Ausstehend;
                case "BEAUFTRAGT":
                    return AngebotsstatusEnum.Beauftragt;
                case "ERLEDIGT":
                    return AngebotsstatusEnum.Erledigt;
                case "KONZEPTION":
                    return AngebotsstatusEnum.Konzeption;
                case "NACHGEFASST":
                    return AngebotsstatusEnum.Nachgefasst;
                case "UNGUELTIG":
                    return AngebotsstatusEnum.Ungueltig;
                case "UNVERBINDLICH":
                    return AngebotsstatusEnum.Unverbindlich;
                case "VERBINDLICH":
                    return AngebotsstatusEnum.Verbindlich;
            }
            throw new Exception("Cannot unmarshal type AngebotsstatusEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AngebotsstatusEnum)untypedValue;
            switch (value)
            {
                case AngebotsstatusEnum.Abgelehnt:
                    serializer.Serialize(writer, "ABGELEHNT");
                    return;
                case AngebotsstatusEnum.Ausstehend:
                    serializer.Serialize(writer, "AUSSTEHEND");
                    return;
                case AngebotsstatusEnum.Beauftragt:
                    serializer.Serialize(writer, "BEAUFTRAGT");
                    return;
                case AngebotsstatusEnum.Erledigt:
                    serializer.Serialize(writer, "ERLEDIGT");
                    return;
                case AngebotsstatusEnum.Konzeption:
                    serializer.Serialize(writer, "KONZEPTION");
                    return;
                case AngebotsstatusEnum.Nachgefasst:
                    serializer.Serialize(writer, "NACHGEFASST");
                    return;
                case AngebotsstatusEnum.Ungueltig:
                    serializer.Serialize(writer, "UNGUELTIG");
                    return;
                case AngebotsstatusEnum.Unverbindlich:
                    serializer.Serialize(writer, "UNVERBINDLICH");
                    return;
                case AngebotsstatusEnum.Verbindlich:
                    serializer.Serialize(writer, "VERBINDLICH");
                    return;
            }
            throw new Exception("Cannot marshal type AngebotsstatusEnum");
        }

        public static readonly AngebotsstatusEnumConverter Singleton = new AngebotsstatusEnumConverter();
    }
}
