using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RingMaker.ViewModels
{
    public class LandingViewModel : BaseViewModel
    {
        public LandingViewModel()
        {
            Title = "Main Page";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}
