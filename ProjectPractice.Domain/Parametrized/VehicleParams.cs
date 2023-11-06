
using Microsoft.AspNetCore.Mvc;

namespace ProjectPractice.Domain.Parametrized
{
    public class VehicleParams
    {
        [FromQuery(Name = "brand_name")]
        public string[]? BrandName { get; set; }

        [FromQuery(Name = "vehi_plate")]
        public string[]? VehiPlate {get; set;}

        [FromQuery(Name = "user_id")]
        public int[]? UserId { get; set; }
    }
}
