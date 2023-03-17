using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace DataRepository.ConverterJson
{
    /*
        code used from -> "https://app.quicktype.io/"
     */
    public class Converter
    {
        public static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings
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
