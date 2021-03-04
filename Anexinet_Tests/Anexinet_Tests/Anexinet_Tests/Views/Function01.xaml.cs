using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Anexinet_Tests.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Function01 : ContentPage
    {
        public Function01()
        {
            InitializeComponent();
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            Recalculate();
            RecalculateMinutes();
        }

        void OnSwitchToggledDays(object sender, ToggledEventArgs args)
        {
            Recalculate();
        }

        void OnSwitchToggledMinutes(object sender, ToggledEventArgs args)
        {
            Recalculate();
            RecalculateMinutes();
        }

        void Recalculate()
        {
            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date +
                (includeSwitchDays.IsToggled ? TimeSpan.FromDays(1) : TimeSpan.Zero);

            resultLabelDays.Text = String.Format("{0} day{1} between dates",
                                                timeSpan.Days, timeSpan.Days == 1 ? "" : "s");
        }

        void RecalculateMinutes()
        {
            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date +
                (includeSwitchMinutes.IsToggled ? TimeSpan.FromMinutes(1440) : TimeSpan.Zero);

            resultLabelMinutes.Text = String.Format("{0} minute{1} between dates",
                                                timeSpan.TotalMinutes, timeSpan.TotalMinutes == 1 ? "" : "s");
        }
    }
}