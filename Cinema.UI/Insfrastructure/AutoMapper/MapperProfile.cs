using AutoMapper;
using Cinema.Entities.Concrete;
using Cinema.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Insfrastructure.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Department,DepartmentVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Movie, MovieVM>().ReverseMap();
            CreateMap<Payment, PaymentVM>().ReverseMap();
            CreateMap<Reservation, ReservationVM>().ReverseMap();
            CreateMap<Room, RoomVM>().ReverseMap();
            CreateMap<Session, SessionVM>().ReverseMap();
            CreateMap<Ticket, TicketVM>().ReverseMap();

            CreateMap<Category, CategoryConvertVM>().ReverseMap();
        }
    }
}
