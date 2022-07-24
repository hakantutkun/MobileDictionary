using Sharpnado.Presentation.Forms.iOS;
using UIKit;

namespace MobileDictionary.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, typeof(AppDelegate));

            Xamarin.Forms.Forms.Init();
            Sharpnado.Tabs.iOS.Preserver.Preserve();
            SharpnadoInitializer.Initialize();
        }
    }
}
