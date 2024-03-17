using System;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wiFind.Server.Helpers;
using wiFind.Server.ControlModels;

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

        // Returns All Wifi Listing
        [Authorize]
        [HttpGet("wifilistings")]
        public async Task<IActionResult> GetListings()
        {
            var listings = await _wifFindContext.Wifis.ToListAsync();
            return Ok(listings);
        }

        // Adds Wifi to listing
        // Requires the user's id in owned_by
        [Authorize]
        [HttpPost("addwifi")]
        public async Task<IActionResult> AddWifi(WifiReg wifi)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Wifi Submission");

            _wifFindContext.Wifis.Add(new Wifi
            {
                wifi_id = Guid.NewGuid().ToString(),
                wifi_name = wifi.wifi_name,
                security = wifi.security,
                download_speed = wifi.download_speed,
                upload_speed = wifi.upload_speed,
                wifi_latitude = wifi.wifi_latitude,
                wifi_longitude = wifi.wifi_longitude,
                radius = wifi.radius,
                wifi_source = wifi.wifi_source,
                owned_by = wifi.owned_by,
                max_users = wifi.max_users
            });
            await _wifFindContext.SaveChangesAsync();

            return Ok("Wifi listed successfully.");
        }

        // Remove Wifi Listing by wifi_id
        // Condition: User cannot remove wifi listing if Rents table has a user renting that wifi id
        // Parameter consideration: using just wifi_id instead of the entire object
        [Authorize]
        [HttpDelete("removewifi")]
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
        [Authorize]
        [HttpPost("updatewifi")]
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