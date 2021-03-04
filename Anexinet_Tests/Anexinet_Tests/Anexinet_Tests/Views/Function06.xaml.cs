using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Anexinet_Tests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Function06 : ContentPage
    {
        public Function06()
        {
            InitializeComponent();
        }

        async void CheckAngle_Clicked(object sender, EventArgs e)
        {
            await validateAngle();
        }

        private async Task validateAngle()
        {
            //Validates if the value in the Entrys is empty or is equal to null
            if (String.IsNullOrWhiteSpace(hourEntry.Text))
            {
                await DisplayAlert("Warning", "Please enter a hour.", "OK");
                return;
            }

            if (String.IsNullOrWhiteSpace(minuteEntry.Text))
            {
                await DisplayAlert("Warning", "Please enter a minute.", "OK");
                return;
            }

            //Check length of only 12 digit of number
            string caractEspecial = @"^(1[0-2]|[1-9])$";
            bool result = Regex.IsMatch(hourEntry.Text, caractEspecial, RegexOptions.IgnoreCase);
            if (!result)
            {
                await DisplayAlert("Warning", "Only the 12 hour time system is allowed, please try again.", "OK");
                return;
            }

            double num1 = double.Parse(hourEntry.Text);
            double num2 = double.Parse(minuteEntry.Text);

            // Validate the input
            if (num1 < 0 || num2 < 0 ||
                num1 > 12 || num2 > 60)
              
            if (num1 == 12)
                num1 = 0;

            if (num2 == 60)
            {
                num2 = 0;
                num1 += 1;
                if (num1 > 12)
                    num1 = num1 - 12;
            }

            // Calculate the angles moved by hour and minute hands with reference to 12:00
            int hour_angle = (int)(0.5 * (num1 * 60 + num2));
            int minute_angle = (int)(6 * num2);

            // Find the difference between two angles
            int angle = Math.Abs(hour_angle - minute_angle);

            // Smaller angle of two possible angles
            angle = Math.Min(360 - angle, angle);

            //Return angle;
            Console.WriteLine("Angle:" + " " + angle);
            resultLbl.Text = angle.ToString() + "°";
        }
    }
}