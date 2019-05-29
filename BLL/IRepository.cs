using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(string id);
        void Create(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
