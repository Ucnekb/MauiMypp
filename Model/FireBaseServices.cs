using Firebase.Auth;
using Firebase.Auth.Providers;
using System;
using System.Threading.Tasks;

namespace MauiMypp.Model
{
    public class FireBaseServices
    {
        static String project_id = "mauimyapp1-b924a";
        static String ApiKey = "AIzaSyBnTpPmXO6hgIGiJKR9UTJU4RP_oAF_XVg";
        static String AuthDomain = $"{project_id}.firebaseapp.com"; // Düzeltildi

        static FirebaseAuthConfig config = new FirebaseAuthConfig()
        {
            ApiKey = ApiKey,
            AuthDomain = AuthDomain,
            Providers = new[] { new EmailProvider() }
        };

        public static async Task<User> Login(string email, string pass)
        {
            try
            {
                var client = new FirebaseAuthClient(config);
                var res = await client.SignInWithEmailAndPasswordAsync(email, pass);
                return res.User;
            }
            catch (Exception ex)
            {
                // Hata mesajını yazdır veya logla
                Console.WriteLine($"Login hatası: {ex.Message}");
                return null;
            }
        }

        public static async Task<User> Register(string ad, string email, string pass)
        {
            try
            {
                var client = new FirebaseAuthClient(config);
                var res = await client.CreateUserWithEmailAndPasswordAsync(email, pass, ad);
                return res.User;
            }
            catch (Exception ex)
            {
                // Hata mesajını yazdır veya logla
                Console.WriteLine($"Register hatası: {ex.Message}");
                return null;
            }
        }
    }
}
