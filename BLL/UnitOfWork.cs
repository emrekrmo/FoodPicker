using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public BaseRepository<Food> foodRep;
        public BaseRepository<Restaurant> restRep;
        public UnitOfWork()
        {
            foodRep = new BaseRepository<Food>(db);
            restRep = new BaseRepository<Restaurant>(db);
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
