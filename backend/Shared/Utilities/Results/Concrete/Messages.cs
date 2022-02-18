namespace Shared.Utilities.Results.Concrete
{
    public static class Messages
    {
        public static string Error()
        {
            return "Bir Hata İle Karşılaşıldı";
        }

        public static class Token
        {
            public static string NotFound()
            {
                return "token Bulunmadı";
            }
        }
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
            public static string NonUser()
            {
                return "Kullanıcı Bulunamadı";
            }
        }


        public static class Ticket
        {
            public static string BadGateway()
            {
                return "Bir Hata Oluştu";
            }
            public static string NotFound()
            {
                return "Bilet Bulunamadı";
            }
            public static string Success()
            {
                return "Bilet Başarıyla Silindi";
            }
        }
    }
}
