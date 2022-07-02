using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class SessionVM
    {
        public int MovieId { get; set; } //FilmId
        public int RoomId { get; set; } //OdaId

        public DateTime ShowDate { get; set; } //GösterimTarihi
        public DateTime ShowTime { get; set; } //GösteriZamanı
        public bool Status { get; set; }
    }
}
