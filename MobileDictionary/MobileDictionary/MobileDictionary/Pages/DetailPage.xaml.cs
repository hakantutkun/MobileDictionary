using MobileDictionary.ViewModels.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileDictionary.Pages
{
    /// <summary>
    /// Detail page that selected word information displayed.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DetailPage()
        {
            // Set the binding context instance
            BindingContext = DetailPageViewModel.Instance;

            // Initialize components
            InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Closes the detail page. Goes back to the previous page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
            TabHost.SelectedIndex = 0;
        }

        #endregion
    }
}