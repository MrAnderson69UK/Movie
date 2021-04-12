using CsvHelper.Configuration;
using CsvHelper;
using Movie.DataModels;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System;
using System.Linq;
using Movie.Common;
using Movie.Models;

namespace Movie.DataAccess
{
    public class MovieDataWriter : IMovieDataWriter
    {
        private readonly string _metadatSaveFilename = Constants.MetadataDataSaves;

        public MovieDataWriter()
        {
        }

        public int SaveMovieData(IEnumerable<Metadata> metadata)
        {
            try
            {
                if (metadata.Count() > 0)
                {
                    var success = WriteMovieData(metadata);
                    return success;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return 0;
        }

        #region Data Writer Helpers

        // method is virtual to allow Moq to mock the method in XUnit tests.
        public virtual int WriteMovieData(IEnumerable<Metadata> metadata)
        {
            // Check if the save file exists, if not create it.
            if (!File.Exists(_metadatSaveFilename))
                File.CreateText(_metadatSaveFilename);

            using (var fs = new StreamWriter(_metadatSaveFilename, true, Encoding.UTF8))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    PrepareHeaderForMatch = args => args.Header.ToLower(),
                    Delimiter = ",",
                    Encoding = Encoding.Unicode
                };
                new CsvWriter(fs, config).WriteRecords<Metadata>(metadata);
                return metadata.Count();
            }
        }

        #endregion
    }

}
