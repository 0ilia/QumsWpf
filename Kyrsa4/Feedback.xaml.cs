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
using System.Net;

namespace Kyrsa4
{
    public partial class Feedback : UserControl
    {
        static string Connect = "server=localhost;user=root;database=qums;password=;";
        static MySqlConnection myConnection = new MySqlConnection(Connect);

        public Feedback()
        {
            InitializeComponent();
        }

        private void MailSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                myConnection.Open();

                string theammail = TheamMail.Text;
                theammail = string.Join(" ", theammail.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                string messagemail = MessageMail.Text;
                messagemail = string.Join(" ", messagemail.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
                if ((theammail != "") && (messagemail != ""))
                {
                    IPHostEntry host;
                    string localIP = "?";
                    host = Dns.GetHostEntry(Dns.GetHostName());
                    foreach (IPAddress ip in host.AddressList)
                    {
                        if (ip.AddressFamily.ToString() == "InterNetwork")
                        {
                            localIP = ip.ToString();
                        }
                    }
                    string CountRow = "SELECT COUNT(*) from mail";
                    MySqlCommand CoutRowQ = new MySqlCommand(CountRow, myConnection);
                    int CountRowTableMail = int.Parse(CoutRowQ.ExecuteScalar().ToString());

                    string AddEmailBD = "INSERT INTO mail (id, theam, text_message,date_n,ip) VALUES (" + ++CountRowTableMail + ", '" + theammail + "', '" + messagemail + "','" + DateTime.Now
                    + "','" + localIP + "')";

                    MySqlCommand commandAddEmailBD = new MySqlCommand(AddEmailBD, myConnection);
                    commandAddEmailBD.ExecuteScalar();

                    TheamMail.Text = "";
                    MessageMail.Text = "";
                    resMess.Foreground = Brushes.Green;
                    resMess.Content = "✔";
                }
                else
                {
                    resMess.Foreground = Brushes.Red;
                    resMess.Content = "✔";
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
            finally
            {
                myConnection.Close();

            }
        }
    }
}
