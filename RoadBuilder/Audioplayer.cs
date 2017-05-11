using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading.Tasks;
using System.Threading;

namespace Roadbuilder
{
    sealed class Audioplayer // Klasse zum Wiedergeben von Audiodateien
    {
        private SoundPlayer player;
        private long lastPlayTime;

        public Audioplayer(string file) //Konstruktor
        {
            player = new SoundPlayer(); //Neue SoundPlayer instanz wird erstellt
            lastPlayTime = 0;
            load(file); //Läd datei. Siehe methode load
        }

        private void load(string file) //Läd die Datei falls vorhanden, in einen neuen Thread (Asynchron)
        {
            try
            {
                player.SoundLocation = new System.IO.FileInfo(file).FullName; //Audiopfad wird in das Objekt eingelesen
                player.LoadAsync(); //Asynchrones laden der Audiodatei
            }
            catch
            {
                MessageBox.Show(null, "SoundDatei [" + file + "] konnte nicht geladen werden", "Fehler"); //Datei kann nicht geladen werden
            }
        }

        public void play() //Gibt die eingelesene Audiodatei in einem neuen Thread parallel wieder
        {

            if (new TimeSpan(DateTime.Now.Ticks - lastPlayTime).Milliseconds > 20)
            {
                player.Play();
                lastPlayTime = DateTime.Now.Ticks;
            }
        }

        public void stop() //Stoppt die Wiedergabe
        {
            player.Stop();
        }
    }

}
