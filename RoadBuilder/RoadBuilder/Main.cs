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
    sealed public partial class Roadbuilder : Form
    {
        private LevelManager LevelManager;

        private GamestateManager GamestateManager;
        private KeyInputManager KeyInputManager;
        private MouseInputManager MouseInputManager;
        private EventHandler EventHandler;

        #region Events
        private EVENT_GAME_PAUSED EVENT_GAME_PAUSED = new EVENT_GAME_PAUSED(10, "GAME_PAUSED");
        private EVENT_GAME_PAUSED EVENT_GAME_RESUMED = new EVENT_GAME_PAUSED(11, "GAME_RESUMED");
        private EVENT_MOUSE_CLICK EVENT_MOUSE_CLICK= new EVENT_MOUSE_CLICK(12, "MOUSE_CLICK");
        private EVENT_TIMER_TICK EVENT_TIMER_TICK = new EVENT_TIMER_TICK(13, "TIMER_TICK");
        private EVENT_LEVEL_CHANGED EVENT_LEVEL_CHANGED = new EVENT_LEVEL_CHANGED(13, "LEVEL_CHANGED");
        #endregion

        private Player Player;
        private GameTimer Timer1;

        public void OnLoad()
        {


            LevelManager = new LevelManager();
            LevelManager.AddLevel("Level 1", new Level("Level1", 15, 9));
            LevelManager.AddLevel("Level 2", new Level("Level2", 3, 9));

            LevelManager.SelectLevel("Level 1");
            LevelManager.GenerateLevel();

            GamestateManager = new GamestateManager();
            KeyInputManager = new KeyInputManager();
            MouseInputManager = new MouseInputManager("data\\res\\cursor\\cursor_normal.png");
            EventHandler = new EventHandler();

            KeyInputManager.BindKey(Keys.Left, new Action(() => { Player.Position = new Point(Player.Position.X - 3, Player.Position.Y); }), GameState.GAME_IN_GAME, true);
            KeyInputManager.BindKey(Keys.Right, new Action(() => { Player.Position = new Point(Player.Position.X + 3, Player.Position.Y); }), GameState.GAME_IN_GAME, true);
            KeyInputManager.BindKey(Keys.Escape, PauseGame, GameState.GAME_IN_GAME, false);
            KeyInputManager.BindKey(Keys.Escape, ResumeGame, GameState.GAME_IN_PAUSE_SCREEN, false);

            KeyInputManager.BindKey(Keys.Up, new Action(() => { LevelManager.SelectLevel("Level 1"); EventHandler.PushEvent(EVENT_LEVEL_CHANGED); }), GameState.GAME_IN_GAME, false);
            KeyInputManager.BindKey(Keys.Down, new Action(() => { LevelManager.SelectLevel("Level 2"); EventHandler.PushEvent(EVENT_LEVEL_CHANGED); }), GameState.GAME_IN_GAME, false);

            Player = new Player(10, new Point(100, 100), new Size(50, 50), "data\\res\\textures\\player1.png", true);
            Timer1 = new GameTimer();

            ///////// LAMBDA FUNCTIONS

            EventHandler.RegisterEvent(EVENT_GAME_PAUSED);
            EventHandler.RegisterEvent(EVENT_GAME_RESUMED);
            EventHandler.RegisterEvent(EVENT_MOUSE_CLICK);
            EventHandler.RegisterEvent(EVENT_TIMER_TICK);
            EventHandler.RegisterEvent(EVENT_LEVEL_CHANGED);

            EventHandler.RegisterEventListener(new Action<Event>(((e) => {

                Event Event = (Event) e;

                //MessageBox.Show("Event Triggered: " + Event.Name);

                if (Event == EVENT_GAME_PAUSED)
                {
                    Event = Event as EVENT_GAME_PAUSED;

                    MessageBox.Show("Game Paused");
                }
                else if (Event == EVENT_GAME_RESUMED)
                {
                    MessageBox.Show("Game Resumed");
                }
                else if (Event == EVENT_MOUSE_CLICK)
                {

                }
                else if (Event == EVENT_TIMER_TICK)
                {
                    
                }
                else if (Event == EVENT_LEVEL_CHANGED)
                {
                    MouseInputManager.UnregisterInteractiveObjects(LevelManager.CurrentLevelObjects);
                    LevelManager.GenerateLevel();
                    MouseInputManager.RegisterInteractiveObjects(LevelManager.CurrentLevelObjects);
                }

            })));

            MouseInputManager.RegisterInteractiveObject(Player);

            MouseInputManager.RegisterInteractiveObjects(LevelManager.CurrentLevelObjects);

            MouseInputManager.AddCursorType(Cursortypes.MOUSEOVER, "data\\res\\cursor\\cursor_interact.png");

            MouseInputManager.RegisterClickListener(new Action<MouseClickEvent>(((e) => {
            MouseClickEvent Click = (MouseClickEvent) e;

                if (Click.Button == MouseButtons.Left)
                {
                    if (Click.ClickTarget != null)
                    {
                        //MessageBox.Show("Clicked with Left Mouse at Interactive Object: " + Click.ClickTarget.ID);

                        //MessageBox.Show("IDType: " + IDSystemManager.GetTypeFromID(Click.ClickTarget.ID).ToString());
                        if (Click.ClickTarget != Player)
                        {
                            Player.Move((Tile)Click.ClickTarget);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Clicked with Left Mouse at no Object ");
                    }
                }
                else if (Click.Button == MouseButtons.Right)
                {
                    if (Click.ClickTarget != null)
                    {
                        MessageBox.Show("Clicked with Right Mouse at Interactive Object: " + Click.ClickTarget.ID);
                    }
                    else
                    {
                        MessageBox.Show("Clicked with Left Mouse at no Object ");
                    }
                }

            })));

            MouseInputManager.RegisterMouseOverListener(new Action<MouseOverEvent>(((e) => {
            MouseOverEvent MouseOver = (MouseOverEvent)e;

                    if (MouseOver.MouseOverType == MouseOverEvent.MOUSEOVER_ENTER)
                    {
                        MouseOver.MouseOverTarget.RenderRectangle = true;
                    }
                    else if (MouseOver.MouseOverType == MouseOverEvent.MOUSEOVER_LEAVE)
                    {
                        MouseOver.MouseOverTarget.RenderRectangle = false;
                    }
                
            })));

            GamestateManager.ChangeGamestate(GameState.GAME_IN_GAME);

            Timer1.RegisterEventListener(new Action<TimerTickEvent>(((e) => {

                EventHandler.PushEvent(EVENT_TIMER_TICK);

            })));

            Timer1.Start();
        }
        
        public void OnUpdate()
        {
            Timer1.Tick();
        }

        public void OnRender(PaintEventArgs e)
        {
            LevelManager.Render(e);
            Player.Render(e);
            MouseInputManager.Render(e);
        }

        public void OnKeyInput(KeyEventArgs e, uint KeyState)
        {
            KeyInputManager.DoEvents(e, KeyState, GamestateManager.CurrentGamestate);
        }

        public void OnMouseInput(MouseEventArgs e)
        {
            MouseInputManager.UpdatePosition(e);
        }

        public void PauseGame()
        {
            this.Text = "Paused";
            GamestateManager.ChangeGamestate(GameState.GAME_IN_PAUSE_SCREEN);

            EventHandler.PushEvent(new EVENT_GAME_PAUSED());
        }

        public void ResumeGame()
        {
            this.Text = "Resumed";
            GamestateManager.ChangeGamestate(GameState.GAME_IN_GAME);

            EventHandler.PushEvent(EVENT_GAME_RESUMED);
        }

    }
}
