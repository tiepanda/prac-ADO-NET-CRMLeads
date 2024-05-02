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


        public IActionResult AddLead()
        {
            return View();

        }


        public IActionResult AddNewLead(LeadsEntity leadDetails)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (leadDetails.NextFollowUpDate <leadDetails.LeadDate)
                    {


                        ViewBag.Message = "Follow up date cannot be less than Lead date";
                        return View("AddLead");

                    }
                    LeadRepository _DbLead = new LeadRepository();
                    if (_DbLead.AddLead(leadDetails))
                    {

                        return RedirectToAction("Index");
                    }
                }
                return View();
            }

            catch
            {
                return View();

            }

        }

    }
}
