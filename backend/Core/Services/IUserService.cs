using Core.Concrete;
using Core.Dtos;
using MongoDB.Bson;
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
        Task<UserToken> CreateToken(LoginDto loginDto);
        Task<IDataResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Result> RevokeToken(UserToken token);
    }
}
