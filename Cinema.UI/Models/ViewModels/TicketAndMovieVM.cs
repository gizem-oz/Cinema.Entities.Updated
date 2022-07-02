using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class TicketAndMovieVM:ModelBase
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        //_________________________________
        public int SessionId { get; set; }
        public int ReservationId { get; set; }
        public DateTime BuyDate { get; set; }
        public bool Status { get; set; }
    }
}
