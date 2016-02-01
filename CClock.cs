using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormJam
{
    //public delegate void delegTimeEvent(int Time);    //delegate qui représente la methode Simulator.TimeEvent


    class CClock
    {
        public DateTime Time { get; set; }                      //heure de la simulation
        public Game Game { get; private set; }       //pointeur vers le simulateur dans lequel il se trouve
        public bool Running { get; set; }                       //indique si la simulation est en pause ou non
        public int Speed { get; set; }                          //indique a quel vitesse le temps de la simulation s'écoule
        //public System.Timers.Timer Clock { get; private set; }  //le timer
        public System.Windows.Forms.Timer Clock { get; set; }
        //private Thread thread { get; set; }
        //delegTimeEvent TimeEvent;//ma variable delegate que jutilise pour appeler une methode dehors de clock
        

        public CClock(Game _game)
        {
            Time = new DateTime();
            Game = _game;
            Running = false;
            Speed = 100;
            Clock = new System.Windows.Forms.Timer();
            Clock.Interval = Speed;
            Clock.Tick += Clock_Tick;
        }

        /// <summary>
        /// boucle principale
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Clock_Tick(object sender, EventArgs e)
        {
            //Game.TimeEvent(Time.ToString("HH:mm:ss"));
            Time = Time.AddSeconds(15);
        }

        /// <summary>
        /// demarre le timer
        /// </summary>
        public void Start()
        {
            Running = true;
            Clock.Start();
        }

        /// <summary>
        /// pause le timer
        /// </summary>
        public void Pause()
        {
            Running = false;
            Clock.Stop();
        }

        /// <summary>
        /// accelere le timer
        /// </summary>
        public void Faster()
        {
            if (Clock.Interval > 20)
                Clock.Interval -= 20;
        }

        /// <summary>
        /// ralentit le timer
        /// </summary>
        public void Slower()
        {
            if (Clock.Interval < 200)
                Clock.Interval += 20;
        }
    }
}
