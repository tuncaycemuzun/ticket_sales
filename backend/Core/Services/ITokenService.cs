using Core.Concrete;
using Core.Configuration;
using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public  interface ITokenService
    {
        TokenDto CreateToken(User user);
        ClientTokenDto CreteTokenByClient(Client client);
    }
}
