using MobileDictionary.Helpers;
using MobileDictionary.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileDictionary
{
    /// <summary>
    /// Application Main Class
    /// </summary>
    public partial class App : Application
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
            // Initialize
            InitializeComponent();

            // Activate sharpnado
            Sharpnado.Tabs.Initializer.Initialize(false, false);
            Sharpnado.Shades.Initializer.Initialize(loggerEnable: false);

            // Set the theme 
            TheTheme.SetTheme();

            // Set the main page when application started
            MainPage = new NavigationPage(new MainPage());
        }

        #endregion

        #region Methods

        /// <summary>
        /// On Start Method
        /// </summary>
        protected override void OnStart()
        {
            OnResume();
        }

        /// <summary>
        /// On Sleep Method
        /// </summary>
        protected override void OnSleep()
        {
            // Set theme
            TheTheme.SetTheme();
            
            // Unhook from event.
            RequestedThemeChanged -= App_RequestThemeChanged;
        }

        /// <summary>
        /// On Resume Method
        /// </summary>
        protected override void OnResume()
        {
            // Set theme
            TheTheme.SetTheme();
            
            // Hook to event
            RequestedThemeChanged += App_RequestThemeChanged;
        }

        /// <summary>
        /// Fires when application theme change request received.
        /// </summary>
        private void App_RequestThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                // Change current theme
                OSAppTheme currentTheme = Current.RequestedTheme;

                // Set the theme
                TheTheme.SetTheme();
            });
        }

        #endregion
    }
}
