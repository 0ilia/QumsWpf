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
using System.Net.Mail;

namespace Kyrsa4
{
    public partial class Feedback : UserControl
    {
        ConnectBD BD = new ConnectBD();
        AreCommonMethod arecommonmethod = new AreCommonMethod();

        public Feedback()
        {
            InitializeComponent();
        }
        
       
        private void KeyDownEnterForSend(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MailSend.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
        private void MailSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BD.myConnection.Open();
                string theammail = arecommonmethod.correctTextBox(TheamMail.Text);
                string messagemail = arecommonmethod.correctTextBox(MessageMail.Text);
                string EmailTextBox = arecommonmethod.correctTextBox(E_mail_TextBox.Text);

                if ((theammail.Length < 26) && (messagemail.Length < 201) && (theammail.Length > 3) && (messagemail.Length > 6)&& (arecommonmethod.IsValid(E_mail_TextBox.ToString())==true))
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
                    MySqlCommand CoutRowQ = new MySqlCommand(CountRow, BD.myConnection);
                    int CountRowTableMail = int.Parse(CoutRowQ.ExecuteScalar().ToString());

                    string AddEmailBD = "INSERT INTO mail (id, theam, text_message,date_n,ip,email_from) VALUES (" + ++CountRowTableMail + ", '" + theammail.ToString() + "', '" + messagemail.ToString() + "','" + DateTime.Now
                    + "','" + localIP + "','"+ EmailTextBox.ToString()+"')";
                    MySqlCommand commandAddEmailBD = new MySqlCommand(AddEmailBD, BD.myConnection);
                    commandAddEmailBD.ExecuteScalar();
                    TheamMail.Text = "";
                    MessageMail.Text = "";
                    E_mail_TextBox.Text = "";
                    resMess.Foreground = Brushes.Green;
                    resMess.Content = "✔";
                    ErrorsSendMail.Content = "";
                }
                else
                {
                    resMess.Foreground = Brushes.Red;
                    resMess.Content = "✖";
                    if ((theammail.Length > 25) || (theammail.Length < 4))
                    {
                        ErrorsSendMail.Content = "Длина темы должна быть больше 3 и меньшн 26";
                        goto logoutCheckErrorsEmail;
                    }
                    if(arecommonmethod.IsValid(E_mail_TextBox.ToString()) != true)
                    {
                        ErrorsSendMail.Content = "Ввести корректный email";
                        goto logoutCheckErrorsEmail;
                    }
                    if ((messagemail.Length > 200) || (messagemail.Length < 7))
                    {
                        ErrorsSendMail.Content = "Длина сообщения должна быть больше 6 и меньшн 201";
                    }
                logoutCheckErrorsEmail:;
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка");
            }
            finally
            {
                BD.myConnection.Close();

            }
        }
    }
}
