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
using System.Windows.Shapes;

namespace Kyrsa4
{
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
        }
        int player = 0;
        private void checkButton()
        {
            player = 0;
            b1.Content = "";
            b2.Content = "";
            b3.Content = "";
            b4.Content = "";
            b5.Content = "";
            b6.Content = "";
            b7.Content = "";
            b8.Content = "";
            b9.Content = "";
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
        }
        private void Button_Game(object sender, RoutedEventArgs e)
        {
            try
            {
                if (player == 0)
                {
                    sender.GetType().GetProperty("Content").SetValue(sender, "X");
                    player++;
                }
                else
                {
                    sender.GetType().GetProperty("Content").SetValue(sender, "O");
                    player--;
                }
                sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                checkWin();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
        
        private void  checkWin()
        {
            if ((b1.Content == b2.Content) && (b2.Content == b3.Content))
            {
                if (b1.Content != "")
                {
                    MessageBox.Show("Победили " + b2.Content);
                    checkButton();
                }
            }
            if ((b4.Content == b5.Content) && (b5.Content == b6.Content))
            {
                if (b4.Content != "")
                {
                    MessageBox.Show("Победили " + b4.Content);
                    checkButton();
                }
            }
            if ((b7.Content == b8.Content) && (b8.Content == b9.Content))
            {
                if (b7.Content != "")
                {
                    MessageBox.Show("Победили " + b7.Content);
                    checkButton();
                }
            }

            if ((b1.Content == b4.Content) && (b4.Content == b7.Content))
            {
                if (b1.Content != "")
                {
                    MessageBox.Show("Победили " + b1.Content);
                    checkButton();
                }
            }
            if ((b2.Content == b5.Content) && (b5.Content == b8.Content))
            {
                if (b2.Content != "")
                {
                    MessageBox.Show("Победили " + b2.Content);
                    checkButton();
                }
            }
            if ((b3.Content == b6.Content) && (b6.Content == b9.Content))
            {
                if (b3.Content != "")
                {
                    MessageBox.Show("Победили " + b3.Content);
                    checkButton();
                }
            }

            if ((b1.Content == b5.Content) && (b5.Content == b9.Content))
            {
                if (b1.Content != "")
                {
                    MessageBox.Show("Победили " + b1.Content);
                    checkButton();
                }
            }
            if ((b3.Content == b5.Content) && (b5.Content == b7.Content))
            {
                if (b3.Content != "")
                {
                    MessageBox.Show("Победили " + b3.Content);
                    checkButton();
                   
                }
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            checkButton();
          
        }
    }
}
