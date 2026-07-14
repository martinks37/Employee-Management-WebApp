using MySql.Data.MySqlClient;

namespace EmployeeApi.Data
{
    public class DatabaseHelper
    {
        private readonly string m_ConnectionString;
        public DatabaseHelper( IConfiguration objconfig)
        {
            m_ConnectionString = objconfig 
            .GetConnectionString ("DefaultConnection");

        }
        public MySqlConnection GetConnection()
        {    
            return new MySqlConnection(m_ConnectionString);
        }
    }
   
}
