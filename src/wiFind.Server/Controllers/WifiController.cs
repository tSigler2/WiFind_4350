using System;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WifiController : ControllerBase
    {
        private readonly WiFindContext _wifFindContext;

        public WifiController(WiFindContext wifFindContext)
        {
            _wifFindContext = wifFindContext;
        }

        // TODO: Add Client token verification
        // Returns All Wifi Listing
        [HttpGet]
        public async Task<IActionResult> GetListings()
        {
            var listings = await _wifFindContext.Wifis.ToListAsync();
            return Ok(listings);
        }

        // Adds Wifi to listing
        // Requires the user's id in owned_by
        [HttpPost]
        public async Task<IActionResult> AddWifi(Wifi wifi)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Wifi Submission");

            _wifFindContext.Wifis.Add(wifi);
            await _wifFindContext.SaveChangesAsync();

            return Ok("Wifi listed successfully.");
        }

        // Remove Wifi Listing by wifi_id
        // Condition: User cannot remove wifi listing if Rents table has a user renting that wifi id
        // Parameter consideration: using just wifi_id instead of the entire object
        [HttpDelete]
        public async Task<IActionResult> RemoveWifiListing(Wifi wifi)
        {
            var query = from rent in _wifFindContext.Set<Rent>() where rent.wifi_id == wifi.wifi_id select rent;
            if (query.Count() > 0)
                return BadRequest("Cannot remove Wifi from listing if users are still using.");

            _wifFindContext.Wifis.Remove(wifi);
            await _wifFindContext.SaveChangesAsync();
            return Ok("Successfully Removed.");
        }

        // Edit Wifi, for users that want to edit information on the wifi listed
        // Condition: User cannot reduce max number of user allowed IF RENTS count > new max
        // Change to Post later? Not sure why but HttpPost causes middleware error (Swagger)
        [HttpPut]
        public async Task<IActionResult> EditWifiListing(Wifi wifi)
        {
            var query = from rent in _wifFindContext.Set<Rent>() where rent.wifi_id == wifi.wifi_id select rent;
            if (query.Count() > wifi.max_users)
                return BadRequest("Cannot update max users when current renters are greater.");

            // Same as updateUserProfile, need to have wifi_id to override existing Wifi object...
            _wifFindContext.Wifis.Add(wifi);
            await _wifFindContext.SaveChangesAsync();

            return Ok("Placeholder at the moment");
        }

    }
}
