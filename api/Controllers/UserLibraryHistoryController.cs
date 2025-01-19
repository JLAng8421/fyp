// Programmer Name  : Ang Jia Liang TP068299
// Program Name     : UserLibraryHistoryController.cs
// Description      : The api controller for history
// First Written on : 10-Dec-2024
// Edited on        : 22-Dec-2024

using api.Data;
using api.Dtos.UserLibraryHistory;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/userlibraryhistory")]
    [ApiController]
    public class UserLibraryHistoryController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserLibraryHistoryController(ApplicationDBContext context)
        {
            _context = context;
        }

        // To retrieve all history
        // GET: api/userlibraryhistory
        [HttpGet]
        public IActionResult GetAll()
        {
            var historys = _context.UserLibrarHistory.ToList().Select(s => s.ToUserLibrarHistoryDto());  // To retrieve the data from db and convert it to list and filter with Dtos

            return Ok(historys);
        }

        // To retrieve specific history with id
        // GET: api/userlibraryhistory/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var history = _context.UserLibrarHistory.Find(id); // To search for a data with id in db

            if (history == null) // return not found if the there is no result
            {
                return NotFound();
            }

            return Ok(history.ToUserLibrarHistoryDto());
        }

        // To add a new history
        // POST: api/userlibraryhistory
        [HttpPost]
        public IActionResult CreateUserLibraryHistory([FromBody] CreateUserLibraryHistoryDto historyDto)
        {
            var historyModel = historyDto.ToCreateUserLibraryHistoryDto(); // convert the input into preset dtos
            _context.UserLibrarHistory.Add(historyModel); // add the input to the db
            _context.SaveChanges(); // save the changes
            return CreatedAtAction(nameof(GetById), new {id = historyModel.UserLibrarHistoryID}, historyModel.ToUserLibrarHistoryDto()); // return the saved data
        }
    }
}