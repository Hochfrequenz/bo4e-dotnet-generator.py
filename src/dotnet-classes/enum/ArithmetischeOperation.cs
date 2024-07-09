// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var arithmetischeOperation = ArithmetischeOperation.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Mit dieser Aufzählung können arithmetische Operationen festgelegt werden.
    /// </summary>
    public enum ArithmetischeOperationEnum { Addition, Division, Multiplikation, Subtraktion };

    public class ArithmetischeOperation
    {
        public static ArithmetischeOperationEnum FromJson(string json) => JsonConvert.DeserializeObject<ArithmetischeOperationEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ArithmetischeOperationEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ArithmetischeOperationEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ArithmetischeOperationEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ArithmetischeOperationEnum) || t == typeof(ArithmetischeOperationEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ADDITION":
                    return ArithmetischeOperationEnum.Addition;
                case "DIVISION":
                    return ArithmetischeOperationEnum.Division;
                case "MULTIPLIKATION":
                    return ArithmetischeOperationEnum.Multiplikation;
                case "SUBTRAKTION":
                    return ArithmetischeOperationEnum.Subtraktion;
            }
            throw new Exception("Cannot unmarshal type ArithmetischeOperationEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ArithmetischeOperationEnum)untypedValue;
            switch (value)
            {
                case ArithmetischeOperationEnum.Addition:
                    serializer.Serialize(writer, "ADDITION");
                    return;
                case ArithmetischeOperationEnum.Division:
                    serializer.Serialize(writer, "DIVISION");
                    return;
                case ArithmetischeOperationEnum.Multiplikation:
                    serializer.Serialize(writer, "MULTIPLIKATION");
                    return;
                case ArithmetischeOperationEnum.Subtraktion:
                    serializer.Serialize(writer, "SUBTRAKTION");
                    return;
            }
            throw new Exception("Cannot marshal type ArithmetischeOperationEnum");
        }

        public static readonly ArithmetischeOperationEnumConverter Singleton = new ArithmetischeOperationEnumConverter();
    }
}
