using CRMLeads.Models;
using System.Data;
using System.Data.SqlClient;
namespace CRMLeads.Data
{
    public class LeadRepository
    {
        private SqlConnection _connection;

        public LeadRepository()
        {
            string connStr = "server =.; database =CRMLeads; " +
                "Integrated Security=True; TrustServerCertificate=true";

            _connection = new SqlConnection(connStr);

        }


        public List<LeadsEntity> GetAllLeads()
        {
            List<LeadsEntity> LeadsListEntity = new List<LeadsEntity>();

            SqlCommand cmd = new SqlCommand("GetAllLeads" , _connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                LeadsListEntity.Add(
                    new LeadsEntity
                    {
                        Id = Convert.ToInt32(dr["id"]),
                        LeadDate = Convert.ToDateTime(dr["LeadDate"]),
                        Name = dr["name"].ToString(),
                        EmailAddress = dr["EmailAddress"].ToString(),
                        Mobile = dr["Mobile"].ToString(),
                        LeadSource = dr["LeadSource"].ToString(),
                        LeadStatus = dr["LeadStatus"].ToString(),
                        NextFollowUpDate = Convert.ToDateTime(dr["NextFollowUpDate"]),
                    }
                    );


            }
                
            return LeadsListEntity;

        }
         
    }
}
