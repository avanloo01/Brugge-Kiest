using System;
using MLToolkit.Forms.SwipeCardView.Core;
using BruggeKiest0_1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;
using Refit;
using System.Threading.Tasks;


namespace BruggeKiest0_1
{
    [DesignTimeVisible(false), XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private int currentCard = 0;
        private int currentLikes;
        private int currentDislikes;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CardViewModel();
            swipeCardView.Swiped += OnSwiped;
            swipeCardView.AnimationLength = 50;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CallApi();
        }
        async Task CallApi()
        {
            var nsAPI = RestService.For<API>("https://brugge-kiest-a28a3.firebaseio.com");
            var sugars = await nsAPI.GetVoorstellen();
            swipeCardView.ItemsSource = sugars;
        }
        private async void OnSwiped(object sender, SwipedCardEventArgs e)
        {
            var nsAPI = RestService.For<API>("https://brugge-kiest-a28a3.firebaseio.com");
            currentLikes = await nsAPI.GetLikes(currentCard);
            currentDislikes = await nsAPI.GetDislikes(currentCard);
            var currentInhoud = await nsAPI.GetInhoud(currentCard);
            switch (e.Direction)
            {
                case SwipeCardDirection.None:
                    break;
                case SwipeCardDirection.Down:
                    currentCard++;
                    break;
                case SwipeCardDirection.Right: //Like
                    currentLikes++;
                    var replacement1 = currentInhoud.Replace("\"", "");
                    var like = new dbVoorstel
                    {
                        Id = currentCard,
                        Inhoud = replacement1,
                        Titel = "Voorstel " + (currentCard + 1).ToString(),
                        Voor = currentLikes,
                        Tegen = currentDislikes
                    };
                    await nsAPI.LikeVoorstel(currentCard, like);
                    currentCard++;
                    break;
                case SwipeCardDirection.Left: //Dislike
                    currentDislikes++;
                    var replacement2 = currentInhoud.Replace("\"", "");
                    var dislike = new dbVoorstel
                    {
                        Id = currentCard,
                        Inhoud = replacement2,
                        Titel = "Voorstel " + (currentCard + 1).ToString(),
                        Voor = currentLikes,
                        Tegen = currentDislikes
                    };
                    await nsAPI.DislikeVoorstel(currentCard, dislike);
                    currentCard++;
                    break;
            }
        }
        void Help_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }
        private void Hart_Clicked(object sender, EventArgs e)
        {
            swipeCardView.InvokeSwipe(SwipeCardDirection.Right);
            swipeCardView.AnimationLength = 650;
        }
        private void Kruis_Clicked(System.Object sender, System.EventArgs e)
        {
            swipeCardView.InvokeSwipe(SwipeCardDirection.Left);
            swipeCardView.AnimationLength = 650;
        }
        void SKIP_Clicked(System.Object sender, System.EventArgs e)
        {
            swipeCardView.InvokeSwipe(SwipeCardDirection.Down);
        }
        
    }
}
