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

            


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            RuneCalc = new RuneInfo
            {
                LevelFrom = Convert.ToInt32(startLevel.Text),
                LevelTo = Convert.ToInt32(endLevel.Text),
                RunesRequired = "To go from " + startLevel.Text + " to level " + endLevel.Text +".  You will need xxxxxx runes."


            };
            OnPropertyChanged();
        }
               
    }
}