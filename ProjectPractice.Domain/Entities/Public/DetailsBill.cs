using System;
using System.Collections.Generic;

namespace ProjectPractice.Domain.Entities.Public;
public partial class DetailsBill
{
    public int BillDetailNumber { get; set; }

    public int BillNumber { get; set; }

    public int? VehiId { get; set; }

    public decimal? PricePerItem { get; set; }

    public virtual Bill BillNumberNavigation { get; set; } = null!;

    public virtual Vehicle? Vehi { get; set; }
}
