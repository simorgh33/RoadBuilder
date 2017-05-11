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
    class GameFont : DrawableGameObject
    {
        private string _Text;
        private Font _Font;
        private SolidBrush _FontColorBrush;
        private Color _FontColor;
        private Size _MeasureStringSize;


        private bool _RecalculateMeasureStringSize;

        public GameFont() : base()
        {

        }

        public GameFont(string Name, uint ID, Point Position, string Text, Font Font, Color FontColor, EventHandler EventHandler) : base(Name, ID, Position, EventHandler)
        {
            this._Text = Text;
            this._Font = Font;
            this._FontColor = FontColor;
            this._FontColorBrush = new SolidBrush(FontColor);
            this._RecalculateMeasureStringSize = true;
        }

        public GameFont(string Name, uint ID, Point Position, Color BackColor, string Text, Font Font, Color FontColor, EventHandler EventHandler) : base(Name, ID, Position, new Size(0,0), BackColor, EventHandler)
        {
            this._Text = Text;
            this._Font = Font;
            this._FontColor = FontColor;
            this._FontColorBrush = new SolidBrush(FontColor);
            this._RecalculateMeasureStringSize = true;
        }

        public override void Render(PaintEventArgs e)
        {
            base.Render(e);

            if (this._RecalculateMeasureStringSize == true)
            {
                this._MeasureStringSize = this.CalculateMeasureSize(e);
                base.Size = this._MeasureStringSize;
                this._RecalculateMeasureStringSize = false;
            }

            GameRenderEngine.DrawFontString(e, this);

        }

        private Size CalculateMeasureSize(PaintEventArgs e)
        {
            return e.Graphics.MeasureString(this._Text, this._Font).ToSize();
        }

        public string Text
        {
            get
            {
                return this._Text;
            }

            set
            {
                this._Text = value;
                this._RecalculateMeasureStringSize = true;
            }
        }

        public Font Font
        {
            get
            {
                return this._Font;
            }
        }

        public Color FontColor
        {
            get
            {
                return this._FontColor;
            }
            set
            {
                this._FontColor = value;
                this._FontColorBrush = new SolidBrush(value);
            }
        }

       public int TextWidth
       {
            get
            {
                return this._MeasureStringSize.Width;
            }
       }

        public int TextHeight
        {
            get
            {
                return this._MeasureStringSize.Height;
            }
        }


        public SolidBrush Brush
        {
            get
            {
                return this._FontColorBrush;
            }
        }


    }
}
