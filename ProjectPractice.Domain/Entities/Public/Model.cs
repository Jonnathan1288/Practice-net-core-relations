using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectPractice.Domain.Entities.Public;

public partial class Model
{
    public int ModelId { get; set; }

    public string ModelName { get; set; } = null!;

    public bool? ModelStatus { get; set; }

    public int? ModelAvailableQuantity { get; set; }

    public decimal? ModelPrice { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    [JsonIgnore]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
