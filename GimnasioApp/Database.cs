using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace GimnasioApp
{
    public class Database
    {
        private readonly string connectionString;

        public Database()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionGymDB"].ConnectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
