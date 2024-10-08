// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var oekozertifikat = Oekozertifikat.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Zertifikate für Ökostrom von verschiedenen Herausgebern.
    /// </summary>
    public enum OekozertifikatEnum { Bet, CmsEe01, CmsEe02, Eecs, Fraunhofer, Freiberg, KlimaInvest, Lga, Recs, RegsEgl, Tuev, TuevHessen, TuevNord, TuevRheinland, TuevSued, TuevSuedEe01, TuevSuedEe02 };

    public class Oekozertifikat
    {
        public static OekozertifikatEnum FromJson(string json) => JsonConvert.DeserializeObject<OekozertifikatEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this OekozertifikatEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                OekozertifikatEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class OekozertifikatEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(OekozertifikatEnum) || t == typeof(OekozertifikatEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BET":
                    return OekozertifikatEnum.Bet;
                case "CMS_EE01":
                    return OekozertifikatEnum.CmsEe01;
                case "CMS_EE02":
                    return OekozertifikatEnum.CmsEe02;
                case "EECS":
                    return OekozertifikatEnum.Eecs;
                case "FRAUNHOFER":
                    return OekozertifikatEnum.Fraunhofer;
                case "FREIBERG":
                    return OekozertifikatEnum.Freiberg;
                case "KLIMA_INVEST":
                    return OekozertifikatEnum.KlimaInvest;
                case "LGA":
                    return OekozertifikatEnum.Lga;
                case "RECS":
                    return OekozertifikatEnum.Recs;
                case "REGS_EGL":
                    return OekozertifikatEnum.RegsEgl;
                case "TUEV":
                    return OekozertifikatEnum.Tuev;
                case "TUEV_HESSEN":
                    return OekozertifikatEnum.TuevHessen;
                case "TUEV_NORD":
                    return OekozertifikatEnum.TuevNord;
                case "TUEV_RHEINLAND":
                    return OekozertifikatEnum.TuevRheinland;
                case "TUEV_SUED":
                    return OekozertifikatEnum.TuevSued;
                case "TUEV_SUED_EE01":
                    return OekozertifikatEnum.TuevSuedEe01;
                case "TUEV_SUED_EE02":
                    return OekozertifikatEnum.TuevSuedEe02;
            }
            throw new Exception("Cannot unmarshal type OekozertifikatEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (OekozertifikatEnum)untypedValue;
            switch (value)
            {
                case OekozertifikatEnum.Bet:
                    serializer.Serialize(writer, "BET");
                    return;
                case OekozertifikatEnum.CmsEe01:
                    serializer.Serialize(writer, "CMS_EE01");
                    return;
                case OekozertifikatEnum.CmsEe02:
                    serializer.Serialize(writer, "CMS_EE02");
                    return;
                case OekozertifikatEnum.Eecs:
                    serializer.Serialize(writer, "EECS");
                    return;
                case OekozertifikatEnum.Fraunhofer:
                    serializer.Serialize(writer, "FRAUNHOFER");
                    return;
                case OekozertifikatEnum.Freiberg:
                    serializer.Serialize(writer, "FREIBERG");
                    return;
                case OekozertifikatEnum.KlimaInvest:
                    serializer.Serialize(writer, "KLIMA_INVEST");
                    return;
                case OekozertifikatEnum.Lga:
                    serializer.Serialize(writer, "LGA");
                    return;
                case OekozertifikatEnum.Recs:
                    serializer.Serialize(writer, "RECS");
                    return;
                case OekozertifikatEnum.RegsEgl:
                    serializer.Serialize(writer, "REGS_EGL");
                    return;
                case OekozertifikatEnum.Tuev:
                    serializer.Serialize(writer, "TUEV");
                    return;
                case OekozertifikatEnum.TuevHessen:
                    serializer.Serialize(writer, "TUEV_HESSEN");
                    return;
                case OekozertifikatEnum.TuevNord:
                    serializer.Serialize(writer, "TUEV_NORD");
                    return;
                case OekozertifikatEnum.TuevRheinland:
                    serializer.Serialize(writer, "TUEV_RHEINLAND");
                    return;
                case OekozertifikatEnum.TuevSued:
                    serializer.Serialize(writer, "TUEV_SUED");
                    return;
                case OekozertifikatEnum.TuevSuedEe01:
                    serializer.Serialize(writer, "TUEV_SUED_EE01");
                    return;
                case OekozertifikatEnum.TuevSuedEe02:
                    serializer.Serialize(writer, "TUEV_SUED_EE02");
                    return;
            }
            throw new Exception("Cannot marshal type OekozertifikatEnum");
        }

        public static readonly OekozertifikatEnumConverter Singleton = new OekozertifikatEnumConverter();
    }
}
