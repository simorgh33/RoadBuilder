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
    class MoveableGameObject : GameObject
    {
        public MoveableGameObject() : base()
        {

        }

        public MoveableGameObject(uint ID, Point Position, Size Size, string TexturePath) : base(ID, Position, Size, TexturePath)
        {

        }

        public MoveableGameObject(uint ID, Point Position, Size Size, string TexturePath, bool IsVisible) : base(ID, Position, Size, TexturePath, IsVisible)
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
