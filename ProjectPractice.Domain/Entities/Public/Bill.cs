using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ProjectPractice.Domain.Entities.Public;

public partial class Bill
{
    public int BillNumber { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public int? UserId { get; set; }

    public decimal? Amount { get; set; }

    public string? PaymentMethod { get; set; }

    [JsonIgnore]
    public virtual ICollection<DetailsBill> DetailsBills { get; set; } = new List<DetailsBill>();

    public virtual User? User { get; set; }
}
