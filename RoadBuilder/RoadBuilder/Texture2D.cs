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
    struct Texture2D // Struktur für Texturen
    {
        private string path; //Bildpfad
        private Bitmap image; //Bitmap - Bild
        private TextureBrush brush;
        private Color color;
        private SolidBrush solidBrush;

        public Texture2D(string file) //Konstruktor 
        {
            this.path = file;
            this.image = null;
            this.color = Color.Empty;
            this.brush = null;
            this.solidBrush = null;

            image = new Bitmap(path); //Neue Bitmap wird erstellt
            brush = new TextureBrush(image);

            this.brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
        }

        public Texture2D(Color color) //Konstruktor 
        {
            this.path = "NoPath";
            this.color = color;
            this.image = null;
            this.brush = null;
            this.solidBrush = new SolidBrush(color);
        }


        //Properties//

        public string File //Get & Set zum ändern der Datei. Läd Automatisch
        {
            get
            {
                return path;
            }
        }

        public Bitmap Image
        {
            get
            {
                return this.image;
            }
        }

        public TextureBrush TextureBrush
        {
            get
            {
                return this.brush;
            }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
                this.solidBrush = new SolidBrush(value);
            }
        }

        public SolidBrush Solidbrush
        {
            get
            {
                return this.solidBrush;
            }
        }
    }
}
