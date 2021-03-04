using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace Anexinet_Tests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Function05 : ContentPage
    {
        public Function05()
        {
            InitializeComponent();
        }

        async void Combinations_Clicked(object sender, EventArgs e)
        {
            await printCombinations();
        }

        void _printParenthesis(char[] str, int pos, int n, int open, int close)
        {
            if (close == n)
            {
                // print the possible combinations 
                for (int i = 0; i < str.Length; i++)
                    Console.Write(str[i]);
                return;
            }
            else
            {
                if (open > close)
                {
                    str[pos] = ')';
                    _printParenthesis(str, pos + 1,
                                    n, open, close + 1);
                }
                if (open < n)
                {
                    str[pos] = '(';
                    _printParenthesis(str, pos + 1,
                                    n, open + 1, close);
                }
            }
        }

        // Wrapper over _printParenthesis() 
        void printParenthesis(char[] str, int n)
        {
            if (n > 0)
                _printParenthesis(str, 0, n, 0, 0);
            return;
        }
        private async Task printCombinations()
        {
            //Validates if the value in the Entrys is empty or is equal to null
            if (String.IsNullOrWhiteSpace(numberEntry.Text))
            {
                await DisplayAlert("Warning", "Please enter a number.", "OK");
                return;
            }

            int num = int.Parse(numberEntry.Text);
            char[] str = new char[2 * num];
            printParenthesis(str, num);

            //Return the combinations;
            Console.WriteLine("Combinations:" + " " + str);

            foreach (var item in str)
            {
                if (resultLbl.Text == null)
                {
                    resultLbl.Text = item.ToString();
                }
                else
                {
                    resultLbl.Text = resultLbl.Text + item.ToString();
                }
            }
        }
    }
}