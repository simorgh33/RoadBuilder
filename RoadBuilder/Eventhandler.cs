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
        private List<string> _RegisteredEvents;
        private Action<string, Event> _EventListener;
        private List<Event> _PushedEvents;

        public EventHandler()
        {
            _RegisteredEvents = new List<string>();
            _PushedEvents = new List<Event>();
        }

        public void RegisterEvent(string EventName)
        {
            _RegisteredEvents.Add(EventName);
        }

        public void RegisterEventListener(Action<string, Event> Action)
        {
            _EventListener = Action;
        }

        public void UnregisterEvent(string EventName)
        {
            _RegisteredEvents.Remove(EventName);
        }

        public void PushEvent(Event Event)
        {
            _PushedEvents.Add(Event);
        }

        private void RemovePushedEvent(Event Event)
        {
            _PushedEvents.Remove(Event);
        }

        public void PollEvents()
        {
            for (int i = 0; i < _PushedEvents.Count; i++)
            {
                for (int o = 0; o < _RegisteredEvents.Count; o++)
                {
                    if (i < _PushedEvents.Count && o < _RegisteredEvents.Count)
                    {
                        if (_PushedEvents[i].Name == _RegisteredEvents[o])
                        {
                            _EventListener(_PushedEvents[i].Name, _PushedEvents[i]);

                            RemovePushedEvent(_PushedEvents[i]);
                        }
                    }
                }
            }
        }
    }
}
