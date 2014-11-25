using De06B_Nhom02.Helpers;
using De06B_Nhom02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De06B_Nhom02.ViewModels
{
    public class NodeControlViewModel : BindableBase
    {
        private Node node;
        private double scale = Params.Scale;

        public NodeControlViewModel(Node node)
        {
            this.node = node;
            SetStartCommand = new RelayCommand((param) => this.SetStart(param));
            SetGoalCommand = new RelayCommand((param) => this.SetGoal(param));
            MouseMoveCommand = new RelayCommand((param) => MouseMove());
        }

        public static NodeType CurrentType { get; set; }

        public ICommand MouseMoveCommand { get; set; }

        public Node Node
        {
            get { return node; }
        }

        public double Scale
        {
            get { return scale; }
            set { scale = value; OnPropertyChanged("Scale"); }
        }

        public ICommand SetGoalCommand { get; set; }

        public ICommand SetStartCommand { get; set; }

        private void MouseMove()
        {
            if (Node.Type != NodeType.Start && Node.Type != NodeType.Goal)
                Node.Type = CurrentType;
        }

        private void SetGoal(object param)
        {
            int id = Convert.ToInt32(param);
            Node.Id = id;
            MapControlViewModel.Instance.SetGoal(Node, id);
        }

        private void SetStart(object param)
        {
            int id = Convert.ToInt32(param);
            Node.Id = id;
            MapControlViewModel.Instance.SetStart(Node, id);
        }
    }
}