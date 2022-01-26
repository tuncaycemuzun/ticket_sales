using Core.Dtos;
using Shared.Utilities.Results.Abstract;
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
        Task<IDataResult<UserDto>> AddAsync(CreateUserDto createUserDto);
        Task<IDataResult<TokenDto>> CreateToken(LoginDto loginDto);
    }
}
