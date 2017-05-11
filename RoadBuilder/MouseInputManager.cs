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
    class MouseInputManager : EventHandlingObject
    {
        private Point _CursorPos;
        private Size _CursorSize;

        private Rectangle _CursorRectangle;

        private List<DrawableGameObject> _InteractiveObjects;

        private uint _CurrentCursorType;
        private Hashtable _CursorTypes;

        private DrawableGameObject _CurrentMouseOverObject;

        public MouseInputManager() : base()
        {
            this._CursorPos = new Point(0, 0);
            this._CursorSize = new Size(16, 16);

            this._CursorRectangle = new Rectangle(this._CursorPos, this._CursorSize);

            this._CurrentCursorType = Cursortypes.NORMAL;
            this._CursorTypes = new Hashtable();

            this._CurrentMouseOverObject = null;

            this._InteractiveObjects = new List<DrawableGameObject>();
        }

        public MouseInputManager(string Texture, EventHandler EventHandler) : base(EventHandler)
        {
            this._CursorPos = new Point(0, 0);
            this._CursorSize = new Size(16, 16);

            this._CursorRectangle = new Rectangle(this._CursorPos, this._CursorSize);

            this._CurrentCursorType = Cursortypes.NORMAL;
            this._CursorTypes = new Hashtable();
            this._CursorTypes.Add(Cursortypes.NORMAL, new CursorType(Texture));

            this._CurrentMouseOverObject = null;

            this._InteractiveObjects = new List<DrawableGameObject>();
        }

        public void AddCursorType(uint Cursortype, string Texture)
        {
            this._CursorTypes.Add(Cursortype, new CursorType(Texture));
        }

        public void UpdateCursorPosition(MouseEventArgs e)
        {
            if (e.Location != _CursorPos)
            {
                base.PushEvent(new EVENT_MOUSE_MOVE(null, EventType.EVENT_MOUSE_MOVE));

                this._CursorPos = e.Location;
                this._CursorRectangle.Location = e.Location;

                DrawableGameObject MouseOverObject = null;

                foreach (DrawableGameObject Object in this._InteractiveObjects)
                {
                    if (IsMouseOver(Object) == true)
                    {
                        MouseOverObject = Object;
                        break;
                    }
                }

                if (MouseOverObject != null)
                {
                    if (this._CurrentMouseOverObject == null)
                    {
                        this._CurrentCursorType = Cursortypes.MOUSEOVER;
                        this._CurrentMouseOverObject = MouseOverObject;
                        base.PushEvent(new EVENT_MOUSE_ENTER(null, EventType.EVENT_MOUSE_ENTER, this._CurrentMouseOverObject));
                    }
                    else
                    {
                        if (this._CurrentMouseOverObject != MouseOverObject)
                        {
                            this._CurrentCursorType = Cursortypes.NORMAL;
                            base.PushEvent(new EVENT_MOUSE_LEAVE(null, EventType.EVENT_MOUSE_LEAVE, this._CurrentMouseOverObject));
                            this._CurrentMouseOverObject = null;
                        }
                    }
                }
                else
                {
                    if (this._CurrentMouseOverObject != null)
                    {
                        this._CurrentCursorType = Cursortypes.NORMAL;
                        base.PushEvent(new EVENT_MOUSE_LEAVE(null, EventType.EVENT_MOUSE_LEAVE, this._CurrentMouseOverObject));
                        this._CurrentMouseOverObject = null;
                    }
                }
            }
        }

        private bool IsMouseOver(DrawableGameObject Object)
        {
            if (this._CursorRectangle.IntersectsWith(Object.Rectangle) == true)
            {
                return true;
            }

            return false;
        }

        public void PerformClick(MouseEventArgs e)
        {
            base.PushEvent(new EVENT_MOUSE_CLICK(null, EventType.EVENT_MOUSE_CLICK, e.Button, e.Location, this._CurrentMouseOverObject));
        }

        public void RegisterInteractiveObject(DrawableGameObject Object)
        {
            this._InteractiveObjects.Add(Object);
        }

        public void RegisterInteractiveObjects(List<DrawableGameObject> Objects)
        {
            this._InteractiveObjects.AddRange(Objects);
        }

        public void UnregisterInteractiveObject(DrawableGameObject Object)
        {
            this._InteractiveObjects.Remove(Object);
        }

        public void UnregisterInteractiveObjects(List<DrawableGameObject> Objects)
        {
            foreach (DrawableGameObject O in Objects)
            {
                this._InteractiveObjects.Remove(O);
            }
        }

        public void Render(PaintEventArgs e)
        {
            CursorType CursorType = (CursorType)this._CursorTypes[this._CurrentCursorType];

            if (CursorType != null)
            {
                GameRenderEngine.DrawGameObject(e, CursorType.Texture, _CursorRectangle);
            }
            else
            {
                CursorType = (CursorType)this._CursorTypes[Cursortypes.NORMAL];
                GameRenderEngine.DrawGameObject(e, CursorType.Texture, _CursorRectangle);
            }
        }

        public Point Position
        {
            get
            {
                return this._CursorPos;
            }
        }

        public Size Size
        {
            get
            {
                return this._CursorSize;
            }
        }
    }

    static class Cursortypes
    {
        public static uint NORMAL = 0;
        public static uint MOUSEOVER = 1;
    }
}
