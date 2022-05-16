using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RingMaker.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RingMaker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsumableRunePage : ContentPage
    {
        public ConsumableRuneInfo RuneCalc { get; set; }
        public ConsumableRunePage()
        {
            InitializeComponent();

            RuneCalc = new ConsumableRuneInfo
            {
                XPNeeded = Convert.ToInt32(xpNeeded.Text),
                RuneSize = Convert.ToString(pkrRuneSize.SelectedItem),
                ConsumableRunesRequired = ""
            };
        }

        public void btnCalculateNumberOfRunes_Clicked(object sender, EventArgs e)
        {
            // add test to see if xpNeeded or pkrRuneSize are empty before showing hidden
            ShowHidden();
            RuneCalc.ConsumableRunesRequired = "Test Test Test";

            lblRunesNeededResults.Text = RuneCalc.ConsumableRunesRequired;
        }

        public void ShowHidden()
        {
            lblRunesNeededHeader.IsVisible = true;
            lblRunesNeededResults.IsVisible = true;
            
        }
    }
}