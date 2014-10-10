using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop06b.ViewModels
{
    public class MapControlViewModel : ModelBase
    {
        private Map map;

        private ObservableCollection<NodeControlViewModel> nodes = new ObservableCollection<NodeControlViewModel>();

        public MapControlViewModel(Map map)
        {
            Instance = this;
            this.map = map;
            SetView();
        }

        public void SetGoal(Node node)
        {
            map.Goal = node;
        }

        public void SetStart(Node node)
        {
            map.Start = node;
        }

        public static MapControlViewModel Instance { get; private set; }

        public ObservableCollection<NodeControlViewModel> Nodes
        {
            get { return nodes; }
        }

        public void DemoMap()
        {
            for (int i = -13; i <= 13; i++)
            {
                int start = (int)Math.Ceiling(-i / 2.0 - 6.7);
                int end = (int)Math.Floor(-i / 2.0 + 6.7);
            }
        }

        private void SetView()
        {
            foreach (var item in map)
            {
                this.Nodes.Add(new NodeControlViewModel(item));
            }
        }
    }
}