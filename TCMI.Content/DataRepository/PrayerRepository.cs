using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.BaseClass;
using Models;

namespace DataRepository
{
    public class PrayerRepository : IRepository<Prayer>
    {
        public Prayer GetById(int id)
        {
            return GetAll().FirstOrDefault(p => p.id.Equals(id));
        }

        public IEnumerable<Prayer> GetAll()
        {
            IEnumerable<Prayer> result = null;
            using (var context = new TCMIDBContext())
            {
                //context.OrderByDescending(p => p.Received).ToList();
                result = context.Prayers.ToList();
            }
            return result.OrderByDescending(p => p.Received);
        }

        public string InsertOnSubmit(Prayer entity)
        {
            string value = string.Empty;
            using (var context = new TCMIDBContext())
            {
                try
                {
                    context.Prayers.Add(entity);
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
                    Prayer p = context.Prayers.Find(id);
                    context.Prayers.Remove(p);
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

        public string UpdateOnSubmit(Prayer entity)
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
