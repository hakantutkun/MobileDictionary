using Xamarin.Essentials;

namespace MobileDictionary.Helpers
{
    /// <summary>
    /// Settings of the application
    /// </summary>
    public static class Settings
    {
        #region Members

        /// <summary>
        /// Theme selection
        /// 0 = default, 1 = light, 2 = dark
        /// </summary>
        const int theme = 0;

        /// <summary>
        /// Save number of words to preferences once program started...
        /// </summary>
        const int numberOfWords = 0;

        /// <summary>
        /// Theme
        /// </summary>
        public static int Theme
        {
            get => Preferences.Get(nameof(Theme), theme);
            set => Preferences.Set(nameof(Theme), value);
        }

        /// <summary>
        /// Number of words
        /// </summary>
        public static int NumberOfWords
        {
            get => Preferences.Get(nameof(NumberOfWords), numberOfWords);
            set => Preferences.Set(nameof(NumberOfWords), value);
        }

        #endregion
    }
}
