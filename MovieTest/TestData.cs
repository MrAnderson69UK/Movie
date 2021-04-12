using System;
using System.Collections.Generic;
using Movie.DataModels;
using Movie.Models;

namespace MovieTest
{
    public class TestData
    {
        #region Data Layert Data

        public List<Metadata> metadata = new List<Metadata>
        {
            { new Metadata() { Id = 1, MovieId = 1, Title = "MOVIE 1", Language = "EN", Duration = new TimeSpan(01,49,00), ReleaseYear = 2013 } },
            { new Metadata() { Id = 2, MovieId = 1, Title = "Movie 1", Language = "AR", Duration = new TimeSpan(01,49,00), ReleaseYear = 2013 } },
            { new Metadata() { Id = 3, MovieId = 2, Title = "MOVIE 2", Language = "EN", Duration = new TimeSpan(02,45,00), ReleaseYear = 2012 } },
            { new Metadata() { Id = 4, MovieId = 2, Title = " Movie2", Language = "RU", Duration = new TimeSpan(02,45,00), ReleaseYear = 2012 } },
            { new Metadata() { Id = 5, MovieId = 2, Title = "Movie 2", Language = "AR", Duration = new TimeSpan(02,45,00), ReleaseYear = 2012 } },
            { new Metadata() { Id = 6, MovieId = 3, Title = "Movie 3", Language = "AR", Duration = new TimeSpan(01,58,00), ReleaseYear = 2014 } },
            { new Metadata() { Id = 7, MovieId = 3, Title = "MOVIE 3", Language = "EN", Duration = new TimeSpan(01,58,00), ReleaseYear = 2014 } }
        };

        public List<Stats> stats = new List<Stats>
        {
            { new Stats() { MovieId = 1, watchDurationMs = 1000000 } },
            { new Stats() { MovieId = 1, watchDurationMs = 2000000 } },
            { new Stats() { MovieId = 2, watchDurationMs = 1000000 } },
            { new Stats() { MovieId = 2, watchDurationMs = 2000000 } },
            { new Stats() { MovieId = 2, watchDurationMs = 3000000 } },
            { new Stats() { MovieId = 3, watchDurationMs = 1000000 } },
            { new Stats() { MovieId = 3, watchDurationMs = 4000000 } }
        };

        public List<Metadata> updateMetadata = new List<Metadata>
        {
            { new Metadata() { MovieId = 1, Title = "TEST MOVIE 1", Language = "EN", Duration = new TimeSpan(01,35,00), ReleaseYear = 2010 } },
            //{ new MovieUpdateData() { MovieId = 1, Title = "Test Movie 1", Language = "AR", Duration = new TimeSpan(01,35,00), ReleaseYear = 2010 } },
            //{ new MovieUpdateData() { MovieId = 2, Title = "TEST MOVIE 2", Language = "EN", Duration = new TimeSpan(02,25,00), ReleaseYear = 2015 } },
            //{ new MovieUpdateData() { MovieId = 2, Title = " Test Movie2", Language = "RU", Duration = new TimeSpan(02,25,00), ReleaseYear = 2015 } },
            //{ new MovieUpdateData() { MovieId = 2, Title = "Test Movie 2", Language = "AR", Duration = new TimeSpan(02,25,00), ReleaseYear = 2015 } },
            //{ new MovieUpdateData() { MovieId = 3, Title = "Test Movie 3", Language = "AR", Duration = new TimeSpan(02,28,00), ReleaseYear = 2013 } },
            //{ new MovieUpdateData() { MovieId = 3, Title = "TEST MOVIE 3", Language = "EN", Duration = new TimeSpan(02,28,00), ReleaseYear = 2013 } }
        };

        #endregion

        #region Model Data

        public List<MovieMetadata> movieMetadata = new List<MovieMetadata>
        {
            { new MovieMetadata() { MovieId = 1, Title = "MOVIE 1", Language = "EN", Duration = "01:49:00", ReleaseYear = 2013 } },
            { new MovieMetadata() { MovieId = 1, Title = "Movie 1", Language = "AR", Duration = "01:49:00", ReleaseYear = 2013 } },
            { new MovieMetadata() { MovieId = 2, Title = "MOVIE 2", Language = "EN", Duration = "02:45:00", ReleaseYear = 2012 } },
            { new MovieMetadata() { MovieId = 2, Title = " Movie2", Language = "RU", Duration = "02:45:00", ReleaseYear = 2012 } },
            { new MovieMetadata() { MovieId = 2, Title = "Movie 2", Language = "AR", Duration = "02:45:00", ReleaseYear = 2012 } },
            { new MovieMetadata() { MovieId = 3, Title = "Movie 3", Language = "AR", Duration = "01:58:00", ReleaseYear = 2014 } },
            { new MovieMetadata() { MovieId = 3, Title = "MOVIE 3", Language = "EN", Duration = "01:58:00", ReleaseYear = 2014 } }
        };

        public List<MovieMetadataStats> movieStats = new List<MovieMetadataStats>
        {
            { new MovieMetadataStats() { MovieId = 1, AverageWatchDurationS = 1500000, ReleaseYear = 2012, Title = "Movie 1", Watches = 2} },
            { new MovieMetadataStats() { MovieId = 2, AverageWatchDurationS = 2000000, ReleaseYear = 2013, Title = "Movie 2", Watches = 3} },
            { new MovieMetadataStats() { MovieId = 3, AverageWatchDurationS = 2500000, ReleaseYear = 2014, Title = "Movie 3", Watches = 2} }
        };

        public List<MovieUpdateData> movieUpdateMetadata = new List<MovieUpdateData>
        {
            { new MovieUpdateData() { MovieId = 1, Title = "TEST MOVIE 1", Language = "EN", Duration = new TimeSpan(01,35,00), ReleaseYear = 2010 } },
            //{ new MovieUpdateData() { MovieId = 1, Title = "Test Movie 1", Language = "AR", Duration = new TimeSpan(01,35,00), ReleaseYear = 2010 } },
            //{ new MovieUpdateData() { MovieId = 2, Title = "TEST MOVIE 2", Language = "EN", Duration = new TimeSpan(02,25,00), ReleaseYear = 2015 } },
            //{ new MovieUpdateData() { MovieId = 2, Title = " Test Movie2", Language = "RU", Duration = new TimeSpan(02,25,00), ReleaseYear = 2015 } },
            //{ new MovieUpdateData() { MovieId = 2, Title = "Test Movie 2", Language = "AR", Duration = new TimeSpan(02,25,00), ReleaseYear = 2015 } },
            //{ new MovieUpdateData() { MovieId = 3, Title = "Test Movie 3", Language = "AR", Duration = new TimeSpan(02,28,00), ReleaseYear = 2013 } },
            //{ new MovieUpdateData() { MovieId = 3, Title = "TEST MOVIE 3", Language = "EN", Duration = new TimeSpan(02,28,00), ReleaseYear = 2013 } }
        };

        #endregion

    }
}
