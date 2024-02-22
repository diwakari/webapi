using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        
        private readonly ILogger<LocationController> _logger;

        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetLocation")]
        public IEnumerable<Location> Get()
        {

            DateTime nowTime = DateTime.Now;
            TimeSpan startTime = TimeSpan.Parse("10:00");
            TimeSpan endTime = TimeSpan.Parse("14:00");

            if (nowTime.TimeOfDay >= startTime && nowTime.TimeOfDay <= endTime)
            {
                var locations = Enumerable.Range(1, 5)
                .Select(index => new Location
                {
                    id = index,
                    location_name = "supermarket no " + index,
                    opening_time = "10:00",
                    ending_time = "14:00"
                }).ToArray();

                // if need from api value filter
                //.Where(location =>
                // {
                //     TimeSpan openingTime = TimeSpan.Parse(location.opening_time);
                //     TimeSpan closingTime = TimeSpan.Parse(location.ending_time);
                //     return nowTime.TimeOfDay >= openingTime && nowTime.TimeOfDay <= closingTime;
                // })
                return locations;
            }
            else
            {
                return new List<Location>
                {
                    new Location
                    {
                        id = 0,
                        location_name = "Please try later in availability between opening time and ending time .",
                        opening_time = "10:00",
                        ending_time = "14:00"
                    }
                };
            }
        }
    }
}
