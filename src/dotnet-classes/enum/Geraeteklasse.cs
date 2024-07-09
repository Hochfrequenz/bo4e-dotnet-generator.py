// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var geraeteklasse = Geraeteklasse.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Auflistung möglicher übergreifenden Geräteklassen.
    /// </summary>
    public enum GeraeteklasseEnum { Kommunikationseinrichtung, Mengenumwerter, SmartmeterGateway, Steuerbox, TechnischeSteuereinrichtung, Wandler, Zaehleinrichtung };

    public class Geraeteklasse
    {
        public static GeraeteklasseEnum FromJson(string json) => JsonConvert.DeserializeObject<GeraeteklasseEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GeraeteklasseEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                GeraeteklasseEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class GeraeteklasseEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GeraeteklasseEnum) || t == typeof(GeraeteklasseEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "KOMMUNIKATIONSEINRICHTUNG":
                    return GeraeteklasseEnum.Kommunikationseinrichtung;
                case "MENGENUMWERTER":
                    return GeraeteklasseEnum.Mengenumwerter;
                case "SMARTMETER_GATEWAY":
                    return GeraeteklasseEnum.SmartmeterGateway;
                case "STEUERBOX":
                    return GeraeteklasseEnum.Steuerbox;
                case "TECHNISCHE_STEUEREINRICHTUNG":
                    return GeraeteklasseEnum.TechnischeSteuereinrichtung;
                case "WANDLER":
                    return GeraeteklasseEnum.Wandler;
                case "ZAEHLEINRICHTUNG":
                    return GeraeteklasseEnum.Zaehleinrichtung;
            }
            throw new Exception("Cannot unmarshal type GeraeteklasseEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GeraeteklasseEnum)untypedValue;
            switch (value)
            {
                case GeraeteklasseEnum.Kommunikationseinrichtung:
                    serializer.Serialize(writer, "KOMMUNIKATIONSEINRICHTUNG");
                    return;
                case GeraeteklasseEnum.Mengenumwerter:
                    serializer.Serialize(writer, "MENGENUMWERTER");
                    return;
                case GeraeteklasseEnum.SmartmeterGateway:
                    serializer.Serialize(writer, "SMARTMETER_GATEWAY");
                    return;
                case GeraeteklasseEnum.Steuerbox:
                    serializer.Serialize(writer, "STEUERBOX");
                    return;
                case GeraeteklasseEnum.TechnischeSteuereinrichtung:
                    serializer.Serialize(writer, "TECHNISCHE_STEUEREINRICHTUNG");
                    return;
                case GeraeteklasseEnum.Wandler:
                    serializer.Serialize(writer, "WANDLER");
                    return;
                case GeraeteklasseEnum.Zaehleinrichtung:
                    serializer.Serialize(writer, "ZAEHLEINRICHTUNG");
                    return;
            }
            throw new Exception("Cannot marshal type GeraeteklasseEnum");
        }

        public static readonly GeraeteklasseEnumConverter Singleton = new GeraeteklasseEnumConverter();
    }
}