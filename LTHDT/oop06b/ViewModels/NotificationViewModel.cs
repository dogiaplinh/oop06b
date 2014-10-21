using Oop06b.Helpers;
using Oop06b.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop06b.ViewModels
{
    public class NotificationViewModel : ModelBase
    {
        private int distance;
        private bool isSuccess;
        private int threadId;
        private double time;
        private int visitedNo;

        public NotificationViewModel(Node start, Node goal)
        {
            Start = start;
            Goal = goal;
        }

        public Node Start { get; private set; }

        public Node Goal { get; private set; }

        public int Distance
        {
            get { return distance; }
            set { distance = value; OnPropertyChanged("Distance"); }
        }

        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; OnPropertyChanged("IsSuccess"); }
        }

        public int ThreadId
        {
            get { return threadId; }
            set { threadId = value; OnPropertyChanged("ThreadId"); }
        }

        public double Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged("Time"); }
        }

        public int VisitedNo
        {
            get { return visitedNo; }
            set { visitedNo = value; OnPropertyChanged("VisitedNo"); }
        }
    }
}