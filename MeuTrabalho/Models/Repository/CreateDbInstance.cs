using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace MeuTrabalho.Models.Repository
{
    public class CreateDbInstance
    {
        private static SqlConnection _connection = null;

        public static SqlConnection GetDbInstance
        {
            get
            {
                if (_connection == null)
                    _connection = new SqlConnection("Server=.; Database=MEUDB; Trusted_Connection = True;");

                return _connection;
            }
        }
    }
}
