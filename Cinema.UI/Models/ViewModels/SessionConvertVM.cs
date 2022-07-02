using Cinema.UI.Models.ViewModels.ViewModelBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Models.ViewModels
{
    public class SessionConvertVM: ModelBase
    {
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public int MovieId { get; set; } //FilmId
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public int RoomId { get; set; } //OdaId
        [Required(ErrorMessage = "Boş Geçilemez!")]

        public DateTime ShowDate { get; set; } //GösterimTarihi
        [Required(ErrorMessage = "Boş Geçilemez!")]
        public DateTime ShowTime { get; set; } //GösteriZamanı
        public bool Status { get; set; }
    }
}
