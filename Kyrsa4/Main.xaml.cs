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
using MySql.Data.MySqlClient;

namespace Kyrsa4
{
    public partial class Main : UserControl
    {
        static string Connect = "server=localhost;user=root;database=qums;password=;";
        static MySqlConnection myConnection = new MySqlConnection(Connect);
        public Main()
        {
            InitializeComponent();
        }

        private void Send_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                myConnection.Open();
                string CountRow = "SELECT COUNT(*) from message";
                MySqlCommand CoutRowQ = new MySqlCommand(CountRow, myConnection);
                int CountRowTableMesssage = int.Parse(CoutRowQ.ExecuteScalar().ToString());

                string name = Nik.Text;
                name = string.Join(" ", name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string message = Message.Text;
                message = string.Join(" ", message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string code = Code.Password;
                code = string.Join(" ", code.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                if (name == "")
                {
                    name = "Anonymous";
                }
                if ((code.Length > 4) && (code.Length < 10) && (message.Length > 1) && (message.Length < 255))
                {
                    string AddMessage = "INSERT INTO message (id, name, code,text_message) VALUES (" + ++CountRowTableMesssage + ", '" + name + "', '" + code + "','" + message + "')";

                    MySqlCommand commandAddMessage = new MySqlCommand(AddMessage, myConnection);
                    commandAddMessage.ExecuteScalar();
                   
                }
                int state = 0;
                if ((code.Length > 4) && (code.Length < 10))
                {
                    string ShowMessage = "SELECT name, text_message FROM message WHERE code =" + code;
                    MySqlCommand commandShowMessage = new MySqlCommand(ShowMessage, myConnection);
                    MySqlDataReader reader = commandShowMessage.ExecuteReader();
                    resMessage.Text = "";
                  
                    while (reader.Read())
                    {
                         resMessage.Text += reader[0].ToString() + ": " + reader[1].ToString() + Environment.NewLine;
                        state++; 
                    }
                    reader.Close();
                }
                if (state > 0)
                {
                    resMess.Foreground = Brushes.Green;
                    resMess.Content = "✔";
                    Message.Text = "";
                }
                else
                {
                    resMess.Foreground = Brushes.Red;
                    resMess.Content = "✖";
                }
            }
            catch
            {
                resMess.Foreground = Brushes.Red;
                resMess.Content = "✖";
                myConnection.Close();

            }
            finally
            {
                myConnection.Close();

            }
        }
    }
}
