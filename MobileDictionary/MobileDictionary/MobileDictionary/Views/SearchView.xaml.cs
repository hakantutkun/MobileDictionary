using MobileDictionary.Models;
using MobileDictionary.Pages;
using MobileDictionary.ViewModels.Pages;
using MobileDictionary.ViewModels.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentView
    {
        ObservableCollection<Kelime> wordList = new ObservableCollection<Kelime>();

        public SearchView()
        {
            try
            {
                InitializeComponent();

                BindingContext = new SearchViewModel();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void searchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                await ((SearchViewModel)BindingContext).SearchLikeAsync((sender as Entry).Text);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async void CopyLabel_Tapped(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(searchEntry.Text);
            MainPageViewModel.Instance.DisplayPopup("Bilgi", "İçerik başarıyla kopyalandı.");
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;
            if (viewCell.View != null)
            {
                if (Application.Current.UserAppTheme == OSAppTheme.Dark)
                {
                    viewCell.View.BackgroundColor = Color.DarkGray;
                }
                else
                {
                    viewCell.View.BackgroundColor = Color.LightGray;
                }
            }
        }

        private async void AllWordsGrid_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AllWordsPage());
        }

        private async void SettingsGrid_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SettingsPage());
        }

        private async void wordListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView item = sender as ListView;

            var kelime = (Kelime)item.SelectedItem;

            await ((SearchViewModel)BindingContext).SetDetails(kelime);

            await Navigation.PushModalAsync(new DetailPage());
        }
    }
}