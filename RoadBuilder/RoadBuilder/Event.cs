using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roadbuilder
{
    abstract class Event
    {
        private uint _ID;
        private string _Name;
        private long _TriggerTimeTicks; 

        public Event()
        {
            this._ID = 0;
            this._Name = string.Empty;
        }

        public Event(uint _ID, string _Name)
        {
            this._ID = _ID;
            this._Name = _Name;
        }

        public virtual void TriggerEvent()
        {
            _TriggerTimeTicks = DateTime.Now.Ticks;
        }

        public uint ID
        {
            get
            {
                return this._ID;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public long TriggerTimeTicks
        {
            get
            {
                return this._TriggerTimeTicks;
            }
        }
    }
}
