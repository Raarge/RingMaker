using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RingMaker.ViewModels
{
    public class RuneCalcViewModel : BaseViewModel
    {
        public RuneCalcViewModel()
        {
            Title = "Rune Calculation Page";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

            //DisplayResults = new Command( Label.IsVisibleProperty = true);
        }

        public ICommand OpenWebCommand { get; }

        public event PropertyChangingEventHandler PropertyChanged;           
        
        public ICommand DisplayResults { get; set; }

    }
}
