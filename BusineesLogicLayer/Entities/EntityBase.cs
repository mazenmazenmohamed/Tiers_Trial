using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogicLayer.Entities
{
    public class EntityBase
    {
        public EntityState State { get; set; } = EntityState.UnChanged;  
    }
}
