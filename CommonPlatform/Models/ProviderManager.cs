using System;
using System.Collections.Generic;
using System.Text;

namespace CommonPlatform.Models
{
    public enum Provider
    {
        Unknown = 0,
        Facebook,
        Google
    }

    public static class ProviderManager
    {
        private static OAuthSettings FacebookOAuthSettings
        {
            get
            {
                return new OAuthSettings
                {
                    ClientId = "Twój_Id_Kliencki",
                    ClientSecret = "Twoje_hasło_klienckie",
                    AuthorizeUrl = "https://m.facebook.com/dialog/oauth/",
                    RedirectUrl = "https://www.facebook.com/connect/login_success.html",
                    AccessTokenUrl = "https://graph.fcebook.com/v2.3/oauth/access_token",
                    Scopes = new List<string>
                        {
                            ""
                        }
                };
            }
        }
        private static OAuthSettings GoogleOAuthSettings
        {
            get
            {
                return new OAuthSettings
                {
                    ClientId = "Twój_Id_Kliencki",
                    ClientSecret = "Twoje_hasło_klienckie",
                    AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth",
                    RedirectUrl = "https://googleapis.com/plus/v1/people/me",
                    AccessTokenUrl = "https://accounts.google.com/o/oauth2/token",
                    Scopes = new List<string>
                        {
                            "openid"
                        }
                };
            }
        }
        public static OAuthSettings GetProviderOAuthSettings(Provider provider)
        {
            switch(provider)
            {
                case Provider.Facebook:
                    {
                        return FacebookOAuthSettings;
                    }
                case Provider.Google:
                    {
                        return GoogleOAuthSettings;
                    }
            }
            return new OAuthSettings();
        }
    }
}
