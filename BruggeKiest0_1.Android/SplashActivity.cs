using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Xamarin.Forms;

namespace BruggeKiest0_1.Droid
{
    [Activity(Label = "Brugge Kiest", Icon = "@drawable/Icon_Flag", Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {

        public SplashActivity()
        {

        }
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }

    }
}