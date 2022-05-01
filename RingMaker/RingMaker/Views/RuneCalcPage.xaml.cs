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
                RunesRequired = 0,
                PhysDefGained = 0.0
            };

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            RuneCalc.RunesRequired = CreateRunesRequiredInt(startLevel.Text, endLevel.Text);
            RuneCalc.PhysDefGained = CreatePhysicalDefensiveStatImprovementsMinusStatBonus(startLevel.Text, endLevel.Text);
            RuneCalc.OtherDefGained = CreateOtherDefensiveGainedMinusStatBonus(startLevel.Text, endLevel.Text);

            if (Convert.ToInt32(startLevel.Text) > 0 && Convert.ToInt32(startLevel.Text) < Convert.ToInt32(endLevel.Text))
            {

                CalcResults.IsVisible = true;
                PhysDefLabel.IsVisible = true;
                PhysDefResult.IsVisible = true;
                OtherDefLabel.IsVisible = true;
                OtherDefResult.IsVisible = true;
                CalcResultLabel.IsVisible = true;
                btnDefInfo.IsVisible = true;
                btnOtherInfo.IsVisible = true;
                CalcResults.Text = Convert.ToString(RuneCalc.RunesRequired);
                PhysDefResult.Text = Convert.ToString(RuneCalc.PhysDefGained);
                OtherDefResult.Text = Convert.ToString(RuneCalc.OtherDefGained);


            }
            else
            {
                DisplayAlert("Alert", "You did not enter valid value for Level From or Level To!", "Ok");
            }
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            CalcResultLabel.IsVisible = false;
            CalcResults.IsVisible = false;
            CalcResults.Text = "";
            PhysDefLabel.IsVisible = false;
            PhysDefResult.IsVisible = false;
            PhysDefResult.Text = "";
            OtherDefResult.IsVisible = false;
            OtherDefLabel.IsVisible = false;
            OtherDefResult.Text = "";
            btnDefInfo.IsVisible = false;
            btnOtherInfo.IsVisible = false;
            startLevel.Text = String.Empty;
            endLevel.Text = String.Empty;
        }

        public int CreateRunesRequiredInt(string start, string end)
        {
            var runeNeeded = 0;
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

            if (start == null && end == null && Convert.ToInt32(end) < 713)
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
                for (int i = Convert.ToInt32(start) + 1; i <= Convert.ToInt32(end); i++)
                {
                    neededExp += OneToTweve[i];
                }
            }
            else if (Convert.ToInt32(start) <= 12 && Convert.ToInt32(end) > 12)
            {
                for (int i = Convert.ToInt32(start) + 1; i <= 12; i++)
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
                for (int i = Convert.ToInt32(start) + 1; i <= Convert.ToInt32(end); i++)
                {
                    neededExp += (Int32)(0.02 * Math.Pow(i, 3) + 3.06 * Math.Pow(i, 2) + 105.6 * i - 895);
                }
            }
            else
            {
                DisplayAlert("Alert", "You did not enter valid value for Level From or Level To!", "Ok");
            }



            runeNeeded = neededExp;

            return runeNeeded;
        }

        public double CreatePhysicalDefensiveStatImprovementsMinusStatBonus(string start, string end)
        {
            var physicalDefenseGained = 0.0;
            var one_OneFiftyPhy = .4;
            var oneFiftyOne_OneSeventyPhy = 1.0;
            var oneSeventyOne_TwoFourtyPhy = .21;
            var twoFourtyOne_SevenThirteenPhy = .04;
            var startFrom = Convert.ToDouble(start);
            var endOn = Convert.ToDouble(end);
            var physicalDefGained = 0.0;

            #region OneToSevenThirteen
            if (startFrom <= 150.0 && endOn < 151.0)
            {
                var numberToCalculate = 0.0;

                numberToCalculate = endOn - startFrom;

                physicalDefGained = one_OneFiftyPhy * numberToCalculate;

            }
            else if (startFrom <= 150.0 && endOn >= 151 && endOn < 171.0)
            {
                var belowOneFiftyNumber = 151.0 - startFrom;
                var aboveOneFiftyNumber = endOn - 151.0;

                physicalDefGained = belowOneFiftyNumber * one_OneFiftyPhy;
                physicalDefGained += aboveOneFiftyNumber * oneFiftyOne_OneSeventyPhy;

            }
            else if (startFrom <= 150.0 && endOn >= 171 && endOn < 241.0)
            {
                var belowOneFifty = 151.0 - startFrom;
                var aboveOneFiftyOne = 170.0 - 151.0;
                var aboveOneSeventyOne = endOn - 170.0;

                physicalDefGained = belowOneFifty * one_OneFiftyPhy;
                physicalDefGained += oneFiftyOne_OneSeventyPhy * aboveOneFiftyOne;
                physicalDefGained += aboveOneSeventyOne * oneSeventyOne_TwoFourtyPhy;

            }
            else if (startFrom <= 150 && endOn >= 241.0 & endOn <= 713.0)
            {
                var belowOneFifty = 151.0 - startFrom;
                var aboveOneFifty = 170.0 - 151.0;
                var aboveOneSeventyOne = 240.0 - 171.0;
                var aboveTwoFourtyOne = endOn - 240.0;

                physicalDefGained = belowOneFifty * one_OneFiftyPhy;
                physicalDefGained += aboveOneFifty * oneFiftyOne_OneSeventyPhy;
                physicalDefGained += aboveOneSeventyOne * oneSeventyOne_TwoFourtyPhy;
                physicalDefGained += aboveTwoFourtyOne * twoFourtyOne_SevenThirteenPhy;
            }
            #endregion

            #region OneFiftyOneToSevenThirteen
            else if (startFrom >= 151.0 && endOn >150.0 && endOn < 171.0)
            {
                var belowOneSeventy = endOn - startFrom;

                physicalDefGained = belowOneSeventy * oneFiftyOne_OneSeventyPhy;
            }
            else if (startFrom >= 151.0 && startFrom < 171.0 && endOn > 170.0 && endOn < 241.0)
            {
                var belowOneSeventyOne = 171.0 - startFrom;
                var belowTwoFourtyOne = endOn - 171.0;

                physicalDefGained = belowOneSeventyOne * oneFiftyOne_OneSeventyPhy;
                physicalDefGained += belowTwoFourtyOne * oneSeventyOne_TwoFourtyPhy;
            }
            else if ( startFrom >= 151.0 && startFrom < 171.0 && endOn > 240.0 && endOn <= 714.0)
            {
                var belowOneSeventyOne = 171.0 - startFrom;
                var belowTwoFourtyOne = 241.0 - 171.0;
                var belowOrEqualToSevenThirteen = endOn - 241.0;

                physicalDefGained = belowOneSeventyOne * oneFiftyOne_OneSeventyPhy;
                physicalDefGained += belowTwoFourtyOne * oneSeventyOne_TwoFourtyPhy;
                physicalDefGained += belowOrEqualToSevenThirteen * twoFourtyOne_SevenThirteenPhy;
            }
            #endregion

            #region OneSeventyToTwoFourty
            else if (startFrom >= 171.0 && endOn < 241.0)
            {
                var belowTwoFourty = endOn - startFrom;
                
                physicalDefGained = belowTwoFourty * oneSeventyOne_TwoFourtyPhy;
            }
            else if (startFrom >= 171.0 && startFrom < 241 && endOn > 240 && endOn < 714.0)
            {
                var belowtwoFourty = 241.0 - startFrom;
                var belowSevenThirteen = 714 - endOn;

                physicalDefGained = belowtwoFourty * oneSeventyOne_TwoFourtyPhy;
                physicalDefGained += belowSevenThirteen * twoFourtyOne_SevenThirteenPhy;
            }
            #endregion

            #region TwoFourtytoSevenThirteen
            else if (startFrom >= 241.0 && endOn < 714.0)
            {
                var belowTwoFourty = endOn - startFrom;

                physicalDefGained = belowTwoFourty * twoFourtyOne_SevenThirteenPhy;
            }
            #endregion


            physicalDefenseGained = physicalDefGained;

            return physicalDefenseGained;

        }

        public double CreateOtherDefensiveGainedMinusStatBonus(string start, string end)
        {
            var otherDefenseGained = 0.0;
            var otherDefGained = 0.0;
            var one_OneFiftyOther = .2;
            var oneFiftyOne_OneNinetyOther = 1.0;
            var oneNinetyOne_twofourtyOther = .3;
            var twoFourtyOne_SevenThirteenOther = .04;
            var startFrom = Convert.ToDouble(start);
            var endFrom = Convert.ToDouble(end);


            #region One_OneFifty
            if(startFrom > 0 && startFrom <= 150 && endFrom <= 150)
            {
                var belowOneFiftyOne = endFrom - startFrom + 1;

                otherDefGained = belowOneFiftyOne * one_OneFiftyOther;
            }
            else if(startFrom > 0 && startFrom <= 150 && endFrom >= 151 && endFrom < 191)
            {
                var belowOneFiftyOne = 151 - startFrom;
                var belowOneNinetyOne = 191 - endFrom;

                otherDefGained = belowOneFiftyOne * one_OneFiftyOther;
                otherDefGained += belowOneNinetyOne * oneFiftyOne_OneNinetyOther;
            }
            else if(startFrom > 0 && startFrom <= 150 && endFrom >= 191 && endFrom < 241)
            {
                var belowOneFiftyOne = 151 - startFrom;
                var belowOneNinetyOne = 191 - 151;
                var belowtwoFourtyOne = endFrom - 191;

                otherDefGained = belowOneFiftyOne * one_OneFiftyOther;
                otherDefGained += belowOneNinetyOne * oneFiftyOne_OneNinetyOther;
                otherDefGained += belowtwoFourtyOne * oneNinetyOne_twofourtyOther;

            }
            else if(startFrom > 0 && startFrom <= 150 && endFrom >= 241 && endFrom < 714)
            {
                var belowOneFiftyOne = 151 - startFrom;
                var belowOneNinetyOne = 191 - 151;
                var belowtwoFourtyOne = 241 - 191;
                var belowSevenFourteen = endFrom - 241;

                otherDefGained = belowOneFiftyOne * one_OneFiftyOther;
                otherDefGained += belowOneNinetyOne * oneFiftyOne_OneNinetyOther;
                otherDefGained += belowtwoFourtyOne * oneNinetyOne_twofourtyOther;
                otherDefGained += belowSevenFourteen * twoFourtyOne_SevenThirteenOther;
            }
            #endregion

            #region OneFifty_OneNinety
            else if(startFrom > 150 && startFrom <= 190 && endFrom >= 151 && endFrom < 191)
            {
                var aboveOneFiftyOne = endFrom - startFrom + 1;

                otherDefGained = aboveOneFiftyOne * oneFiftyOne_OneNinetyOther;
                
            }
            else if(startFrom > 150 && startFrom <= 190 && endFrom >= 191 && endFrom < 241)
            {
                var aboveOneFiftyOne = 191 - startFrom;
                var aboveOneNinetyOne = endFrom - 191;

                otherDefGained = aboveOneFiftyOne * oneFiftyOne_OneNinetyOther;
                otherDefGained += aboveOneNinetyOne * oneNinetyOne_twofourtyOther;
            }
            else if(startFrom > 150 && startFrom <= 190 && endFrom >= 241 && endFrom < 714)
            {
                var aboveOneFiftyOne = 191 - startFrom;
                var aboveOneNinetyOne = 241 - 191;
                var aboveTwoFourtyOne = endFrom - 241;

                otherDefGained = aboveOneFiftyOne * oneFiftyOne_OneNinetyOther;
                otherDefGained += aboveOneNinetyOne * oneNinetyOne_twofourtyOther;
                otherDefGained += aboveTwoFourtyOne * twoFourtyOne_SevenThirteenOther;
            }
            #endregion

            #region OneNinety_TwoFourty
            else if(startFrom > 190 && startFrom <= 240 && endFrom >= 191 && endFrom < 241)
            {
                var aboveOneNinetyOne = endFrom - startFrom + 1;

                otherDefGained += aboveOneNinetyOne * oneNinetyOne_twofourtyOther;
            }
            else if(startFrom > 190 && startFrom <= 240 && endFrom >= 241 && endFrom < 714)
            {
                var aboveOneNinetyOne = 241 - startFrom;
                var aboveTwoFourtyOne = endFrom - 241;

                otherDefGained = aboveOneNinetyOne * oneNinetyOne_twofourtyOther;
                otherDefGained += aboveTwoFourtyOne * twoFourtyOne_SevenThirteenOther;
            }
            #endregion

            #region TwoFourtyOne_SevenThirteen
            else if(startFrom > 240 && startFrom <= 713 && endFrom > 241 && endFrom < 714)
            {
                var aboveTwoFourtyOne = endFrom - startFrom;

                otherDefGained = aboveTwoFourtyOne * twoFourtyOne_SevenThirteenOther;
            }
            #endregion

            otherDefenseGained = otherDefGained;

            return otherDefenseGained;
        }
        public void entryTextChanged(object sender, EventArgs e)
        {
            if (startLevel.Text.Length > 0 && endLevel.Text.Length > 0 && endLevel.Text.Length < 713)
            {
                btnCalculateButton.IsEnabled = true;
            }
        }

        public void DefInfo_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Defensive Information", "Defenses includes the following: \n- Physical Defense (VS Slash/Strike/Pierce)\n- Magic Defense\n- Fire Defense\n- Lightning Defense\n- Holy Defense\n\nNOTE: These figures do not include\n bonuses provided by stats.", "Ok");
        }

        public void OtherInfo_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Other Defense Information", "Other Defenses include the following: \n - Immunity\n- Robustness\n- Focus\n- Vitality\n\nNOTE: These figures do not include\n bonuses provided by stats.", "Ok");
        }
    }
}