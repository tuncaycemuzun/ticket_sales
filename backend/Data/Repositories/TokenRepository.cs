using Core.Abstract;
using Core.Concrete;
using Data.Settings;
using Microsoft.Extensions.Options;

namespace Data.Repositories
{
    public class TokenRepository : MongoDbRepositoryBase<UserToken>, ITokenRepository
    {
        public TokenRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
