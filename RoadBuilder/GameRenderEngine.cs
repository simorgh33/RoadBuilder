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
    static class GameRenderEngine
    {
        public static void DrawGameObject(PaintEventArgs e, DrawableGameObject Object)
        {
            if (Object.Texture.IsColorTexture == false)
            {
                e.Graphics.DrawImageUnscaled(Object.Texture.Image, Object.Position);
            }
            else
            {
                e.Graphics.FillRectangle(Object.Texture.Solidbrush, Object.Rectangle);
            }
        }

       /*public static void DrawInterfaceObject(PaintEventArgs e, DrawableInterfaceObject Object)
        {
            if (Object.Texture.IsColorTexture == false)
            {
                e.Graphics.DrawImageUnscaled(Object.Texture.Image, Object.Position);
            }
            else
            {
                e.Graphics.FillRectangle(Object.Texture.Solidbrush, Object.Rectangle);
            }
        }*/

        public static void DrawGameObject(PaintEventArgs e, Texture2D Texture, Rectangle Rectangle)
        {
            e.Graphics.DrawImage(Texture.Image, Rectangle);
        }

        public static void DrawRectangleOfObject(PaintEventArgs e, Rectangle Rectangle)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, Rectangle);
        }

        public static void DrawRectangleOfObject(PaintEventArgs e, DrawableGameObject Object)
        {
            e.Graphics.DrawRectangle(Pens.LightGray, Object.Rectangle);
        }

        public static void DrawFontString(PaintEventArgs e, GameFont Font)
        {
            e.Graphics.DrawString(Font.Text, Font.Font, Font.Brush, Font.Position);
        }
    }
}
