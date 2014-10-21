using Oop06b.Algorithm;
using Oop06b.Controls;
using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private CancellationTokenSource[] cts;
        private NodeType currentNodeType;
        private Map map;
        private MapControlViewModel mapControl;
        private ObservableCollection<NotificationViewModel> notifications = new ObservableCollection<NotificationViewModel>();
        private int speed = 0;
        private int threadNo = 1;
        private int[] timeDelay = { 64, 32, 16, 8, 128, 256 };

        public MainWindowViewModel()
        {
            map = new Map();
            MapControl = new MapControlViewModel(map);
            cts = new CancellationTokenSource[10];
            CurrentNodeType = NodeType.Obstacle;
            ResetMapCommand = new RelayCommand((param) => ResetMap());
            CleanMapCommand = new RelayCommand((param) => CleanMap());
            FindPathCommand = new RelayCommand((param) => FindPath());
            RandomMapCommand = new RelayCommand((param) => RandomMap());
            CancelFindCommand = new RelayCommand((param) => CancelFind());
        }

        private void RandomMap()
        {
            foreach (var item in cts)
            {
                if (item != null)
                    item.Cancel();
            }
            Notifications.Clear();
            map.RandomGenerate(threadNo);
        }

        public ICommand CancelFindCommand { get; private set; }

        public ICommand CleanMapCommand { get; private set; }

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

        public ICommand FindPathCommand { get; private set; }

        public MapControlViewModel MapControl
        {
            get { return mapControl; }
            set { mapControl = value; OnPropertyChanged("MapControl"); }
        }

        public ObservableCollection<NotificationViewModel> Notifications
        {
            get { return notifications; }
        }

        public ICommand RandomMapCommand { get; private set; }

        public ICommand ResetMapCommand { get; private set; }

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

        public int ThreadNo
        {
            get { return threadNo - 1; }
            set { threadNo = value + 1; OnPropertyChanged("ThreadNo"); }
        }

        private void CancelFind()
        {
            foreach (var item in cts)
            {
                if (item != null)
                    item.Cancel();
            }
        }

        private void CleanMap()
        {
            foreach (var item in cts)
            {
                if (item != null)
                    item.Cancel();
            }
            map.Clean();
            Notifications.Clear();
        }

        private async void FindPath()
        {
            foreach (var item in cts)
            {
                if (item != null)
                    item.Cancel();
            }
            Notifications.Clear();
            List<AStarAlgorithm> aStar = new List<AStarAlgorithm>();
            for (int i = 0; i < 5; i++)
            {
                AStarAlgorithm item = new AStarAlgorithm(map, map.GetStart(i), map.GetGoal(i));
                aStar.Add(item);
            }
            await Task.Delay(100);
            map.Clean();
            for (int i = 0; i < 5; i++)
            {
                FindPath(aStar, i);
            }
        }

        private async void FindPath(List<AStarAlgorithm> aStar, int i)
        {
            cts[i] = new CancellationTokenSource();
            Stopwatch timer = new Stopwatch();
            try
            {
                timer.Start();
                var list = await aStar[i].Run(cts[i].Token);
                timer.Stop();
                if (list != null)
                {
                    var noti = new NotificationViewModel(map.GetStart(i), map.GetGoal(i))
                    {
                        ThreadId = i,
                        IsSuccess = true,
                        VisitedNo = aStar[i].VisitedNo,
                        Time = timer.Elapsed.TotalSeconds,
                        Distance = aStar[i].Distance,
                    };
                    Notifications.Add(noti);
                    Controls.MapControl.Instance.ConnectPath(list, i);
                }
                else
                {
                    var noti = new NotificationViewModel(map.GetStart(i), map.GetGoal(i))
                    {
                        ThreadId = i,
                        IsSuccess = false,
                        VisitedNo = aStar[i].VisitedNo,
                        Time = timer.Elapsed.TotalSeconds,
                        Distance = aStar[i].Distance,
                    };
                    Notifications.Add(noti);
                }
            }
            catch (OperationCanceledException)
            {
                cts[i] = null;
            }
        }

        private void ResetMap()
        {
            foreach (var item in cts)
            {
                if (item != null)
                    item.Cancel();
            }
            map.Clear();
            Notifications.Clear();
        }
    }
}