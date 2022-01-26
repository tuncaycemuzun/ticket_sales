using Core.Dtos;
using Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IUserService
    {
        Task<DataResult<UserDto>> AddAsync(CreateUserDto createUserDto);
    }
}
