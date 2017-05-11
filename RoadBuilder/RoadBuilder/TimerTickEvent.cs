using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roadbuilder
{
    class TimerTickEvent : Event
    {
        public TimerTickEvent(uint ID, string Name) : base(ID, Name)
        {
            base.TriggerEvent();
        }
    }
}
