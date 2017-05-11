using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roadbuilder
{
    abstract class Event
    {
        private GameObject _Sender;
        private string _Name;
        private DateTime _TriggerTime; 

        public Event()
        {
            this._Sender = null;
            this._Name = string.Empty;
            this._TriggerTime = new DateTime();
        }

        public Event(string Name)
        {
            this._Sender = null;
            this._Name = Name;
            this._TriggerTime = DateTime.Now;
        }

        public Event(GameObject Sender, string Name)
        {
            this._Sender = Sender;
            this._Name = Name;
            this._TriggerTime = DateTime.Now;
        }

        public GameObject Sender
        {
            get
            {
                return this._Sender;
            }
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public DateTime TriggerTime
        {
            get
            {
                return this._TriggerTime;
            }
        }
    }
}
