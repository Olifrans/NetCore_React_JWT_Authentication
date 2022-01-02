using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReactJwt.Domain.Entities
{
    public class Scheduling
    {
        public int Id { get; set; }
        public string? NameClient { get; set; }
        public DateTime SchedulingDate { get; set; }
    }
}
