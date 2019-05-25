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
        private void KeyDownEnterForSend(object sender , KeyEventArgs e )
        {
            if (e.Key == Key.Enter)
            {
                AddMessage.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        private string correctTextBox(string NameTextBox = "")
        {
            // string theammail = "";
            string theammail = NameTextBox;
            theammail = string.Join(" ", theammail.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            return theammail;
        }
        private void Send_Button(object sender, RoutedEventArgs e)
        {

            try
            {
                myConnection.Open();
                string CountRow = "SELECT COUNT(*) from message";
                MySqlCommand CoutRowQ = new MySqlCommand(CountRow, myConnection);
                int CountRowTableMesssage = int.Parse(CoutRowQ.ExecuteScalar().ToString());

                /*string name = Nik.Text.ToString();
                name = string.Join(" ", name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string message = Message.Text.ToString();
                message = string.Join(" ", message.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string code = Code.Password.ToString();
                code = string.Join(" ", code.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));*/
                string name = correctTextBox(Nik.Text.ToString());
                string message = correctTextBox(Message.Text.ToString());
                string code = correctTextBox(Code.Password.ToString());

                if (name == "")
                {
                    name = "Anonymous";
                }
                if ((code.Length > 4) && (code.Length < 10) && (message.Length > 1) && (message.Length < 255))
                {
                    string AddMessage = "INSERT INTO message (id, name, code,text_message) VALUES (" + ++CountRowTableMesssage + ", '" + name.ToString() + "', '" + code.ToString() + "','" + message.ToString() + "')";
                    MySqlCommand commandAddMessage = new MySqlCommand(AddMessage, myConnection);
                    commandAddMessage.ExecuteScalar();
                }
                else
                {
                    if((code.Length <5)||(code.Length>9))
                    {
                        messageError.Content = "Длина кода не должна быть больше 9 символов и меньше 5 ";
                        goto logoutCheckErrorsMessage;
                    }
                    if (((message.Length > 254)||(message.Length < 2))&&(message != ""))
                    {
                        messageError.Content = "Длина сообщения не должна быть меньше 2 символов и больше 254";
                    }
                logoutCheckErrorsMessage:;
                }
                int state = 0;
                if ((code.Length > 4) && (code.Length < 10))
                {
                    messageError.Content = "";
                    string ShowMessage = "SELECT name, text_message FROM message WHERE code = '" + code.ToString() + "'";
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
                else
                {
                    if ((code != "") && ((code.Length > 4) || (code.Length < 10)))
                    {
                        messageError.Content = "Длина кода не должна быть больше 9 символов и меньше 5 ";
                    }
                }
                if ((state > 0)&&(message.Length > 1))
                {
                    resMess.Foreground = Brushes.Green;
                    messageError.Content = "";
                    resMess.Content = "✔";
                    Message.Focus();
                    Message.Text = "";
                }
                else if((code.Length < 10) && (code != "")&& (message == "") && (code.Length > 4)&&(resMessage.Text == ""))
                {
                    messageError.Content = "Сообщений не найдено";
                }
            }
            catch
            {
                resMess.Foreground = Brushes.Red;
                resMess.Content = "✖";

            }
            finally
            {
                myConnection.Close();

            }
        }
    }
}
