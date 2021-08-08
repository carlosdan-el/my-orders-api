-- *****************************************************************************
-- Created by: Carlos Daniel
-- Created at: 2021/08/07
-- Updated by: -
-- Updated at: -
-- ***************************************************************************** 

USE ShopCart

GO

CREATE TABLE tbRole (
    Id VARCHAR(36) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(500),
    CreatedBy VARCHAR(36) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

CREATE TABLE tbUser (
    Id VARCHAR(36) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(15),
    RoleId VARCHAR(36) FOREIGN KEY REFERENCES tbRole(Id) NOT NULL,
    CreatedBy VARCHAR(36) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

CREATE TABLE tbProductCategory (
    Id VARCHAR(36) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL UNIQUE,
    Description VARCHAR(500) NOT NULL,
    CreatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

CREATE TABLE tbProductType (
    Id VARCHAR(36) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(500),
    ProductCategoryId VARCHAR(36) FOREIGN KEY REFERENCES tbProductCategory(Id) NOT NULL,
    CreatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

CREATE TABLE tbProductSize (
    Id VARCHAR(36) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(500),
    CreatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

CREATE TABLE tbProduct (
    Id VARCHAR(36) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description VARCHAR(500),
    CategoryId VARCHAR(36) FOREIGN KEY REFERENCES tbProductCategory(Id) NOT NULL,
    TypeId VARCHAR(36) FOREIGN KEY REFERENCES tbProductType(Id) NOT NULL,
    SizeId VARCHAR(36) FOREIGN KEY REFERENCES tbProductType(Id) NOT NULL,
    Price MONEY NOT NULL,
    Tags VARCHAR(500),
    CreatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

CREATE TABLE tbOrder (
    Id VARCHAR(36) PRIMARY KEY,
    UserId VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    Price MONEY NOT NULL,
    CreatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

CREATE TABLE tbOrderItem (
    Id VARCHAR(36) PRIMARY KEY,
    OrderId VARCHAR(36) FOREIGN KEY REFERENCES tbOrder(Id) NOT NULL,
    ProductId VARCHAR(36) FOREIGN KEY REFERENCES tbProduct(Id) NOT NULL,
    Quantity NUMERIC NOT NULL,
    Price MONEY NOT NULL,
    CreatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) FOREIGN KEY REFERENCES tbUser(Id) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)

GO