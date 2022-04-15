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
        }

        public ICommand OpenWebCommand { get; }
    }
}
