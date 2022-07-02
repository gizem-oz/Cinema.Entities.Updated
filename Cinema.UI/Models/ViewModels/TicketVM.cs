using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class TicketVM
    {
        public int SessionId { get; set; }
        public int ReservationId { get; set; }
        public double Price { get; set; }
        public DateTime BuyDate { get; set; }
        public bool Status { get; set; }
    }
}
