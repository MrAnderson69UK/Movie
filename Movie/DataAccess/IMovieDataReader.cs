using System.Collections.Generic;
using Movie.DataModels;

namespace Movie.DataAccess
{
    public interface IMovieDataReader
    {
        IEnumerable<Metadata> GetMovieData(int? id = null);
        IEnumerable<Stats> GetMovieStats();
        IEnumerable<Metadata> LoadMovieData();

    }
}