// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var gebiettyp = Gebiettyp.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// List of possible Gebiettypen.
    /// </summary>
    public enum GebiettypEnum { Arealnetz, Bilanzierungsgebiet, Grundversorgungsgebiet, Marktgebiet, Regelzone, Regionalnetz, Transportnetz, Versorgungsgebiet, Verteilnetz };

    public class Gebiettyp
    {
        public static GebiettypEnum FromJson(string json) => JsonConvert.DeserializeObject<GebiettypEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GebiettypEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                GebiettypEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class GebiettypEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(GebiettypEnum) || t == typeof(GebiettypEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AREALNETZ":
                    return GebiettypEnum.Arealnetz;
                case "BILANZIERUNGSGEBIET":
                    return GebiettypEnum.Bilanzierungsgebiet;
                case "GRUNDVERSORGUNGSGEBIET":
                    return GebiettypEnum.Grundversorgungsgebiet;
                case "MARKTGEBIET":
                    return GebiettypEnum.Marktgebiet;
                case "REGELZONE":
                    return GebiettypEnum.Regelzone;
                case "REGIONALNETZ":
                    return GebiettypEnum.Regionalnetz;
                case "TRANSPORTNETZ":
                    return GebiettypEnum.Transportnetz;
                case "VERSORGUNGSGEBIET":
                    return GebiettypEnum.Versorgungsgebiet;
                case "VERTEILNETZ":
                    return GebiettypEnum.Verteilnetz;
            }
            throw new Exception("Cannot unmarshal type GebiettypEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GebiettypEnum)untypedValue;
            switch (value)
            {
                case GebiettypEnum.Arealnetz:
                    serializer.Serialize(writer, "AREALNETZ");
                    return;
                case GebiettypEnum.Bilanzierungsgebiet:
                    serializer.Serialize(writer, "BILANZIERUNGSGEBIET");
                    return;
                case GebiettypEnum.Grundversorgungsgebiet:
                    serializer.Serialize(writer, "GRUNDVERSORGUNGSGEBIET");
                    return;
                case GebiettypEnum.Marktgebiet:
                    serializer.Serialize(writer, "MARKTGEBIET");
                    return;
                case GebiettypEnum.Regelzone:
                    serializer.Serialize(writer, "REGELZONE");
                    return;
                case GebiettypEnum.Regionalnetz:
                    serializer.Serialize(writer, "REGIONALNETZ");
                    return;
                case GebiettypEnum.Transportnetz:
                    serializer.Serialize(writer, "TRANSPORTNETZ");
                    return;
                case GebiettypEnum.Versorgungsgebiet:
                    serializer.Serialize(writer, "VERSORGUNGSGEBIET");
                    return;
                case GebiettypEnum.Verteilnetz:
                    serializer.Serialize(writer, "VERTEILNETZ");
                    return;
            }
            throw new Exception("Cannot marshal type GebiettypEnum");
        }

        public static readonly GebiettypEnumConverter Singleton = new GebiettypEnumConverter();
    }
}