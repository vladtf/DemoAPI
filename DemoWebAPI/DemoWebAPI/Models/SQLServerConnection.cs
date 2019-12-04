using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DemoWebAPI.Models
{
    internal class SQLServerConnection
    {
        public static List<Person> GetPeople()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection("Data Source=work.database.windows.net;Initial Catalog=work;User ID=worker;Password=;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                var output = connection.Query<Person>("select * from [dbo].[employees];").ToList();
                return output;
            }
        }
    }
}