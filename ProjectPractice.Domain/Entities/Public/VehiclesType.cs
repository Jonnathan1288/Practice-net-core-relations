using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectPractice.Domain.Entities.Public;
public partial class VehiclesType
{
    public int VehiTypeId { get; set; }

    public string VehiTypeName { get; set; } = null!;

    public bool? VehiTypeStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
