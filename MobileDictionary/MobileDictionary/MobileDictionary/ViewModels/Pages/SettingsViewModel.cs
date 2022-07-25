using MobileDictionary.Helpers;
using MobileDictionary.ViewModels.Base;

namespace MobileDictionary.ViewModels.Pages
{
    public class SettingsViewModel : BasePageViewModel<SettingsViewModel>
    {
        #region Members

        /// <summary>
        /// System theme checked flag
        /// </summary>
        private bool _systemThemeChecked;

        public bool SystemThemeChecked
        {
            get { return _systemThemeChecked; }
            set { _systemThemeChecked = value; OnPropertyChanged(nameof(SystemThemeChecked)); }
        }

        /// <summary>
        /// Light theme checked flag
        /// </summary>
        private bool _lightThemeChecked;

        public bool LightThemeChecked
        {
            get { return _lightThemeChecked; }
            set { _lightThemeChecked = value; OnPropertyChanged(nameof(LightThemeChecked)); }
        }

        /// <summary>
        /// Dark theme checked flag
        /// </summary>
        private bool _darkThemeChecked;

        public bool DarkThemeChecked
        {
            get { return _darkThemeChecked; }
            set { _darkThemeChecked = value; OnPropertyChanged(nameof(DarkThemeChecked)); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        public SettingsViewModel()
        {
            // Set selected theme
            switch (Settings.Theme)
            {
                case 0:
                    SystemThemeChecked = true;
                    break;
                case 1:
                    LightThemeChecked = true;
                    break;
                case 2:
                    DarkThemeChecked = true;
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
