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

       private Random zufallszahl;

        private GamestateManager GamestateManager;
        private KeyInputManager KeyInputManager;
        private MouseInputManager MouseInputManager;
        private EventHandler EventHandler;

        private Player Player;
        private GameTimer Timer1;
        private GameTimer Timer2;

        private GameButton Button1;

        private GameFont Fontstring1;
        private GameFont Fontstring2;

        public void OnLoad()
        {

            LevelManager = new LevelManager();
            LevelManager.AddLevel("Level 1", new Level("Level1", 15, 9));
            LevelManager.AddLevel("Level 2", new Level("Level2", 3, 9));

            LevelManager.SelectLevel("Level 1");
            LevelManager.GenerateLevel();

            GamestateManager = new GamestateManager();
            KeyInputManager = new KeyInputManager();
            EventHandler = new EventHandler();

            MouseInputManager = new MouseInputManager("data\\res\\cursor\\cursor_normal.png", this.EventHandler);

            KeyInputManager.BindKey(Keys.Left, new Action(() => { Player.Position = new Point(Player.Position.X - 3, Player.Position.Y); }), GameState.GAME_IN_GAME, true);
            KeyInputManager.BindKey(Keys.Right, new Action(() => { Player.Position = new Point(Player.Position.X + 3, Player.Position.Y); }), GameState.GAME_IN_GAME, true);
            KeyInputManager.BindKey(Keys.Escape, PauseGame, GameState.GAME_IN_GAME, false);
            KeyInputManager.BindKey(Keys.Escape, ResumeGame, GameState.GAME_IN_PAUSE_SCREEN, false);

            //KeyInputManager.BindKey(Keys.Up, new Action(() => { LevelManager.SelectLevel("Level 1"); EventHandler.PushEvent(EVENT_LEVEL_CHANGED); }), GameState.GAME_IN_GAME, false);
            //KeyInputManager.BindKey(Keys.Down, new Action(() => { LevelManager.SelectLevel("Level 2"); EventHandler.PushEvent(EVENT_LEVEL_CHANGED); }), GameState.GAME_IN_GAME, false);

            Player = new Player("Player", 10, new Point(100, 100), new Size(50, 50), "data\\res\\textures\\player1.png", true, this.EventHandler);

            Timer1 = new GameTimer("Timer1", 30, this.EventHandler);
            Timer2 = new GameTimer("Timer2", 30, this.EventHandler);

            Button1 = new GameButton("Button1", 10, new Point(400, 550), new Size(120, 50), Color.Yellow, "Hallo Welt", this.EventHandler);

            Fontstring1 = new GameFont("Fontstring Hallo", 15, new Point(this.Width - 100, 15), String.Empty, new Font(FontFamily.GenericMonospace, 14), Color.LightGreen, this.EventHandler);
            Fontstring2 = new GameFont("Fontstring Hallo", 15, new Point(this.Width - 100, 40), Color.Blue, "Hallo", new Font(FontFamily.GenericMonospace, 14), Color.LightGreen, this.EventHandler);

            ///////// LAMBDA FUNCTIONS

            EventHandler.RegisterEvent(EventType.EVENT_FPS_UPDATE);
            EventHandler.RegisterEvent(EventType.EVENT_PLAYER_MOVED);
            EventHandler.RegisterEvent(EventType.EVENT_TIMER_TICK);
            EventHandler.RegisterEvent(EventType.EVENT_MOUSE_MOVE);
            EventHandler.RegisterEvent(EventType.EVENT_MOUSE_CLICK);
            EventHandler.RegisterEvent(EventType.EVENT_MOUSE_LEAVE);
            EventHandler.RegisterEvent(EventType.EVENT_MOUSE_ENTER);

            EventHandler.RegisterEventListener(new Action<string, Event>(((EventName, PushedEvent) => {
            Event RawEvent = (Event)PushedEvent;

                // MessageBox.Show(EventName);

                if (EventName == EventType.EVENT_TIMER_TICK)
                {
                    GameTimer gt = (GameTimer)RawEvent.Sender;

                    if (RawEvent.Sender.Name == Timer1.Name)
                    {
                        //MessageBox.Show("Timer 1 Ticked");
                    }
                    else if (RawEvent.Sender.Name == Timer2.Name)
                    {
                        // MessageBox.Show("Timer 2 Ticked");
                    }
                }
                else if (EventName == EventType.EVENT_GAME_PAUSED)
                {

                }
                else if (EventName == EventType.EVENT_GAME_RESUMED)
                {

                }
                else if (EventName == EventType.EVENT_MOUSE_MOVE)
                {
                    //MessageBox.Show("MOUSE MOVE");

                }
                else if (EventName == EventType.EVENT_MOUSE_ENTER)
                {
                    EVENT_MOUSE_ENTER Event = RawEvent as EVENT_MOUSE_ENTER;


                    Event.EnteredObject.RenderRectangle = true;

                }
                else if (EventName == EventType.EVENT_MOUSE_LEAVE)
                {
                    EVENT_MOUSE_LEAVE Event = RawEvent as EVENT_MOUSE_LEAVE;


                    Event.LeavedObject.RenderRectangle = false;


                }
                else if (EventName == EventType.EVENT_MOUSE_CLICK)
                {
                    EVENT_MOUSE_CLICK Event = RawEvent as EVENT_MOUSE_CLICK;

                    if (Event.ClickedObject != null)
                    {
                        if (Event.ClickedObject != Player && Event.ClickedObject != Fontstring1)
                        {
                            
                            Player.Move((Tile)Event.ClickedObject);
                            Tile t = ((Tile)Event.ClickedObject);
                            MessageBox.Show("data\\res\\textures\\" + test + ".png");
                            t.Texture = new Texture2D("data\\res\\textures\\"+test+".png");
                            MessageBox.Show("data\\res\\textures\\" + test + ".png");
                            test++;
                        }
                    }

                }
                else if (EventName == EventType.EVENT_FPS_UPDATE)
                {
                    EVENT_FPS_UPDATE Event = RawEvent as EVENT_FPS_UPDATE;

                    Fontstring1.Text = Event.FPS + " Fps";
                }

            })));

            MouseInputManager.RegisterInteractiveObject(Player);
            MouseInputManager.RegisterInteractiveObject(Button1);
            MouseInputManager.RegisterInteractiveObject(Fontstring1);

            MouseInputManager.RegisterInteractiveObjects(LevelManager.CurrentLevelObjects);

            MouseInputManager.AddCursorType(Cursortypes.MOUSEOVER, "data\\res\\cursor\\cursor_interact.png");

            GamestateManager.ChangeGamestate(GameState.GAME_IN_GAME);

            //Timer1.Start();
            //Timer2.Start();
        }
        
        public void OnUpdate()
        {
            Timer1.Tick();
            Timer2.Tick();
        }

        public void OnRender(PaintEventArgs e)
        {
            LevelManager.Render(e);
            Player.Render(e);
            Button1.Render(e);
            Fontstring1.Render(e);
            Fontstring2.Render(e);
            MouseInputManager.Render(e);
        }

        public void OnKeyInput(KeyEventArgs e, uint KeyState)
        {
            KeyInputManager.DoEvents(e, KeyState, GamestateManager.CurrentGamestate);
        }

        public void PauseGame()
        {
            this.Text = "Paused";
            GamestateManager.ChangeGamestate(GameState.GAME_IN_PAUSE_SCREEN);
        }

        public void ResumeGame()
        {
            this.Text = "Resumed";
            GamestateManager.ChangeGamestate(GameState.GAME_IN_GAME);
        }

    }
}
