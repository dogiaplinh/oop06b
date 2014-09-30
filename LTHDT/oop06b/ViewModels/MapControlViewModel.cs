using oop06b.Helpers;
using oop06b.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop06b.ViewModels
{
    public class MapControlViewModel : ViewModelBase
    {
        private ObservableCollection<Node> nodes = new ObservableCollection<Node>();

        public ObservableCollection<Node> Nodes
        {
            get { return nodes; }
        }

        private Map map;

        public MapControlViewModel()
        {
            DemoMap();
        }

        public MapControlViewModel(Map map)
        {
            this.map = map;
            SetView();
        }

        private void SetView()
        {
            foreach (var item in map.Nodes)
            {
                this.Nodes.Add(item);
            }
        }

        public void DemoMap()
        {
            for (int i = -13; i <= 13; i++)
            {
                int start = (int)Math.Ceiling(-i / 2.0 - 6.2);
                int end = (int)Math.Floor(-i / 2.0 + 6.7);
                for (int j = start; j <= end; j++)
                {
                    Nodes.Add(new Node() { X = i, Y = j });
                }
            }
        }
    }
}