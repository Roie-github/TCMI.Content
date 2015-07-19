using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.BaseClass
{
    interface IRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        string InsertOnSubmit(T entity);
        string RemoveOnSubmit(int id);
        string UpdateOnSubmit(T entity);
    }
}
