using System;
using Newtonsoft.Json.Converters;

namespace Movie.Common
{
    public class DurationDateTimeToTimeConverter : IsoDateTimeConverter
    {
        public DurationDateTimeToTimeConverter()
        {
            DateTimeFormat = "o";
        }

        public DurationDateTimeToTimeConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}	
