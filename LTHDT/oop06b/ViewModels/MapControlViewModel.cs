using De06B_Nhom02.Helpers;
using De06B_Nhom02.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De06B_Nhom02.ViewModels
{
    public class MapControlViewModel : BindableBase
    {
        private Map map;
        private ObservableCollection<NodeControlViewModel> nodes = new ObservableCollection<NodeControlViewModel>();

        public MapControlViewModel(Map map)
        {
            Instance = this;
            this.map = map;
            SetView();
        }

        public static MapControlViewModel Instance { get; private set; }

        public ObservableCollection<NodeControlViewModel> Nodes
        {
            get { return nodes; }
        }

        public void SetGoal(Node node, int i)
        {
            map.SetGoal(node, i);
        }

        public void SetStart(Node node, int i)
        {
            map.SetStart(node, i);
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