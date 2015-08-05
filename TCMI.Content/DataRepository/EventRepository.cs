using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.BaseClass;
using Models;

namespace DataRepository
{
  public  class EventRepository : IRepository<Event>
    {
        public Event GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.id.Equals(id));
        }

        public IEnumerable<Event> GetAll()
        {
            IEnumerable<Event> result = null;

            using (var context = new TCMIDBContext())
            {
                //context.OrderByDescending(p => p.Received).ToList();
                result = context.Events.ToList();
            }
            return result.OrderByDescending(e => e.DateOfEvent);
        
            
        }

        public string InsertOnSubmit(Event entity)
        {
            string value = string.Empty;
            using (var context = new TCMIDBContext())
            {
                try
                {
                    context.Events.Add(entity);
                    context.SaveChanges();
                    value = "Success";
                }
                catch (Exception ex)
                {
                    value = "Falied " + ex.Message;
                }

            }
            return value;
        }

        public string RemoveOnSubmit(int id)
        {
            string value = string.Empty;
            using (var context = new TCMIDBContext())
            {
                try
                {
                    Event e = context.Events.Find(id);
                    context.Events.Remove(e);
                    context.SaveChanges();
                    value = "Success";
                }
                catch (Exception ex)
                {
                    value = "Falied " + ex.Message;
                }

            }

            return value;
        }

        public string UpdateOnSubmit(Event entity)
        {
            string value = string.Empty;
            using (var context = new TCMIDBContext())
            {
                try
                {
                    context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    value = "Success";

                }
                catch (Exception ex)
                {
                    value = "Falied " + ex.Message;
                }

            }
            return value;
        }
    }
}
