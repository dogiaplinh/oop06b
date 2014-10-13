using Oop06b.Algorithm;
using Oop06b.Controls;
using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private CancellationTokenSource cts;
        private NodeType currentNodeType;
        private Map map;
        private MapControlViewModel mapControl;
        private int speed = 0;
        private int[] timeDelay = { 64, 32, 16, 8, 128, 256 };
        private double time;

        public double Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged("Time"); }
        }

        public MainWindowViewModel()
        {
            map = new Map();
            MapControl = new MapControlViewModel(map);
            CurrentNodeType = NodeType.Obstacle;
            ResetMapCommand = new RelayCommand((param) => ResetMap());
            FindPathCommand = new RelayCommand((param) => FindPath());
            RandomMapCommand = new RelayCommand((param) =>
            {
                if (cts != null)
                    cts.Cancel();
                map.RandomGenerate();
            });
        }

        public NodeType CurrentNodeType
        {
            get { return currentNodeType; }
            set
            {
                currentNodeType = value;
                NodeControlViewModel.CurrentType = value;
                OnPropertyChanged("CurrentNodeType");
            }
        }

        public ICommand FindPathCommand { get; set; }

        public MapControlViewModel MapControl
        {
            get { return mapControl; }
            set { mapControl = value; OnPropertyChanged("MapControl"); }
        }

        public ICommand RandomMapCommand { get; set; }

        public ICommand ResetMapCommand { get; set; }

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

        private async void FindPath()
        {
            if (cts != null)
                cts.Cancel();
            AStarAlgorithm astar = new AStarAlgorithm(map);
            await Task.Delay(100);
            map.Clean();
            cts = new CancellationTokenSource();
            Stopwatch timer = new Stopwatch();
            try
            {
                timer.Start();
                var list = await astar.Run(cts.Token);
                timer.Stop();
                Time = timer.Elapsed.TotalSeconds;
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

        private void ResetMap()
        {
            if (cts != null)
                cts.Cancel();
            map.Clear();
        }
    }
}