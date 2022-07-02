using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Entities.Concrete
{
    public class Ticket:IEntity //Bİlet
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int ReservationId { get; set; }
        public double Price { get; set; }
        public DateTime BuyDate { get; set; }
        public bool Status { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Session Session { get; set; }
    }
}
