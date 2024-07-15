using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class PurchaseOrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? PhoneId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public virtual PurchaseOrder? Order { get; set; }

    public virtual Phone? Phone { get; set; }
}
