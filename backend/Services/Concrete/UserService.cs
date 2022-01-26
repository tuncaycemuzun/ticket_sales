using Core.Abstract;
using Core.Concrete;
using Core.Dtos;
using Core.Services;
using Services.Extensions;
using Shared.Utilities.Results.ComplexTypes;
using Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{

    public class UserService : IUserService
    {
        private readonly IUserDal _user;

        public UserService(IUserDal user)
        {
            _user = user;
        }

        public async Task<DataResult<UserDto>> AddAsync(CreateUserDto createUserDto)
        {
            var user = ObjectMapper.Mapper.Map<User>(createUserDto);
            MD5 md5Hash = MD5.Create();
            string hash = Tools.GetMd5Hash(md5Hash, user.Password);
            user.Password = hash;
            await _user.AddAsync(user);
            return new DataResult<UserDto>(ResultCode.Error, "Başarılı", new UserDto
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.FirstName
            });
        }
    }
}
