using Cinema.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.UI.Components.RoomList
{
    public class RoomList:ViewComponent
    {
        private readonly IRoomService _roomService;
        public RoomList(IRoomService roomService)
        {
            _roomService = roomService;
        }
        public IViewComponentResult Invoke()
        {
            var list = _roomService.RoomList().Result;
            return View(list);
        }
    }
}
