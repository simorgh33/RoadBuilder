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
    class StaticGameObject : GameObject
    {
        public StaticGameObject() : base()
        {

        }

        public StaticGameObject(uint ID, Point Position, Size Size, string TexturePath) : base(ID, Position, Size, TexturePath)
        {

        }

        public StaticGameObject(uint ID, Point Position, Size Size, string TexturePath, bool IsVisible) : base(ID, Position, Size, TexturePath, IsVisible)
        {

        }
    }
}
