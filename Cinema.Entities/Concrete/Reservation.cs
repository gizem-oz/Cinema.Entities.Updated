using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Reservation:IEntity // Rezervasyon
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public bool Status { get; set; }
        public virtual Customer Customer {get;set;}
        public virtual Employee Employee {get;set;}
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
