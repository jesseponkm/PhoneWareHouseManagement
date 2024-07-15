use master
go

-- Tạo cơ sở dữ liệu
CREATE DATABASE PhoneWarehouseDB;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE PhoneWarehouseDB;
GO

-- Tạo bảng Brand với cột Status
CREATE TABLE Brand (
    BrandID INT PRIMARY KEY IDENTITY(1,1),
    BrandName NVARCHAR(50) NOT NULL UNIQUE,
    Status INT NOT NULL DEFAULT 1 -- 1: Tồn tại, 0: Xóa
);
GO

-- Tạo bảng Phones với cột Status và tham chiếu tới bảng Brand
CREATE TABLE Phones (
    PhoneID INT PRIMARY KEY IDENTITY(1,1),
    ModelName NVARCHAR(100) NOT NULL,
    BrandID INT,
    Price DECIMAL(18, 2) NOT NULL,
    Stock INT NOT NULL,
    Description NVARCHAR(MAX),
    Status INT NOT NULL DEFAULT 1, -- 1: Tồn tại, 0: Xóa
    FOREIGN KEY (BrandID) REFERENCES Brand(BrandID)
);
GO

-- Tạo bảng Suppliers với cột Status
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(100) NOT NULL,
    ContactName NVARCHAR(100),
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    Status INT NOT NULL DEFAULT 1 -- 1: Tồn tại, 0: Xóa
);
GO

-- Tạo bảng PurchaseOrders với cột Status
CREATE TABLE PurchaseOrders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    Status INT NOT NULL DEFAULT 1, -- 1: Tồn tại, 0: Xóa
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);
GO

-- Tạo bảng PurchaseOrderDetails với cột Status
CREATE TABLE PurchaseOrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    PhoneID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Status INT NOT NULL DEFAULT 1, -- 1: Tồn tại, 0: Xóa
    FOREIGN KEY (OrderID) REFERENCES PurchaseOrders(OrderID),
    FOREIGN KEY (PhoneID) REFERENCES Phones(PhoneID)
);
GO

-- Tạo bảng Customers với cột Status
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(200),
    Status INT NOT NULL DEFAULT 1 -- 1: Tồn tại, 0: Xóa
);
GO

-- Tạo bảng SalesOrders với cột Status
CREATE TABLE SalesOrders (
    SaleOrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    Status INT NOT NULL DEFAULT 1, -- 1: Tồn tại, 0: Xóa
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
GO

-- Tạo bảng SalesOrderDetails với cột Status
CREATE TABLE SalesOrderDetails (
    SaleDetailID INT PRIMARY KEY IDENTITY(1,1),
    SaleOrderID INT,
    PhoneID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    Status INT NOT NULL DEFAULT 1, -- 1: Tồn tại, 0: Xóa
    FOREIGN KEY (SaleOrderID) REFERENCES SalesOrders(SaleOrderID),
    FOREIGN KEY (PhoneID) REFERENCES Phones(PhoneID)
);
GO

-- Thêm dữ liệu mẫu vào bảng Brand
INSERT INTO Brand (BrandName, Status) VALUES ('Apple', 1), ('Samsung', 1), ('Xiaomi', 1);
GO

-- Thêm dữ liệu mẫu vào bảng Phones
INSERT INTO Phones (ModelName, BrandID, Price, Stock, Description, Status) VALUES 
('iPhone 13', 1, 799.99, 50, 'Latest model of iPhone', 1),
('iPhone 12', 1, 699.99, 30, 'Previous model of iPhone', 1),
('Galaxy S21', 2, 999.99, 40, 'Latest model of Galaxy S series', 1),
('Galaxy Note 20', 2, 949.99, 20, 'Previous model of Galaxy Note series', 1),
('Redmi Note 10', 3, 199.99, 100, 'Affordable model from Xiaomi', 1);
GO

-- Thêm dữ liệu mẫu vào bảng Suppliers
INSERT INTO Suppliers (SupplierName, ContactName, Phone, Email, Address, Status) VALUES
('ABC Supply Co.', 'John Doe', '123456789', 'johndoe@abc.com', '123 Main St', 1),
('XYZ Distributors', 'Jane Smith', '987654321', 'janesmith@xyz.com', '456 Elm St', 1);
GO

-- Thêm dữ liệu mẫu vào bảng Customers
INSERT INTO Customers (CustomerName, Phone, Email, Address, Status) VALUES
('Alice Johnson', '555123456', 'alice.johnson@example.com', '789 Oak St', 1),
('Bob Brown', '555987654', 'bob.brown@example.com', '321 Pine St', 1);
GO

-- Thêm dữ liệu mẫu vào bảng PurchaseOrders
INSERT INTO PurchaseOrders (SupplierID, OrderDate, TotalAmount, Status) VALUES 
(1, '2023-01-01', 10000.00, 1),
(2, '2023-02-01', 15000.00, 1);
GO

-- Thêm dữ liệu mẫu vào bảng PurchaseOrderDetails
INSERT INTO PurchaseOrderDetails (OrderID, PhoneID, Quantity, Price, Status) VALUES 
(1, 1, 50, 750.00, 1),
(1, 2, 30, 650.00, 1),
(2, 3, 40, 950.00, 1),
(2, 4, 20, 900.00, 1),
(2, 5, 100, 190.00, 1);
GO

-- Thêm dữ liệu mẫu vào bảng SalesOrders
INSERT INTO SalesOrders (CustomerID, OrderDate, TotalAmount, Status) VALUES 
(1, '2023-03-01', 5000.00, 1),
(2, '2023-04-01', 7000.00, 1);
GO

-- Thêm dữ liệu mẫu vào bảng SalesOrderDetails
INSERT INTO SalesOrderDetails (SaleOrderID, PhoneID, Quantity, Price, Status) VALUES 
(1, 1, 5, 799.99, 1),
(1, 2, 3, 699.99, 1),
(2, 3, 4, 999.99, 1),
(2, 4, 2, 949.99, 1),
(2, 5, 10, 199.99, 1);
GO
