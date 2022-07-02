using Cinema.Business.Abstract;
using Cinema.DataAccess.Abstract;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Business.Concrete
{
    public class ReservationManager:IReservationService
    {
        private readonly IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public async Task Add(Reservation reservation)
        {
            await _reservationDal.Add(reservation);
        }

        public async Task AddRange(List<Reservation> reservation)
        {
            await _reservationDal.AddRange(reservation);
        }

        public async Task Delete(int id)
        {
            Reservation reservation = await GetReservationById(id);
            if (reservation != null)
            {
                reservation.Status = false;
                await Update(reservation);
            }
       
        }

        public async Task<IList<Reservation>> GetAllReservationList()
        {
            return await _reservationDal.GetAll(x=>x.Status == true);
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _reservationDal.Get(x=>x.Id == id);
        }

        public async Task Update(Reservation reservation)
        {
            await _reservationDal.Update(reservation);
        }
    }
}
