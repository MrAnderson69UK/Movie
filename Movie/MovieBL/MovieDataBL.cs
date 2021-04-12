using System;
using System.Collections.Generic;
using System.Linq;
using Movie.DataAccess;
using Movie.DataModels;
using Movie.Models;

namespace Movie.MovieBL
{
    public class MovieDataBL : IMovieDataBL
    {
        private readonly IMovieDataReader _movieDataReader;
        private readonly IMovieDataWriter _movieDataWriter;

        public MovieDataBL(IMovieDataReader movieDataReader, IMovieDataWriter movieDataWriter)
        {
            _movieDataReader = movieDataReader;
            _movieDataWriter = movieDataWriter;
        }

        public IEnumerable<MovieMetadata> GetMovieData(int? id = null)
        {
            try
            {
                var metadata = _movieDataReader.GetMovieData(id);
                var model = FilterMovies(metadata, id);

                return SortMetadataModel(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return SortMetadataModel(new List<MovieMetadata>());
        }

        public IEnumerable<MovieMetadataStats> GetMovieStats()
        {
            try
            {
                var metadata = _movieDataReader.GetMovieData();
                var stats = _movieDataReader.GetMovieStats();
                var model = MergeMovieStats(metadata, stats);

                return SortStatsModel(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return SortStatsModel(new List<MovieMetadataStats>());
        }

        public bool SaveMovieData(MovieUpdateData movieUpdateData)
        {
            var metadata = new List<Metadata>();
            metadata.Add(
                new Metadata
                {
                    MovieId = movieUpdateData.MovieId,
                    Title = movieUpdateData.Title,
                    Language = movieUpdateData.Language,
                    Duration = DateTime.TryParse(movieUpdateData.Duration, out var duration) ? duration.TimeOfDay : new TimeSpan(0),
                    ReleaseYear = movieUpdateData.ReleaseYear
                });

            var result = _movieDataWriter.SaveMovieData(metadata);
            return result > 0;
        }


        public IEnumerable<MovieMetadata> FilterMovies(IEnumerable<Metadata> metadata, int? id)
        {
            if (!id.HasValue)
                return new List<MovieMetadata>();

            var filteredById = metadata.Where(m => m.MovieId == id && m.ValidateMovieData()).OrderByDescending(m => m.Id);
            var latest = filteredById.GroupBy(m => m.Language).Select(g => g.First());

            // project to metadata presentation model
            var model = latest.Select(m => new MovieMetadata { MovieId = m.MovieId, Title = m.Title, Language = m.Language, Duration = $"{m.Duration.Hours}:{m.Duration.Minutes}:{m.Duration.Seconds}", ReleaseYear = m.ReleaseYear });
            return model;
        }

        public IEnumerable<MovieMetadataStats> MergeMovieStats(IEnumerable<Metadata> metadata, IEnumerable<Stats> movieStats)
        {
            // Project to stats presentation model with calculated average watch duration and watch count

            // calculate averege watch duration and watch count 
            var movieMetadataStats = movieStats.GroupBy(m => m.MovieId).
                Select(g => new MovieMetadataStats
                {
                    MovieId = g.Key,
                    Watches = g.Count(),
                    AverageWatchDurationS = g.Sum(gs => gs.watchDurationMs) / g.Count()
                });

            // project to stats presentation model 
            var model = movieMetadataStats.Join(
                metadata,
                s => s.MovieId,
                m => m.MovieId,
                (s, m) => new MovieMetadataStats
                {
                    MovieId = m.MovieId,
                    Title = m.Title,
                    AverageWatchDurationS = s.AverageWatchDurationS,
                    Watches = s.Watches,
                    ReleaseYear = m.ReleaseYear
                });

            return model;
        }

        public IEnumerable<MovieMetadata> SortMetadataModel(IEnumerable<MovieMetadata> model)
        {
            // order the model by movie language
            var result = model.OrderBy(m => m.Language).ToList();
            return result;
        }

        public IEnumerable<MovieMetadataStats> SortStatsModel(IEnumerable<MovieMetadataStats> model)
        {
            // order the model most watched, then by most recently released
            var result = model.OrderByDescending(msd => msd.Watches).ThenByDescending(msd => msd.ReleaseYear);
            return result.ToList();
        }
    }
}
