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
        private int _runesRequired;
        private double _physDefGained;

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

        public int RunesRequired 
        { 
            get => _runesRequired;
            set 
            {
                _runesRequired = value;
                RaisePropertyChanged(nameof(RunesRequired));
            }
        }

        public double PhysDefGained
        {
            get => _physDefGained;
            set
            {
                _physDefGained = value;
                RaisePropertyChanged(nameof(PhysDefGained));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
