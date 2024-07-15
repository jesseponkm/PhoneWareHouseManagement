use master
go

-- Tạo cơ sở dữ liệu
CREATE DATABASE PhoneWarehouseDB;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE PhoneWarehouseDB;
GO

-- Tạo bảng Brand
CREATE TABLE Brand (
    BrandID INT PRIMARY KEY IDENTITY(1,1),
    BrandName NVARCHAR(50) NOT NULL UNIQUE
);
GO

-- Tạo bảng Phones và thêm cột BrandID để tham chiếu đến bảng Brand
CREATE TABLE Phones (
    PhoneID INT PRIMARY KEY IDENTITY(1,1),
    ModelName NVARCHAR(100) NOT NULL,
    BrandID INT,
    Price DECIMAL(18, 2) NOT NULL,
    Stock INT NOT NULL,
    Description NVARCHAR(MAX),
    FOREIGN KEY (BrandID) REFERENCES Brand(BrandID)
);
GO

-- Tạo bảng Suppliers
CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(100) NOT NULL,
    ContactName NVARCHAR(100),
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(200)
);
GO

-- Tạo bảng PurchaseOrders
CREATE TABLE PurchaseOrders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    SupplierID INT,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (SupplierID) REFERENCES Suppliers(SupplierID)
);
GO

-- Tạo bảng PurchaseOrderDetails
CREATE TABLE PurchaseOrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT,
    PhoneID INT,
    Quantity INT NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (OrderID) REFERENCES PurchaseOrders(OrderID),
    FOREIGN KEY (PhoneID) REFERENCES Phones(PhoneID)
);
GO

-- Tạo bảng Customers
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(200)
);
GO

-- Tạo bảng SalesOrders
CREATE TABLE SalesOrders (
    SaleOrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    OrderDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
GO

-- Tạo bảng SalesOrderDetails
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

-- Thêm dữ liệu mẫu vào bảng Brand
INSERT INTO Brand (BrandName) VALUES ('Apple');
INSERT INTO Brand (BrandName) VALUES ('Samsung');
INSERT INTO Brand (BrandName) VALUES ('Xiaomi');
GO

-- Thêm dữ liệu mẫu vào bảng Phones
INSERT INTO Phones (ModelName, BrandID, Price, Stock, Description) VALUES 
('iPhone 13', 1, 799.99, 50, 'Latest model of iPhone'),
('iPhone 12', 1, 699.99, 30, 'Previous model of iPhone'),
('Galaxy S21', 2, 999.99, 40, 'Latest model of Galaxy S series'),
('Galaxy Note 20', 2, 949.99, 20, 'Previous model of Galaxy Note series'),
('Redmi Note 10', 3, 199.99, 100, 'Affordable model from Xiaomi');
GO

-- Thêm dữ liệu mẫu vào bảng Suppliers
INSERT INTO Suppliers (SupplierName, ContactName, Phone, Email, Address) VALUES
('ABC Supply Co.', 'John Doe', '123456789', 'johndoe@abc.com', '123 Main St'),
('XYZ Distributors', 'Jane Smith', '987654321', 'janesmith@xyz.com', '456 Elm St');
GO

-- Thêm dữ liệu mẫu vào bảng Customers
INSERT INTO Customers (CustomerName, Phone, Email, Address) VALUES
('Alice Johnson', '555123456', 'alice.johnson@example.com', '789 Oak St'),
('Bob Brown', '555987654', 'bob.brown@example.com', '321 Pine St');
GO

-- Thêm dữ liệu mẫu vào bảng PurchaseOrders
INSERT INTO PurchaseOrders (SupplierID, OrderDate, TotalAmount) VALUES 
(1, '2023-01-01', 10000.00),
(2, '2023-02-01', 15000.00);
GO

-- Thêm dữ liệu mẫu vào bảng PurchaseOrderDetails
INSERT INTO PurchaseOrderDetails (OrderID, PhoneID, Quantity, Price) VALUES 
(1, 1, 50, 750.00),
(1, 2, 30, 650.00),
(2, 3, 40, 950.00),
(2, 4, 20, 900.00),
(2, 5, 100, 190.00);
GO

-- Thêm dữ liệu mẫu vào bảng SalesOrders
INSERT INTO SalesOrders (CustomerID, OrderDate, TotalAmount) VALUES 
(1, '2023-03-01', 5000.00),
(2, '2023-04-01', 7000.00);
GO

-- Thêm dữ liệu mẫu vào bảng SalesOrderDetails
INSERT INTO SalesOrderDetails (SaleOrderID, PhoneID, Quantity, Price) VALUES 
(1, 1, 5, 799.99),
(1, 2, 3, 699.99),
(2, 3, 4, 999.99),
(2, 4, 2, 949.99),
(2, 5, 10, 199.99);
GO
