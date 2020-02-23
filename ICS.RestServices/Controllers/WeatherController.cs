using ICS.RestServices.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ICS.RestServices.Controllers
{

    public class WeatherController:ApiController
    {
        //GET /Weather? City = Wollongong
        public async Task<IHttpActionResult> Get(string city)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", city, "ede5297e3be3d80d27421db0da52ef79");
                    using (var response = httpClient.GetAsync(url).Result)
                    {

                        if (response.IsSuccessStatusCode)
                        {

                            var weatherJsonString = await response.Content.ReadAsStringAsync();
                            var weatherdata = JsonConvert.DeserializeObject<WeatherData>(weatherJsonString);
                            var temperature = KelvinToCensius(weatherdata.main.temp, true);
                            return Json(new { temperature = temperature, success = true, message = "City found." });
                        }
                        else
                        {
                            return Json(new { temperature = string.Empty, success = false, message ="City not found."});
                        }
                    }
                }
            }catch(Exception ex)
            {
                return Json(new { temperature = string.Empty, success = false,message=ex.Message});
            }
        }


        private static double KelvinToCensius(double d, bool kelvin = false)
        {
            return kelvin ? (d - 273.15) : (d + 273.15);
        }
    }
}