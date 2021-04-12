using System;
using CsvHelper.Configuration.Attributes;
using Movie.Common;

namespace Movie.DataModels
{
    // Data Layer Model for datasource "metadata.csv"
    public class Metadata
    {
        [Index(0)]
        public int Id { get; set; }
        [Index(1)]
        public int MovieId { get; set; }
        [Index(2)]
        public string Title { get; set; }
        [Index(3)]
        public string Language { get; set; }
        [Index(4)]
        public TimeSpan Duration { get; set; }
        [Index(5)]
        public int ReleaseYear { get; set; }

        public override string ToString()
        {
            return $"Movie Id({Id}) {MovieId}: Title: {Title}, Language: {Language}, Duration: {Duration.Hours}:{Duration.Minutes}:{Duration.Seconds}, ReleaseYear: {ReleaseYear}";
        }

        public bool ValidateMovieData()
        {
            return MovieId != 0
                && !string.IsNullOrWhiteSpace(Title)
                && !string.IsNullOrWhiteSpace(Language)
                && Duration.TotalMilliseconds > 0
                && ReleaseYear >= Constants.EarliestMotionPicture;
        }


    }
}