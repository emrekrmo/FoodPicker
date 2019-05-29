using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _db = new ApplicationDbContext();
        public UnitOfWork()
        {
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
