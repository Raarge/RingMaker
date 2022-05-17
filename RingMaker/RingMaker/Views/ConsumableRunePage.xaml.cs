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

        Dictionary<string, int> ConsRunes = new Dictionary<string, int>();

        public ConsumableRunePage()
        {
            ConsRunes.Add("Lord's Rune", 50000);
            ConsRunes.Add("Hero's Rune[5]", 35000);
            ConsRunes.Add("Hero's Rune[4]", 30000);
            ConsRunes.Add("Hero's Rune[3]", 25000);
            ConsRunes.Add("Hero's Rune[2]", 20000);
            ConsRunes.Add("Hero's Rune[1]", 15000);
            ConsRunes.Add("Numen's Rune", 12500);
            ConsRunes.Add("Golden Rune[13]", 10000);
            ConsRunes.Add("Golden Rune[12]", 7500);
            ConsRunes.Add("Golden Rune[11]", 6250);
            ConsRunes.Add("Golden Rune[10]", 5000);
            ConsRunes.Add("Golden Rune[9]", 3800);
            ConsRunes.Add("Golden Rune[8]", 3000);
            ConsRunes.Add("Golden Rune[7]", 2500);
            ConsRunes.Add("Golden Rune[6]", 2000);
            ConsRunes.Add("Golden Rune[5]", 1600);
            ConsRunes.Add("Golden Rune[4]", 1200);
            ConsRunes.Add("Golden Rune[3]", 800);
            ConsRunes.Add("Golden Rune[2]", 400);
            ConsRunes.Add("Golden Rune[1]", 200);
            ConsRunes.Add("Lands Between Rune", 3000);


            InitializeComponent();

            
        }

        public void btnCalculateNumberOfRunes_Clicked(object sender, EventArgs e)
        {
            RuneCalc = new ConsumableRuneInfo
            {
                XPNeeded = Convert.ToInt32(xpNeeded.Text),
                RuneSize = Convert.ToString(pkrRuneSize.SelectedItem),
                ConsumableRunesRequired = ""
            };

            if (xpNeeded.Text != null && pkrRuneSize.SelectedItem != null)
            {
                ShowHidden();
                RuneCalc.ConsumableRunesRequired = CalculateAndBuildString(RuneCalc.XPNeeded, RuneCalc.RuneSize);

                lblRunesNeededResults.Text = RuneCalc.ConsumableRunesRequired;
            }
            else
            {
                DisplayAlert("Alert", "You did not enter any values to evaluate.", "OK");
            }
        }

        public void btnReset_Clicked(object sender, EventArgs e)
        {
            lblRunesNeededHeader.IsVisible = false;
            lblRunesNeededResults.IsVisible = false;
            btnReset.IsVisible = false;
            lblRunesNeededResults.Text = "";
            xpNeeded.Text = "";
            pkrRuneSize.SelectedItem = 0;
            
        }

        public string CalculateAndBuildString(int needed, string conrune)
        {
            var builtString = "";
            var tempTtl = 0;
            var tempRemainder = 0;

            tempTtl = needed / ConsRunes[conrune];
            tempRemainder = needed % ConsRunes[conrune];
            if(tempRemainder > 0)
            {
                tempTtl += 1;
            }

            builtString = "The number of " + conrune + "'s that are needed to gain " + needed + " is " + tempTtl + ". This will yield " + tempTtl * ConsRunes[conrune] + 
                " Runes, which is " + ((tempTtl * ConsRunes[conrune]) - needed) + " more than needed.";
            
            return builtString;
        }

        public void ShowHidden()
        {
            lblRunesNeededHeader.IsVisible = true;
            lblRunesNeededResults.IsVisible = true;
            btnReset.IsVisible = true;
            
        }
    }
}