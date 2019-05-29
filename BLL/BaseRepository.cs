using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Create(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public void Delete(string id)
        {
            var delete = GetById(id);
            _db.Set<T>().Remove(delete);
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetById(string id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Type t = typeof(T);
            string className = t.Name;
            var idProp = t.GetProperty("Id");
            string id = (string)idProp.GetValue(entity);

            var oldEntity = GetById(id);
            _db.Entry(oldEntity).CurrentValues.SetValues(entity);
        }
    }
}
