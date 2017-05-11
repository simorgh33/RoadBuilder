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
    interface IDrawable
    {

        void Hide();
        void Show();
        void Render(PaintEventArgs e);

        Rectangle Rectangle { get; }
        Point Position { get; set; }
        bool IsVisible { get; }

    }
}
