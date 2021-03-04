using System;
using Xamarin.Forms;
using Anexinet_Tests.Views;

namespace Anexinet_Tests
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoTo_Function01(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Function01());
        }
        private async void GoTo_Function02(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Function02());
        }
        private async void GoTo_Function03(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Function03());
        }
        private async void GoTo_Function04(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Function04());
        }
        private async void GoTo_Function05(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Function05());
        }
        private async void GoTo_Function06(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Function06());
        }
        private async void GoTo_Function07(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Function07());
        }
    }
}
