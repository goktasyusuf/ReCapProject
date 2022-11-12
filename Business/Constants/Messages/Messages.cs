using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class Messages
    {
        public static string UserNotFound = "Kullanıcı Bulunamadı.";
        internal static string TokenCreated = "Token Oluşturuldu.";
        internal static string WrongPassword = "Parola Hatası.";
        internal static string SuccessfullyLogin = "Başarıyla Giriş Yapıldı.";
        internal static string SuccessfullySignedIn = "Başarıyla Kayıt Olundu.";
        internal static string UserAlreadyExists = "Kullanıcı Zaten Mevcut.";
        internal static string ImageSuccessfullyUpdated = "Resim Başarıyla Yüklendi.";
        internal static string CarAdded = "Araba Eklendi.";
        internal static string AccessDenied = "Erişim Reddedildi.";
    }
}
