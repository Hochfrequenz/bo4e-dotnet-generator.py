// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var messgroesse = Messgroesse.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Gibt die physikalische Größe an, die gemessen wurde.
    /// </summary>
    public enum MessgroesseEnum { Blindleistung, Brennwert, Druck, Gradtzagszahlen, Lastgang, Lastprofil, Preise, Spannung, Strom, Temperatur, Volumenstrom, Wirkleistung, Zzahl };

    public class Messgroesse
    {
        public static MessgroesseEnum FromJson(string json) => JsonConvert.DeserializeObject<MessgroesseEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MessgroesseEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MessgroesseEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class MessgroesseEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MessgroesseEnum) || t == typeof(MessgroesseEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BLINDLEISTUNG":
                    return MessgroesseEnum.Blindleistung;
                case "BRENNWERT":
                    return MessgroesseEnum.Brennwert;
                case "DRUCK":
                    return MessgroesseEnum.Druck;
                case "GRADTZAGSZAHLEN":
                    return MessgroesseEnum.Gradtzagszahlen;
                case "LASTGANG":
                    return MessgroesseEnum.Lastgang;
                case "LASTPROFIL":
                    return MessgroesseEnum.Lastprofil;
                case "PREISE":
                    return MessgroesseEnum.Preise;
                case "SPANNUNG":
                    return MessgroesseEnum.Spannung;
                case "STROM":
                    return MessgroesseEnum.Strom;
                case "TEMPERATUR":
                    return MessgroesseEnum.Temperatur;
                case "VOLUMENSTROM":
                    return MessgroesseEnum.Volumenstrom;
                case "WIRKLEISTUNG":
                    return MessgroesseEnum.Wirkleistung;
                case "ZZAHL":
                    return MessgroesseEnum.Zzahl;
            }
            throw new Exception("Cannot unmarshal type MessgroesseEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MessgroesseEnum)untypedValue;
            switch (value)
            {
                case MessgroesseEnum.Blindleistung:
                    serializer.Serialize(writer, "BLINDLEISTUNG");
                    return;
                case MessgroesseEnum.Brennwert:
                    serializer.Serialize(writer, "BRENNWERT");
                    return;
                case MessgroesseEnum.Druck:
                    serializer.Serialize(writer, "DRUCK");
                    return;
                case MessgroesseEnum.Gradtzagszahlen:
                    serializer.Serialize(writer, "GRADTZAGSZAHLEN");
                    return;
                case MessgroesseEnum.Lastgang:
                    serializer.Serialize(writer, "LASTGANG");
                    return;
                case MessgroesseEnum.Lastprofil:
                    serializer.Serialize(writer, "LASTPROFIL");
                    return;
                case MessgroesseEnum.Preise:
                    serializer.Serialize(writer, "PREISE");
                    return;
                case MessgroesseEnum.Spannung:
                    serializer.Serialize(writer, "SPANNUNG");
                    return;
                case MessgroesseEnum.Strom:
                    serializer.Serialize(writer, "STROM");
                    return;
                case MessgroesseEnum.Temperatur:
                    serializer.Serialize(writer, "TEMPERATUR");
                    return;
                case MessgroesseEnum.Volumenstrom:
                    serializer.Serialize(writer, "VOLUMENSTROM");
                    return;
                case MessgroesseEnum.Wirkleistung:
                    serializer.Serialize(writer, "WIRKLEISTUNG");
                    return;
                case MessgroesseEnum.Zzahl:
                    serializer.Serialize(writer, "ZZAHL");
                    return;
            }
            throw new Exception("Cannot marshal type MessgroesseEnum");
        }

        public static readonly MessgroesseEnumConverter Singleton = new MessgroesseEnumConverter();
    }
}
