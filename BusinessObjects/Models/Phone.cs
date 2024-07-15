using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class Phone
{
    public int PhoneId { get; set; }

    public string ModelName { get; set; } = null!;

    public int? BrandId { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string? Description { get; set; }

    public int Status { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; } = new List<PurchaseOrderDetail>();

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
