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
    class Tile : StaticGameObject
    {
        public Tile() : base()
        {

        }

        public Tile(uint ID, Point Position, string TexturePath, Size Size) : base(ID, Position, Size, TexturePath)
        {

        }

        public Tile(uint ID, Point Position, string TexturePath, Size Size, bool IsVisible) : base(ID, Position, Size, TexturePath, IsVisible)
        {

        }
    }
}
