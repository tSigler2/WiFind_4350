
using System.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Json;
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
        [HttpPost("getrenteeview")]
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
        [Authorize]
        [HttpPost("getrenterview")]
        public async Task<IActionResult> GetRenterView(UsernameInput usernameInput)
        {
            // Need to show that where renter wifi's are not in rent have 0 users using it.
            // Need to show that where renter wifi's exist on inner join rent have whatever number of users using it.
            //var rentedout = from w in _wiFindContext.Set<Wifi>() where (w.owned_by == usernameInput.Username) select w;
            //await rentedout.ForEachAsync( (e) => {
            //    var occurances = from r in _wiFindContext.Set<Rent>() where (r.wifi_id == e.wifi_id) select r;
                
            //});

            IList<RenterDTO> rentedWifiInfo = [
                new RenterDTO{
                    wifi_id = "1c243a97-b08d-4edb-b6e0-2fcadfe26c71",
                    num_users_renting = 1,
                },
                new RenterDTO{
                    wifi_id = "eca15f8b-ddfe-4109-bc9f-2e053e728c14",
                    num_users_renting = 0,
                }];
            return Ok(rentedWifiInfo);
            //return BadRequest("Under construction");
        }
        // ToDo: Get Renter's Wifis for Editting?
    }
}
