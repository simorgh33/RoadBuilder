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
    class MouseInputManager
    {
       
        private Point _CursorPos;
        private Size _CursorSize;

        private Rectangle _CursorRectangle;

        private List<GameObject> _InteractiveObjects;

        private Action<MouseClickEvent> _ClickListener;
        private Action<MouseOverEvent> _MouseOverListener;

        private uint _CurrentCursorType;
        private Hashtable _CursorTypes;

        private GameObject _CurrentMouseOverObject;
        private GameObject _LastMouseOverObject;

        public MouseInputManager()
        {
            this._CursorPos = new Point(0, 0);
            this._CursorSize = new Size(16, 16);

            this._CursorRectangle = new Rectangle(this._CursorPos, this._CursorSize);

            this._CurrentCursorType = Cursortypes.NORMAL;
            this._CursorTypes = new Hashtable();

            this._CurrentMouseOverObject = null;
            this._LastMouseOverObject = null;

            this._InteractiveObjects = new List<GameObject>();
        }

        public MouseInputManager(string Texture)
        {
            this._CursorPos = new Point(0, 0);
            this._CursorSize = new Size(16, 16);

            this._CursorRectangle = new Rectangle(this._CursorPos, this._CursorSize);

            this._CurrentCursorType = Cursortypes.NORMAL;
            this._CursorTypes = new Hashtable();
            this._CursorTypes.Add(Cursortypes.NORMAL, new CursorType(Texture));

            this._CurrentMouseOverObject = null;
            this._LastMouseOverObject = null;

            this._InteractiveObjects = new List<GameObject>();
        }

        public void RegisterClickListener(Action<MouseClickEvent> Action)
        {
            _ClickListener = Action;
        }

        public void RegisterMouseOverListener(Action<MouseOverEvent> Action)
        {
            _MouseOverListener = Action;
        }

        public void AddCursorType(uint Cursortype, string Texture)
        {
            this._CursorTypes.Add(Cursortype, new CursorType(Texture));
        }

        public void UpdatePosition(MouseEventArgs e)
        {
            this._CursorPos = e.Location;

            this._CursorRectangle.Location= this._CursorPos;

            if (_InteractiveObjects.Count > 0)
            {
                bool FoundMouseOverObject = false;

                Parallel.ForEach(_InteractiveObjects, (Object, state) => {

                    if (this.IntersectsCursorWithRect(Object.Rectangle))
                    {
                        this._CurrentMouseOverObject = Object;
                        FoundMouseOverObject = true;

                        if (_LastMouseOverObject == null)
                        {
                            this._LastMouseOverObject = _CurrentMouseOverObject;
                        }

                        state.Break();
                    }
                });



                if (FoundMouseOverObject == true)
                {
                    if (_CurrentMouseOverObject != _LastMouseOverObject)
                    {
                        _MouseOverListener(new MouseOverEvent(16, "MouseOverEvent", this._LastMouseOverObject, MouseOverEvent.MOUSEOVER_LEAVE));
                        this._LastMouseOverObject = this._CurrentMouseOverObject;
                    }

                    this._CurrentCursorType = Cursortypes.MOUSEOVER;
                    _MouseOverListener(new MouseOverEvent(16, "MouseOverEvent" , this._CurrentMouseOverObject, MouseOverEvent.MOUSEOVER_ENTER));
                }
                else
                {
                    this._CurrentCursorType = Cursortypes.NORMAL;

                    if (this._CurrentMouseOverObject != null)
                    {
                        _MouseOverListener(new MouseOverEvent(16, "MouseOverEvent", this._CurrentMouseOverObject, MouseOverEvent.MOUSEOVER_LEAVE));
                    }

                    this._CurrentMouseOverObject = null;
                }
            }

        }

        public void PerformClick(MouseEventArgs e)
        {
            if (_InteractiveObjects.Count > 0)
            {
                  
                if (this._CurrentMouseOverObject != null)
                {
                    _ClickListener(new MouseClickEvent(15, "MouseClickEvent", e.Button, this._CursorPos, this._CurrentMouseOverObject));
                }
                else
                {
                    _ClickListener(new MouseClickEvent(15, "MouseClickEvent", e.Button, this._CursorPos));
                }
                
            }
            else
            {
                _ClickListener(new MouseClickEvent(15, "MouseClickEvent" ,e.Button, this._CursorPos));
            }
        }

        public void RegisterInteractiveObject(GameObject Object)
        {
            this._InteractiveObjects.Add(Object);
        }

        public void RegisterInteractiveObjects(List<GameObject> Objects)
        {
            this._InteractiveObjects.AddRange(Objects);
        }

        public void UnregisterInteractiveObject(GameObject Object)
        {
            this._InteractiveObjects.Remove(Object);
        }

        public void UnregisterInteractiveObjects(List<GameObject> Objects)
        {
            foreach (GameObject O in Objects)
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

        public bool IntersectsCursorWithRect(Rectangle Rectangle)
        {
            if (this._CursorRectangle.IntersectsWith(Rectangle))
            {
                return true;
            }

            return false;
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
