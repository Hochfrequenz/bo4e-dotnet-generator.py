// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var vertragsart = Vertragsart.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Aufzählung der Vertragsarten.
    /// </summary>
    public enum VertragsartEnum { Bilanzierungsvertrag, Buendelvertrag, Energieliefervertrag, Messstellenbetriebsvertrag, Netznutzungsvertrag };

    public class Vertragsart
    {
        public static VertragsartEnum FromJson(string json) => JsonConvert.DeserializeObject<VertragsartEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this VertragsartEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                VertragsartEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class VertragsartEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(VertragsartEnum) || t == typeof(VertragsartEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BILANZIERUNGSVERTRAG":
                    return VertragsartEnum.Bilanzierungsvertrag;
                case "BUENDELVERTRAG":
                    return VertragsartEnum.Buendelvertrag;
                case "ENERGIELIEFERVERTRAG":
                    return VertragsartEnum.Energieliefervertrag;
                case "MESSSTELLENBETRIEBSVERTRAG":
                    return VertragsartEnum.Messstellenbetriebsvertrag;
                case "NETZNUTZUNGSVERTRAG":
                    return VertragsartEnum.Netznutzungsvertrag;
            }
            throw new Exception("Cannot unmarshal type VertragsartEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (VertragsartEnum)untypedValue;
            switch (value)
            {
                case VertragsartEnum.Bilanzierungsvertrag:
                    serializer.Serialize(writer, "BILANZIERUNGSVERTRAG");
                    return;
                case VertragsartEnum.Buendelvertrag:
                    serializer.Serialize(writer, "BUENDELVERTRAG");
                    return;
                case VertragsartEnum.Energieliefervertrag:
                    serializer.Serialize(writer, "ENERGIELIEFERVERTRAG");
                    return;
                case VertragsartEnum.Messstellenbetriebsvertrag:
                    serializer.Serialize(writer, "MESSSTELLENBETRIEBSVERTRAG");
                    return;
                case VertragsartEnum.Netznutzungsvertrag:
                    serializer.Serialize(writer, "NETZNUTZUNGSVERTRAG");
                    return;
            }
            throw new Exception("Cannot marshal type VertragsartEnum");
        }

        public static readonly VertragsartEnumConverter Singleton = new VertragsartEnumConverter();
    }
}
