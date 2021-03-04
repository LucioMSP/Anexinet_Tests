using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Anexinet_Tests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Function02 : ContentPage
    {
        public Function02()
        {
            InitializeComponent();
        }

        async void Reverse_Clicked(object sender, EventArgs e)
        {
            await reverseString();
        }

        private async Task reverseString()
        {
            //Validates if the value in the Entry is empty or is equal to null
            if (String.IsNullOrWhiteSpace(stringEntry.Text))
            {
                await this.DisplayAlert("Warning", "Please write something.", "OK");
                return;
            }

            // With the built-in Array.Reverse method
            char[] charArray = stringEntry.Text.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(new string(charArray));

            resultLbl.Text = (new string(charArray));
        }
    }
}