using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var librarys = _context.Library.ToList();

            return Ok(librarys);
        }

        // To retrieve specific library with id
        // GET: api/library/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var library = _context.Library.Find(id);

            if (library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }
    }
}