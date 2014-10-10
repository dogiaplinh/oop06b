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
    public class NodeControlViewModel : ModelBase
    {
        private Node node;
        private double scale = Params.Scale;

        public NodeControlViewModel(Node node)
        {
            this.node = node;
            SetStartCommand = new RelayCommand((param) => this.SetStart());
            SetGoalCommand = new RelayCommand((param) => this.SetGoal());
            MouseMoveCommand = new RelayCommand((param) => MouseMove(param));
        }

        private void MouseMove(object obj)
        {
            Node.Type = NodeType.Obstacle;
        }

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

        public ICommand MouseMoveCommand { get; set; }

        private void SetGoal()
        {
            MapControlViewModel.Instance.SetGoal(Node);
        }

        private void SetStart()
        {
            MapControlViewModel.Instance.SetStart(Node);
        }
    }
}