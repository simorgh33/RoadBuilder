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
    class Keybind
    {
        private Keys _Key;
        private Hashtable _KeyActions;

        private bool _IsKeyDown;
        private bool _IsRepeatable;

        public Keybind()
        {
            this._Key = Keys.None;
            this._KeyActions = new Hashtable();
        }

        public Keybind(Keys Key, Action Action, bool Repeatable)
        {
            this._Key = Key;
            this._KeyActions = new Hashtable();

            this._KeyActions.Add(GameState.ALL, Action);

            this._IsKeyDown = false;
            this._IsRepeatable = Repeatable;
        }

        public Keybind(Keys Key, Action Action, bool Repeatable, uint Gamestate)
        {
            this._Key = Key;
            this._KeyActions = new Hashtable();

            this._KeyActions.Add(Gamestate, Action);

            this._IsKeyDown = false;
            this._IsRepeatable = Repeatable;
        }

        public void ChangeKey(Keys NewKey)
        {
            this._Key = NewKey;
        }

        public void ClearKeyActions()
        {
            this._KeyActions.Clear();
        }

        public void ClearKey()
        {
            this._Key = Keys.None;
        }

        public void PressKey(uint Gamestate)
        {
            if (this._IsRepeatable == true)
            {
                if (this._KeyActions.ContainsKey(Gamestate) == true)
                {
                    Action Action = (Action)this._KeyActions[Gamestate];
                    Action();
                }
                else
                {
                    if (this._KeyActions.ContainsKey(GameState.ALL) == true)
                    {
                        Action Action = (Action)this._KeyActions[GameState.ALL];
                        Action();
                    }
                }
            }
            else
            {
                if (this._IsKeyDown == false)
                {
                    if (this._KeyActions.ContainsKey(Gamestate) == true)
                    {
                        Action Action = (Action)this._KeyActions[Gamestate];
                        Action();
                    }
                    else
                    {
                        if (this._KeyActions.ContainsKey(GameState.ALL) == true)
                        {
                            Action Action = (Action)this._KeyActions[GameState.ALL];
                            Action();
                        }
                    }
                }
            }
        }

        public void ReleaseKey()
        {
            this._IsKeyDown = false;
        }

        public Keys Key
        {
            get
            {
                return this._Key;
            }
        }

        public bool IsKeyDown
        {
            get
            {
                return this._IsKeyDown;
            }
        }

        public bool IsRepeatable
        {
            get
            {
                return this._IsRepeatable;
            }
        }
    }
}
