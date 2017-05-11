using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Roadbuilder
{
    class DrawableInterfaceObject : GameObject, IDrawable
    {
        private Size _Size;
        private Point _Position;
        private Rectangle _RenderRectangle;
        private bool _DrawRenderRectangle;
        private bool _IsVisible;

        public DrawableInterfaceObject() : base()
        {
            this._Size = new Size();
            this._Position = new Point();
            this._RenderRectangle = new Rectangle();
            this._DrawRenderRectangle = false;
            this._IsVisible = false;
        }

        public DrawableInterfaceObject(string Name, uint ID, Point Position) : base(Name, ID)
        {
            this._Size = new Size();
            this._Position = Position;
            this._RenderRectangle = new Rectangle();
            this._DrawRenderRectangle = false;
            this._IsVisible = false;
        }

        public DrawableInterfaceObject(string Name, uint ID, Point Position, EventHandler EventHandler) : base(Name, ID, EventHandler)
        {
            this._Size = new Size();
            this._Position = Position;
            this._RenderRectangle = new Rectangle();
            this._DrawRenderRectangle = false;
            this._IsVisible = false;
        }

        public void Show()
        {
            this._IsVisible = true;
        }

        public void Hide()
        {
            this._IsVisible = false;
        }

        public virtual void Render(PaintEventArgs e)
        {
            if (this._IsVisible == true)
            {
                //GameRenderEngine.DrawInterfaceObject(e, this);

                if (this._DrawRenderRectangle == true)
                {
                    GameRenderEngine.DrawRectangleOfObject(e, this._RenderRectangle);
                }
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
                this._RenderRectangle.Location = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return this._RenderRectangle;
            }
        }

        public bool IsVisible
        {
            get
            {
                return this._IsVisible;
            }
        }

        public bool DrawRenderRectangle
        {
            get
            {
                return this._DrawRenderRectangle;
            }

            set
            {
                this._DrawRenderRectangle = value;
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
                this._RenderRectangle.Size = value;
            }
        }
    }
}
