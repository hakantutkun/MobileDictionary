using MobileDictionary.Helpers;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            switch (Settings.Theme)
            {
                case 0:
                    radioSystem.IsChecked = true;
                    break;
                case 1:
                    radioLight.IsChecked = true;
                    break;
                case 2:
                    radioDark.IsChecked = true;
                    break;
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void RadioSystemTapped(object sender, EventArgs e)
        {
            radioSystem.IsChecked = true;
            radioLight.IsChecked = false;
            radioDark.IsChecked = false;

            Settings.Theme = 0;

            TheTheme.SetTheme();
        }

        private void RadioLightTapped(object sender, EventArgs e)
        {
            radioLight.IsChecked = true;
            radioSystem.IsChecked = false;
            radioDark.IsChecked = false;
            Settings.Theme = 1;

            TheTheme.SetTheme();
        }

        private void RadioDarkTapped(object sender, EventArgs e)
        {
            radioDark.IsChecked = true;
            radioSystem.IsChecked = false;
            radioLight.IsChecked = false;
            Settings.Theme = 2;

            TheTheme.SetTheme();
        }
    }
}