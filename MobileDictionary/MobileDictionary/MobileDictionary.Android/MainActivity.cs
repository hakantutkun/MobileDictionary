﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using MobileDictionary.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MobileDictionary.Droid.Environment))]
namespace MobileDictionary.Droid
{
    [Activity(Label = "Mingi Tav Sözlük", Icon = "@mipmap/MingitavSozlukIcon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class Environment : IEnvironment
    {
        [Obsolete]
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;

            var activity = Platform.CurrentActivity;
            var window = activity.Window;

            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            //window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            //window.SetStatusBarColor(color.ToPlatformColor());

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                //var flag = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
                //window.DecorView.SystemUiVisibility = darkStatusBarTint ? flag : 0;
            }

            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.Lollipop)
            {
                //window.SetStatusBarColor(Android.Graphics.Color.Orange);
                window.SetNavigationBarColor(color.ToPlatformColor());
            }
        }
    }
}