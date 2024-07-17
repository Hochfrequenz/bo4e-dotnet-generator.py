// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var regionalePreisgarantie = RegionalePreisgarantie.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Abbildung einer Preisgarantie mit regionaler Abgrenzung
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/RegionalePreisgarantie.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `RegionalePreisgarantie JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/RegionalePreisgarantie.json>`_
    /// </summary>
    public partial class RegionalePreisgarantie
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
        /// Freitext zur Beschreibung der Preisgarantie.
        /// </summary>
        [JsonProperty("beschreibung")]
        public string Beschreibung { get; set; }

        /// <summary>
        /// Festlegung, auf welche Preisbestandteile die Garantie gewährt wird.
        /// </summary>
        [JsonProperty("preisgarantietyp")]
        public Preisgarantietyp? Preisgarantietyp { get; set; }

        /// <summary>
        /// Regionale Eingrenzung der Preisgarantie.
        /// </summary>
        [JsonProperty("regionaleGueltigkeit")]
        public RegionaleGueltigkeit RegionaleGueltigkeit { get; set; }

        /// <summary>
        /// Freitext zur Beschreibung der Preisgarantie.
        /// </summary>
        [JsonProperty("zeitlicheGueltigkeit")]
        public Zeitraum ZeitlicheGueltigkeit { get; set; }

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






    public partial class RegionalePreisgarantie
    {
        public static RegionalePreisgarantie FromJson(string json) => JsonConvert.DeserializeObject<RegionalePreisgarantie>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this RegionalePreisgarantie self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PreisgarantietypConverter.Singleton,
                GueltigkeitstypConverter.Singleton,
                TarifregionskriteriumConverter.Singleton,
                MengeneinheitConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PreisgarantietypConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Preisgarantietyp) || t == typeof(Preisgarantietyp?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ALLE_PREISBESTANDTEILE_BRUTTO":
                    return Preisgarantietyp.AllePreisbestandteileBrutto;
                case "ALLE_PREISBESTANDTEILE_NETTO":
                    return Preisgarantietyp.AllePreisbestandteileNetto;
                case "NUR_ENERGIEPREIS":
                    return Preisgarantietyp.NurEnergiepreis;
                case "PREISBESTANDTEILE_OHNE_ABGABEN":
                    return Preisgarantietyp.PreisbestandteileOhneAbgaben;
            }
            throw new Exception("Cannot unmarshal type Preisgarantietyp");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Preisgarantietyp)untypedValue;
            switch (value)
            {
                case Preisgarantietyp.AllePreisbestandteileBrutto:
                    serializer.Serialize(writer, "ALLE_PREISBESTANDTEILE_BRUTTO");
                    return;
                case Preisgarantietyp.AllePreisbestandteileNetto:
                    serializer.Serialize(writer, "ALLE_PREISBESTANDTEILE_NETTO");
                    return;
                case Preisgarantietyp.NurEnergiepreis:
                    serializer.Serialize(writer, "NUR_ENERGIEPREIS");
                    return;
                case Preisgarantietyp.PreisbestandteileOhneAbgaben:
                    serializer.Serialize(writer, "PREISBESTANDTEILE_OHNE_ABGABEN");
                    return;
            }
            throw new Exception("Cannot marshal type Preisgarantietyp");
        }

        public static readonly PreisgarantietypConverter Singleton = new PreisgarantietypConverter();
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

    internal class MengeneinheitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Mengeneinheit) || t == typeof(Mengeneinheit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "HALBJAHR":
                    return Mengeneinheit.Halbjahr;
                case "JAHR":
                    return Mengeneinheit.Jahr;
                case "KUBIKMETER":
                    return Mengeneinheit.Kubikmeter;
                case "KVAR":
                    return Mengeneinheit.Kvar;
                case "KVARH":
                    return Mengeneinheit.Kvarh;
                case "KW":
                    return Mengeneinheit.Kw;
                case "KWH":
                    return Mengeneinheit.Kwh;
                case "KWHK":
                    return Mengeneinheit.Kwhk;
                case "MINUTE":
                    return Mengeneinheit.Minute;
                case "MONAT":
                    return Mengeneinheit.Monat;
                case "MW":
                    return Mengeneinheit.Mw;
                case "MWH":
                    return Mengeneinheit.Mwh;
                case "PROZENT":
                    return Mengeneinheit.Prozent;
                case "QUARTAL":
                    return Mengeneinheit.Quartal;
                case "SEKUNDE":
                    return Mengeneinheit.Sekunde;
                case "STUECK":
                    return Mengeneinheit.Stueck;
                case "STUNDE":
                    return Mengeneinheit.Stunde;
                case "TAG":
                    return Mengeneinheit.Tag;
                case "VAR":
                    return Mengeneinheit.Var;
                case "VARH":
                    return Mengeneinheit.Varh;
                case "VIERTEL_STUNDE":
                    return Mengeneinheit.ViertelStunde;
                case "W":
                    return Mengeneinheit.W;
                case "WH":
                    return Mengeneinheit.Wh;
                case "WOCHE":
                    return Mengeneinheit.Woche;
            }
            throw new Exception("Cannot unmarshal type Mengeneinheit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Mengeneinheit)untypedValue;
            switch (value)
            {
                case Mengeneinheit.Halbjahr:
                    serializer.Serialize(writer, "HALBJAHR");
                    return;
                case Mengeneinheit.Jahr:
                    serializer.Serialize(writer, "JAHR");
                    return;
                case Mengeneinheit.Kubikmeter:
                    serializer.Serialize(writer, "KUBIKMETER");
                    return;
                case Mengeneinheit.Kvar:
                    serializer.Serialize(writer, "KVAR");
                    return;
                case Mengeneinheit.Kvarh:
                    serializer.Serialize(writer, "KVARH");
                    return;
                case Mengeneinheit.Kw:
                    serializer.Serialize(writer, "KW");
                    return;
                case Mengeneinheit.Kwh:
                    serializer.Serialize(writer, "KWH");
                    return;
                case Mengeneinheit.Kwhk:
                    serializer.Serialize(writer, "KWHK");
                    return;
                case Mengeneinheit.Minute:
                    serializer.Serialize(writer, "MINUTE");
                    return;
                case Mengeneinheit.Monat:
                    serializer.Serialize(writer, "MONAT");
                    return;
                case Mengeneinheit.Mw:
                    serializer.Serialize(writer, "MW");
                    return;
                case Mengeneinheit.Mwh:
                    serializer.Serialize(writer, "MWH");
                    return;
                case Mengeneinheit.Prozent:
                    serializer.Serialize(writer, "PROZENT");
                    return;
                case Mengeneinheit.Quartal:
                    serializer.Serialize(writer, "QUARTAL");
                    return;
                case Mengeneinheit.Sekunde:
                    serializer.Serialize(writer, "SEKUNDE");
                    return;
                case Mengeneinheit.Stueck:
                    serializer.Serialize(writer, "STUECK");
                    return;
                case Mengeneinheit.Stunde:
                    serializer.Serialize(writer, "STUNDE");
                    return;
                case Mengeneinheit.Tag:
                    serializer.Serialize(writer, "TAG");
                    return;
                case Mengeneinheit.Var:
                    serializer.Serialize(writer, "VAR");
                    return;
                case Mengeneinheit.Varh:
                    serializer.Serialize(writer, "VARH");
                    return;
                case Mengeneinheit.ViertelStunde:
                    serializer.Serialize(writer, "VIERTEL_STUNDE");
                    return;
                case Mengeneinheit.W:
                    serializer.Serialize(writer, "W");
                    return;
                case Mengeneinheit.Wh:
                    serializer.Serialize(writer, "WH");
                    return;
                case Mengeneinheit.Woche:
                    serializer.Serialize(writer, "WOCHE");
                    return;
            }
            throw new Exception("Cannot marshal type Mengeneinheit");
        }

        public static readonly MengeneinheitConverter Singleton = new MengeneinheitConverter();
    }
}
