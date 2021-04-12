using Microsoft.AspNetCore.Mvc;

namespace Movie.Controllers
{
    public interface IMetadataController
    {
        IActionResult GetById(int? id);
        IActionResult GetStats();
    } 
}