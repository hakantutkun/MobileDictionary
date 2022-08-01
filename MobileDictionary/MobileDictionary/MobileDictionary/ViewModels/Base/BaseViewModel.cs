using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace MobileDictionary.ViewModels.Base
{
    /// <summary>
    /// A Base ViewModel for all ViewModel Classes
    /// </summary>
    public class BaseViewModel<I> : INotifyPropertyChanged where I : class, new()
    {
        #region Singleton Implementation

        /// <summary>
        /// Singleton lock object
        /// </summary>
        private static readonly object lockObj = new object();

        /// <summary>
        /// Singleton instance
        /// </summary>
        private static I _instance;

        /// <summary>
        /// Instance Property
        /// </summary>
        public static I Instance
        {
            get
            {
                lock (lockObj)
                {
                    // Check null reference
                    if (_instance == null)
                    {
                        // Create a new instance if it is null
                        _instance = new I();
                    }
                    return _instance;
                }
            }
        }



        /// <summary>
        /// Page fading opacity value
        /// </summary>
        private double _fadeOpacity = 1;

        public double FadeOpacity
        {
            get { return _fadeOpacity; }
            set { _fadeOpacity = value; OnPropertyChanged(nameof(FadeOpacity)); }
        }

        public async Task SetFade(bool value)
        {
            if (value)
            {
                FadeOpacity = 1;

                for (int i = 200; i > 0; i--)
                {
                    FadeOpacity -= 0.005;
                    Thread.Sleep(1);
                }
            }
            else if (!value)
            {
                FadeOpacity = 0;

                for (int i = 0; i < 200; i++)
                {
                    FadeOpacity += 0.005;
                    Thread.Sleep(1);
                }
            }
        }

        #endregion

        #region Public Events

        /// <summary>
        /// INotifyPropertyChanged event implementation
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Helper Methods

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
