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
    class Player : MoveableGameObject
    {
        private Tile _CurrentTile;

        public Player() : base()
        {
            _CurrentTile = null;
        }

        public Player(uint ID, Point Position, Size Size, string TexturePath) : base(ID, Position, Size, TexturePath)
        {
            _CurrentTile = null;
        }

        public Player(uint ID, Point Position, Size Size, string TexturePath, bool IsVisible) : base(ID, Position, Size, TexturePath, IsVisible)
        {
            _CurrentTile = null;
        }

        public void Move(Tile NewTile)
        {
            _CurrentTile = NewTile;
            base.Position = NewTile.Position;
        }
    }
}
