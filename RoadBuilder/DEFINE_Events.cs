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



    static class EventType
    {

        //ENGINE EVENTS
        public static string EVENT_FPS_UPDATE = "EVENT_FPS_UPDATE";

        //GAME EVENTS
        public static string EVENT_GAME_PAUSED = "EVENT_GAME_PAUSED";
        public static string EVENT_GAME_RESUMED = "EVENT_GAME_RESUMED";

        //PLAYER EVENTS
        public static string EVENT_PLAYER_MOVED = "EVENT_PLAYER_MOVED";


        //TIMER EVENTS
        public static string EVENT_TIMER_TICK = "EVENT_TIMER_TICK";

        //MOUSE EVENTS
        public static string EVENT_MOUSE_CLICK = "EVENT_MOUSE_CLICK";
        public static string EVENT_MOUSE_ENTER = "EVENT_MOUSE_ENTER";
        public static string EVENT_MOUSE_LEAVE = "EVENT_MOUSE_LEAVE";
        public static string EVENT_MOUSE_MOVE = "EVENT_MOUSE_MOVE";

    }



    sealed class EVENT_GAME_PAUSED : Event
    {
        public EVENT_GAME_PAUSED() : base()
        {

        }

        public EVENT_GAME_PAUSED(GameObject Sender, string Name) : base(Sender, Name)
        {

        }
    }

    sealed class EVENT_GAME_RESUMED : Event
    {
        public EVENT_GAME_RESUMED() : base()
        {

        }

        public EVENT_GAME_RESUMED(GameObject Sender, string Name) : base(Sender, Name)
        {

        }
    }

    sealed class EVENT_MOUSE_CLICK : Event
    {
        private MouseButtons _Button;
        private DrawableGameObject _ClickedObject;
        private Point _ClickPosition;

        public EVENT_MOUSE_CLICK() : base()
        {
            this._Button = MouseButtons.None;
            this._ClickedObject = null;
            this._ClickPosition = Point.Empty;

        }

        public EVENT_MOUSE_CLICK(GameObject Sender, string Name, MouseButtons Button, Point ClickPosition, DrawableGameObject ClickedObject) : base(Sender, Name)
        {
            this._Button = Button;
            this._ClickPosition = ClickPosition;
            this._ClickedObject = ClickedObject;
        }

        public MouseButtons Mousebutton
        {
            get
            {
                return this._Button;
            }
        }

        public DrawableGameObject ClickedObject
        {
            get
            {
                return this._ClickedObject;
            }
        }

        public Point ClickPositon
        {
            get
            {
                return this._ClickPosition;
            }
        }
    }

    sealed class EVENT_MOUSE_MOVE : Event
    {
        public EVENT_MOUSE_MOVE() : base()
        {

        }

        public EVENT_MOUSE_MOVE(GameObject Sender, string Name) : base(Sender, Name)
        {

        }
    }

    sealed class EVENT_MOUSE_ENTER : Event
    {
        private DrawableGameObject _EnteredObject;

        public EVENT_MOUSE_ENTER() : base()
        {
            _EnteredObject = null;
        }

        public EVENT_MOUSE_ENTER(GameObject Sender, string Name, DrawableGameObject EnteredObject) : base(Sender, Name)
        {
            this._EnteredObject = EnteredObject;
        }

        public DrawableGameObject EnteredObject
        {
            get
            {
                return this._EnteredObject;
            }
        }
    }

    sealed class EVENT_MOUSE_LEAVE : Event
    {
        private DrawableGameObject _LeavedObject;

        public EVENT_MOUSE_LEAVE() : base()
        {
            this._LeavedObject = null;
        }

        public EVENT_MOUSE_LEAVE(GameObject Sender, string Name, DrawableGameObject LeavedObject) : base(Sender, Name)
        {
            this._LeavedObject = LeavedObject;
        }

        public DrawableGameObject LeavedObject
        {
            get
            {
                return this._LeavedObject;
            }
        }
    }

    sealed class EVENT_TIMER_TICK : Event
    {
        public EVENT_TIMER_TICK() : base()
        {

        }

        public EVENT_TIMER_TICK(GameObject Sender, string Name) : base(Sender, Name)
        {

        }
    }

    sealed class EVENT_LEVEL_CHANGED : Event
    {

        public EVENT_LEVEL_CHANGED() : base()
        {

        }

        public EVENT_LEVEL_CHANGED(GameObject Sender, string Name) : base(Sender, Name)
        {

        }
    }

    sealed class EVENT_PLAYER_MOVED : Event
    {

        public EVENT_PLAYER_MOVED() : base()
        {

        }

        public EVENT_PLAYER_MOVED(GameObject Sender, string Name) : base(Sender, Name)
        {

        }
    }

    sealed class EVENT_FPS_UPDATE : Event
    {
        private int _CurrentFPS;

        public EVENT_FPS_UPDATE() : base()
        {
            this._CurrentFPS = 0;
        }

        public EVENT_FPS_UPDATE(string Name, int CurrentFPS) : base(Name)
        {
            this._CurrentFPS = CurrentFPS;
        }

        public int FPS
        {
            get
            {
                return this._CurrentFPS;
            }
        }
    }
}
