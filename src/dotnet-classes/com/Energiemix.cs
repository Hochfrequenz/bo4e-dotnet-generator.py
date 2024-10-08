// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var energiemix = Energiemix.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Zusammensetzung der gelieferten Energie aus den verschiedenen Primärenergieformen.
    ///
    /// .. raw:: html
    ///
    /// <object data="../_static/images/bo4e/com/Energiemix.svg" type="image/svg+xml"></object>
    ///
    /// .. HINT::
    /// `Energiemix JSON Schema
    /// <https://json-schema.app/view/%23?url=https://raw.githubusercontent.com/BO4E/BO4E-Schemas/v202401.2.1/src/bo4e_schemas/com/Energiemix.json>`_
    /// </summary>
    public partial class Energiemix
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
        /// Anteile der jeweiligen Erzeugungsart
        /// </summary>
        [JsonProperty("anteil")]
        public Energieherkunft[] Anteil { get; set; }

        /// <summary>
        /// Höhe des erzeugten Atommülls in g/kWh
        /// </summary>
        [JsonProperty("atommuell")]
        public double? Atommuell { get; set; }

        /// <summary>
        /// Bemerkung zum Energiemix
        /// </summary>
        [JsonProperty("bemerkung")]
        public string Bemerkung { get; set; }

        /// <summary>
        /// Bezeichnung des Energiemix
        /// </summary>
        [JsonProperty("bezeichnung")]
        public string Bezeichnung { get; set; }

        /// <summary>
        /// Höhe des erzeugten CO2-Ausstosses in g/kWh
        /// </summary>
        [JsonProperty("co2Emission")]
        public double? Co2Emission { get; set; }

        /// <summary>
        /// Strom oder Gas etc.
        /// </summary>
        [JsonProperty("energieart")]
        public Sparte? Energieart { get; set; }

        /// <summary>
        /// Eindeutige Nummer zur Identifizierung des Energiemixes
        /// </summary>
        [JsonProperty("energiemixnummer")]
        public long? Energiemixnummer { get; set; }

        /// <summary>
        /// Jahr, für das der Energiemix gilt
        /// </summary>
        [JsonProperty("gueltigkeitsjahr")]
        public long? Gueltigkeitsjahr { get; set; }

        /// <summary>
        /// Kennzeichen, ob der Versorger zu den Öko Top Ten gehört
        /// </summary>
        [JsonProperty("istInOekoTopTen")]
        public bool? IstInOekoTopTen { get; set; }

        /// <summary>
        /// Ökolabel für den Energiemix
        /// </summary>
        [JsonProperty("oekolabel")]
        public string[] Oekolabel { get; set; }

        /// <summary>
        /// Zertifikate für den Energiemix
        /// </summary>
        [JsonProperty("oekozertifikate")]
        public string[] Oekozertifikate { get; set; }

        /// <summary>
        /// Internetseite, auf der die Strommixdaten veröffentlicht sind
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

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





    public partial class Energiemix
    {
        public static Energiemix FromJson(string json) => JsonConvert.DeserializeObject<Energiemix>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Energiemix self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ErzeugungsartConverter.Singleton,
                SparteConverter.Singleton,
                OekolabelConverter.Singleton,
                OekozertifikatConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ErzeugungsartConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Erzeugungsart) || t == typeof(Erzeugungsart?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BIOGAS":
                    return Erzeugungsart.Biogas;
                case "BIOMASSE":
                    return Erzeugungsart.Biomasse;
                case "FOSSIL":
                    return Erzeugungsart.Fossil;
                case "GAS":
                    return Erzeugungsart.Gas;
                case "GEOTHERMIE":
                    return Erzeugungsart.Geothermie;
                case "KERNKRAFT":
                    return Erzeugungsart.Kernkraft;
                case "KLIMANEUTRALES_GAS":
                    return Erzeugungsart.KlimaneutralesGas;
                case "KOHLE":
                    return Erzeugungsart.Kohle;
                case "KWK":
                    return Erzeugungsart.Kwk;
                case "SOLAR":
                    return Erzeugungsart.Solar;
                case "SONSTIGE":
                    return Erzeugungsart.Sonstige;
                case "SONSTIGE_EEG":
                    return Erzeugungsart.SonstigeEeg;
                case "WASSER":
                    return Erzeugungsart.Wasser;
                case "WIND":
                    return Erzeugungsart.Wind;
            }
            throw new Exception("Cannot unmarshal type Erzeugungsart");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Erzeugungsart)untypedValue;
            switch (value)
            {
                case Erzeugungsart.Biogas:
                    serializer.Serialize(writer, "BIOGAS");
                    return;
                case Erzeugungsart.Biomasse:
                    serializer.Serialize(writer, "BIOMASSE");
                    return;
                case Erzeugungsart.Fossil:
                    serializer.Serialize(writer, "FOSSIL");
                    return;
                case Erzeugungsart.Gas:
                    serializer.Serialize(writer, "GAS");
                    return;
                case Erzeugungsart.Geothermie:
                    serializer.Serialize(writer, "GEOTHERMIE");
                    return;
                case Erzeugungsart.Kernkraft:
                    serializer.Serialize(writer, "KERNKRAFT");
                    return;
                case Erzeugungsart.KlimaneutralesGas:
                    serializer.Serialize(writer, "KLIMANEUTRALES_GAS");
                    return;
                case Erzeugungsart.Kohle:
                    serializer.Serialize(writer, "KOHLE");
                    return;
                case Erzeugungsart.Kwk:
                    serializer.Serialize(writer, "KWK");
                    return;
                case Erzeugungsart.Solar:
                    serializer.Serialize(writer, "SOLAR");
                    return;
                case Erzeugungsart.Sonstige:
                    serializer.Serialize(writer, "SONSTIGE");
                    return;
                case Erzeugungsart.SonstigeEeg:
                    serializer.Serialize(writer, "SONSTIGE_EEG");
                    return;
                case Erzeugungsart.Wasser:
                    serializer.Serialize(writer, "WASSER");
                    return;
                case Erzeugungsart.Wind:
                    serializer.Serialize(writer, "WIND");
                    return;
            }
            throw new Exception("Cannot marshal type Erzeugungsart");
        }

        public static readonly ErzeugungsartConverter Singleton = new ErzeugungsartConverter();
    }

    internal class SparteConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Sparte) || t == typeof(Sparte?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ABWASSER":
                    return Sparte.Abwasser;
                case "FERNWAERME":
                    return Sparte.Fernwaerme;
                case "GAS":
                    return Sparte.Gas;
                case "NAHWAERME":
                    return Sparte.Nahwaerme;
                case "STROM":
                    return Sparte.Strom;
                case "STROM_UND_GAS":
                    return Sparte.StromUndGas;
                case "WASSER":
                    return Sparte.Wasser;
            }
            throw new Exception("Cannot unmarshal type Sparte");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Sparte)untypedValue;
            switch (value)
            {
                case Sparte.Abwasser:
                    serializer.Serialize(writer, "ABWASSER");
                    return;
                case Sparte.Fernwaerme:
                    serializer.Serialize(writer, "FERNWAERME");
                    return;
                case Sparte.Gas:
                    serializer.Serialize(writer, "GAS");
                    return;
                case Sparte.Nahwaerme:
                    serializer.Serialize(writer, "NAHWAERME");
                    return;
                case Sparte.Strom:
                    serializer.Serialize(writer, "STROM");
                    return;
                case Sparte.StromUndGas:
                    serializer.Serialize(writer, "STROM_UND_GAS");
                    return;
                case Sparte.Wasser:
                    serializer.Serialize(writer, "WASSER");
                    return;
            }
            throw new Exception("Cannot marshal type Sparte");
        }

        public static readonly SparteConverter Singleton = new SparteConverter();
    }

    internal class OekolabelConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Oekolabel) || t == typeof(Oekolabel?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ENERGREEN":
                    return Oekolabel.Energreen;
                case "GASGREEN":
                    return Oekolabel.Gasgreen;
                case "GASGREEN_GRUENER_STROM":
                    return Oekolabel.GasgreenGruenerStrom;
                case "GRUENER_STROM":
                    return Oekolabel.GruenerStrom;
                case "GRUENER_STROM_GOLD":
                    return Oekolabel.GruenerStromGold;
                case "GRUENER_STROM_SILBER":
                    return Oekolabel.GruenerStromSilber;
                case "GRUENES_GAS":
                    return Oekolabel.GruenesGas;
                case "NATURWATT_STROM":
                    return Oekolabel.NaturwattStrom;
                case "OK_POWER":
                    return Oekolabel.OkPower;
                case "RENEWABLE_PLUS":
                    return Oekolabel.RenewablePlus;
                case "WATERGREEN":
                    return Oekolabel.Watergreen;
                case "WATERGREEN_PLUS":
                    return Oekolabel.WatergreenPlus;
            }
            throw new Exception("Cannot unmarshal type Oekolabel");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Oekolabel)untypedValue;
            switch (value)
            {
                case Oekolabel.Energreen:
                    serializer.Serialize(writer, "ENERGREEN");
                    return;
                case Oekolabel.Gasgreen:
                    serializer.Serialize(writer, "GASGREEN");
                    return;
                case Oekolabel.GasgreenGruenerStrom:
                    serializer.Serialize(writer, "GASGREEN_GRUENER_STROM");
                    return;
                case Oekolabel.GruenerStrom:
                    serializer.Serialize(writer, "GRUENER_STROM");
                    return;
                case Oekolabel.GruenerStromGold:
                    serializer.Serialize(writer, "GRUENER_STROM_GOLD");
                    return;
                case Oekolabel.GruenerStromSilber:
                    serializer.Serialize(writer, "GRUENER_STROM_SILBER");
                    return;
                case Oekolabel.GruenesGas:
                    serializer.Serialize(writer, "GRUENES_GAS");
                    return;
                case Oekolabel.NaturwattStrom:
                    serializer.Serialize(writer, "NATURWATT_STROM");
                    return;
                case Oekolabel.OkPower:
                    serializer.Serialize(writer, "OK_POWER");
                    return;
                case Oekolabel.RenewablePlus:
                    serializer.Serialize(writer, "RENEWABLE_PLUS");
                    return;
                case Oekolabel.Watergreen:
                    serializer.Serialize(writer, "WATERGREEN");
                    return;
                case Oekolabel.WatergreenPlus:
                    serializer.Serialize(writer, "WATERGREEN_PLUS");
                    return;
            }
            throw new Exception("Cannot marshal type Oekolabel");
        }

        public static readonly OekolabelConverter Singleton = new OekolabelConverter();
    }

    internal class OekozertifikatConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Oekozertifikat) || t == typeof(Oekozertifikat?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BET":
                    return Oekozertifikat.Bet;
                case "CMS_EE01":
                    return Oekozertifikat.CmsEe01;
                case "CMS_EE02":
                    return Oekozertifikat.CmsEe02;
                case "EECS":
                    return Oekozertifikat.Eecs;
                case "FRAUNHOFER":
                    return Oekozertifikat.Fraunhofer;
                case "FREIBERG":
                    return Oekozertifikat.Freiberg;
                case "KLIMA_INVEST":
                    return Oekozertifikat.KlimaInvest;
                case "LGA":
                    return Oekozertifikat.Lga;
                case "RECS":
                    return Oekozertifikat.Recs;
                case "REGS_EGL":
                    return Oekozertifikat.RegsEgl;
                case "TUEV":
                    return Oekozertifikat.Tuev;
                case "TUEV_HESSEN":
                    return Oekozertifikat.TuevHessen;
                case "TUEV_NORD":
                    return Oekozertifikat.TuevNord;
                case "TUEV_RHEINLAND":
                    return Oekozertifikat.TuevRheinland;
                case "TUEV_SUED":
                    return Oekozertifikat.TuevSued;
                case "TUEV_SUED_EE01":
                    return Oekozertifikat.TuevSuedEe01;
                case "TUEV_SUED_EE02":
                    return Oekozertifikat.TuevSuedEe02;
            }
            throw new Exception("Cannot unmarshal type Oekozertifikat");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Oekozertifikat)untypedValue;
            switch (value)
            {
                case Oekozertifikat.Bet:
                    serializer.Serialize(writer, "BET");
                    return;
                case Oekozertifikat.CmsEe01:
                    serializer.Serialize(writer, "CMS_EE01");
                    return;
                case Oekozertifikat.CmsEe02:
                    serializer.Serialize(writer, "CMS_EE02");
                    return;
                case Oekozertifikat.Eecs:
                    serializer.Serialize(writer, "EECS");
                    return;
                case Oekozertifikat.Fraunhofer:
                    serializer.Serialize(writer, "FRAUNHOFER");
                    return;
                case Oekozertifikat.Freiberg:
                    serializer.Serialize(writer, "FREIBERG");
                    return;
                case Oekozertifikat.KlimaInvest:
                    serializer.Serialize(writer, "KLIMA_INVEST");
                    return;
                case Oekozertifikat.Lga:
                    serializer.Serialize(writer, "LGA");
                    return;
                case Oekozertifikat.Recs:
                    serializer.Serialize(writer, "RECS");
                    return;
                case Oekozertifikat.RegsEgl:
                    serializer.Serialize(writer, "REGS_EGL");
                    return;
                case Oekozertifikat.Tuev:
                    serializer.Serialize(writer, "TUEV");
                    return;
                case Oekozertifikat.TuevHessen:
                    serializer.Serialize(writer, "TUEV_HESSEN");
                    return;
                case Oekozertifikat.TuevNord:
                    serializer.Serialize(writer, "TUEV_NORD");
                    return;
                case Oekozertifikat.TuevRheinland:
                    serializer.Serialize(writer, "TUEV_RHEINLAND");
                    return;
                case Oekozertifikat.TuevSued:
                    serializer.Serialize(writer, "TUEV_SUED");
                    return;
                case Oekozertifikat.TuevSuedEe01:
                    serializer.Serialize(writer, "TUEV_SUED_EE01");
                    return;
                case Oekozertifikat.TuevSuedEe02:
                    serializer.Serialize(writer, "TUEV_SUED_EE02");
                    return;
            }
            throw new Exception("Cannot marshal type Oekozertifikat");
        }

        public static readonly OekozertifikatConverter Singleton = new OekozertifikatConverter();
    }
}
