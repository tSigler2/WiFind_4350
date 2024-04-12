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

        // Returns All Wifi Listing, Do not include wifi ids in listing cards.
        [Authorize]
        [HttpGet("wifilistings")]
        public async Task<IActionResult> GetListings()
        {
            var listings = await _wifFindContext.Wifis.ToListAsync();
            return Ok(listings);
        }

        // Get User's Listed Wifi by username
        [Authorize]
        [HttpGet("listuserswifis")]
        public async Task<IActionResult> ListUsersWifis(UsernameInput username)
        {
            var listedWifis = from w in _wifFindContext.Set<Wifi>() where w.owned_by == username.Username select w;
            var asListObj = await listedWifis.ToListAsync();
            return Ok(asListObj);
        }

        // Adds Wifi to listing
        // Requires the user's id in owned_by
        [Authorize]
        [HttpPost("addwifi")]
        public async Task<IActionResult> AddWifi(WifiReg wifi)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Wifi Submission");
            var context = (AccountInfo)HttpContext.Items["User"];

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
                curr_rate = wifi.curr_rate,
                time_listed = DateTime.Now,
                owned_by = context.username,
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
        public async Task<IActionResult> RemoveWifiListing(WifiUpdate wifi)
        {
            var query = from rent in _wifFindContext.Set<Rent>() where rent.wifi_id == wifi.wifi_id select rent;
            if (query.Count() > 0)
                return BadRequest("Cannot remove Wifi from listing if users are still using.");

            var deletion = from w in _wifFindContext.Set<Wifi>() where wifi.wifi_id.Equals(w.wifi_id) select w;
            _wifFindContext.Wifis.Remove(deletion.First());
            await _wifFindContext.SaveChangesAsync();
            return Ok("Successfully Removed.");
        }

        // Front end needs to pass the follow arguments hidden from user.
        // Requires that you show the user's listings first then allow them to pick the wifi to edit so you can select that wifi's id
        // wifi_id, time_listed, owned_by (which is the username). These should be the same as the object was initially
        [Authorize]
        [HttpPost("updatewifi")]
        public async Task<IActionResult> EditWifiListing(WifiUpdate wifi)
        {
            var query = from w in _wifFindContext.Set<Wifi>() where w.wifi_id == wifi.wifi_id select w;
            var initialwifi = query.First();

            var updatedWifi = new Wifi
            {
                wifi_id = wifi.wifi_id,
                wifi_name = wifi.wifi_name, 
                security = wifi.security,
                download_speed = wifi.download_speed,
                upload_speed = wifi.upload_speed,
                wifi_latitude = wifi.wifi_latitude,
                wifi_longitude = wifi.wifi_longitude,
                radius = wifi.radius,
                wifi_source = wifi.wifi_source,
                curr_rate = wifi.curr_rate,
                time_listed = initialwifi.time_listed,
                owned_by = initialwifi.owned_by,
                max_users = wifi.max_users,
            };

            _wifFindContext.Wifis.Update(updatedWifi);
            await _wifFindContext.SaveChangesAsync();

            return Ok("Wifi Id: " + wifi.wifi_id +" has been updated.");
        }

    }
}