using System;
using System.Collections.Generic;

namespace BusinessObjects.Models;

public partial class SalesOrderDetail
{
    public int SaleDetailId { get; set; }

    public int? SaleOrderId { get; set; }

    public int? PhoneId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public int Status { get; set; }

    public virtual Phone? Phone { get; set; }

    public virtual SalesOrder? SaleOrder { get; set; }
}
