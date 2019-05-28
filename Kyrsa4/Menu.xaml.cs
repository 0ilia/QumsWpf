using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Kyrsa4
{
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void MenuItem_Main(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mw = null;
                foreach (var w in Application.Current.Windows)
                {
                    if (w is MainWindow)
                    {
                        mw = (MainWindow)w;
                    }
                }
                mw.Windows.Children.Clear();
                mw.Windows.Children.Add(new Main());
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }


        private void MenuItem_FeedBack(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mw = null;
                foreach (var w in Application.Current.Windows)
                {
                    if (w is MainWindow)
                    {
                        mw = (MainWindow)w;
                    }
                }
                mw.Windows.Children.Clear();
                mw.Windows.Children.Add(new Feedback());

            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

       

        private void Randomer_Window(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindow mw = null;
                foreach (var w in Application.Current.Windows)
                {
                    if (w is MainWindow)
                    {
                        mw = (MainWindow)w;
                    }
                }
                mw.Windows.Children.Clear();
                mw.Windows.Children.Add(new Randomer());

            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
        
        private void MenuLoad(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
       
    }
        
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            DateTime T = DateTime.Now;
            clock.Text = T.Hour.ToString()+":"+T.Minute.ToString()+":"+T.Second.ToString();
        }
    }
}
