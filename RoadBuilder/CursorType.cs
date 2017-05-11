using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roadbuilder
{
    class CursorType
    {
        private Texture2D _Texture;

        public CursorType(string TexturePath)
        {
            this._Texture = new Texture2D(TexturePath);
        }

        public Texture2D Texture
        {
            get
            {
                return this._Texture;
            }
        }
    }
}
