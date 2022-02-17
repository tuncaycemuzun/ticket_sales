using Core.Concrete;
using Core.Dtos;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.Concrete;

namespace Core.Services
{
    public interface IUserService
    {
        Task<IDataResult<UserDto>> AddAsync(CreateUserDto createUserDto);
        Task<IDataResult<TokenDto>> CreateToken(LoginDto loginDto);
        Task<IDataResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Result> RevokeToken(UserToken token);
    }
}
