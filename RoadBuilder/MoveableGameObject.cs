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
    class MoveableGameObject : DrawableGameObject
    {
        public MoveableGameObject() : base()
        {

        }

        public MoveableGameObject(string Name, uint ID, Point Position, Size Size, Color Color, EventHandler EventHandler) : base(Name, ID, Position, Size, Color, EventHandler)
        {

        }

        public MoveableGameObject(string Name, uint ID, Point Position, Size Size, string TexturePath, EventHandler EventHandler) : base(Name, ID, Position, Size, TexturePath, EventHandler)
        {

        }

        public MoveableGameObject(string Name, uint ID, Point Position, Size Size, Color Color, bool IsVisible, EventHandler EventHandler) : base(Name, ID, Position, Size, Color, IsVisible, EventHandler)
        {

        }

        public MoveableGameObject(string Name, uint ID, Point Position, Size Size, string TexturePath, bool IsVisible, EventHandler EventHandler) : base(Name, ID, Position, Size, TexturePath, IsVisible, EventHandler)
        {

        }

        public virtual void MoveLeft()
        {

        }

        public virtual void MoveRight()
        {

        }

        public virtual void MoveUp()
        {

        }

        public virtual void MoveDown()
        {

        }
    }
}
