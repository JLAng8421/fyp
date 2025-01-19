// Programmer Name  : Ang Jia Liang TP068299
// Program Name     : UserController.cs
// Description      : The api controller for user
// First Written on : 10-Dec-2024
// Edited on        : 20-Dec-2024

using api.Data;
using api.Dtos.User;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        // To retrieve all user
        // GET: api/user
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList().Select(s => s.ToUserDto()); // To retrieve the data from db and convert it to list and filter with Dtos

            return Ok(users);
        }

        // To retrieve specific user with id
        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Find(id); // To search for a data with id in db

            if (user == null) // return not found if the there is no result
            {
                return NotFound();
            }

            return Ok(user.ToUserDto());
        }

        // To add a user
        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequestDto userDto)
        {
            var userModel = userDto.ToCreateUserRequestDto(); // convert the input into preset dtos
            _context.Users.Add(userModel); // add the input to the db
            _context.SaveChanges(); // save the changes
            return CreatedAtAction(nameof(GetById), new {id = userModel.UserID}, userModel.ToUserDto()); // return the saved data
        }

        // To update a user's info
        // PUT: api/user
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUserInfo([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.UserID == id); // To search for a data with id in db

            if (userModel == null) // return not found if the there is no result
            {
                return NotFound();
            }

            userModel.Username = updateDto.Username; // update the data
            userModel.ContactNumber = updateDto.ContactNumber; // update the data
            userModel.Email = updateDto.Email; // update the data
            userModel.Password = updateDto.Password; // update the data

            _context.SaveChanges(); // save the changes

            return Ok(userModel.ToUserDto());
        }

        // To delete a user
        // Delete: api/user
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserID == id); // To search for a data with id in db

            if (user == null)  // return not found if the there is no result
            {
                return NotFound();
            }

            _context.Users.Remove(user); // delete the selected data
            _context.SaveChanges(); // save the changes
            
            return NoContent();
        } 
    }
}