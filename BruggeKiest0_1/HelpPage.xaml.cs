using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BruggeKiest0_1
{
    public partial class HelpPage : ContentPage
    {
        public HelpPage()
        {
            InitializeComponent();
        }

        void Back_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
