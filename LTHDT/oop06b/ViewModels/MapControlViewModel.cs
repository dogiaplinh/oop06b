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
            InitView();
        }

        public static MapControlViewModel Instance { get; private set; }

        public ObservableCollection<NodeControlViewModel> Nodes
        {
            get { return nodes; }
        }

        public void SetGoal(int i, Node node)
        {
            map.SetGoal(i, node);
        }

        public void SetStart(int i, Node node)
        {
            map.SetStart(i, node);
        }

        private void InitView()
        {
            foreach (var item in map)
            {
                this.Nodes.Add(new NodeControlViewModel(item));
            }
        }
    }
}