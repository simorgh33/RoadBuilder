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

        private static double FRAME_LIMIT = 60.0;
        private static double FRAME_TOLERANCE = 3.8;

        private int frames = 0; //Anzahl Bilder pro Sekunde

        public Roadbuilder()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            Cursor.Hide();
        }

        public void GameLoop()
        { 
            long startTime = DateTime.Now.Ticks; //Startzeit
            long updateLoopStartTime = DateTime.Now.Ticks; //Startzeit der Updateschleife
            double maxReachableFps = 1000.0 / FRAME_LIMIT; //Delta zwischen den Durchläufen. Zurückgerechnet, ergibt dies die Anzahl an durchläufen der Updateschleife pro Sekunde in gleichgroßen Zeitabständen

            OnLoad();

            while (this.Created)
            {
                if (this.WindowState != FormWindowState.Minimized) //Falls nicht Minimiert
                {
                    if (new TimeSpan(DateTime.Now.Ticks - updateLoopStartTime).Milliseconds >= maxReachableFps - FRAME_TOLERANCE) //Bewirkt eine Limitierte Bilder pro Sekunde anzahl
                    {

                        updateLoopStartTime = DateTime.Now.Ticks;
                        frames++; //Bilder pro Sekunde

                        EventHandler.PollEvents();

                        OnUpdate();

                        TimeSpan deltaFpsCounter = new TimeSpan(DateTime.Now.Ticks - startTime);

                        if (deltaFpsCounter.Seconds >= 1) //Falls der Zeitunterschied größer als eine Sekunde ist, sollen die Bilder pro Sekunde etc. Aktualisiert werden
                        {
                            EventHandler.PushEvent(new EVENT_FPS_UPDATE("EVENT_FPS_UPDATE", frames));
                            frames = 0;
                            startTime = DateTime.Now.Ticks;
                        }
                    }
                }

                Application.DoEvents(); //Events werden abgearbeitet. Ohne diesen Befehl aufgrund von Dauerschleife keine Abarbeitung
                this.Invalidate(); //Neuzeichnen der Form wird ausgelöst
            }
        }

        private void Roadbuilder_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            OnRender(e);
        }

        private void Roadbuilder_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyInput(e, KeyInputManager.KEYSTATE_RELEASE);
        }

        private void Roadbuilder_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyInput(e, KeyInputManager.KEYSTATE_PRESS);
        }

        private void Roadbuilder_MouseMove(object sender, MouseEventArgs e)
        {
            MouseInputManager.UpdateCursorPosition(e);
        }

        private void Roadbuilder_MouseDown(object sender, MouseEventArgs e)
        {
            MouseInputManager.PerformClick(e);
        }

        private void Roadbuilder_MouseUp(object sender, MouseEventArgs e)
        {
            MouseInputManager.PerformClick(e);
        }
    }
}
