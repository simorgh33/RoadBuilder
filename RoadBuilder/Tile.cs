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
        private bool _CLICKED = false;
        private bool _Coin = false;
        public Tile() : base()
        {

        }

        public Tile(string Name, uint ID, Point Position, Color Color, Size Size) : base(Name, ID, Position, Size, Color, null)
        {

        }

        public Tile(string Name, uint ID, Point Position, string TexturePath, Size Size) : base(Name, ID, Position, Size, TexturePath, null)
        {

        }

        public Tile(string Name, uint ID, Point Position, string TexturePath, Size Size, EventHandler EventHandler) : base(Name, ID, Position, Size, TexturePath, EventHandler)
        {

        }

        public Tile(string Name, uint ID, Point Position, string TexturePath, Size Size, bool IsVisible, EventHandler EventHandler) : base(Name, ID, Position, Size, TexturePath, IsVisible, EventHandler)
        {

        }
        public bool IsClicked
        {
            get { return this._CLICKED; }
            set { this._CLICKED = value; }
        }
        public bool setCoin
        {
            get { return this._Coin; }
            set { this._Coin = value; }
        }
    }
}
