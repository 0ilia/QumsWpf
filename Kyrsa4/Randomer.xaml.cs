using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Kyrsa4
{
    /// <summary>
    /// Логика взаимодействия для Randomer.xaml
    /// </summary>
    public partial class Randomer : UserControl
    {
        public Randomer()
        {
            InitializeComponent();
        }
        Random R = new Random();
        
        private void Window_Randomer_Loader(object sender, RoutedEventArgs e)
        {
            RandomNumbers.Text = R.Next(0, 1004).ToString();    
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            try
            {  
                if (countNumbers.Text.ToString() == "00" || countNumbers.Text.ToString() == "000" ||countNumbers.Text.ToString() == "0" || countNumbers.Text.ToString() == "")
                {
                    countNumbers.Text = "1";
                }
                RandomNumbers.Text = "";
                if (RandomNumbers1.Text.ToString() == "" && RandomNumbers2.Text.ToString() == "")
                {
                    RandomNumbers.Text = R.Next().ToString();
                    goto logoutCheckErrors;
                }
                

                if (RandomNumbers1.Text.ToString() == "" || RandomNumbers2.Text.ToString() == "")
                {
                    RandomNumbers.Foreground = Brushes.Red;
                    RandomNumbers.Text = "Введите диапазон";
                    goto logoutCheckErrors;
                }
                if (RandomNumbers1.Text.ToString() != "" && RandomNumbers2.Text.ToString() != "")
                {
                    int numb1 = int.Parse(RandomNumbers1.Text.ToString());
                    
                    int numb2 = int.Parse(RandomNumbers2.Text.ToString());
                    int temp = numb2;
                    int count = int.Parse(countNumbers.Text.ToString());
                    if (numb1>numb2)
                    {
                        numb2 = numb1;
                        numb1 = temp;
                    }
                    RandomNumbers.Foreground = Brushes.Black;
                    if ((numb1 < int.MinValue) || numb2 > int.MaxValue)
                    {
                        RandomNumbers.Text = "Диапазон не должен быть больше "+int.MaxValue+" и меньше "+int.MinValue;
                        goto logoutCheckErrors;
                    }
                    for (int i = 0; i < count; i++)
                    {
                          RandomNumbers.Text += R.Next(numb1, numb2).ToString() + " ";
                       // RandomNumbers.Text += "SAD";
                    }
                }
            logoutCheckErrors:;
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void OnlyNumber_Input(object sender, TextCompositionEventArgs e)
        {
            TextBox ctrl = sender as TextBox;
            e.Handled = "-0123456789".IndexOf(e.Text) < 0;//только цифры
           
        }

        
    }
}
