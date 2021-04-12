using System.Collections.Generic;
using Movie.DataModels;
using Movie.Models;

namespace Movie.DataAccess
{
    public interface IMovieDataWriter
    {
        int SaveMovieData(IEnumerable<Metadata> metadata);
        int WriteMovieData(IEnumerable<Metadata> metadata);
    }
}
