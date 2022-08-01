using MobileDictionary.Models;
using MobileDictionary.Pages;
using MobileDictionary.ViewModels.Pages;
using MobileDictionary.ViewModels.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentView
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchView()
        {
            InitializeComponent();

            // Set binding context
            BindingContext = SearchViewModel.Instance;
        }

        /// <summary>
        /// Fired when search box entry changed every time.
        /// </summary>
        private async void searchEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Search current content
            await ((SearchViewModel)BindingContext).SearchLikeAsync((sender as Entry).Text);
        }

        /// <summary>
        /// Fired when copy label tapped.
        /// </summary>
        private async void CopyLabel_Tapped(object sender, EventArgs e)
        {
            // Copy content to the clipboard.
            await Clipboard.SetTextAsync(searchEntry.Text);

            // Display an information popup.
            MainPageViewModel.Instance.DisplayPopup("Bilgi", "İçerik başarıyla kopyalandı.");
        }

        /// <summary>
        /// Fired when all words grid tapped.
        /// </summary>
        private async void AllWordsGrid_Tapped(object sender, EventArgs e)
        {
            // Navigate to all words page.
            await Navigation.PushModalAsync(new AllWordsPage());
        }

        /// <summary>
        /// Fired when settings grid tapped.
        /// </summary>
        private async void SettingsGrid_Tapped(object sender, EventArgs e)
        {
            // Navigate to settings page.
            await Navigation.PushModalAsync(new SettingsPage());
        }

        /// <summary>
        /// Fired when an item selected from list view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void wordListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Catch list view
            ListView item = sender as ListView;

            // get selected item.
            var kelime = (Kelime)item.SelectedItem;

            // Set the details for details page.
            await ((SearchViewModel)BindingContext).SetDetails(kelime);

            // Then, navigate to details page.
            await Navigation.PushModalAsync(new DetailPage());
        }
    }
}