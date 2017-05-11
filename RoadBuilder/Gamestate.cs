using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roadbuilder
{
    class GamestateManager
    {
        private uint _CurrentGamestate;
        private uint _LastGamestate;


        public GamestateManager()
        {
            this._CurrentGamestate = GameState.NONE;
            this._LastGamestate = GameState.NONE;
        }

        public void ChangeGamestate(uint NewGameState)
        {
            this._LastGamestate = this._CurrentGamestate;
            this._CurrentGamestate = NewGameState;
        }

        public uint CurrentGamestate
        {
            get
            {
                return this._CurrentGamestate;
            }
        }

        public uint LastGamestate
        {
            get
            {
                return this._LastGamestate;
            }
        }
    }

    public static class GameState
    {
        public static uint ALL = 10;
        public static uint NONE = 0;
        public static uint GAME_LOADING = 1;
        public static uint GAME_IN_TITLE_SCREEN = 2;
        public static uint GAME_IN_KEYBOARD_OPTIONS = 3;
        public static uint GAME_IN_GRAPHIC_OPTIONS = 4;
        public static uint GAME_IN_PAUSE_SCREEN = 5;
        public static uint GAME_IN_GAME = 6;
    }
}
