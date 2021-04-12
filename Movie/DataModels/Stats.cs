using System;
using CsvHelper.Configuration.Attributes;

namespace Movie.DataModels
{
    // Data Layer Model for datasource "stats.csv"
    public class Stats
    {
        [Index(0)]
        public int MovieId { get; set; }
        [Index(1)]
        public long watchDurationMs { get; set; }

        public override string ToString()
        {
            return $"Movie {MovieId}: watchDurationMs: {watchDurationMs}";
        }

        public bool ValidateStatsData()
        {
            return MovieId != 0 && watchDurationMs >= 0;
        }
    }
}