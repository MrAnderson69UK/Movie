using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Movie.Common;
using Movie.DataModels;

namespace Movie.DataAccess  
{
    public class MovieDataReader : IMovieDataReader
    {
        private readonly string _metadataFilename = Constants.MetadataDataSource;
        private readonly string _statsFilename = Constants.StatsDataSource;

        private IEnumerable<Metadata> _metadata = new List<Metadata>();
        private IEnumerable<Stats> _movieStats = new List<Stats>();

        public MovieDataReader()
        {
        }

        public IEnumerable<Metadata> GetMovieData(int? id = null)
        {
            try
            {
                _metadata = LoadMovieData();
                return _metadata.Where(m => !id.HasValue || m.MovieId == id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new List<Metadata>();
        }

        public IEnumerable<Stats> GetMovieStats()
        {
            try
            {
                _movieStats = LoadMovieStats();
                return _movieStats;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new List<Stats>();
        }

        #region MovieData Helpers

        // method is virtual to allow Moq to mock the method in XUnit tests.
        public virtual IEnumerable<Metadata> LoadMovieData()
        {
            using (var fs = new StreamReader(_metadataFilename, true))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                    Delimiter = ",",
                    Encoding = Encoding.Unicode
                };
                var metadata = new CsvReader(fs, config).GetRecords<Metadata>().ToList();
                return metadata;
            }
        }

        #endregion

        #region MovieStats Helpers

        // method is virtual to allow Moq to mock the method in XUnit tests.
        public virtual IEnumerable<Stats> LoadMovieStats()
        {
            using (var fs = new StreamReader(_statsFilename, true))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                    Delimiter = ",",
                    Encoding = Encoding.Unicode
                };
                var movieStats = new CsvReader(fs, config).GetRecords<Stats>().ToList();
                return movieStats;
            }
        }

        #endregion
    }
}
