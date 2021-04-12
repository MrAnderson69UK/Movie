using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Movie.Models;
using Movie.MovieBL;

namespace Movie.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MetadataController : ControllerBase, IMetadataController
    {
        private readonly IMovieDataBL _movieDataBL;

        public MetadataController(IMovieDataBL movieDataBL)
        {
            _movieDataBL = movieDataBL;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            var moviesResponseData = _movieDataBL.GetMovieData(id);
            if (moviesResponseData.Count() > 0)
                return Ok(moviesResponseData);

            if (id.HasValue)
                return NotFound();

            return Ok();
        }

        [HttpGet("stats")]
        public IActionResult GetStats()
        {
            var movieStatsResponseData = _movieDataBL.GetMovieStats();
            return Ok(movieStatsResponseData);
        }


        [HttpPost]
        public IActionResult Post([FromBody] MovieUpdateData movieUpdateData)
        {
            var moviesPostResponseData = _movieDataBL.SaveMovieData(movieUpdateData);
            return Ok(moviesPostResponseData);
        }

    }
}
