// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using BO4EDotNet;
//
//    var messpreistyp = Messpreistyp.FromJson(jsonString);

namespace BO4EDotNet
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Festlegung, welcher Typ von Messung mit einem Preis belegt wird
    /// </summary>
    public enum MesspreistypEnum { AufschlagTarifschaltung, AufschlagWandler, ElektronischerAufsatz, MesspreisG10, MesspreisG16, MesspreisG25, MesspreisG4, MesspreisG40, MesspreisG6, MesspreistypMesspreisG25, MesspreistypSmartMeterMesspreisG25, SmartMeterMesspreisG10, SmartMeterMesspreisG16, SmartMeterMesspreisG25, SmartMeterMesspreisG4, SmartMeterMesspreisG40, SmartMeterMesspreisG6, VerrechnungspreisEtDreh, VerrechnungspreisEtWechsel, VerrechnungspreisLEt, VerrechnungspreisLZt, VerrechnungspreisSm, VerrechnungspreisZtDreh, VerrechnungspreisZtWechsel };

    public class Messpreistyp
    {
        public static MesspreistypEnum FromJson(string json) => JsonConvert.DeserializeObject<MesspreistypEnum>(json, BO4EDotNet.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this MesspreistypEnum self) => JsonConvert.SerializeObject(self, BO4EDotNet.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                MesspreistypEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class MesspreistypEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MesspreistypEnum) || t == typeof(MesspreistypEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AUFSCHLAG_TARIFSCHALTUNG":
                    return MesspreistypEnum.AufschlagTarifschaltung;
                case "AUFSCHLAG_WANDLER":
                    return MesspreistypEnum.AufschlagWandler;
                case "ELEKTRONISCHER_AUFSATZ":
                    return MesspreistypEnum.ElektronischerAufsatz;
                case "MESSPREIS_G10":
                    return MesspreistypEnum.MesspreisG10;
                case "MESSPREIS_G16":
                    return MesspreistypEnum.MesspreisG16;
                case "MESSPREIS_G25":
                    return MesspreistypEnum.MesspreistypMesspreisG25;
                case "MESSPREIS_G2_5":
                    return MesspreistypEnum.MesspreisG25;
                case "MESSPREIS_G4":
                    return MesspreistypEnum.MesspreisG4;
                case "MESSPREIS_G40":
                    return MesspreistypEnum.MesspreisG40;
                case "MESSPREIS_G6":
                    return MesspreistypEnum.MesspreisG6;
                case "SMART_METER_MESSPREIS_G10":
                    return MesspreistypEnum.SmartMeterMesspreisG10;
                case "SMART_METER_MESSPREIS_G16":
                    return MesspreistypEnum.SmartMeterMesspreisG16;
                case "SMART_METER_MESSPREIS_G25":
                    return MesspreistypEnum.MesspreistypSmartMeterMesspreisG25;
                case "SMART_METER_MESSPREIS_G2_5":
                    return MesspreistypEnum.SmartMeterMesspreisG25;
                case "SMART_METER_MESSPREIS_G4":
                    return MesspreistypEnum.SmartMeterMesspreisG4;
                case "SMART_METER_MESSPREIS_G40":
                    return MesspreistypEnum.SmartMeterMesspreisG40;
                case "SMART_METER_MESSPREIS_G6":
                    return MesspreistypEnum.SmartMeterMesspreisG6;
                case "VERRECHNUNGSPREIS_ET_DREH":
                    return MesspreistypEnum.VerrechnungspreisEtDreh;
                case "VERRECHNUNGSPREIS_ET_WECHSEL":
                    return MesspreistypEnum.VerrechnungspreisEtWechsel;
                case "VERRECHNUNGSPREIS_L_ET":
                    return MesspreistypEnum.VerrechnungspreisLEt;
                case "VERRECHNUNGSPREIS_L_ZT":
                    return MesspreistypEnum.VerrechnungspreisLZt;
                case "VERRECHNUNGSPREIS_SM":
                    return MesspreistypEnum.VerrechnungspreisSm;
                case "VERRECHNUNGSPREIS_ZT_DREH":
                    return MesspreistypEnum.VerrechnungspreisZtDreh;
                case "VERRECHNUNGSPREIS_ZT_WECHSEL":
                    return MesspreistypEnum.VerrechnungspreisZtWechsel;
            }
            throw new Exception("Cannot unmarshal type MesspreistypEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MesspreistypEnum)untypedValue;
            switch (value)
            {
                case MesspreistypEnum.AufschlagTarifschaltung:
                    serializer.Serialize(writer, "AUFSCHLAG_TARIFSCHALTUNG");
                    return;
                case MesspreistypEnum.AufschlagWandler:
                    serializer.Serialize(writer, "AUFSCHLAG_WANDLER");
                    return;
                case MesspreistypEnum.ElektronischerAufsatz:
                    serializer.Serialize(writer, "ELEKTRONISCHER_AUFSATZ");
                    return;
                case MesspreistypEnum.MesspreisG10:
                    serializer.Serialize(writer, "MESSPREIS_G10");
                    return;
                case MesspreistypEnum.MesspreisG16:
                    serializer.Serialize(writer, "MESSPREIS_G16");
                    return;
                case MesspreistypEnum.MesspreistypMesspreisG25:
                    serializer.Serialize(writer, "MESSPREIS_G25");
                    return;
                case MesspreistypEnum.MesspreisG25:
                    serializer.Serialize(writer, "MESSPREIS_G2_5");
                    return;
                case MesspreistypEnum.MesspreisG4:
                    serializer.Serialize(writer, "MESSPREIS_G4");
                    return;
                case MesspreistypEnum.MesspreisG40:
                    serializer.Serialize(writer, "MESSPREIS_G40");
                    return;
                case MesspreistypEnum.MesspreisG6:
                    serializer.Serialize(writer, "MESSPREIS_G6");
                    return;
                case MesspreistypEnum.SmartMeterMesspreisG10:
                    serializer.Serialize(writer, "SMART_METER_MESSPREIS_G10");
                    return;
                case MesspreistypEnum.SmartMeterMesspreisG16:
                    serializer.Serialize(writer, "SMART_METER_MESSPREIS_G16");
                    return;
                case MesspreistypEnum.MesspreistypSmartMeterMesspreisG25:
                    serializer.Serialize(writer, "SMART_METER_MESSPREIS_G25");
                    return;
                case MesspreistypEnum.SmartMeterMesspreisG25:
                    serializer.Serialize(writer, "SMART_METER_MESSPREIS_G2_5");
                    return;
                case MesspreistypEnum.SmartMeterMesspreisG4:
                    serializer.Serialize(writer, "SMART_METER_MESSPREIS_G4");
                    return;
                case MesspreistypEnum.SmartMeterMesspreisG40:
                    serializer.Serialize(writer, "SMART_METER_MESSPREIS_G40");
                    return;
                case MesspreistypEnum.SmartMeterMesspreisG6:
                    serializer.Serialize(writer, "SMART_METER_MESSPREIS_G6");
                    return;
                case MesspreistypEnum.VerrechnungspreisEtDreh:
                    serializer.Serialize(writer, "VERRECHNUNGSPREIS_ET_DREH");
                    return;
                case MesspreistypEnum.VerrechnungspreisEtWechsel:
                    serializer.Serialize(writer, "VERRECHNUNGSPREIS_ET_WECHSEL");
                    return;
                case MesspreistypEnum.VerrechnungspreisLEt:
                    serializer.Serialize(writer, "VERRECHNUNGSPREIS_L_ET");
                    return;
                case MesspreistypEnum.VerrechnungspreisLZt:
                    serializer.Serialize(writer, "VERRECHNUNGSPREIS_L_ZT");
                    return;
                case MesspreistypEnum.VerrechnungspreisSm:
                    serializer.Serialize(writer, "VERRECHNUNGSPREIS_SM");
                    return;
                case MesspreistypEnum.VerrechnungspreisZtDreh:
                    serializer.Serialize(writer, "VERRECHNUNGSPREIS_ZT_DREH");
                    return;
                case MesspreistypEnum.VerrechnungspreisZtWechsel:
                    serializer.Serialize(writer, "VERRECHNUNGSPREIS_ZT_WECHSEL");
                    return;
            }
            throw new Exception("Cannot marshal type MesspreistypEnum");
        }

        public static readonly MesspreistypEnumConverter Singleton = new MesspreistypEnumConverter();
    }
}
