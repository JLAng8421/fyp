using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var users = _context.Users.ToList().Select(s => s.ToUserDto());

            return Ok(users);
        }

        // To retrieve specific user with id
        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
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
            var userModel = userDto.ToCreateUserRequestDto();
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new {id = userModel.UserID}, userModel.ToUserDto());
        }

        // To update a user's info
        // PUT: api/user
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUserInfo([FromRoute] int id, [FromBody] UpdateUserRequestDto updateDto)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.UserID == id);

            if (userModel == null)
            {
                return NotFound();
            }

            userModel.Username = updateDto.Username;
            userModel.ContactNumber = updateDto.ContactNumber;
            userModel.Email = updateDto.Email;
            userModel.Password = updateDto.Password;

            _context.SaveChanges();

            return Ok(userModel.ToUserDto());
        }

        // To delete a user
        // Delete: api/user
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteUser([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserID == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            
            return NoContent();
        } 
    }
}