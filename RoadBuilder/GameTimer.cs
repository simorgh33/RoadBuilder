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

using System.Collections;

namespace Roadbuilder
{
    class GameTimer : GameObject
    {
        private long _StartTicks;
        private long _CurrentTicks;
        private long _LastTickTime;

        private uint _Intervall = 1000;

        private bool _IsStarted;

        public GameTimer() : base()
        {
            this._StartTicks = 0;
            this._CurrentTicks = 0;
            this._LastTickTime = 0;
            this._Intervall = 1000;
            this._IsStarted = false;

        }

        public GameTimer(string Name, uint ID, EventHandler EventHandler) : base(Name, ID, EventHandler)
        {
            this._StartTicks = 0;
            this._CurrentTicks = 0;
            this._LastTickTime = 0;
            this._Intervall = 1000;
            this._IsStarted = false;

        }

        public void Start()
        {
            _IsStarted = true;

            _StartTicks = DateTime.Now.Ticks;
            _CurrentTicks = DateTime.Now.Ticks;
            _LastTickTime = DateTime.Now.Ticks;

        }

        public void Resume()
        {
            _IsStarted = true;
        }

        public void Pause()
        {
            _IsStarted = false;
        }


        public void Stop()
        {
            _IsStarted = false;

            _StartTicks = 0;
            _CurrentTicks = 0;
            _LastTickTime = 0;
        }

        public void Tick()
        {
            if (this._IsStarted == true)
            {
                _CurrentTicks = DateTime.Now.Ticks;

                if (new TimeSpan(_CurrentTicks - _LastTickTime).TotalMilliseconds >= _Intervall)
                {
                    _LastTickTime = DateTime.Now.Ticks;

                    base.PushEvent(new EVENT_TIMER_TICK(this, EventType.EVENT_TIMER_TICK));
                }
            }
        }

        public long Ticks
        {
            get
            {
                return new TimeSpan(this._CurrentTicks - this._LastTickTime).Ticks;
            }
        }

        public uint Intervall
        {
            get
            {
                return this._Intervall;
            }

            set
            {
                this._Intervall = value;
            }
        }
    }
}
