using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var historys = _context.UserLibrarHistory.ToList().Select(s => s.ToUserLibrarHistoryDto());

            return Ok(historys);
        }

        // To retrieve specific history with id
        // GET: api/userlibraryhistory/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var history = _context.UserLibrarHistory.Find(id);

            if (history == null)
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
            var historyModel = historyDto.ToCreateUserLibraryHistoryDto();
            _context.UserLibrarHistory.Add(historyModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = historyModel.UserLibrarHistoryID}, historyModel.ToUserLibrarHistoryDto());
        }
    }
}