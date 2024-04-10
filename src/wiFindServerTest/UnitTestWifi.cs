using NUnit.Framework;
using NUnit.Framework.Legacy;

using Microsoft.AspNetCore.Mvc;
using wiFind.Server.Controllers;
using wiFind.Server.AuthModels;
using wiFind.Server.ControlModels;

namespace wiFind.Server.UnitTest
{

    [TestFixture]
    public class WifiTests
    {
        private readonly WiFindContext _wifFindContext = null; // Use Moq.EntityFramework for testing.

        [SetUp]
        public void setup()
        {
            
        }
        
        [Test]
        public void AddTest()
        {
            var wifiControl = new WifiController(_wifFindContext);

            var testWifi = new WifiReg{
                wifi_name = "testing",
                security = "WPA2",
                download_speed = 100,
                upload_speed = 100,
                wifi_latitude = 2.2f,
                wifi_longitude = 2.2f,
                radius = 1.0f,
                wifi_source = "new york, new york",
                curr_rate = 10.0M,
                time_listed = DateTime.UtcNow,
                owned_by = "Cotton Eye Joe",
                max_users = 10
            };

            var response = wifiControl.AddWifi(testWifi);

            ClassicAssert.AreEqual(response, "Wifi listed successfully.");
        }

        [Test]
        public void RemoveTest()
        {
            var wifiControl = new WifiController(_wifFindContext);

            Wifi wifi = new Wifi
            {
                wifi_id = "91720bff-b076-4b89-9a6e-36eebd68403f",
                wifi_name = "ItsWifi",
                security = "SurpriseMe",
                download_speed = 500,
                upload_speed = 500,
                wifi_latitude = 0,
                wifi_longitude = 0,
                wifi_source = "HotSpot",
                radius = 10,
                curr_rate = 0.50M,
                time_listed = DateTime.Now,
                owned_by = "user9",
                max_users = 1
            };
            var response = wifiControl.RemoveWifiListing(wifi);
            ClassicAssert.AreEqual(response, "Successfully Removed.");
        }

        [Test]
        public void EditWifiTest()
        {
            private readonly WiFindContext _wifFindContext = null; // Use Moq.EntityFramework for testing.

            Wifi wifi = new Wifi
            {
                wifi_id = "91720bff-b076-4b89-9a6e-36eebd68403f",
                wifi_name = "ItsWifiTime",
                security = "SurpriseMe",
                download_speed = 500,
                upload_speed = 500,
                wifi_latitude = 0,
                wifi_longitude = 0,
                wifi_source = "HotSpot",
                radius = 10,
                curr_rate = 0.50M,
                time_listed = DateTime.Now,
                owned_by = "user9",
                max_users = 1
            };

            var response = wifiControl.EditWifiListing(wifi);

            ClassicAssert.AreEqual(response, "Placeholder at the moment");
        }
    }
}