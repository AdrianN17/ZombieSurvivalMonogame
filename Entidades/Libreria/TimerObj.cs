using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvival.CustomLibs
{
    public class TimerObj
    {
        public Action action;
        public float maxTime;
        public float time;
        public bool isRepeat;
        public string name;

        public TimerObj(Action action, float maxTime, float time, bool isRepeat, string name)
        {
            this.action = action;
            this.maxTime = maxTime;
            this.time = time;
            this.isRepeat = isRepeat;
            this.name = name;
        }
    }
}
