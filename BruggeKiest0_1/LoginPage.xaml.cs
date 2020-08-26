using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Xamarin.Essentials;


namespace BruggeKiest0_1
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void ForgotPass(object sender, EventArgs args)
        {
            await OpenWachtwoordVergeten("https://www.brugge.be/recover");
        }
        public async Task OpenWachtwoordVergeten(string url)
        {
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }
        void LoginClicked(System.Object sender, System.EventArgs e)
        {
        }

    }
}
