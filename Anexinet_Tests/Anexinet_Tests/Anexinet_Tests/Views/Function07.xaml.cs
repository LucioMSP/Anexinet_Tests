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
        async void Check_Clicked(object sender, EventArgs e)
        {
            await validateNumber();
        }

        private async Task validateNumber()
        {
            //Validates if the value in the Entry is empty or is equal to null
            if (String.IsNullOrWhiteSpace(numberEntry.Text))
            {
                await this.DisplayAlert("Warning", "Please enter a number.", "OK");
                return;
            }
            
            double num = double.Parse(numberEntry.Text);

            long m = BitConverter.DoubleToInt64Bits(num);
            string str = Convert.ToString(m, 2);
            
            // Check if the number is between 0 to 1 or not  
            if (num >= 1 || num <= 0)
            {
                await this.DisplayAlert("Warning", "The number entered is not between the value 0 and 1.", "OK");
                return;
            }

            StringBuilder binary = new StringBuilder();
            binary.Append(".");

            while (num > 0)
            {
                // Setting a limit on length: 32 characters. If the number cannot be represented accurately in binary with at most 32 character 
                if (binary.Length >= 32)
                {
                    await this.DisplayAlert("Error", "", "OK");
                    return;
                }
                 
                // Multiply by 2 in num to check it 1 or 0  
                double r = num * 2;
                if (r >= 1)
                {
                    binary.Append(1);
                    num = r - 1;
                }
                else
                {
                    binary.Append(0);
                    num = r;
                }
            }
            Console.WriteLine("Binary Value" + binary.ToString());

            resultLbl.Text = 0 + binary.ToString();
        }
    }
}