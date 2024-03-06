using System;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using wiFind.Server;

namespace wiFind.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WifiController : ControllerBase
    {
        private readonly WiFindContext server;

        public WifiController(WiFindContext s)
        {
            server = s;
        }

        [HttpGet]
        public async Task<IActionResult> GetListings()
        {
            var listings = await server.WifiListing.ToListAsync();
            return Ok(listings);
        }
    }
}