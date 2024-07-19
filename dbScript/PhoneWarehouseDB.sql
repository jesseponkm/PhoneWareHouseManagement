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

-- Tạo bảng SalesOrders với cột Status
CREATE TABLE SalesOrders (
    SaleOrderID INT PRIMARY KEY IDENTITY(1,1),
    PhoneNumber VARCHAR(12) NOT NULL,
	CustomerName VARCHAR(50) NOT NULL,
    OrderDate DATETIME NOT NULL,
    TotalPrice DECIMAL(18, 0) NOT NULL,
	Note NVARCHAR(MAX)
);
GO

-- Tạo bảng SalesOrderDetails với cột Status
CREATE TABLE SalesOrderDetails (
    SaleDetailID INT PRIMARY KEY IDENTITY(1,1),
    SaleOrderID INT,
    PhoneID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (SaleOrderID) REFERENCES SalesOrders(SaleOrderID),
    FOREIGN KEY (PhoneID) REFERENCES Phones(PhoneID)
);
GO
