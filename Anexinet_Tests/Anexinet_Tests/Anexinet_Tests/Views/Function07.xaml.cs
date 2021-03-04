using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Anexinet_Tests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Function07 : ContentPage
    {
        public Function07()
        {
            InitializeComponent();
        }

        private async Task validateNumber()
        {
            //Validates if the value in the Entry is empty or is equal to null
            if (String.IsNullOrWhiteSpace(numberEntry.Text))
            {
                await this.DisplayAlert("Warning", "Please enter a number.", "OK");
                return;
            }
            
            double i = double.Parse(numberEntry.Text);

            // Check if the number is between 0 to 1 or not  
            if (i >= 1 || i <= 0)
            {
                await this.DisplayAlert("Warning", "The number entered is not between the value 0 and 1.", "OK");
                return;
            }

            long m = BitConverter.DoubleToInt64Bits(i);
            string str = Convert.ToString(m, 2);

            Console.WriteLine(str);

            //Validates if binary value exceeds 32 characters
            if (str.Length >= 32)
            {
                await this.DisplayAlert("Warning", "The binary value of this number exceeds 32 characters.", "OK");
                return;
            }

            resultLbl.Text = str;
        }

        async void Check_Clicked(object sender, EventArgs e)
        {
           await validateNumber();
        }
    }
}