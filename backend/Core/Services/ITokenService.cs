using Core.Concrete;
using Core.Configuration;
using Core.Dtos;

namespace Core.Services
{
    public interface ITokenService
    {
        TokenDto CreateToken(User user);
        ClientTokenDto CreteTokenByClient(Client client);
    }
}
