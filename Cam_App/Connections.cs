using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Cam_App
{
    class Connections
    {
        private static string stringConnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Cam_App\Cam_App\Database1.mdf;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
