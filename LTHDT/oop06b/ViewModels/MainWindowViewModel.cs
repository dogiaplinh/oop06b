﻿using oop06b.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private MapControlViewModel map = new MapControlViewModel();

        public MapControlViewModel Map
        {
            get { return map; }
            set { map = value; OnPropertyChanged("Map"); }
        }

        public MainWindowViewModel()
        { }
    }
}