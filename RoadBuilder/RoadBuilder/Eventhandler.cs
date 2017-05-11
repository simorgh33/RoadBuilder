using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

using System.Threading;
using System.Threading.Tasks;

namespace Roadbuilder
{
    class EventHandler
    {
        private List<Event> _RegisteredEvents;
        private Action<Event> _EventListener;
        private Hashtable _PushedEvents;

        public EventHandler()
        {
            _RegisteredEvents = new List<Event>();
            _PushedEvents = new Hashtable();
        }

        public void RegisterEvent(Event Event)
        {
            _RegisteredEvents.Add(Event);
        }
        
        public void RegisterEventListener(Action<Event> Action)
        {
            _EventListener = Action;
        }

        public void UnregisterEvent(Event Event)
        {
            _RegisteredEvents.Remove(Event);
        }

        public void PushEvent(Event Event)
        {
            _PushedEvents.Add(Event.Name, Event);
        }

        private void RemovePushedEvent(Event Event)
        {
            _PushedEvents.Remove(Event.Name);
        }

        public void PollEvents()
        {
            /*foreach (Event Event in _RegisteredEvents)
            {
                if (_PushedEvents[Event.Name] != null)
                {
                    Event.TriggerEvent();

                    _EventListener(Event);

                    RemovePushedEvent(Event);
                }
            }*/


            Parallel.ForEach(_RegisteredEvents, (Event) => {


                if (_PushedEvents[Event.Name] != null)
                {
                    Event.TriggerEvent();

                    _EventListener(Event);

                    RemovePushedEvent(Event);
                }


            });
        }
    }
}
