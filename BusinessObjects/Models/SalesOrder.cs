using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class SalesOrder
{
    public int SaleOrderId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string CustomerName { get; set; } = null!;

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
