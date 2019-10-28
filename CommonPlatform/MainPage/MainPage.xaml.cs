using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CommonPlatform
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private Button openUriButton;
        private Button startTimerButton;
        private Button marshalUIThreadButton;
        private Button displayAlertButton;
        private Button displayActionSheetButton;
        private Button openMapButton;
        private StackLayout stackLayout;

        public MainPage()
        {
            openUriButton = new Button
            {
                Text = "Otwórz Xamarin Evolve"
            };
            startTimerButton = new Button
            {
                Text = "Uruchom Stoper"
            };
            marshalUIThreadButton = new Button
            {
                Text = "Uruchom w głównym wątku"
            };
            displayAlertButton = new Button
            {
                Text = "Wyświetl komunikat"
            };
            displayActionSheetButton = new Button
            {
                Text = "Wyświetl listę akcji"
            };
            openMapButton = new Button
            {
                Text = "Otwórz mapę"
            };
            openUriButton.Clicked += OpenUriButton_Clicked;
            startTimerButton.Clicked += StartTimerButton_Clicked;
            marshalUIThreadButton.Clicked += MarshalUIThreadButton_Clicked;
            displayAlertButton.Clicked += DisplayAlertButton_Clicked;
            displayActionSheetButton.Clicked += DisplayActionSheetButton_Clicked;
            openMapButton.Clicked += OpenMapButton_Clicked;

            stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                Padding = new Thickness(10),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    openUriButton,
                    startTimerButton,
                    marshalUIThreadButton,
                    displayAlertButton,
                    displayActionSheetButton,
                    openMapButton
                }
            };
            Content = stackLayout;
        }

        void OpenMapButton_Clicked (object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CustomPages.MapPage());
        }

        async void DisplayActionSheetButton_Clicked (object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Prosta lista akcji", "Anuluj", "Usuń",
                new string[]
                {
                    "Akcja 1",
                    "Akcja 2",
                    "Akcja 3",
                });
            Debug.WriteLine("Kliknąłeś {0}", action);
        }

        async void DisplayAlertButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Prosty komunikat", "Super!", "OK", "Anuluj");
            Debug.WriteLine("Kliknięty przycisk: {0}", result ? "OK" : "Anuluj");
        }

        void MarshalUIThreadButton_Clicked(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                for (int i = 0; i < 3; i++)
                {
                    await Task.Delay(1000);
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        marshalUIThreadButton.Text = string.Format("Wywołany {0}", i);
                    });
                }
            });
        }

        void StartTimerButton_Clicked(object sender, EventArgs e)
        {
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Debug.WriteLine("Wywołany delegat stopera");
                return true;
            });
        }

        void OpenUriButton_Clicked(object sender, EventArgs e)
        {
            Launcher.OpenAsync(new Uri("http://xamarin.com/evolve"));
        }
    }
}
