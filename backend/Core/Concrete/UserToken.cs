using MongoDB.Bson;

namespace Core.Concrete
{
    public class UserToken : BaseEntity
    {
        public ObjectId UserId { get; set; }
        public string AccessToken{ get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }

    }
}
