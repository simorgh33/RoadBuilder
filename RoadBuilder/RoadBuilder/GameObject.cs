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
    class GameObject
    {
        private uint _ID;

        private Point _Position;
        private Size _Size;
        private Rectangle _Rectangle;

        private Texture2D _Texture;

        private bool _IsVisible;
        private bool _RenderRectangle; 

        public GameObject()
        {
            this._ID = 0;
            this._Position = new Point();
            this._Size = new Size();
            this._Rectangle = new Rectangle();
            this._Texture = new Texture2D();
            this._IsVisible = false;
            this._RenderRectangle = false;
        }

        public GameObject(uint ID, Point Position, Size Size, string TexturePath)
        {
            this._ID = ID;
            this._Position = Position;
            this._Size = Size;
            this._Rectangle = new Rectangle(Position, Size);
            this._Texture = new Texture2D(TexturePath);
            this._IsVisible = true;
            this._RenderRectangle = false;
        }

        public GameObject(uint ID, Point Position, Size Size, string TexturePath, bool IsVisible)
        {
            this._ID = ID;
            this._Position = Position;
            this._Size = Size;
            this._Rectangle = new Rectangle(Position, Size);
            this._Texture = new Texture2D(TexturePath);
            this._IsVisible = IsVisible;
            this._RenderRectangle = false;
        }

        public virtual void Render(PaintEventArgs e)
        {
            if (this._IsVisible == true)
            {
                GameRenderEngine.DrawGameObject(e, this);

                if (_RenderRectangle == true)
                {
                    GameRenderEngine.DrawRectangleOfObject(e, this);
                }
            }
        }

        public void Show()
        {
            this._IsVisible = true;
        }

        public void Hide()
        {
            this._IsVisible = false;
        }

        public uint ID
        {
            get
            {
                return this._ID;
            }
        }

        public Point Position
        {
            get
            {
                return this._Position;
            }

            set
            {
                this._Position = value;
                this._Rectangle.Location = value;
            }
        }

        public Size Size
        {
            get
            {
                return this._Size;
            }

            set
            {
                this._Size = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return this._Rectangle;
            }

            set
            {
                this._Rectangle = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return this._Texture;
            }

            set
            {
                this._Texture = value;
            }
        }

        public bool RenderRectangle
        {
            get
            {
                return this._RenderRectangle;
            }

            set
            {
                this._RenderRectangle = value;
            }
        }
    }
}
