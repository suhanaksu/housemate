using Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        public Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        public Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto, int id);
    }
}
