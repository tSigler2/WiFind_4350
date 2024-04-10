using Microsoft.AspNetCore.Mvc;
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
        // Need an endpoint that Returns summary from list of wifi_ids in cart for purchase
        [Authorize]
        [HttpPost("purchase")]
        public async Task<IActionResult> PurchaseCart(PurchaseModel payment)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Payment");
            
            if(payment.checkoutCart.cart.Count() == 0) return BadRequest("No Items in Cart");

            decimal total = 0.00M;

            var userid = from a in _wifFindContext.Set<AccountInfo>() where (a.username == payment.username) select a.user_id;

            // i is the wifi's id
            foreach(string i in payment.checkoutCart.cart)
            {
                var wifiCost = from wifi in _wifFindContext.Set<Wifi>()
                                where (wifi.wifi_id == i) select wifi.curr_rate;
                
                var rent = new Rent
                {
                    rent_id = Guid.NewGuid().ToString(), //(_wifFindContext.Rent.Max(total => (int?)total.rentID) ?? 0) + 1, generate a new guid?
                    user_id = userid.First(), // front end will need to pass in user's username atm. can be improved later to use id in validation token instead
                    wifi_id = i,
                    start_time = payment.start,
                    locked_rate = wifiCost.First(),
                    //guest_password = "00000", // needs to be handled later somehow
                };

                _wifFindContext.Rents.Add(rent);

                total += wifiCost.First();
            }
            // need to savechanges after adding new rent objects
            await _wifFindContext.SaveChangesAsync();

            // return total amount? 
            return Ok("Wifi Bought. Total Cost: $" + total + "per hour.");
        }
    }
}