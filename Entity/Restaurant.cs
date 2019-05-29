using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Restaurant : BaseEntity
    {
        public string RestaurantName { get; set; }

        //public string UserId { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
        //public virtual User User { get; set; }
    }
}
