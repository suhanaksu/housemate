using AutoMapper;
using Core.DTOs.User;
using Core.Entities;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly DbSet<User> _users;
        public UserService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _users = dbContext.Set<User>();
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);
            await _users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(UpdateUserDto updateUserDto, int id)
        {
            var user = await _users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("Kullanıcı Bulunamadı!");
            }
            var updateUser = _mapper.Map(updateUserDto, user);
            _users.Update(updateUser);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<UserDto>(updateUser);
        }
    }
}
