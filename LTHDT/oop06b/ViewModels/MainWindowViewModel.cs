using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Oop06b.ViewModels
{
    public class MainWindowViewModel : ModelBase
    {
        private Map map;
        private MapControlViewModel mapControl;

        public MainWindowViewModel()
        {
            map = new Map();
            MapControl = new MapControlViewModel(map);
        }

        public MapControlViewModel MapControl
        {
            get { return mapControl; }
            set { mapControl = value; OnPropertyChanged("MapControl"); }
        }

        public ICommand ResetMapCommand { get; set; }
    }
}