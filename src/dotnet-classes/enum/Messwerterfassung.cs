// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var messwerterfassung = Messwerterfassung.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Die Messwerterfassung des Zählers
    /// </summary>
    public enum MesswerterfassungEnum { Fernauslesbar, ManuellAusgelesene };

    public class Messwerterfassung
    {
        public static MesswerterfassungEnum FromJson(string json) => JsonConvert.DeserializeObject<MesswerterfassungEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MesswerterfassungEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MesswerterfassungEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class MesswerterfassungEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MesswerterfassungEnum) || t == typeof(MesswerterfassungEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "FERNAUSLESBAR":
                    return MesswerterfassungEnum.Fernauslesbar;
                case "MANUELL_AUSGELESENE":
                    return MesswerterfassungEnum.ManuellAusgelesene;
            }
            throw new Exception("Cannot unmarshal type MesswerterfassungEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MesswerterfassungEnum)untypedValue;
            switch (value)
            {
                case MesswerterfassungEnum.Fernauslesbar:
                    serializer.Serialize(writer, "FERNAUSLESBAR");
                    return;
                case MesswerterfassungEnum.ManuellAusgelesene:
                    serializer.Serialize(writer, "MANUELL_AUSGELESENE");
                    return;
            }
            throw new Exception("Cannot marshal type MesswerterfassungEnum");
        }

        public static readonly MesswerterfassungEnumConverter Singleton = new MesswerterfassungEnumConverter();
    }
}
