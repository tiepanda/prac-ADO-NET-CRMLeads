using System.Data.SqlClient;
namespace CRMLeads.Data
{
    public class LeadRepository
    {
        private SqlConnection _connection;

        public LeadRepository()
        {
            string connStr = "server=.; database=CRMLeads; " +
                "Integrated Secutity=true; TrustServerCertificate=true";

            _connection = new SqlConnection(connStr);

        }

        public LeadRepository(SqlConnection connection)
        {
            _connection = connection;

        }

         
    }
}
