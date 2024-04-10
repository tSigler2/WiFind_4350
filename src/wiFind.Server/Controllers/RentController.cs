﻿
using Microsoft.AspNetCore.Mvc;
using wiFind.Server.ControlModels;
using wiFind.Server.Helpers;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly WiFindContext _wiFindContext;
        public RentController(WiFindContext wifindcontext) 
        {
            _wiFindContext = wifindcontext;
        }

        [Authorize]
        [HttpGet("getrenteeview")]
        public async Task<IActionResult> GetRenteeView(UsernameInput usernameInput)
        {
            var username = usernameInput.Username;
            // this query could be improved via joining accountlogin and rent table but atm this is just for fast results
            var userid = from a in _wiFindContext.Set<AccountInfo>() where (a.username == username) select a.user_id;
            var rentedWifi = from r in _wiFindContext.Set<Rent>() where (r.user_id == userid.First()) select r;

            var reqList = new List<RentDTO>();

            foreach (var item in rentedWifi)
            {
                reqList.Add(new RentDTO
                {
                    rentID = item.rent_id,
                    wifiID = item.wifi_id,
                    start = item.start_time,
                    end = item.end_time,
                    locked_rate = item.locked_rate,
                    guest_password = item.guest_password,
                });
            }
            return Ok(reqList);
        }

        // ToDo: Renter View. Will need to pass in list of wifi id's since the seller may be renting out many wifis
        // Should return Each Wifi + # of users using that wifi
        //[Authorize]
        //[HttpGet("getrenterview")]
        //public async Task<IActionResult> GetRenterView(UsernameInput usernameInput)
        //{

        //}
        // ToDo: Get Renter's Wifis for Editting?
    }
}
