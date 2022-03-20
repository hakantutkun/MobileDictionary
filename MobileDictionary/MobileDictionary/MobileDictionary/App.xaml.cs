using Xamarin.Forms;

namespace MobileDictionary
{
    public partial class App : Application
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public App()
        {
            InitializeComponent();

            // Set the main page
            MainPage = new MainPage();
        }

        #endregion

        #region Methods

        /// <summary>
        /// On Start
        /// </summary>
        protected override void OnStart() { }

        /// <summary>
        /// On Sleep
        /// </summary>
        protected override void OnSleep() { }

        /// <summary>
        /// On Resume
        /// </summary>
        protected override void OnResume() { }

        #endregion
    }
}
