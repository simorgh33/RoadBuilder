using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Roadbuilder
{
    abstract class EventHandlingObject
    {
        private EventHandler _EventHandler;

        public EventHandlingObject() : base()
        {
            _EventHandler = null;
        }

        public EventHandlingObject(EventHandler EventHandler)
        {
            this._EventHandler = EventHandler;
        }

        protected void PushEvent(Event Event)
        {
            if (_EventHandler != null)
            {
                this._EventHandler.PushEvent(Event);
            }
        }
    }
}
