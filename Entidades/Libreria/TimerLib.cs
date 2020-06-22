
using System;
using System.Collections.Generic;

namespace ZombieSurvival.CustomLibs
{
    public class TimerLib:IDisposable
    {
        public List<TimerObj> listTimer;

        public TimerLib()
        {
            listTimer = new List<TimerObj>();
        }

        public void Update(float dt)
        {
            foreach(var obj in listTimer)
            {
                obj.time = obj.time + dt;

                if(obj.time>obj.maxTime)
                {
                    obj.action();

                    obj.time = 0;

                    if(!obj.isRepeat)
                    {
                        listTimer.Remove(obj);
                    }

                }
            }
        }

        public void Clear()
        {
            listTimer.Clear();
        }

        public void Add(Action action, float time, string name, bool isRepeat = false)
        {

            foreach (var obj in listTimer)
            {
                if (obj.name == name)
                {
                    Console.WriteLine("existe");
                    return;
                }
            }


            listTimer.Add(new TimerObj(action, time , 0 , isRepeat, name));
        }

        public void Cancel(string name)
        {
            foreach(var obj in listTimer)
            {
                if(obj.name == name)
                {
                    listTimer.Remove(obj);
                    break;
                }
            }
        }

        public void Dispose()
        {
            listTimer.Clear();
        }
    }
}
