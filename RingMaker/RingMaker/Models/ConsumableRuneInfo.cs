using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RingMaker.Models
{
    public class ConsumableRuneInfo : INotifyPropertyChanged
    { 
        private int _xpNeeded;
        private string _runeSize;
        private string _consumableRunesRequired;

        public int XPNeeded
        {
            get => _xpNeeded;
            set
            {
                _xpNeeded = value;
                RaisePropertyChanged(nameof(XPNeeded));
            }
        }

        public string RuneSize
        {
            get => _runeSize;
            set
            {
                _runeSize = value;
                RaisePropertyChanged(nameof(RuneSize));
            }
        }

        public string ConsumableRunesRequired
        {
            get => _consumableRunesRequired;
            set
            {
                _consumableRunesRequired = value;
                RaisePropertyChanged(nameof(ConsumableRunesRequired));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
