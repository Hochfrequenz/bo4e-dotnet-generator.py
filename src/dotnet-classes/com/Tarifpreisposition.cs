// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var tarifpreisposition = Tarifpreisposition.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Mit dieser Komponente können Tarifpreise verschiedener Typen abgebildet werden.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/Tarifpreisposition.svg"
    /// type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Tarifpreisposition JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/Tarifpreisposition.json>`_
    /// </summary>
    public partial class Tarifpreisposition
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
        /// Größe, auf die sich die Einheit bezieht, beispielsweise kWh, Jahr
        /// </summary>
        [JsonProperty("bezugseinheit")]
        public Mengeneinheit? Bezugseinheit { get; set; }

        /// <summary>
        /// Einheit des Preises (z.B. EURO)
        /// </summary>
        [JsonProperty("einheit")]
        public Waehrungseinheit? Einheit { get; set; }

        /// <summary>
        /// Gibt an, nach welcher Menge die vorgenannte Einschränkung erfolgt (z.B.
        /// Jahresstromverbrauch in kWh)
        /// </summary>
        [JsonProperty("mengeneinheitstaffel")]
        public Mengeneinheit? Mengeneinheitstaffel { get; set; }

        /// <summary>
        /// Hier sind die Staffeln mit ihren Preisenangaben definiert
        /// </summary>
        [JsonProperty("preisstaffeln")]
        public Preisstaffel[] Preisstaffeln { get; set; }

        /// <summary>
        /// Angabe des Preistypes (z.B. Grundpreis)
        /// </summary>
        [JsonProperty("preistyp")]
        public Preistyp? Preistyp { get; set; }

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




    public partial class Tarifpreisposition
    {
        public static Tarifpreisposition FromJson(string json) => JsonConvert.DeserializeObject<Tarifpreisposition>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Tarifpreisposition self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MengeneinheitConverter.Singleton,
                WaehrungseinheitConverter.Singleton,
                PreistypConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
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

    internal class WaehrungseinheitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Waehrungseinheit) || t == typeof(Waehrungseinheit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "CT":
                    return Waehrungseinheit.Ct;
                case "EUR":
                    return Waehrungseinheit.Eur;
            }
            throw new Exception("Cannot unmarshal type Waehrungseinheit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Waehrungseinheit)untypedValue;
            switch (value)
            {
                case Waehrungseinheit.Ct:
                    serializer.Serialize(writer, "CT");
                    return;
                case Waehrungseinheit.Eur:
                    serializer.Serialize(writer, "EUR");
                    return;
            }
            throw new Exception("Cannot marshal type Waehrungseinheit");
        }

        public static readonly WaehrungseinheitConverter Singleton = new WaehrungseinheitConverter();
    }

    internal class PreistypConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Preistyp) || t == typeof(Preistyp?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ARBEITSPREIS_EINTARIF":
                    return Preistyp.ArbeitspreisEintarif;
                case "ARBEITSPREIS_HT":
                    return Preistyp.ArbeitspreisHt;
                case "ARBEITSPREIS_NT":
                    return Preistyp.ArbeitspreisNt;
                case "ENTGELT_ABLESUNG":
                    return Preistyp.EntgeltAblesung;
                case "ENTGELT_ABRECHNUNG":
                    return Preistyp.EntgeltAbrechnung;
                case "ENTGELT_MSB":
                    return Preistyp.EntgeltMsb;
                case "GRUNDPREIS":
                    return Preistyp.Grundpreis;
                case "LEISTUNGSPREIS":
                    return Preistyp.Leistungspreis;
                case "MESSPREIS":
                    return Preistyp.Messpreis;
                case "PROVISION":
                    return Preistyp.Provision;
            }
            throw new Exception("Cannot unmarshal type Preistyp");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Preistyp)untypedValue;
            switch (value)
            {
                case Preistyp.ArbeitspreisEintarif:
                    serializer.Serialize(writer, "ARBEITSPREIS_EINTARIF");
                    return;
                case Preistyp.ArbeitspreisHt:
                    serializer.Serialize(writer, "ARBEITSPREIS_HT");
                    return;
                case Preistyp.ArbeitspreisNt:
                    serializer.Serialize(writer, "ARBEITSPREIS_NT");
                    return;
                case Preistyp.EntgeltAblesung:
                    serializer.Serialize(writer, "ENTGELT_ABLESUNG");
                    return;
                case Preistyp.EntgeltAbrechnung:
                    serializer.Serialize(writer, "ENTGELT_ABRECHNUNG");
                    return;
                case Preistyp.EntgeltMsb:
                    serializer.Serialize(writer, "ENTGELT_MSB");
                    return;
                case Preistyp.Grundpreis:
                    serializer.Serialize(writer, "GRUNDPREIS");
                    return;
                case Preistyp.Leistungspreis:
                    serializer.Serialize(writer, "LEISTUNGSPREIS");
                    return;
                case Preistyp.Messpreis:
                    serializer.Serialize(writer, "MESSPREIS");
                    return;
                case Preistyp.Provision:
                    serializer.Serialize(writer, "PROVISION");
                    return;
            }
            throw new Exception("Cannot marshal type Preistyp");
        }

        public static readonly PreistypConverter Singleton = new PreistypConverter();
    }
}
