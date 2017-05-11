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

        public Player(string Name, uint ID, Point Position, Size Size, string TexturePath, EventHandler EventHandler) : base(Name, ID, Position, Size, TexturePath, EventHandler)
        {
            _CurrentTile = null;
        }

        public Player(string Name, uint ID, Point Position, Size Size, string TexturePath, bool IsVisible, EventHandler EventHandler) : base(Name, ID, Position, Size, TexturePath, IsVisible, EventHandler)
        {
            _CurrentTile = null;
        }

        public void Move(Tile NewTile)
        {
            _CurrentTile = NewTile;
            base.Position = NewTile.Position;

            base.PushEvent(new EVENT_PLAYER_MOVED(this, EventType.EVENT_PLAYER_MOVED));
        }
    }
}
