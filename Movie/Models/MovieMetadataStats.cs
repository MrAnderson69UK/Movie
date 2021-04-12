using CsvHelper.Configuration.Attributes;

namespace Movie.Models
{
    // Presentation Model for /metadata/stats GET endpoint
    public class MovieMetadataStats
    {
        [Index(0)]
        public int MovieId { get; set; }
        [Index(1)]
        public string Title { get; set; }
        [Index(2)]
        public double AverageWatchDurationS { get; set; }
        [Index(4)]
        public long Watches { get; set; }
        [Index(5)]
        public int ReleaseYear { get; set; }

        public override string ToString()
        {
            return $"Movie {MovieId}: Title: {Title}, AverageWatchDurationS: {AverageWatchDurationS}, watches: {Watches}, ReleaseYear: {ReleaseYear}";
        }
    }
}