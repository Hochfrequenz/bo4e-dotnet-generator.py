// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var messwertstatus = Messwertstatus.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Der Status eines Zählerstandes
    /// </summary>
    public enum MesswertstatusEnum { Abgelesen, AngabeFuerLieferschein, Energiemengesummiert, Ersatzwert, Fehlt, NichtVerwendbar, Prognosewert, Vorlaeufigerwert, Vorschlagswert };

    public class Messwertstatus
    {
        public static MesswertstatusEnum FromJson(string json) => JsonConvert.DeserializeObject<MesswertstatusEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MesswertstatusEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MesswertstatusEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class MesswertstatusEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MesswertstatusEnum) || t == typeof(MesswertstatusEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ABGELESEN":
                    return MesswertstatusEnum.Abgelesen;
                case "ANGABE_FUER_LIEFERSCHEIN":
                    return MesswertstatusEnum.AngabeFuerLieferschein;
                case "ENERGIEMENGESUMMIERT":
                    return MesswertstatusEnum.Energiemengesummiert;
                case "ERSATZWERT":
                    return MesswertstatusEnum.Ersatzwert;
                case "FEHLT":
                    return MesswertstatusEnum.Fehlt;
                case "NICHT_VERWENDBAR":
                    return MesswertstatusEnum.NichtVerwendbar;
                case "PROGNOSEWERT":
                    return MesswertstatusEnum.Prognosewert;
                case "VORLAEUFIGERWERT":
                    return MesswertstatusEnum.Vorlaeufigerwert;
                case "VORSCHLAGSWERT":
                    return MesswertstatusEnum.Vorschlagswert;
            }
            throw new Exception("Cannot unmarshal type MesswertstatusEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MesswertstatusEnum)untypedValue;
            switch (value)
            {
                case MesswertstatusEnum.Abgelesen:
                    serializer.Serialize(writer, "ABGELESEN");
                    return;
                case MesswertstatusEnum.AngabeFuerLieferschein:
                    serializer.Serialize(writer, "ANGABE_FUER_LIEFERSCHEIN");
                    return;
                case MesswertstatusEnum.Energiemengesummiert:
                    serializer.Serialize(writer, "ENERGIEMENGESUMMIERT");
                    return;
                case MesswertstatusEnum.Ersatzwert:
                    serializer.Serialize(writer, "ERSATZWERT");
                    return;
                case MesswertstatusEnum.Fehlt:
                    serializer.Serialize(writer, "FEHLT");
                    return;
                case MesswertstatusEnum.NichtVerwendbar:
                    serializer.Serialize(writer, "NICHT_VERWENDBAR");
                    return;
                case MesswertstatusEnum.Prognosewert:
                    serializer.Serialize(writer, "PROGNOSEWERT");
                    return;
                case MesswertstatusEnum.Vorlaeufigerwert:
                    serializer.Serialize(writer, "VORLAEUFIGERWERT");
                    return;
                case MesswertstatusEnum.Vorschlagswert:
                    serializer.Serialize(writer, "VORSCHLAGSWERT");
                    return;
            }
            throw new Exception("Cannot marshal type MesswertstatusEnum");
        }

        public static readonly MesswertstatusEnumConverter Singleton = new MesswertstatusEnumConverter();
    }
}
