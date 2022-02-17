using Core.Abstract;
using Core.Concrete;
using Core.Dtos;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Extensions;
using Services.Helpers;
using Shared.Utilities.Results.Abstract;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Services.Concrete
{

    public class UserService : IUserService
    {

        private readonly IUserRepository _user;
        private readonly ITokenRepository _token;
        private readonly JwtSettings _jwtSetting;
        public UserService(IUserRepository user, IConfiguration configuration, ITokenRepository token, JwtSettings jwtSetting)
        {
            _user = user;
            _token = token;
            _jwtSetting = jwtSetting;
        }
        public async Task<IDataResult<UserDto>> AddAsync(CreateUserDto createUserDto)
        {

            var user = ObjectMapper.Mapper.Map<User>(createUserDto);
            MD5 md5Hash = MD5.Create();
            string hash = Tools.GetMd5Hash(md5Hash, user.Password);
            user.Password = hash;
            await _user.AddAsync(user);
            return new DataResult<UserDto>(ResultCode.Success, Messages.User.SuccessCreate(), new UserDto
            {
                Email = user.Email,
                Id = user.Id.ToString(),
                UserName = user.FirstName
            });
        }
        public async Task<IDataResult<TokenDto>> CreateToken(LoginDto loginDto)
        {
           
            MD5 md5Hash = MD5.Create();
            var hashPass = Tools.GetMd5Hash(md5Hash, loginDto.Password);
            var user = await _user.GetAsync(x => x.Email == loginDto.Email && x.Password == hashPass);
            //var userId = await 
            if (user == null) return new DataResult<TokenDto>(ResultCode.NoContent, Messages.User.LoginError());
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtSetting.IssuerSigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Roles[0]),
                    new Claim(ClaimTypes.Email,user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var hasToken = await _token.DeleteAsync(x => x.UserId == user.Id);
            UserToken userToken = new UserToken();
            userToken.AccessToken = tokenHandler.WriteToken(token);
            userToken.AccessTokenExpiration = (DateTime)tokenDescriptor.Expires;
            userToken.RefreshToken = GetRefreshToken();
            userToken.RefreshTokenExpiration = DateTime.UtcNow.AddDays(1);
            userToken.UserId = user.Id;
            await _token.AddAsync(userToken);
            var tokenDto = ObjectMapper.Mapper.Map<TokenDto>(userToken);
            return new DataResult<TokenDto>(ResultCode.Success, Messages.User.LoginSuccess(), tokenDto);

        }
        public async Task<IDataResult<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var tokenEntity = await _token.GetAsync(x => x.RefreshToken == refreshToken);
            if (tokenEntity == null) return new DataResult<TokenDto>(ResultCode.NoContent, Messages.User.InvalidRefreshToken());
            var user = await _user.GetAsync(x => x.Id == tokenEntity.UserId);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_jwtSetting.IssuerSigningKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Role,user.Roles[0]),
                    new Claim(ClaimTypes.Email,user.Email),
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            tokenEntity.AccessToken = tokenHandler.WriteToken(token);
            tokenEntity.AccessTokenExpiration = (DateTime)tokenDescriptor.Expires;
            tokenEntity.RefreshToken = GetRefreshToken();
            tokenEntity.RefreshTokenExpiration = DateTime.UtcNow.AddDays(1);
            await _token.UpdateAsync(tokenEntity, x => x.UserId == user.Id);
            tokenEntity = await _token.GetAsync(x => x.RefreshToken == tokenEntity.RefreshToken);
            return new DataResult<TokenDto>(ResultCode.Success, Messages.User.LoginSuccess(), new TokenDto
            {
                AccessToken = tokenEntity.AccessToken,
                AccessTokenExpiration = tokenEntity.AccessTokenExpiration,
                RefreshToken = tokenEntity.RefreshToken,
                RefreshTokenExpiration = tokenEntity.RefreshTokenExpiration
            });
        }
        public async Task<Result> RevokeToken(UserToken token)
        {
            await _token.DeleteAsync(token);
            return new Result(ResultCode.Success);
        }
        public string GetRefreshToken()
        {
            var key = new Byte[32];
            using (var refreshTokenGenerator = RandomNumberGenerator.Create())
            {
                refreshTokenGenerator.GetBytes(key);
                return Convert.ToBase64String(key);
            }
        }

    }
}
