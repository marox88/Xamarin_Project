using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CommonPlatform.Droid.Platform_Specific
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageRenderer : ContentPage
    {
        public LoginPageRenderer()
        {
            InitializeComponent();
        }
    }
}