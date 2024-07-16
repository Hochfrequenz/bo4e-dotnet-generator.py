// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var zaehlwerk = Zaehlwerk.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Mit dieser Komponente werden Zählwerke modelliert.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/Zaehlwerk.svg" type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Zaehlwerk JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/Zaehlwerk.json>`_
    /// </summary>
    public partial class Zaehlwerk
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
        /// Abrechnungsrelevant
        /// </summary>
        [JsonProperty("anzahlAblesungen")]
        public long? AnzahlAblesungen { get; set; }

        [JsonProperty("bezeichnung")]
        public string Bezeichnung { get; set; }

        [JsonProperty("einheit")]
        public Mengeneinheit? Einheit { get; set; }

        /// <summary>
        /// Anzahl der Nachkommastellen
        /// </summary>
        [JsonProperty("istAbrechnungsrelevant")]
        public bool? IstAbrechnungsrelevant { get; set; }

        /// <summary>
        /// Schwachlastfaehigkeit
        /// </summary>
        [JsonProperty("istSchwachlastfaehig")]
        public bool? IstSchwachlastfaehig { get; set; }

        /// <summary>
        /// Konzessionsabgabe
        /// </summary>
        [JsonProperty("istSteuerbefreit")]
        public bool? IstSteuerbefreit { get; set; }

        /// <summary>
        /// Stromverbrauchsart/Verbrauchsart Marktlokation
        /// </summary>
        [JsonProperty("istUnterbrechbar")]
        public bool? IstUnterbrechbar { get; set; }

        /// <summary>
        /// Wärmenutzung Marktlokation
        /// </summary>
        [JsonProperty("konzessionsabgabe")]
        public Konzessionsabgabe Konzessionsabgabe { get; set; }

        /// <summary>
        /// Anzahl der Vorkommastellen
        /// </summary>
        [JsonProperty("nachkommastelle")]
        public long? Nachkommastelle { get; set; }

        [JsonProperty("obisKennzahl")]
        public string ObisKennzahl { get; set; }

        [JsonProperty("richtung")]
        public Energierichtung? Richtung { get; set; }

        /// <summary>
        /// Stromverbrauchsart/Verbrauchsart Marktlokation
        /// </summary>
        [JsonProperty("verbrauchsart")]
        public Verbrauchsart? Verbrauchsart { get; set; }

        /// <summary>
        /// Schwachlastfaehigkeit
        /// </summary>
        [JsonProperty("verwendungszwecke")]
        public VerwendungszweckProMarktrolle[] Verwendungszwecke { get; set; }

        /// <summary>
        /// Steuerbefreiung
        /// </summary>
        [JsonProperty("vorkommastelle")]
        public long? Vorkommastelle { get; set; }

        /// <summary>
        /// Unterbrechbarkeit Marktlokation
        /// </summary>
        [JsonProperty("waermenutzung")]
        public Waermenutzung? Waermenutzung { get; set; }

        [JsonProperty("wandlerfaktor")]
        public double? Wandlerfaktor { get; set; }

        [JsonProperty("zaehlwerkId")]
        public string ZaehlwerkId { get; set; }

        /// <summary>
        /// Anzahl Ablesungen pro Jahr
        /// </summary>
        [JsonProperty("zaehlzeitregister")]
        public Zaehlzeitregister Zaehlzeitregister { get; set; }

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










    public partial class Zaehlwerk
    {
        public static Zaehlwerk FromJson(string json) => JsonConvert.DeserializeObject<Zaehlwerk>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Zaehlwerk self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
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
                AbgabeArtConverter.Singleton,
                EnergierichtungConverter.Singleton,
                VerbrauchsartConverter.Singleton,
                MarktrolleConverter.Singleton,
                VerwendungszweckConverter.Singleton,
                WaermenutzungConverter.Singleton,
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

    internal class EnergierichtungConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Energierichtung) || t == typeof(Energierichtung?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AUSSP":
                    return Energierichtung.Aussp;
                case "EINSP":
                    return Energierichtung.Einsp;
            }
            throw new Exception("Cannot unmarshal type Energierichtung");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Energierichtung)untypedValue;
            switch (value)
            {
                case Energierichtung.Aussp:
                    serializer.Serialize(writer, "AUSSP");
                    return;
                case Energierichtung.Einsp:
                    serializer.Serialize(writer, "EINSP");
                    return;
            }
            throw new Exception("Cannot marshal type Energierichtung");
        }

        public static readonly EnergierichtungConverter Singleton = new EnergierichtungConverter();
    }

    internal class VerbrauchsartConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Verbrauchsart) || t == typeof(Verbrauchsart?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "KL":
                    return Verbrauchsart.Kl;
                case "KLW":
                    return Verbrauchsart.Klw;
                case "KLWS":
                    return Verbrauchsart.Klws;
                case "W":
                    return Verbrauchsart.W;
                case "WS":
                    return Verbrauchsart.Ws;
            }
            throw new Exception("Cannot unmarshal type Verbrauchsart");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Verbrauchsart)untypedValue;
            switch (value)
            {
                case Verbrauchsart.Kl:
                    serializer.Serialize(writer, "KL");
                    return;
                case Verbrauchsart.Klw:
                    serializer.Serialize(writer, "KLW");
                    return;
                case Verbrauchsart.Klws:
                    serializer.Serialize(writer, "KLWS");
                    return;
                case Verbrauchsart.W:
                    serializer.Serialize(writer, "W");
                    return;
                case Verbrauchsart.Ws:
                    serializer.Serialize(writer, "WS");
                    return;
            }
            throw new Exception("Cannot marshal type Verbrauchsart");
        }

        public static readonly VerbrauchsartConverter Singleton = new VerbrauchsartConverter();
    }

    internal class MarktrolleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Marktrolle) || t == typeof(Marktrolle?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BIKO":
                    return Marktrolle.Biko;
                case "BKV":
                    return Marktrolle.Bkv;
                case "BTR":
                    return Marktrolle.Btr;
                case "DP":
                    return Marktrolle.Dp;
                case "EIV":
                    return Marktrolle.Eiv;
                case "ESA":
                    return Marktrolle.Esa;
                case "KN":
                    return Marktrolle.Kn;
                case "LF":
                    return Marktrolle.Lf;
                case "MGV":
                    return Marktrolle.Mgv;
                case "MSB":
                    return Marktrolle.Msb;
                case "NB":
                    return Marktrolle.Nb;
                case "RB":
                    return Marktrolle.Rb;
                case "UENB":
                    return Marktrolle.Uenb;
            }
            throw new Exception("Cannot unmarshal type Marktrolle");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Marktrolle)untypedValue;
            switch (value)
            {
                case Marktrolle.Biko:
                    serializer.Serialize(writer, "BIKO");
                    return;
                case Marktrolle.Bkv:
                    serializer.Serialize(writer, "BKV");
                    return;
                case Marktrolle.Btr:
                    serializer.Serialize(writer, "BTR");
                    return;
                case Marktrolle.Dp:
                    serializer.Serialize(writer, "DP");
                    return;
                case Marktrolle.Eiv:
                    serializer.Serialize(writer, "EIV");
                    return;
                case Marktrolle.Esa:
                    serializer.Serialize(writer, "ESA");
                    return;
                case Marktrolle.Kn:
                    serializer.Serialize(writer, "KN");
                    return;
                case Marktrolle.Lf:
                    serializer.Serialize(writer, "LF");
                    return;
                case Marktrolle.Mgv:
                    serializer.Serialize(writer, "MGV");
                    return;
                case Marktrolle.Msb:
                    serializer.Serialize(writer, "MSB");
                    return;
                case Marktrolle.Nb:
                    serializer.Serialize(writer, "NB");
                    return;
                case Marktrolle.Rb:
                    serializer.Serialize(writer, "RB");
                    return;
                case Marktrolle.Uenb:
                    serializer.Serialize(writer, "UENB");
                    return;
            }
            throw new Exception("Cannot marshal type Marktrolle");
        }

        public static readonly MarktrolleConverter Singleton = new MarktrolleConverter();
    }

    internal class VerwendungszweckConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Verwendungszweck) || t == typeof(Verwendungszweck?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BILANZKREISABRECHNUNG":
                    return Verwendungszweck.Bilanzkreisabrechnung;
                case "ENDKUNDENABRECHNUNG":
                    return Verwendungszweck.Endkundenabrechnung;
                case "ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS":
                    return Verwendungszweck.ErmittlungAusgeglichenheitBilanzkreis;
                case "MEHRMINDERMENGENABRECHNUNG":
                    return Verwendungszweck.Mehrmindermengenabrechnung;
                case "NETZNUTZUNGSABRECHNUNG":
                    return Verwendungszweck.Netznutzungsabrechnung;
                case "UEBERMITTLUNG_AN_DAS_HKNR":
                    return Verwendungszweck.UebermittlungAnDasHknr;
            }
            throw new Exception("Cannot unmarshal type Verwendungszweck");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Verwendungszweck)untypedValue;
            switch (value)
            {
                case Verwendungszweck.Bilanzkreisabrechnung:
                    serializer.Serialize(writer, "BILANZKREISABRECHNUNG");
                    return;
                case Verwendungszweck.Endkundenabrechnung:
                    serializer.Serialize(writer, "ENDKUNDENABRECHNUNG");
                    return;
                case Verwendungszweck.ErmittlungAusgeglichenheitBilanzkreis:
                    serializer.Serialize(writer, "ERMITTLUNG_AUSGEGLICHENHEIT_BILANZKREIS");
                    return;
                case Verwendungszweck.Mehrmindermengenabrechnung:
                    serializer.Serialize(writer, "MEHRMINDERMENGENABRECHNUNG");
                    return;
                case Verwendungszweck.Netznutzungsabrechnung:
                    serializer.Serialize(writer, "NETZNUTZUNGSABRECHNUNG");
                    return;
                case Verwendungszweck.UebermittlungAnDasHknr:
                    serializer.Serialize(writer, "UEBERMITTLUNG_AN_DAS_HKNR");
                    return;
            }
            throw new Exception("Cannot marshal type Verwendungszweck");
        }

        public static readonly VerwendungszweckConverter Singleton = new VerwendungszweckConverter();
    }

    internal class WaermenutzungConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Waermenutzung) || t == typeof(Waermenutzung?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "DIREKTHEIZUNG":
                    return Waermenutzung.Direktheizung;
                case "SPEICHERHEIZUNG":
                    return Waermenutzung.Speicherheizung;
                case "WAERMEPUMPE":
                    return Waermenutzung.Waermepumpe;
            }
            throw new Exception("Cannot unmarshal type Waermenutzung");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Waermenutzung)untypedValue;
            switch (value)
            {
                case Waermenutzung.Direktheizung:
                    serializer.Serialize(writer, "DIREKTHEIZUNG");
                    return;
                case Waermenutzung.Speicherheizung:
                    serializer.Serialize(writer, "SPEICHERHEIZUNG");
                    return;
                case Waermenutzung.Waermepumpe:
                    serializer.Serialize(writer, "WAERMEPUMPE");
                    return;
            }
            throw new Exception("Cannot marshal type Waermenutzung");
        }

        public static readonly WaermenutzungConverter Singleton = new WaermenutzungConverter();
    }
}
