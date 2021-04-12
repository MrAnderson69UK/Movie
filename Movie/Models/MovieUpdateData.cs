using System;
using CsvHelper.Configuration.Attributes;
using Movie.Common;

namespace Movie.Models
{
    // Presentation Model for /metadata POST endpoint
    public class MovieUpdateData
    {
        [Ignore]
        private DateTime duration { get; set; }

        [Index(0)]
        public int MovieId { get; set; }
        [Index(1)]
        public string Title { get; set; }
        [Index(2)]
        public string Language { get; set; }
        [Index(3)]
        public string Duration { get { return duration.ToString(Constants.DurationFormatString); } set { duration = DateTime.Parse(value); } }
        [Index(4)]
        public int ReleaseYear { get; set; }

        public override string ToString()
        {
            return $"Movie {MovieId}: Title: {Title}, Language: {Language}, Duration: {Duration:HH:mm:ss}, ReleaseYear: {ReleaseYear}";
        }

        public bool ValidateMovieData()
        {
            return MovieId != 0
                && !string.IsNullOrWhiteSpace(Title)
                && !string.IsNullOrWhiteSpace(Language)
                && DateTime.TryParse(Duration, out var duration) && duration.TimeOfDay > new TimeSpan(0)
                && ReleaseYear >= Constants.EarliestMotionPicture;
        }


    }
}