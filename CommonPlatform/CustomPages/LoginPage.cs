using CommonPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CommonPlatform.CustomPages
{
    public class LoginPage : ContentPage
    {
       public OAuthSettings ProviderOAuthSettings { get; set; }
       public LoginPage(Provider provider)
        {
            ProviderOAuthSettings = ProviderManager.GetProviderOAuthSettings(provider);
        }
    }
}