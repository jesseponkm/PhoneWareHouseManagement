using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class SalesOrder
{
    public int SaleOrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public int Status { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
