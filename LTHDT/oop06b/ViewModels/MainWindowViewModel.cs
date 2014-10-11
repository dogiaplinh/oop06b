using Oop06b.Algorithm;
using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Oop06b.ViewModels
{
    public class MainWindowViewModel : ModelBase
    {
        private Map map;
        private MapControlViewModel mapControl;
        private CancellationTokenSource cts;
        private int[] timeDelay = { 200, 100, 50, 25, 400, 800 };
        private int speed;

        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
                if (speed >= 0)
                    Params.Delay = timeDelay[speed];
            }
        }

        public MainWindowViewModel()
        {
            map = new Map();
            MapControl = new MapControlViewModel(map);
            ResetMapCommand = new RelayCommand((param) => ResetMap());
            FindPathCommand = new RelayCommand((param) => FindPath());
            RandomMapCommand = new RelayCommand((param) =>
            {
                if (cts != null)
                    cts.Cancel();
                map.RandomGenerate();
            });
        }

        private void ResetMap()
        {
            if (cts != null)
                cts.Cancel();
            map.Clear();
        }

        public MapControlViewModel MapControl
        {
            get { return mapControl; }
            set { mapControl = value; OnPropertyChanged("MapControl"); }
        }

        private async void FindPath()
        {
            if (cts != null)
                cts.Cancel();
            AStarAlgorithm astar = new AStarAlgorithm(map);
            await Task.Delay(100);
            map.Clean();
            cts = new CancellationTokenSource();
            try
            {
                var list = await astar.Run(cts.Token);
                if (list != null)
                {
                    Controls.MapControl.Instance.ConnectPath(list);
                }
            }
            catch (OperationCanceledException)
            {
                cts = null;
                return;
            }
        }

        public ICommand ResetMapCommand { get; set; }

        public ICommand FindPathCommand { get; set; }

        public ICommand RandomMapCommand { get; set; }
    }
}