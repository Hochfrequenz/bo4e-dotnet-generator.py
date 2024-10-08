// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var regionaleGueltigkeit = RegionaleGueltigkeit.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Mit dieser Komponente können regionale Gültigkeiten, z.B. für Tarife, Zu- und Abschläge
    /// und Preise definiert werden.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/RegionaleGueltigkeit.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `RegionaleGueltigkeit JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/RegionaleGueltigkeit.json>`_
    /// </summary>
    public partial class RegionaleGueltigkeit
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
        /// Unterscheidung ob Positivliste oder Negativliste übertragen wird
        /// </summary>
        [JsonProperty("gueltigkeitstyp")]
        public Gueltigkeitstyp? Gueltigkeitstyp { get; set; }

        /// <summary>
        /// Hier stehen die Kriterien, die die regionale Gültigkeit festlegen
        /// </summary>
        [JsonProperty("kriteriumsWerte")]
        public KriteriumWert[] KriteriumsWerte { get; set; }

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



    public partial class RegionaleGueltigkeit
    {
        public static RegionaleGueltigkeit FromJson(string json) => JsonConvert.DeserializeObject<RegionaleGueltigkeit>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RegionaleGueltigkeit self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                GueltigkeitstypConverter.Singleton,
                TarifregionskriteriumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class GueltigkeitstypConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Gueltigkeitstyp) || t == typeof(Gueltigkeitstyp?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "NICHT_IN":
                    return Gueltigkeitstyp.NichtIn;
                case "NUR_IN":
                    return Gueltigkeitstyp.NurIn;
                case "NUR_IN_KOMBINATION_MIT":
                    return Gueltigkeitstyp.NurInKombinationMit;
            }
            throw new Exception("Cannot unmarshal type Gueltigkeitstyp");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Gueltigkeitstyp)untypedValue;
            switch (value)
            {
                case Gueltigkeitstyp.NichtIn:
                    serializer.Serialize(writer, "NICHT_IN");
                    return;
                case Gueltigkeitstyp.NurIn:
                    serializer.Serialize(writer, "NUR_IN");
                    return;
                case Gueltigkeitstyp.NurInKombinationMit:
                    serializer.Serialize(writer, "NUR_IN_KOMBINATION_MIT");
                    return;
            }
            throw new Exception("Cannot marshal type Gueltigkeitstyp");
        }

        public static readonly GueltigkeitstypConverter Singleton = new GueltigkeitstypConverter();
    }

    internal class TarifregionskriteriumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Tarifregionskriterium) || t == typeof(Tarifregionskriterium?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "GRUNDVERSORGER_NUMMER":
                    return Tarifregionskriterium.GrundversorgerNummer;
                case "NETZ_NUMMER":
                    return Tarifregionskriterium.NetzNummer;
                case "ORT":
                    return Tarifregionskriterium.Ort;
                case "POSTLEITZAHL":
                    return Tarifregionskriterium.Postleitzahl;
                case "REGION":
                    return Tarifregionskriterium.Region;
            }
            throw new Exception("Cannot unmarshal type Tarifregionskriterium");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Tarifregionskriterium)untypedValue;
            switch (value)
            {
                case Tarifregionskriterium.GrundversorgerNummer:
                    serializer.Serialize(writer, "GRUNDVERSORGER_NUMMER");
                    return;
                case Tarifregionskriterium.NetzNummer:
                    serializer.Serialize(writer, "NETZ_NUMMER");
                    return;
                case Tarifregionskriterium.Ort:
                    serializer.Serialize(writer, "ORT");
                    return;
                case Tarifregionskriterium.Postleitzahl:
                    serializer.Serialize(writer, "POSTLEITZAHL");
                    return;
                case Tarifregionskriterium.Region:
                    serializer.Serialize(writer, "REGION");
                    return;
            }
            throw new Exception("Cannot marshal type Tarifregionskriterium");
        }

        public static readonly TarifregionskriteriumConverter Singleton = new TarifregionskriteriumConverter();
    }
}
