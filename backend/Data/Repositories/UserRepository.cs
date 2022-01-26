using Core.Abstract;
using Core.Concrete;
using Data.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : MongoDbRepositoryBase<User>,IUserRepository
    {
        public UserRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
