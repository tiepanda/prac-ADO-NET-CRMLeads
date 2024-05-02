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
         


        public bool AddLead(LeadsEntity  lead)
        {
            SqlCommand cmd = new SqlCommand("AddLead",_connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@LeadDate", lead.LeadDate);
            cmd.Parameters.AddWithValue("@Name", lead.Name);
            cmd.Parameters.AddWithValue("@EmailAddress", lead.EmailAddress);
            cmd.Parameters.AddWithValue("@Mobile", lead.Mobile);
            cmd.Parameters.AddWithValue("@LeadSource", lead.LeadSource);
            cmd.Parameters.AddWithValue("@LeadStatus", lead.LeadStatus);
            cmd.Parameters.AddWithValue("@NextFollowUpDate", lead.NextFollowUpDate);


            _connection.Open();

            int i =cmd.ExecuteNonQuery();

            _connection.Close();

            if (i>=1)
            {
                return true;

            }
            else
            {
                return false;
            }


        }
    }
}
