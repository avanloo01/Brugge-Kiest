using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MLToolkit.Forms.SwipeCardView.Core;
using Xamarin.Forms;
using System.Linq;

namespace BruggeKiest0_1.ViewModels
{
    public class CardViewModel : BasePageViewModel
    {



        //private ObservableCollection<dbVoorstel> _voorstellen = new ObservableCollection<dbVoorstel>();



        public CardViewModel()
        {

            InitializeVoorstellen();


            SwipedCommand = new Xamarin.Forms.Command<SwipedCardEventArgs>(OnSwipedCommand);
            DraggingCommand = new Xamarin.Forms.Command<DraggingCardEventArgs>(OnDraggingCommand);
            AddItemsCommand = new Command(OnAddItemsCommand);


        }
        //public ObservableCollection<dbVoorstel> Voorstellen
        //{
        //    get => _voorstellen;
        //    set
        //    {
        //        _voorstellen = value;
        //        this.RaisePropertyChanged();
        //    }
        //}


        public ICommand SwipedCommand { get; }

        public ICommand DraggingCommand { get; }

        public ICommand ClearItemsCommand { get; }

        public ICommand AddItemsCommand { get; }

        private void OnSwipedCommand(SwipedCardEventArgs eventArgs)
        {

        }
        private void OnDraggingCommand(DraggingCardEventArgs eventArgs)
        {
        }
        private void OnAddItemsCommand()
        {
        }
        public void InitializeVoorstellen()
        {

            //Voorstellen.Add(new dbVoorstel { Id = 1, Inhoud = "Dit is mijn eerste testadfagqwegqwgewqgeawhgwhrew.", Titel = "Titel 1" });
        }
    }

    public class dbVoorstel
    {
        public int Id { get; set; }
        public string Inhoud { get; set; }
        public string Titel { get; set; }
        public int Voor { get; set; }
        public int Tegen { get; set; }
    }
}
