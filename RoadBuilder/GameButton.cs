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
    class GameButton : DrawableGameObject
    {
        private string _Text;

        public GameButton() : base()
        {
            this._Text = string.Empty;
        }

        public GameButton(string Name, uint ID, Point Position, Size Size, Color Color, string Text, EventHandler EventHandler) : base(Name, ID, Position, Size, Color, EventHandler)
        {
            this._Text = Text;
        }

        public void OnMouseEnter()
        {
            this._Text = "Dont Klick me";
            base.Texture = new Texture2D(Color.Green);
        }

        public void OnMouseLeave()
        {
            this._Text = "Klick me";
            base.Texture = new Texture2D(Color.LightBlue);
        }
    }
}
