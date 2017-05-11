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
    class KeyInputManager
    {

        public static uint KEYSTATE_PRESS= 1;
        public static uint KEYSTATE_RELEASE = 2;

        private Hashtable _KeyBinds;
     
        public KeyInputManager()
        {
            _KeyBinds = new Hashtable();
        }

        public void BindKey(Keys Key, Action Action, bool IsRepeatable)
        {
            _KeyBinds.Add(Key.ToString() + ":" + GameState.ALL.ToString(), new Keybind(Key, Action, IsRepeatable));
        }

        public void BindKey(Keys Key, Action Action, uint Gamestate, bool IsRepeatable)
        {
            _KeyBinds.Add(Key.ToString() + ":" + Gamestate.ToString(), new Keybind(Key, Action, IsRepeatable, Gamestate));
        }

        public void UnbindKey(Keys Key)
        {
            _KeyBinds.Remove(Key.ToString() + ":" + GameState.ALL.ToString());
        }

        public void UnbindKey(Keys Key, uint Gamestate)
        {
            _KeyBinds.Remove(Key.ToString() + ":" + Gamestate.ToString());
        }

        public void ClearAllKeyBinds(Keys Key, uint Gamestate)
        {
            _KeyBinds.Clear();
        }

        public void DoEvents(KeyEventArgs e, uint Keystate, uint Gamestate)
        {

            Keybind Key = new Keybind();

            if (_KeyBinds.ContainsKey(e.KeyCode.ToString() + ":" + Gamestate.ToString()) == true)
            {
                Key = (Keybind)_KeyBinds[e.KeyCode.ToString() + ":" + Gamestate.ToString()];

                if (Keystate == KEYSTATE_PRESS)
                {
                    Key.PressKey(Gamestate);
                }
                else if (Keystate == KEYSTATE_RELEASE)
                {
                    Key.ReleaseKey();
                }
            }
            else if (_KeyBinds.ContainsKey(e.KeyCode.ToString() + ":" + GameState.ALL.ToString()) == true)
            {
                Key = (Keybind)_KeyBinds[e.KeyCode.ToString() + ":" + GameState.ALL.ToString()];

                if (Keystate == KEYSTATE_PRESS)
                {
                    Key.PressKey(GameState.ALL);
                }
                else if (Keystate == KEYSTATE_RELEASE)
                {
                    Key.ReleaseKey();
                }
            }
        }
    }
}
