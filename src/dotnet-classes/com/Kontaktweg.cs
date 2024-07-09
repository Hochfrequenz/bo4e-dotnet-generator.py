// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var kontaktweg = Kontaktweg.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Die Komponente wird dazu verwendet, die Kontaktwege innerhalb des BOs Person
    /// darzustellen
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/Kontakt.svg" type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Kontakt JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/Kontakt.json>`_
    /// </summary>
    public partial class Kontaktweg
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
        /// Spezifikation, beispielsweise "Durchwahl", "Sammelnummer" etc.
        /// </summary>
        [JsonProperty("beschreibung")]
        public string Beschreibung { get; set; }

        /// <summary>
        /// Gibt an, ob es sich um den bevorzugten Kontaktweg handelt.
        /// </summary>
        [JsonProperty("istBevorzugterKontaktweg")]
        public bool? IstBevorzugterKontaktweg { get; set; }

        /// <summary>
        /// Gibt die Kontaktart des Kontaktes an.
        /// </summary>
        [JsonProperty("kontaktart")]
        public Kontaktart? Kontaktart { get; set; }

        /// <summary>
        /// Die Nummer oder E-Mail-Adresse.
        /// </summary>
        [JsonProperty("kontaktwert")]
        public string Kontaktwert { get; set; }

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
    /// Gibt an, auf welchem Weg die Person oder der Geschäftspartner kontaktiert werden kann.
    /// </summary>
    public enum Kontaktart { EMail, Fax, Postweg, Sms, Telefon };

    public partial class Kontaktweg
    {
        public static Kontaktweg FromJson(string json) => JsonConvert.DeserializeObject<Kontaktweg>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Kontaktweg self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                KontaktartConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class KontaktartConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Kontaktart) || t == typeof(Kontaktart?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "E_MAIL":
                    return Kontaktart.EMail;
                case "FAX":
                    return Kontaktart.Fax;
                case "POSTWEG":
                    return Kontaktart.Postweg;
                case "SMS":
                    return Kontaktart.Sms;
                case "TELEFON":
                    return Kontaktart.Telefon;
            }
            throw new Exception("Cannot unmarshal type Kontaktart");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Kontaktart)untypedValue;
            switch (value)
            {
                case Kontaktart.EMail:
                    serializer.Serialize(writer, "E_MAIL");
                    return;
                case Kontaktart.Fax:
                    serializer.Serialize(writer, "FAX");
                    return;
                case Kontaktart.Postweg:
                    serializer.Serialize(writer, "POSTWEG");
                    return;
                case Kontaktart.Sms:
                    serializer.Serialize(writer, "SMS");
                    return;
                case Kontaktart.Telefon:
                    serializer.Serialize(writer, "TELEFON");
                    return;
            }
            throw new Exception("Cannot marshal type Kontaktart");
        }

        public static readonly KontaktartConverter Singleton = new KontaktartConverter();
    }
}