using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftArchCW
{
    class ambulance
    {
        public string timespent
        {
            get { return TimeSpent; }
            set { TimeSpent = value; }
        }
        private string TimeSpent;

        public string actiontaken
        {
            get { return ActionTaken; }
            set { ActionTaken = value; }
        }
        private string ActionTaken;
    }
}
