using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectPractice.Domain.Entities.Public;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

    public bool? BrandStatus { get; set; }

    [JsonIgnore]
    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
