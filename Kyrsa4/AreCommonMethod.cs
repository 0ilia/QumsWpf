using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
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
using System.Security.Cryptography;

namespace Kyrsa4
{
    class AreCommonMethod
    {
        public string correctTextBox(string NameTextBox = "")
        {
            string theammail = NameTextBox;
            theammail = string.Join(" ", theammail.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            return theammail;
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
       
    }
}
