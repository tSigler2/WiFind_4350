using System;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiFind.Server.ControlModels;
using wiFind.Server.Helpers;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly WiFindContext _wifFindContext;
        
        public PaymentController(WiFindContext wfc)
        {
            _wifFindContext = wfc;
        }

        [Authorize]
        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseCart(PurchaseModel payment, Cart cart)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Payment");
            
            if(cart.cart.Count() == 0) return BadRequest("No Items in Cart");

            decimal total = 0.00M;

            var userid = from a in _wifFindContext.Set<AccountInfo>() where (a.username == payment.username) select a.user_id;

            // i is the wifi's id
            foreach(string i in cart.cart)
            {
                var wifiCost = from wifi in _wifFindContext.Set<Wifi>()
                                where (wifi.wifi_id == i) select wifi.curr_rate;
                
                var rent = new Rent
                {
                    rent_id = Guid.NewGuid().ToString(), //(_wifFindContext.Rent.Max(total => (int?)total.rentID) ?? 0) + 1, generate a new guid?
                    user_id = userid.First(), // front end will need to pass in user's username atm. can be improved later to use id in validation token instead
                    wifi_id = i,
                    start_time = payment.start,
                    end_time = payment.end,
                    locked_rate = wifiCost.First(),
                    //guest_password = "00000", // needs to be handled later somehow
                };

                _wifFindContext.Rents.Add(rent);

                total += wifiCost.First();
            }
            // need to savechanges after adding new rent objects
            await _wifFindContext.SaveChangesAsync();

            // return total amount? 
            return Ok("Wifi Bought. Total Cost: $" + total);
        }

        [Authorize]
        [HttpGet("getRenteeView")]
        public async Task<IActionResult> GetRenteeView(string username)
        {
            // this query could be improved via joining accountlogin and rent table but atm this is just for fast results
            var userid = from a in _wifFindContext.Set<AccountInfo>() where (a.username == username) select a.user_id;
            var rentedWifi = from r in _wifFindContext.Set<Rent>() where (r.user_id == userid.First()) select r;

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
    }
}