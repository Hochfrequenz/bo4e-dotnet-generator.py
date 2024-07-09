// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var konzessionsabgabe = Konzessionsabgabe.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Diese Komponente wird zur Übertagung der Details zu einer Konzessionsabgabe verwendet.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/Konzessionsabgabe.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Konzessionsabgabe JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/Konzessionsabgabe.json>`_
    /// </summary>
    public partial class Konzessionsabgabe
    {
        /// <summary>
        /// zusatz_attribute: Optional[list["ZusatzAttribut"]] = None
        ///
        /// # pylint: disable=duplicate-code
        /// model_config = ConfigDict(
        /// alias_generator=camelize,
        /// populate_by_name=True,
        /// extra="allow",
        /// # json_encoders is deprecated, but there is no easy-to-use alternative. The best way
        /// would be to create
        /// # an annotated version of Decimal, but you would have to use it everywhere in the
        /// pydantic models.
        /// # See this issue for more info: https://github.com/pydantic/pydantic/issues/6375
        /// json_encoders={Decimal: str},
        /// )
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// Version der BO-Struktur aka "fachliche Versionierung"
        /// </summary>
        [JsonProperty("_version")]
        public string Version { get; set; }

        /// <summary>
        /// Gebührenkategorie der Konzessionsabgabe
        /// </summary>
        [JsonProperty("kategorie")]
        public string Kategorie { get; set; }

        /// <summary>
        /// Konzessionsabgabe in E/kWh
        /// </summary>
        [JsonProperty("kosten")]
        public double? Kosten { get; set; }

        /// <summary>
        /// Art der Abgabe
        /// </summary>
        [JsonProperty("satz")]
        public AbgabeArt? Satz { get; set; }

        [JsonProperty("zusatzAttribute")]
        public ZusatzAttribut[] ZusatzAttribute { get; set; }
    }

    /// <summary>
    /// Viele Datenobjekte weisen in unterschiedlichen Systemen eine eindeutige ID (Kundennummer,
    /// GP-Nummer etc.) auf.
    /// Beim Austausch von Datenobjekten zwischen verschiedenen Systemen ist es daher hilfreich,
    /// sich die eindeutigen IDs der anzubindenden Systeme zu merken.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/ZusatzAttribut.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `ZusatzAttribut JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/ZusatzAttribut.json>`_
    /// </summary>
    public partial class ZusatzAttribut
    {
        /// <summary>
        /// Bezeichnung der externen Referenz (z.B. "microservice xyz" oder "SAP CRM GP-Nummer")
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Bezeichnung der externen Referenz (z.B. "microservice xyz" oder "SAP CRM GP-Nummer")
        /// </summary>
        [JsonProperty("wert")]
        public object Wert { get; set; }
    }

    /// <summary>
    /// Art der Konzessionsabgabe
    /// </summary>
    public enum AbgabeArt { Kas, Sa, Sas, Ta, Tas, Tk, Tks, Ts, Tss };

    public partial class Konzessionsabgabe
    {
        public static Konzessionsabgabe FromJson(string json) => JsonConvert.DeserializeObject<Konzessionsabgabe>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Konzessionsabgabe self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AbgabeArtConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AbgabeArtConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AbgabeArt) || t == typeof(AbgabeArt?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "KAS":
                    return AbgabeArt.Kas;
                case "SA":
                    return AbgabeArt.Sa;
                case "SAS":
                    return AbgabeArt.Sas;
                case "TA":
                    return AbgabeArt.Ta;
                case "TAS":
                    return AbgabeArt.Tas;
                case "TK":
                    return AbgabeArt.Tk;
                case "TKS":
                    return AbgabeArt.Tks;
                case "TS":
                    return AbgabeArt.Ts;
                case "TSS":
                    return AbgabeArt.Tss;
            }
            throw new Exception("Cannot unmarshal type AbgabeArt");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AbgabeArt)untypedValue;
            switch (value)
            {
                case AbgabeArt.Kas:
                    serializer.Serialize(writer, "KAS");
                    return;
                case AbgabeArt.Sa:
                    serializer.Serialize(writer, "SA");
                    return;
                case AbgabeArt.Sas:
                    serializer.Serialize(writer, "SAS");
                    return;
                case AbgabeArt.Ta:
                    serializer.Serialize(writer, "TA");
                    return;
                case AbgabeArt.Tas:
                    serializer.Serialize(writer, "TAS");
                    return;
                case AbgabeArt.Tk:
                    serializer.Serialize(writer, "TK");
                    return;
                case AbgabeArt.Tks:
                    serializer.Serialize(writer, "TKS");
                    return;
                case AbgabeArt.Ts:
                    serializer.Serialize(writer, "TS");
                    return;
                case AbgabeArt.Tss:
                    serializer.Serialize(writer, "TSS");
                    return;
            }
            throw new Exception("Cannot marshal type AbgabeArt");
        }

        public static readonly AbgabeArtConverter Singleton = new AbgabeArtConverter();
    }
}
