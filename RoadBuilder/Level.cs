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
    class Level
    {
        private string _Name;
        private uint _VerticalBlocks;
        private uint _HorizontalBlocks;
        private List<DrawableGameObject> _LevelObjects;

        public Level()
        {
            _Name = string.Empty;
            _VerticalBlocks = 0;
            _HorizontalBlocks = 0;
            _LevelObjects = new List<DrawableGameObject>();
        }

        public Level(string LevelName, uint VerticalBlocks, uint HorizontalBlocks)
        {
            _Name = LevelName;
            _VerticalBlocks = VerticalBlocks;
            _HorizontalBlocks = HorizontalBlocks;
            _LevelObjects = new List<DrawableGameObject>();
        }

        public void GenerateBlocks()
        {
            int XPos = 100;
            int YPos = 70;

            int BlockSize = 50;
            int BlockSpace = 1; 

            for (int i = 0; i < _HorizontalBlocks; i++)
            {
                for (int o = 0; o < _VerticalBlocks; o++)
                {
                    _LevelObjects.Add(new Tile("TestTile" , 1,new Point(XPos, YPos), Color.Red, new Size(BlockSize, BlockSize)));
                    XPos = XPos + BlockSize + BlockSpace;
                }

                XPos = 100;
                YPos = YPos + BlockSize + BlockSpace;
            }
        }

        public void DeleteBlocks()
        {
            LevelObjects.Clear();
        }

        public void Render(PaintEventArgs e)
        {
            foreach (DrawableGameObject Object in _LevelObjects)
            {
                Object.Render(e);
            }
           
        }

        public string Name
        {
            get
            {
                return this._Name;
            }
        }

        public List<DrawableGameObject> LevelObjects
        {
            get
            {
                return this._LevelObjects;
            }
        }

    }
}
