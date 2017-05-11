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
using System.Collections;

namespace Roadbuilder
{
    class LevelManager
    {
        private Level _CurrentLevel;
        private Hashtable _Levels;

        public LevelManager()
        {
            _CurrentLevel = null;
            _Levels = new Hashtable();
        }

        public void SelectLevel(string Name)
        {
            if (_Levels[Name] != null)
            {
                _CurrentLevel = (Level)_Levels[Name];
            }
        }

        public void GenerateLevel()
        {
            ClearLevelObjects();

            if (_CurrentLevel != null)
            {
                _CurrentLevel.GenerateBlocks();
            }
        }

        public void ClearLevelObjects()
        {
            _CurrentLevel.DeleteBlocks();
        }

        public void AddLevel(string Name, Level Level)
        {
            _Levels.Add(Name, Level);
        }

        public void Render(PaintEventArgs e)
        {
            _CurrentLevel.Render(e);
        }

        public string CurrentLevelName
        {
            get
            {
                return _CurrentLevel.Name;
            }
        }

        public List<DrawableGameObject> CurrentLevelObjects
        {
            get
            {
                return _CurrentLevel.LevelObjects;
            }
        }
    }
}
