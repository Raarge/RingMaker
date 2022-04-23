using RingMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RingMaker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RuneCalcPage : ContentPage
    {
        public RuneInfo RuneCalc { get; set; }
        public RuneCalcPage()
        {
            InitializeComponent();

            RuneCalc = new RuneInfo
            {
                LevelFrom = Convert.ToInt32(startLevel.Text),
                LevelTo = Convert.ToInt32(endLevel.Text),
                RunesRequired = ""
            };

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            RuneCalc.RunesRequired = CreateRunesRequiredString(startLevel.Text, endLevel.Text);

            if (Convert.ToInt32(startLevel.Text) > 0 && Convert.ToInt32(startLevel.Text) < Convert.ToInt32(endLevel.Text))
            {

                CalcResults.IsVisible = true;
                CalcResults.Text = RuneCalc.RunesRequired;


            }
            else
            {
                DisplayAlert("Alert", "You did not enter valid value for Level From or Level To!", "Ok");
            }
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            CalcResults.IsVisible = false;
            CalcResults.Text = "";
            startLevel.Text = String.Empty;
            endLevel.Text = String.Empty;
        }

        public string CreateRunesRequiredString(string start, string end)
        {
            var runeNeededStatement = "";
            var runeStatement1 = "To go from level ";
            var runeStatement3 = ", to level ";
            var runeStatement5 = ". \r\nRequires ";
            var runeStatement6 = " runes.";
            var startExp = 0;
            var endExp = 0;
            var neededExp = 0;

            var OneToTweve = new Dictionary<int, int>()
            {
                { 1, 0 },
                { 2, 673 },
                { 3, 689 },
                { 4, 706 },
                { 5, 723 },
                { 6, 740 },
                { 7, 757 },
                { 8, 775 },
                { 9, 793 },
                { 10, 811 },
                { 11, 829 },
                { 12, 847 },
            };

            if (start == null && end == null && Convert.ToInt32( end) < 713)
            {
                DisplayAlert("Alert", "You did not enter valid value for Level From or Level To!", "Ok");
            }
            else if (Convert.ToInt32(end) - Convert.ToInt32(start) == 1 && Convert.ToInt32(end) <= 12)
            {
                neededExp = OneToTweve[Convert.ToInt32(end)];
            }
            else if (Convert.ToInt32(end) - Convert.ToInt32(start) == 1 && Convert.ToInt32(end) > 12)
            {
                neededExp = (Int32)(0.02 * Math.Pow(Convert.ToInt32(end), 3) + 3.06 * Math.Pow(Convert.ToInt32(end), 2) + 105.6 * Convert.ToInt32(end) - 895);
            }
            else if (Convert.ToInt32(start) <= 12 && Convert.ToInt32(end) <= 12)
            {
                for (int i = Convert.ToInt32(start); i <= Convert.ToInt32(end); i++)
                {
                    neededExp += OneToTweve[i];
                }
            }
            else if (Convert.ToInt32(start) <= 12 && Convert.ToInt32(end) > 12)
            {
                for (int i = Convert.ToInt32(start); i <= 12; i++)
                {
                    neededExp += OneToTweve[i];
                }

                for (int i = 13; i <= Convert.ToInt32(end); i++)
                {
                    neededExp += (Int32)(0.02 * Math.Pow(i, 3) + 3.06 * Math.Pow(i, 2) + 105.6 * i - 895);
                }
            }
            else if (Convert.ToInt32(start) > 12 && Convert.ToInt32(end) <= 713)
            {
                for (int i = Convert.ToInt32(start); i <= Convert.ToInt32(end); i++)
                {
                    neededExp += (Int32)(0.02 * Math.Pow(i, 3) + 3.06 * Math.Pow(i, 2) + 105.6 * i - 895);
                }
            }
            else
            {
                DisplayAlert("Alert", "You did not enter valid value for Level From or Level To!", "Ok");
            }



            runeNeededStatement = runeStatement1 + start + runeStatement3 + end + runeStatement5 + neededExp + runeStatement6;

            return runeNeededStatement;
        }

        public void entryTextChanged(object sender, EventArgs e)
        {
            if (startLevel.Text.Length > 0 && endLevel.Text.Length > 0 && endLevel.Text.Length < 713)
            {
                btnCalculateButton.IsEnabled = true;
            }
        }
    }
}