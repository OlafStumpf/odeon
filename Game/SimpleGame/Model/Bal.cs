using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SimpleGame.Model
{
    public class Bal
    {
        public Point Locatie { get; set; }

        public Double Diameter { get; private set; }

        public int RichtingX { get; set; }
        public int RichtingY { get; set; }

        public Bal(Point locatie)
        {
            Locatie = locatie;
            Diameter = 35;
            
            Random r = new Random();
            RichtingX = r.Next(2, 4);
            RichtingY = r.Next(2, 4);
        }

        public void Move(double h, double b)
        {
            double newLeft = Locatie.X + RichtingX;
            double newTop = Locatie.Y + RichtingY;
            if (newTop + Diameter >= h || newTop < 0)
            {
                RichtingY = -RichtingY;
                newTop += RichtingY;
            }
            if (newLeft + Diameter >= b || newLeft < 0)
            {
                RichtingX = -RichtingX;
                newLeft += RichtingX;
            }
            Locatie = new Point(newLeft, newTop);
        }

        public void Stop()
        { 
            RichtingX = 0;
            RichtingY = 0;
        }

        public bool Gestopt
        {
            get { return RichtingX == 0 && RichtingY == 0; }
        }
    }
}
