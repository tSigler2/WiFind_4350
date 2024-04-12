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

            // This endpoint is just a placeholder for third party payment group

            // return total amount? 
            return Ok("Payment Method is Valid.");
        }

        [Authorize]
        [HttpPost("saveRentedWifis")]
        public async Task<IActionResult> saveRentedWifis(CartDTO newlyRentedWifis) {
            // Need cart list to be here
            var context = (AccountInfo)HttpContext.Items["User"];
            var userid = context.user_id;
            List<Wifi> wifi = new List<Wifi>();
            foreach(var id in newlyRentedWifis.wifis_id_in_cart)
            {
                var w = _wifFindContext.Set<Wifi>().Find(id);
                wifi.Add(w);
            }
            foreach(var w in wifi)
            {
                await _wifFindContext.Set<Rent>().AddAsync(
                    new Rent
                    {
                        rent_id = Guid.NewGuid().ToString(),
                        user_id = userid,
                        wifi_id = w.wifi_id,
                        start_time = DateTime.Now,
                        locked_rate = w.curr_rate,
                        guest_password = "tba",
                    });
            }
            await _wifFindContext.SaveChangesAsync();

            return Ok("Saved");
        }
    }
}