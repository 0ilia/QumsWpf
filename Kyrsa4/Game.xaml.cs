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
        Random rand = new Random();
        Button[] button = new Button[9];
        int state = 0;
        int player = 0;
        int resWinX = 0;
        int checkCountButton = 0;
        int resWinO = 0;
        private void checkButton()
        {
            checkCountButton = 0;
            player = 0;
            state = 0;
            movePlayer.Content = "Ход X";
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
                button[0] = b1;
                button[1] = b2;
                button[2] = b3;
                button[3] = b4;
                button[4] = b5;
                button[5] = b6;
                button[6] = b7;
                button[7] = b8;
                button[8] = b9;
            
                movePlayer.Content = "Ход X";
                sender.GetType().GetProperty("Content").SetValue(sender, "X");
                sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                checkCountButton++;
            clickButton:
                int Ran = rand.Next(0, 9);

                if (button[Ran].IsEnabled == true)
                {
                    button[Ran].GetType().GetProperty("Content").SetValue(button[Ran], "O");
                    button[Ran].GetType().GetProperty("IsEnabled").SetValue(button[Ran], false);
                    checkCountButton++;
                    checkWin();
                }
                else if (checkCountButton != 9)
                {
                    goto clickButton;
                }
                checkWin();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }
        private void checkWin()
        {

            if ((b1.Content.ToString() == "X" && b2.Content.ToString() == "X" && b3.Content.ToString() == "X") ||
                (b4.Content.ToString() == "X" && b5.Content.ToString() == "X" && b6.Content.ToString() == "X") ||
                (b7.Content.ToString() == "X" && b8.Content.ToString() == "X" && b9.Content.ToString() == "X") ||
                 (b1.Content.ToString() == "X" && b5.Content.ToString() == "X" && b9.Content.ToString() == "X") ||
                 (b3.Content.ToString() == "X" && b5.Content.ToString() == "X" && b7.Content.ToString() == "X") ||
                 (b1.Content.ToString() == "X" && b4.Content.ToString() == "X" && b7.Content.ToString() == "X") ||
                 (b2.Content.ToString() == "X" && b5.Content.ToString() == "X" && b8.Content.ToString() == "X") ||
                 (b3.Content.ToString() == "X" && b6.Content.ToString() == "X" && b9.Content.ToString() == "X")
                )
            {
             
                MessageBox.Show("Победили X");
                checkButton();
                resWinX++;
                resWinXN.Content = resWinX.ToString();


            }
            else
            {
                state++;
            }


            if ((b1.Content.ToString() == "O" && b2.Content.ToString() == "O" && b3.Content.ToString() == "O") ||
                (b4.Content.ToString() == "O" && b5.Content.ToString() == "O" && b6.Content.ToString() == "O") ||
                (b7.Content.ToString() == "O" && b8.Content.ToString() == "O" && b9.Content.ToString() == "O") ||
                 (b1.Content.ToString() == "O" && b5.Content.ToString() == "O" && b9.Content.ToString() == "O") ||
                 (b3.Content.ToString() == "O" && b5.Content.ToString() == "O" && b7.Content.ToString() == "O") ||
                 (b1.Content.ToString() == "O" && b4.Content.ToString() == "O" && b7.Content.ToString() == "O") ||
                 (b2.Content.ToString() == "O" && b5.Content.ToString() == "O" && b8.Content.ToString() == "O") ||
                 (b3.Content.ToString() == "O" && b6.Content.ToString() == "O" && b9.Content.ToString() == "O")
                )
            {
                
                MessageBox.Show("Победили O");
                checkButton();
                resWinO++;
                resWinON.Content = resWinO.ToString();
            }
            if ((state == 9) &&
                (b1.Content.ToString() != "" && b2.Content.ToString() != "" && b3.Content.ToString() != "") &&
                (b4.Content.ToString() != "" && b5.Content.ToString() != "" && b6.Content.ToString() != "") &&
                (b7.Content.ToString() != "" && b8.Content.ToString() != "" && b9.Content.ToString() != "") &&
                 (b1.Content.ToString() != "" && b5.Content.ToString() != "" && b9.Content.ToString() != "") &&
                 (b3.Content.ToString() != "" && b5.Content.ToString() != "" && b7.Content.ToString() != "") &&
                 (b1.Content.ToString() != "" && b4.Content.ToString() != "" && b7.Content.ToString() != "") &&
                 (b2.Content.ToString() != "" && b5.Content.ToString() != "" && b8.Content.ToString() != "") &&
                 (b3.Content.ToString() != "" && b6.Content.ToString() != "" && b9.Content.ToString() != "")
                )
            {
               
                MessageBox.Show("Ничья");
                checkButton();
            }



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            resWinO = 0;
            resWinX = 0;
            resWinXN.Content = resWinX.ToString();
            resWinON.Content = resWinO.ToString();
            checkButton();

        }

    }
}
