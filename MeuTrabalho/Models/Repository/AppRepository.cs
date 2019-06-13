using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MeuTrabalho.Models.Repository
{
    public class AppRepository : IAppRepository
    {
        private SqlConnection connection = null;
        
        public AppRepository()
        {
            connection = CreateDbInstance.GetDbInstance;            
        }
        
        public void Insert(string value)
        {
            connection.Open();
            SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('" + value + "')", connection);
            sql.ExecuteNonQuery();
            connection.Close();
        }
    }
}
