// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var tarifpreisstaffelProOrt = TarifpreisstaffelProOrt.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Gibt die Staffelgrenzen der jeweiligen Preise an
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/TarifpreisstaffelProOrt.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `TarifpreisstaffelProOrt JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/TarifpreisstaffelProOrt.json>`_
    /// </summary>
    public partial class TarifpreisstaffelProOrt
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
        /// Der Arbeitspreis in ct/kWh
        /// </summary>
        [JsonProperty("arbeitspreis")]
        public double? Arbeitspreis { get; set; }

        /// <summary>
        /// Der Arbeitspreis für Verbräuche in der Niedertarifzeit in ct/kWh
        /// </summary>
        [JsonProperty("arbeitspreisNT")]
        public double? ArbeitspreisNt { get; set; }

        /// <summary>
        /// Der Grundpreis in Euro/Jahr
        /// </summary>
        [JsonProperty("grundpreis")]
        public double? Grundpreis { get; set; }

        /// <summary>
        /// Oberer Wert, bis zu dem die Staffel gilt (exklusive)
        /// </summary>
        [JsonProperty("staffelgrenzeBis")]
        public double? StaffelgrenzeBis { get; set; }

        /// <summary>
        /// Unterer Wert, ab dem die Staffel gilt (inklusive)
        /// </summary>
        [JsonProperty("staffelgrenzeVon")]
        public double? StaffelgrenzeVon { get; set; }

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

    public partial class TarifpreisstaffelProOrt
    {
        public static TarifpreisstaffelProOrt FromJson(string json) => JsonConvert.DeserializeObject<TarifpreisstaffelProOrt>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this TarifpreisstaffelProOrt self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
