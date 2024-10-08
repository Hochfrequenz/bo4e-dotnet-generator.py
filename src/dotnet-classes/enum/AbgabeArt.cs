// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var abgabeArt = AbgabeArt.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Art der Konzessionsabgabe
    /// </summary>
    public enum AbgabeArtEnum { Kas, Sa, Sas, Ta, Tas, Tk, Tks, Ts, Tss };

    public class AbgabeArt
    {
        public static AbgabeArtEnum FromJson(string json) => JsonConvert.DeserializeObject<AbgabeArtEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this AbgabeArtEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AbgabeArtEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AbgabeArtEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AbgabeArtEnum) || t == typeof(AbgabeArtEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "KAS":
                    return AbgabeArtEnum.Kas;
                case "SA":
                    return AbgabeArtEnum.Sa;
                case "SAS":
                    return AbgabeArtEnum.Sas;
                case "TA":
                    return AbgabeArtEnum.Ta;
                case "TAS":
                    return AbgabeArtEnum.Tas;
                case "TK":
                    return AbgabeArtEnum.Tk;
                case "TKS":
                    return AbgabeArtEnum.Tks;
                case "TS":
                    return AbgabeArtEnum.Ts;
                case "TSS":
                    return AbgabeArtEnum.Tss;
            }
            throw new Exception("Cannot unmarshal type AbgabeArtEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AbgabeArtEnum)untypedValue;
            switch (value)
            {
                case AbgabeArtEnum.Kas:
                    serializer.Serialize(writer, "KAS");
                    return;
                case AbgabeArtEnum.Sa:
                    serializer.Serialize(writer, "SA");
                    return;
                case AbgabeArtEnum.Sas:
                    serializer.Serialize(writer, "SAS");
                    return;
                case AbgabeArtEnum.Ta:
                    serializer.Serialize(writer, "TA");
                    return;
                case AbgabeArtEnum.Tas:
                    serializer.Serialize(writer, "TAS");
                    return;
                case AbgabeArtEnum.Tk:
                    serializer.Serialize(writer, "TK");
                    return;
                case AbgabeArtEnum.Tks:
                    serializer.Serialize(writer, "TKS");
                    return;
                case AbgabeArtEnum.Ts:
                    serializer.Serialize(writer, "TS");
                    return;
                case AbgabeArtEnum.Tss:
                    serializer.Serialize(writer, "TSS");
                    return;
            }
            throw new Exception("Cannot marshal type AbgabeArtEnum");
        }

        public static readonly AbgabeArtEnumConverter Singleton = new AbgabeArtEnumConverter();
    }
}
