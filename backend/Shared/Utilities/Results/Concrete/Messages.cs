using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utilities.Results.Concrete
{
    public static class Messages
    {
        public static class User
        {
            public static string SuccessCreate()
            {
                return "Hesabınız başarı ile oluşturuldu";
            }
            public static string LoginError()
            {
                return "Email veya Şifre Hatalı";
            }
            public static string LoginSuccess()
            {
                return "Giriş İşlemi Başarılı";
            }
            public static string InvalidRefreshToken()
            {
                return "Refresh Token Geçerli Değil";
            }
        }
    }
}
