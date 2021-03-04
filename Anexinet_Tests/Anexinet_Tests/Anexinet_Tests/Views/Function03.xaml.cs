using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anexinet_Tests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Function03 : ContentPage
    {
        public Function03()
        {
            InitializeComponent();

            string[] array1 = new string[] { "x","y","z" };
            string[] array2 = new string[] { "10", "20", "30" };

            string[] MergedArray = array1.Zip(array2, (a, b) => new[] { a, b }).SelectMany(x => x).ToArray();
            Console.WriteLine(MergedArray);

            foreach (var item in MergedArray)
            {
                if (resultLblCombines_Array.Text == null)
                {
                    resultLblCombines_Array.Text = item;
                }
                else
                {
                    resultLblCombines_Array.Text = resultLblCombines_Array.Text + "," + item;
                }
            }
        }
    }
}