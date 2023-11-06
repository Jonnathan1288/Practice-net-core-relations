using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectPractice.Domain.Entities.Public;

public partial class Vehicle
{
    public int VehiId { get; set; }

    public string VehiPlate { get; set; } = null!;

    public string VehiCode { get; set; } = null!;

    public char? VehiStatus { get; set; }

    public int? ModelId { get; set; }

    public int? VsId { get; set; }

    public int? VehiTypeId { get; set; }

    [JsonIgnore]
    public virtual ICollection<DetailsBill> DetailsBills { get; set; } = new List<DetailsBill>();

    public virtual Model? Model { get; set; }

    public virtual VehiclesType? VehiType { get; set; }

    public virtual VehicleStatus? Vs { get; set; }
}
