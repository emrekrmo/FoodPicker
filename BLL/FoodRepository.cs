using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FoodRepository : BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
