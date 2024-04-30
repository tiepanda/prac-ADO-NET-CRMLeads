using CRMLeads.Data;
using CRMLeads.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRMLeads.Controllers
{
    public class LeadsController : Controller
    {
        public IActionResult Index()
        {
            List<LeadsEntity> leads = new List<LeadsEntity>();
            LeadRepository LeadRepository = new LeadRepository();

            leads = LeadRepository.GetAllLeads();

            return View(leads);
        }
    }
}
