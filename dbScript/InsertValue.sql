USE PhoneWarehouseDB;
GO

-- Thêm dữ liệu mẫu vào bảng Brand
INSERT INTO Brand (BrandName)
VALUES 
    (N'Samsung'),
    (N'Apple'),
    (N'Xiaomi');
GO

-- Thêm dữ liệu mẫu vào bảng Phones
INSERT INTO Phones (ModelName, BrandID, Price, Stock, Description)
VALUES 
    (N'Galaxy S21', 1, 799, 50, N'Samsung flagship model'),
    (N'iPhone 13', 2, 999, 30, N'Apple flagship model'),
    (N'Redmi Note 10', 3, 199, 100, N'Budget phone from Xiaomi');
GO

-- Thêm dữ liệu mẫu vào bảng Suppliers
INSERT INTO Suppliers (SupplierName, ContactName, Phone, Email, Address)
VALUES 
    (N'Supplier A', N'John Doe', N'123456789', N'supplierA@example.com', N'123 Supplier St.'),
    (N'Supplier B', N'Jane Smith', N'987654321', N'supplierB@example.com', N'456 Supplier Ave.');
GO

-- Thêm dữ liệu mẫu vào bảng PurchaseOrders
INSERT INTO PurchaseOrders (SupplierID, OrderDate, TotalAmount)
VALUES 
    (1, GETDATE(), 15999),
    (2, GETDATE(), 4999);
GO

-- Thêm dữ liệu mẫu vào bảng PurchaseOrderDetails
INSERT INTO PurchaseOrderDetails (OrderID, PhoneID, Quantity, Price)
VALUES 
    (1, 1, 20, 799),
    (1, 2, 10, 999),
    (2, 3, 25, 199);
GO

-- Thêm dữ liệu mẫu vào bảng SalesOrders
INSERT INTO SalesOrders (PhoneNumber, CustomerName, OrderDate, TotalPrice, Note)
VALUES 
    (N'0123456789', N'Alice', GETDATE(), 2999, N'First purchase'),
    (N'0987654321', N'Bob', GETDATE(), 3999, N'Returning customer');
GO

-- Thêm dữ liệu mẫu vào bảng SalesOrderDetails
INSERT INTO SalesOrderDetails (SaleOrderID, PhoneID, Quantity, Price)
VALUES 
    (1, 1, 2, 799),
    (1, 3, 1, 199),
    (2, 2, 2, 999);
GO
