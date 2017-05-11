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
    class EVENT_GAME_PAUSED : Event
    {
        public EVENT_GAME_PAUSED() : base()
        {

        }

        public EVENT_GAME_PAUSED(uint ID, string Name) : base(ID, Name)
        {

        }
    }

    class EVENT_GAME_RESUMED : Event
    {
        public EVENT_GAME_RESUMED() : base()
        {

        }

        public EVENT_GAME_RESUMED(uint ID, string Name) : base(ID, Name)
        {

        }
    }

    class EVENT_MOUSE_CLICK : Event
    {
        public EVENT_MOUSE_CLICK() : base()
        {

        }

        public EVENT_MOUSE_CLICK(uint ID, string Name) : base(ID, Name)
        {

        }
    }

    class EVENT_TIMER_TICK : Event
    {
        public EVENT_TIMER_TICK() : base()
        {

        }

        public EVENT_TIMER_TICK(uint ID, string Name) : base(ID, Name)
        {

        }
    }

    class EVENT_LEVEL_CHANGED : Event
    {

        public EVENT_LEVEL_CHANGED() : base()
        {

        }

        public EVENT_LEVEL_CHANGED(uint ID, string Name) : base(ID, Name)
        {

        }
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    class MouseOverEvent : Event
    {
        public static uint MOUSEOVER_ENTER = 1;
        public static uint MOUSEOVER_LEAVE = 2;

        private GameObject _MouseOverTarget;
        private uint _MouseOverType;

        public MouseOverEvent(uint ID, string Name, GameObject Object, uint MouseOverType) : base(ID, Name)
        {
            this._MouseOverTarget = Object;
            this._MouseOverType = MouseOverType;
        }

        public GameObject MouseOverTarget
        {
            get
            {
                return this._MouseOverTarget;
            }
        }

        public uint MouseOverType
        {
            get
            {
                return this._MouseOverType;
            }
        }
    }

    class MouseClickEvent : Event
    {
        private MouseButtons _Button;
        private GameObject _ClickTarget;
        private Point _ClickPosition;

        public MouseClickEvent(uint ID, string Name, MouseButtons Button, Point ClickPosition) : base(ID, Name)
        {
            this._Button = Button;
            this._ClickTarget = null;
            this._ClickPosition = ClickPosition;

            this.TriggerEvent();
        }

        public MouseClickEvent(uint ID, string Name, MouseButtons Button, Point ClickPosition, GameObject ClickTarget) : base(ID, Name)
        {

            this._Button = Button;
            this._ClickTarget = ClickTarget;
            this._ClickPosition = ClickPosition;

            this.TriggerEvent();
        }

        public MouseButtons Button
        {
            get
            {
                return this._Button;
            }
        }

        public GameObject ClickTarget
        {
            get
            {
                return this._ClickTarget;
            }
        }

        public Point ClickPosition
        {
            get
            {
                return this.ClickPosition;
            }
        }
    }
}
