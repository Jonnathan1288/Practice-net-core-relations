using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectPractice.Domain.Entities.Public;

public partial class VehicleStatus
{
    public int VsId { get; set; }

    public string VsName { get; set; } = null!;

    public bool? VsStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
