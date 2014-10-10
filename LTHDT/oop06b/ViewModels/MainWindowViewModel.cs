using Oop06b.Algorithm;
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
            ResetMapCommand = new RelayCommand((param) => map.Clear());
            FindPathCommand = new RelayCommand((param) => FindPath());
        }

        public MapControlViewModel MapControl
        {
            get { return mapControl; }
            set { mapControl = value; OnPropertyChanged("MapControl"); }
        }

        private async void FindPath()
        {
            AStarAlgorithm astar = new AStarAlgorithm(map);
            map.Clean();
            var list = await astar.Run();
            if (list != null)
            {
                Controls.MapControl.Instance.ConnectPath(list);
            }
        }

        public ICommand ResetMapCommand { get; set; }

        public ICommand FindPathCommand { get; set; }
    }
}