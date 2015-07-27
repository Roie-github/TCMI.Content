using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Models;
using DataRepository;

namespace TCMI.Content
{
    /// <summary>
    /// Summary description for TCMIContent
    /// </summary>
    [WebService(Namespace = "http://tcmicrossroadcontent.apphb.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TCMIContent : System.Web.Services.WebService
    {

        [WebMethod]
        public string AddPrayer(string name, string email, string phone, string confidential, string request)
        {
            Prayer p = new Prayer
            {
                Name = name,
                Email = email,
                Phone = phone,
                Confidentiality = confidential,
                PrayerRequest = request,
                Received = DateTime.Now,
                Prayed = 0
            };
            PrayerRepository db = new PrayerRepository();
            string returnValue = db.InsertOnSubmit(p);
            return returnValue;
        }

        [WebMethod]
        public string UpdatePrayer(int id, string name, string email, string phone, string confidential, string request, int prayed)
        {
            //to do sanitized parameters

            Prayer p = new PrayerRepository().GetById(id);
            p.Name = name;
            p.Email = email;
            p.Phone = phone;
            p.Confidentiality = confidential;
            p.PrayerRequest = request;
            p.Prayed = prayed;


            PrayerRepository db = new PrayerRepository();
            string returnValue = db.UpdateOnSubmit(p);
            return returnValue;
        }

        [WebMethod(MessageName="UpdatePrayed")]
        public string UpdatePrayer(int id)
        {
            //to do sanitized parameters

            Prayer p = new PrayerRepository().GetById(id);
            p.Prayed = p.Prayed + 1;


            PrayerRepository db = new PrayerRepository();
            string returnValue = db.UpdateOnSubmit(p);
            return returnValue;
        }

        [WebMethod]
        public string AnsweredPrayer(int id)
        {
            //to do sanitized parameters

            Prayer p = new PrayerRepository().GetById(id);
            p.Answered = true;


            PrayerRepository db = new PrayerRepository();
            string returnValue = db.UpdateOnSubmit(p);
            return returnValue;
        }

        [WebMethod]
        public string Prayed(int id)
        {
            Prayer p = new PrayerRepository().GetById(id);
            p.Prayed = p.Prayed + 1;

            PrayerRepository db = new PrayerRepository();
            string returnValue = db.UpdateOnSubmit(p);
            return returnValue;
        }


        [WebMethod]
        public List<Prayer> GetPrayers()
        {
            PrayerRepository db = new PrayerRepository();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public string RemovePrayer(int id)
        {
            //to do sanitized parameters

            PrayerRepository db = new PrayerRepository();
            string returnValue = db.RemoveOnSubmit(id);
            return returnValue;
        }
        
    }
}
