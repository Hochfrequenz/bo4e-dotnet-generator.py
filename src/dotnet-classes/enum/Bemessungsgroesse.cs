// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var bemessungsgroesse = Bemessungsgroesse.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Zur Abbildung von Messgrössen und zur Verwendung in energiewirtschaftlichen Berechnungen.
    /// </summary>
    public enum BemessungsgroesseEnum { Anzahl, Benutzungsdauer, BlindarbeitInd, BlindarbeitKap, BlindleistungInd, BlindleistungKap, LeistungEl, LeistungTh, Volumen, Volumenstrom, WirkarbeitEl, WirkarbeitTh };

    public class Bemessungsgroesse
    {
        public static BemessungsgroesseEnum FromJson(string json) => JsonConvert.DeserializeObject<BemessungsgroesseEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this BemessungsgroesseEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                BemessungsgroesseEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class BemessungsgroesseEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BemessungsgroesseEnum) || t == typeof(BemessungsgroesseEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ANZAHL":
                    return BemessungsgroesseEnum.Anzahl;
                case "BENUTZUNGSDAUER":
                    return BemessungsgroesseEnum.Benutzungsdauer;
                case "BLINDARBEIT_IND":
                    return BemessungsgroesseEnum.BlindarbeitInd;
                case "BLINDARBEIT_KAP":
                    return BemessungsgroesseEnum.BlindarbeitKap;
                case "BLINDLEISTUNG_IND":
                    return BemessungsgroesseEnum.BlindleistungInd;
                case "BLINDLEISTUNG_KAP":
                    return BemessungsgroesseEnum.BlindleistungKap;
                case "LEISTUNG_EL":
                    return BemessungsgroesseEnum.LeistungEl;
                case "LEISTUNG_TH":
                    return BemessungsgroesseEnum.LeistungTh;
                case "VOLUMEN":
                    return BemessungsgroesseEnum.Volumen;
                case "VOLUMENSTROM":
                    return BemessungsgroesseEnum.Volumenstrom;
                case "WIRKARBEIT_EL":
                    return BemessungsgroesseEnum.WirkarbeitEl;
                case "WIRKARBEIT_TH":
                    return BemessungsgroesseEnum.WirkarbeitTh;
            }
            throw new Exception("Cannot unmarshal type BemessungsgroesseEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BemessungsgroesseEnum)untypedValue;
            switch (value)
            {
                case BemessungsgroesseEnum.Anzahl:
                    serializer.Serialize(writer, "ANZAHL");
                    return;
                case BemessungsgroesseEnum.Benutzungsdauer:
                    serializer.Serialize(writer, "BENUTZUNGSDAUER");
                    return;
                case BemessungsgroesseEnum.BlindarbeitInd:
                    serializer.Serialize(writer, "BLINDARBEIT_IND");
                    return;
                case BemessungsgroesseEnum.BlindarbeitKap:
                    serializer.Serialize(writer, "BLINDARBEIT_KAP");
                    return;
                case BemessungsgroesseEnum.BlindleistungInd:
                    serializer.Serialize(writer, "BLINDLEISTUNG_IND");
                    return;
                case BemessungsgroesseEnum.BlindleistungKap:
                    serializer.Serialize(writer, "BLINDLEISTUNG_KAP");
                    return;
                case BemessungsgroesseEnum.LeistungEl:
                    serializer.Serialize(writer, "LEISTUNG_EL");
                    return;
                case BemessungsgroesseEnum.LeistungTh:
                    serializer.Serialize(writer, "LEISTUNG_TH");
                    return;
                case BemessungsgroesseEnum.Volumen:
                    serializer.Serialize(writer, "VOLUMEN");
                    return;
                case BemessungsgroesseEnum.Volumenstrom:
                    serializer.Serialize(writer, "VOLUMENSTROM");
                    return;
                case BemessungsgroesseEnum.WirkarbeitEl:
                    serializer.Serialize(writer, "WIRKARBEIT_EL");
                    return;
                case BemessungsgroesseEnum.WirkarbeitTh:
                    serializer.Serialize(writer, "WIRKARBEIT_TH");
                    return;
            }
            throw new Exception("Cannot marshal type BemessungsgroesseEnum");
        }

        public static readonly BemessungsgroesseEnumConverter Singleton = new BemessungsgroesseEnumConverter();
    }
}
