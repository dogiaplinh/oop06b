using Oop06b.Helpers;
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
        private TimeSpan time;

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

        public TimeSpan Time
        {
            get { return time; }
            set { time = value; OnPropertyChanged("Time"); }
        }
    }
}