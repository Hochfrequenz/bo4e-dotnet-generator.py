// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var dienstleistung = Dienstleistung.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Abbildung einer abrechenbaren Dienstleistung.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/Dienstleistung.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Dienstleistung JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/Dienstleistung.json>`_
    /// </summary>
    public partial class Dienstleistung
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
        /// Bezeichnung der Dienstleistung
        /// </summary>
        [JsonProperty("bezeichnung")]
        public string Bezeichnung { get; set; }

        /// <summary>
        /// Kennzeichnung der Dienstleistung
        /// </summary>
        [JsonProperty("dienstleistungstyp")]
        public Dienstleistungstyp? Dienstleistungstyp { get; set; }

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


    public partial class Dienstleistung
    {
        public static Dienstleistung FromJson(string json) => JsonConvert.DeserializeObject<Dienstleistung>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Dienstleistung self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                DienstleistungstypConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DienstleistungstypConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Dienstleistungstyp) || t == typeof(Dienstleistungstyp?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ABLESUNG_HALBJAEHRLICH":
                    return Dienstleistungstyp.AblesungHalbjaehrlich;
                case "ABLESUNG_JAEHRLICH":
                    return Dienstleistungstyp.AblesungJaehrlich;
                case "ABLESUNG_MONATLICH":
                    return Dienstleistungstyp.AblesungMonatlich;
                case "ABLESUNG_VIERTELJAEHRLICH":
                    return Dienstleistungstyp.AblesungVierteljaehrlich;
                case "ABLESUNG_ZUSAETZLICH_KUNDE":
                    return Dienstleistungstyp.AblesungZusaetzlichKunde;
                case "ABLESUNG_ZUSAETZLICH_MSB":
                    return Dienstleistungstyp.AblesungZusaetzlichMsb;
                case "AUSLESUNG_2X_TAEGLICH_FERNAUSLESUNG":
                    return Dienstleistungstyp.Auslesung2XTaeglichFernauslesung;
                case "AUSLESUNG_FERNAUSLESUNG":
                    return Dienstleistungstyp.AuslesungFernauslesung;
                case "AUSLESUNG_FERNAUSLESUNG_ZUSAETZLICH_MSB":
                    return Dienstleistungstyp.AuslesungFernauslesungZusaetzlichMsb;
                case "AUSLESUNG_JAEHRLICH_FERNAUSLESUNG":
                    return Dienstleistungstyp.AuslesungJaehrlichFernauslesung;
                case "AUSLESUNG_KOMPAKTMENGENUMWERTER":
                    return Dienstleistungstyp.AuslesungKompaktmengenumwerter;
                case "AUSLESUNG_MANUELL_MSB":
                    return Dienstleistungstyp.AuslesungManuellMsb;
                case "AUSLESUNG_MDE":
                    return Dienstleistungstyp.AuslesungMde;
                case "AUSLESUNG_MOATLICH_FERNAUSLESUNG":
                    return Dienstleistungstyp.AuslesungMoatlichFernauslesung;
                case "AUSLESUNG_MONATLICH_FERNAUSLESUNG":
                    return Dienstleistungstyp.AuslesungMonatlichFernauslesung;
                case "AUSLESUNG_STUENDLICH_FERNAUSLESUNG":
                    return Dienstleistungstyp.AuslesungStuendlichFernauslesung;
                case "AUSLESUNG_SYSTEMMENGENUMWERTER":
                    return Dienstleistungstyp.AuslesungSystemmengenumwerter;
                case "AUSLESUNG_TAEGLICH_FERNAUSLESUNG":
                    return Dienstleistungstyp.AuslesungTaeglichFernauslesung;
                case "AUSLESUNG_TEMPERATURMENGENUMWERTER":
                    return Dienstleistungstyp.AuslesungTemperaturmengenumwerter;
                case "AUSLESUNG_VORGANG":
                    return Dienstleistungstyp.AuslesungVorgang;
                case "AUSLESUNG_ZUSTANDSMENGENUMWERTER":
                    return Dienstleistungstyp.AuslesungZustandsmengenumwerter;
                case "DATENBEREITSTELLUNG_EINMALIG":
                    return Dienstleistungstyp.DatenbereitstellungEinmalig;
                case "DATENBEREITSTELLUNG_HALBJAEHRLICH":
                    return Dienstleistungstyp.DatenbereitstellungHalbjaehrlich;
                case "DATENBEREITSTELLUNG_HISTORISCHE_LG":
                    return Dienstleistungstyp.DatenbereitstellungHistorischeLg;
                case "DATENBEREITSTELLUNG_JAEHRLICH":
                    return Dienstleistungstyp.DatenbereitstellungJaehrlich;
                case "DATENBEREITSTELLUNG_MONATLICH":
                    return Dienstleistungstyp.DatenbereitstellungMonatlich;
                case "DATENBEREITSTELLUNG_MONATLICH_ZUSAETZLICH":
                    return Dienstleistungstyp.DatenbereitstellungMonatlichZusaetzlich;
                case "DATENBEREITSTELLUNG_STUENDLICH":
                    return Dienstleistungstyp.DatenbereitstellungStuendlich;
                case "DATENBEREITSTELLUNG_TAEGLICH":
                    return Dienstleistungstyp.DatenbereitstellungTaeglich;
                case "DATENBEREITSTELLUNG_VIERTELJAEHRLICH":
                    return Dienstleistungstyp.DatenbereitstellungVierteljaehrlich;
                case "DATENBEREITSTELLUNG_WOECHENTLICH":
                    return Dienstleistungstyp.DatenbereitstellungWoechentlich;
                case "ENTSPERRUNG":
                    return Dienstleistungstyp.Entsperrung;
                case "INKASSOKOSTEN":
                    return Dienstleistungstyp.Inkassokosten;
                case "MAHNKOSTEN":
                    return Dienstleistungstyp.Mahnkosten;
                case "SPERRUNG":
                    return Dienstleistungstyp.Sperrung;
            }
            throw new Exception("Cannot unmarshal type Dienstleistungstyp");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Dienstleistungstyp)untypedValue;
            switch (value)
            {
                case Dienstleistungstyp.AblesungHalbjaehrlich:
                    serializer.Serialize(writer, "ABLESUNG_HALBJAEHRLICH");
                    return;
                case Dienstleistungstyp.AblesungJaehrlich:
                    serializer.Serialize(writer, "ABLESUNG_JAEHRLICH");
                    return;
                case Dienstleistungstyp.AblesungMonatlich:
                    serializer.Serialize(writer, "ABLESUNG_MONATLICH");
                    return;
                case Dienstleistungstyp.AblesungVierteljaehrlich:
                    serializer.Serialize(writer, "ABLESUNG_VIERTELJAEHRLICH");
                    return;
                case Dienstleistungstyp.AblesungZusaetzlichKunde:
                    serializer.Serialize(writer, "ABLESUNG_ZUSAETZLICH_KUNDE");
                    return;
                case Dienstleistungstyp.AblesungZusaetzlichMsb:
                    serializer.Serialize(writer, "ABLESUNG_ZUSAETZLICH_MSB");
                    return;
                case Dienstleistungstyp.Auslesung2XTaeglichFernauslesung:
                    serializer.Serialize(writer, "AUSLESUNG_2X_TAEGLICH_FERNAUSLESUNG");
                    return;
                case Dienstleistungstyp.AuslesungFernauslesung:
                    serializer.Serialize(writer, "AUSLESUNG_FERNAUSLESUNG");
                    return;
                case Dienstleistungstyp.AuslesungFernauslesungZusaetzlichMsb:
                    serializer.Serialize(writer, "AUSLESUNG_FERNAUSLESUNG_ZUSAETZLICH_MSB");
                    return;
                case Dienstleistungstyp.AuslesungJaehrlichFernauslesung:
                    serializer.Serialize(writer, "AUSLESUNG_JAEHRLICH_FERNAUSLESUNG");
                    return;
                case Dienstleistungstyp.AuslesungKompaktmengenumwerter:
                    serializer.Serialize(writer, "AUSLESUNG_KOMPAKTMENGENUMWERTER");
                    return;
                case Dienstleistungstyp.AuslesungManuellMsb:
                    serializer.Serialize(writer, "AUSLESUNG_MANUELL_MSB");
                    return;
                case Dienstleistungstyp.AuslesungMde:
                    serializer.Serialize(writer, "AUSLESUNG_MDE");
                    return;
                case Dienstleistungstyp.AuslesungMoatlichFernauslesung:
                    serializer.Serialize(writer, "AUSLESUNG_MOATLICH_FERNAUSLESUNG");
                    return;
                case Dienstleistungstyp.AuslesungMonatlichFernauslesung:
                    serializer.Serialize(writer, "AUSLESUNG_MONATLICH_FERNAUSLESUNG");
                    return;
                case Dienstleistungstyp.AuslesungStuendlichFernauslesung:
                    serializer.Serialize(writer, "AUSLESUNG_STUENDLICH_FERNAUSLESUNG");
                    return;
                case Dienstleistungstyp.AuslesungSystemmengenumwerter:
                    serializer.Serialize(writer, "AUSLESUNG_SYSTEMMENGENUMWERTER");
                    return;
                case Dienstleistungstyp.AuslesungTaeglichFernauslesung:
                    serializer.Serialize(writer, "AUSLESUNG_TAEGLICH_FERNAUSLESUNG");
                    return;
                case Dienstleistungstyp.AuslesungTemperaturmengenumwerter:
                    serializer.Serialize(writer, "AUSLESUNG_TEMPERATURMENGENUMWERTER");
                    return;
                case Dienstleistungstyp.AuslesungVorgang:
                    serializer.Serialize(writer, "AUSLESUNG_VORGANG");
                    return;
                case Dienstleistungstyp.AuslesungZustandsmengenumwerter:
                    serializer.Serialize(writer, "AUSLESUNG_ZUSTANDSMENGENUMWERTER");
                    return;
                case Dienstleistungstyp.DatenbereitstellungEinmalig:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_EINMALIG");
                    return;
                case Dienstleistungstyp.DatenbereitstellungHalbjaehrlich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_HALBJAEHRLICH");
                    return;
                case Dienstleistungstyp.DatenbereitstellungHistorischeLg:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_HISTORISCHE_LG");
                    return;
                case Dienstleistungstyp.DatenbereitstellungJaehrlich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_JAEHRLICH");
                    return;
                case Dienstleistungstyp.DatenbereitstellungMonatlich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_MONATLICH");
                    return;
                case Dienstleistungstyp.DatenbereitstellungMonatlichZusaetzlich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_MONATLICH_ZUSAETZLICH");
                    return;
                case Dienstleistungstyp.DatenbereitstellungStuendlich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_STUENDLICH");
                    return;
                case Dienstleistungstyp.DatenbereitstellungTaeglich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_TAEGLICH");
                    return;
                case Dienstleistungstyp.DatenbereitstellungVierteljaehrlich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_VIERTELJAEHRLICH");
                    return;
                case Dienstleistungstyp.DatenbereitstellungWoechentlich:
                    serializer.Serialize(writer, "DATENBEREITSTELLUNG_WOECHENTLICH");
                    return;
                case Dienstleistungstyp.Entsperrung:
                    serializer.Serialize(writer, "ENTSPERRUNG");
                    return;
                case Dienstleistungstyp.Inkassokosten:
                    serializer.Serialize(writer, "INKASSOKOSTEN");
                    return;
                case Dienstleistungstyp.Mahnkosten:
                    serializer.Serialize(writer, "MAHNKOSTEN");
                    return;
                case Dienstleistungstyp.Sperrung:
                    serializer.Serialize(writer, "SPERRUNG");
                    return;
            }
            throw new Exception("Cannot marshal type Dienstleistungstyp");
        }

        public static readonly DienstleistungstypConverter Singleton = new DienstleistungstypConverter();
    }
}
