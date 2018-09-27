using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SimpleGame.Model
{
    class Wereld
    {
        public Bal Bal { get; set; }
        private DispatcherTimer timer = new DispatcherTimer();
        public double Hoogte { get; set; }
        public double Breedte { get; set; }
        public int Score { get; private set; }
        public bool Playing { get; private set; }

        public Wereld(double h, double b)
        {
            Hoogte = h;
            Breedte = b;

            // plaats een nieuwe bal
            Bal = new Bal(new Point(10, 10));
     
            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 5);
        }

        public void StartSpel()
        {
            timer.Start();
            Playing = true;
        }

        public void HerstartSpel()
        {
            timer.Stop();
            Bal = new Bal(new Point(10, 10));
            StartSpel();
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            Bal.Move(Hoogte, Breedte);
        }

        public void Stop(Point p)
        {
            if (!Playing)
            {
                return;
            }

            double balX = Bal.Locatie.X;
            double balY = Bal.Locatie.Y;
            if (p.X >= balX && p.Y >= balY && p.X <= balX + Bal.Diameter && p.Y <= balY + Bal.Diameter)
            {
                Bal.Stop();
                Score++;
                timer.Stop();
                Playing = false;
            }
        }
    }
}
