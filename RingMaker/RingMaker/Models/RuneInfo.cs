using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RingMaker.Models
{
    public class RuneInfo : INotifyPropertyChanged
    {
        private int _levelFrom;
        private int _levelTo;
        private string _runesRequired;

        public int LevelFrom 
        { 
            get => _levelFrom;
            set
            {
                _levelFrom = value;
                RaisePropertyChanged(nameof(LevelFrom));
            }
        }

        public int LevelTo 
        { 
            get => _levelTo;
            set
            {
                _levelTo = value;
                RaisePropertyChanged(nameof(LevelTo));
            }
        }

        public string RunesRequired 
        { 
            get => _runesRequired;
            set 
            {
                _runesRequired = value;
                RaisePropertyChanged(nameof(RunesRequired));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
