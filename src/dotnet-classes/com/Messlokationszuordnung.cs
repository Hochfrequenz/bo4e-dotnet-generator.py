// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var messlokationszuordnung = Messlokationszuordnung.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Mit dieser Komponente werden Messlokationen zu Marktlokationen zugeordnet.
    /// Dabei kann eine arithmetische Operation (Addition, Subtraktion, Multiplikation, Division)
    /// angegeben werden,
    /// mit der die Messlokation zum Verbrauch der Marktlokation beiträgt.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/Messlokationszuordnung.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Messlokationszuordnung JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/Messlokationszuordnung.json>`_
    /// </summary>
    public partial class Messlokationszuordnung
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

        [JsonProperty("arithmetik")]
        public ArithmetischeOperation? Arithmetik { get; set; }

        /// <summary>
        /// exklusives Endedatum
        /// </summary>
        [JsonProperty("gueltigBis")]
        public DateTimeOffset? GueltigBis { get; set; }

        /// <summary>
        /// gueltig_bis: Optional[pydantic.AwareDatetime] = None
        /// </summary>
        [JsonProperty("gueltigSeit")]
        public DateTimeOffset? GueltigSeit { get; set; }

        /// <summary>
        /// arithmetik: Optional["ArithmetischeOperation"] = None
        ///
        /// gueltig_seit: Optional[pydantic.AwareDatetime] = None
        /// </summary>
        [JsonProperty("messlokationsId")]
        public string MesslokationsId { get; set; }

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
    /// Mit dieser Aufzählung können arithmetische Operationen festgelegt werden.
    /// </summary>
    public enum ArithmetischeOperation { Addition, Division, Multiplikation, Subtraktion };

    public partial class Messlokationszuordnung
    {
        public static Messlokationszuordnung FromJson(string json) => JsonConvert.DeserializeObject<Messlokationszuordnung>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Messlokationszuordnung self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ArithmetischeOperationConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ArithmetischeOperationConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ArithmetischeOperation) || t == typeof(ArithmetischeOperation?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ADDITION":
                    return ArithmetischeOperation.Addition;
                case "DIVISION":
                    return ArithmetischeOperation.Division;
                case "MULTIPLIKATION":
                    return ArithmetischeOperation.Multiplikation;
                case "SUBTRAKTION":
                    return ArithmetischeOperation.Subtraktion;
            }
            throw new Exception("Cannot unmarshal type ArithmetischeOperation");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ArithmetischeOperation)untypedValue;
            switch (value)
            {
                case ArithmetischeOperation.Addition:
                    serializer.Serialize(writer, "ADDITION");
                    return;
                case ArithmetischeOperation.Division:
                    serializer.Serialize(writer, "DIVISION");
                    return;
                case ArithmetischeOperation.Multiplikation:
                    serializer.Serialize(writer, "MULTIPLIKATION");
                    return;
                case ArithmetischeOperation.Subtraktion:
                    serializer.Serialize(writer, "SUBTRAKTION");
                    return;
            }
            throw new Exception("Cannot marshal type ArithmetischeOperation");
        }

        public static readonly ArithmetischeOperationConverter Singleton = new ArithmetischeOperationConverter();
    }
}