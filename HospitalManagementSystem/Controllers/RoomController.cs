using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;
using HospitalManagementSystem.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HospitalManagementSystem.Controllers
{
    [Route("Room")]
    public class RoomController: Controller
    {
        private readonly HospitalDbContext _context;
        private IHospitalRepo _hospitalrepo;
        public RoomController(HospitalDbContext context, IHospitalRepo hospitalrepo) 
        {
            _context = context;
            _hospitalrepo = hospitalrepo;
        }

        [HttpPost]
        [Route("GetRoomByType")]
        [Authorize(Roles = "Admin,Receptionist")]
        public JsonResult GetRoomByType(int roomNo)
        {
            List<Room> room = new List<Room>();
            if ((roomNo != 0))
            {
                room = _hospitalrepo.GetRoomDetails(roomNo);
            }
            return Json(room);
        }
    }
}
