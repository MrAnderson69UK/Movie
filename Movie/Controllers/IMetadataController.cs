using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    public interface IMetadataController
    {
        public IActionResult GetById(int? id);
        public IActionResult GetStats();
    } 
}