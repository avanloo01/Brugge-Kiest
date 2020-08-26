using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly: ExportFont("AirBook.ttf", Alias = "AirFontBook"), ExportFont("AirMedium.ttf", Alias = "AirFontMedium"), ExportFont("AirLight.ttf", Alias = "AirFontLight")]
namespace BruggeKiest0_1
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //MainPage = new LoginPage();
            MainPage = new CustomNavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
