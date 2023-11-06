using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPractice.Domain.Reducers
{
    [NotMapped]
    public class VehicleInformation
    {
        public string VehiPlate { get; set; }
        //public string UserUsername { get; set; }
        //public string BrandName { get; set; }
        public string VsName { get; set; }
    }
}
