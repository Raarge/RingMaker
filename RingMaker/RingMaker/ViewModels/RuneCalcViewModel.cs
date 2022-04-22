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
            DisplayResults = new Command(() => DisplayTextAnswer());

            Title = "Rune Calculation Page";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));            
        }

        private bool _isVisibleLabel;

        public bool IsVisibleLabel
        {
            get => _isVisibleLabel;
            set
            {
                _isVisibleLabel = value;
                OnPropertyChanged();
            }
        }

        private string _someText;

        public string SomeText
        {
            get => _someText;
            set
            {
                _someText = "Test1";
                OnPropertyChanged();
            }
        }

       
        public ICommand OpenWebCommand { get; }

        public event PropertyChangingEventHandler PropertyChanged;           
        
        public ICommand DisplayResults { get; set; }

        public void DisplayAnswer() => IsVisibleLabel = false;

        public void DisplayText() => SomeText = "Testing Text";

        public void DisplayTextAnswer()
        {
            //DisplayAnswer();
            DisplayText();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAnswer();
        }
    }
}
