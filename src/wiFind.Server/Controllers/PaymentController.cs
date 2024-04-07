using System;
using System.Net.WebSockets;
using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiFind.Server.ControlModels;
using wiFind.Server.Helpers;

namespace wiFind.Server.Controllers
{
    public class PaymentController : ControllerBase
    {
        private readonly WiFindContext _WiFindContext;

        public PaymentController(WiFindContext wfc)
        {
            _WiFindContext = wfc;
        }

        [HttpPost("purchase")]
        public static Task<IActionResult> PurchaseCart(PaymentReg payment, Cart cart)
        {
            if(!ModelState.IsValid) return BadRequest("Invalid Payment");
            
            if(cart.Count() == 0) return BadRequest("No Items in Cart");

            float total = 0.0f;

            foreach(string i in cart)
            {
                var wifiCost = from wifi in _WiFindContext.Set<Wifi>()
                                where (wifi.wifi_id == i) select wifi.curr_rate;
                
                var rent = new RentModel
                {
                    rentID = (_WiFindContext.Rent.Max(total => (int?)total.rentID) ?? 0) + 1,
                    userID = payment.userid,
                    user = _WiFindContext.Find(payment.userid),
                    wifiID = i,
                    wifi = _WiFindConext.Wifi.Find(i),
                    start = payment.start,
                    end = payment.end,
                    locked_rate = _WiFindContext.Wifi.Find(i).curr_rate,
                    guest_password = "00000"
                };

                _WiFindContext.Rent.Add(rent);

                total += wifiCost;

                return Ok("Wifi Bought");
            }
        }
    }
}