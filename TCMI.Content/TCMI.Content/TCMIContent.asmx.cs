using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Models;
using DataRepository;
using System.Web.Script.Serialization;

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
        public string UpdatePrayer(int id, string name, string email, string phone, string confidential, string request, int prayed, bool answered)
        {
            //to do sanitized parameters

            Prayer p = new PrayerRepository().GetById(id);
            p.Name = name;
            p.Email = email;
            p.Phone = phone;
            p.Confidentiality = confidential;
            p.PrayerRequest = request;
            p.Prayed = prayed;
            p.Answered = answered;

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
		public void GetPrayersJson()
		{
			PrayerRepository db = new PrayerRepository();
			//return db.GetAll().ToList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(db.GetAll().ToList()));
		}

        [WebMethod]
        public string RemovePrayer(int id)
        {
            //to do sanitized parameters

            PrayerRepository db = new PrayerRepository();
            string returnValue = db.RemoveOnSubmit(id);
            return returnValue;
        }

        /* Event */
        [WebMethod]
        public string AddEvent(string title, string desc, DateTime date, string time, string venue)
        {
            EventRepository er = new EventRepository();
            Event e = new Event
            {
                id = 0,
                Title = title,
                Description = desc,
                DateOfEvent = date,
                Time = time,
                Venue = venue,
                Expired = false
            };
            string result = er.InsertOnSubmit(e);
            return result;
        }

        [WebMethod]
        public string UpdateEvent(int id, string title, string desc, DateTime date, string time, string venue, bool isexpired)
        {
            EventRepository db = new EventRepository();
            Event e = new Event
            {
                id = id,
                Title = title,
                Description = desc,
                DateOfEvent = date,
                Time = time,
                Venue = venue,
                Expired = isexpired
            };
            string result = db.UpdateOnSubmit(e);
            return result;
        }

        [WebMethod]
        public string UpdateEventExpired(int id)
        {
            EventRepository db = new EventRepository();
            Event e = db.GetById(id);
            e.Expired = true;

            string result = db.UpdateOnSubmit(e);
            return result;
        }

        [WebMethod]
        public List<Event> GetAllEvents()
        {
            EventRepository db = new EventRepository();
            return db.GetAll().ToList();
        }

        [WebMethod]
        public List<Event> GetActiveEvents()
        {

            EventRepository db = new EventRepository();
            return db.GetAll().ToList().Where(e => e.Expired == false).ToList();
        }

        [WebMethod]
        public string RemoveEvent(int id)
        {
            //to do sanitized parameters

            EventRepository db = new EventRepository();
            string returnValue = db.RemoveOnSubmit(id);
            return returnValue;
        }

    }
}
