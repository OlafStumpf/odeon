using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SimpleGame.Model;

namespace SimpleGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Wereld wereld;
        private Ellipse balVorm;

        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            
            // timer voor het updaten van de UI
            timer.Tick += TimerOnTick;
            timer.Interval = new TimeSpan(0,0,0,0,10);
            timer.Start();
            
            // alternatief
            //CompositionTarget.Rendering += CompositionTargetOnRendering;
        }

        private void CompositionTargetOnRendering(object sender, EventArgs eventArgs)
        {
            if (wereld != null)
            {
                updateWereld();
            }
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            if (wereld != null)
            {
                updateWereld();
            }
        }

        private void Startknop_Click(object sender, RoutedEventArgs e)
        {
            if (wereld.Playing)
            {
                wereld.HerstartSpel();
            }
            else
            {
                wereld.StartSpel();
                Startknop.Content = "Nieuwe bal";
                WereldCanvas.MouseDown += WereldCanvas_MouseDown;
            }
        }
        
        private void updateWereld()
        {
            // teken de bal
            Bal bal = wereld.Bal;
            Canvas.SetLeft(balVorm, bal.Locatie.X);
            Canvas.SetTop(balVorm, bal.Locatie.Y);
            balVorm.Width = bal.Diameter;
            balVorm.Height = bal.Diameter;
            var balColor = Colors.Firebrick;
            if (bal.Gestopt)
            {
                balColor = Colors.DarkBlue;
            }
            balVorm.Fill = new SolidColorBrush(balColor);

            // toon de score
            ScoreText.Text = $"Score: {wereld.Score}";
        }
        
        private void WereldCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            wereld.Stop(e.GetPosition(WereldCanvas));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // pas hier hebben we de actual size
            wereld = new Wereld(WereldCanvas.ActualHeight, WereldCanvas.ActualWidth);
            balVorm = new Ellipse();
            WereldCanvas.Children.Add(balVorm);
        }
    }
}
