using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                UserID = userModel.UserID,
                Username = userModel.Username,
                ContactNumber = userModel.ContactNumber,
                Email = userModel.Email,
                Password = userModel.Password
            };
        }

        public static User ToCreateUserRequestDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Username = userDto.Username,
                ContactNumber = userDto.ContactNumber,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }
    }
}