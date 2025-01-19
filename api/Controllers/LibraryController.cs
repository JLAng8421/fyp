// Programmer Name  : Ang Jia Liang TP068299
// Program Name     : LibraryController.cs
// Description      : The api controller for library
// First Written on : 10-Dec-2024
// Edited on        : 22-Dec-2024

using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public LibraryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // To retrieve all library
        // GET: api/library
        [HttpGet]
        public IActionResult GetAll()
        {
            var librarys = _context.Library.ToList(); // To retrieve the library data from db and convert it to list

            return Ok(librarys);
        }

        // To retrieve specific library with id
        // GET: api/library/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var library = _context.Library.Find(id); // To search for a data with id in db

            if (library == null) // return not found if the there is no result
            {
                return NotFound();
            }

            return Ok(library);
        }
    }
}