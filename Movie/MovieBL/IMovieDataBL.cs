using System.Collections.Generic;
using Movie.Models;

namespace Movie.MovieBL

{
    public interface IMovieDataBL
    {
        IEnumerable<MovieMetadata> GetMovieData(int? id = null);
        IEnumerable<MovieMetadataStats> GetMovieStats();
        bool SaveMovieData(MovieUpdateData movieUpdateData);
    }
}