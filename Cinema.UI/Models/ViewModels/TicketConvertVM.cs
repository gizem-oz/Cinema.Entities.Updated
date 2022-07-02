using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class TicketConvertVM: ModelBase
    {
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public int SessionId { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public int ReservationId { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public DateTime BuyDate { get; set; }

        public bool Status { get; set; }
    }
}
