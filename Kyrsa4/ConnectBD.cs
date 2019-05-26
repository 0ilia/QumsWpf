using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Kyrsa4
{
    class ConnectBD
    {
       
             static string Connect = "server=localhost;user=root;database=qums;password=;";
             public MySqlConnection myConnection = new MySqlConnection(Connect);
        
    }
}
