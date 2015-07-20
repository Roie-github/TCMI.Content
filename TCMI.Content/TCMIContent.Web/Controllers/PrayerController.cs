using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCMIContent.Web.TCMIContentServices;
using TCMIContent.Web.Models;



namespace TCMIContent.Web.Controllers
{
    public class PrayerController : Controller
    {
        //
        // GET: /Prayer/

        public ActionResult Index()
        {
            List<TCMIContent.Web.TCMIContentServices.Prayer> result = null;
            TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();
            result =client.GetPrayers().ToList();
            return View(result);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return  View();
        }
        [HttpPost]
        [ActionName("Create")]
        public ActionResult CreatePost(TCMIContent.Web.TCMIContentServices.Prayer prayer)
        {
            string retValue = string.Empty;
            if (ModelState.IsValid)
            {
                TCMIContentServices.TCMIContentSoapClient client = new TCMIContentSoapClient();
                retValue= client.AddPrayer(prayer.Name, prayer.Email, prayer.Phone, prayer.Confidentiality, prayer.PrayerRequest);
                ViewBag.ReturnMessage = retValue;
                return RedirectToAction("index");
            }
            ViewBag.ReturnMessage = retValue;
            return View();
        }


    }
}
