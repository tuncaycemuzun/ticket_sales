﻿using Core.Abstract;
using Core.Concrete;
using Data.Settings;
using Microsoft.Extensions.Options;

namespace Data.Repositories
{
    public class UserRepository : MongoDbRepositoryBase<User>,IUserRepository
    {
        public UserRepository(IOptions<MongoDbSettings> options) : base(options)
        {
        }
    }
}
