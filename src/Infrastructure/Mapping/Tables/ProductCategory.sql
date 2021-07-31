-- *****************************************************************************
-- Created by: Carlos Daniel
-- Created at: 2021/07/31
-- Updated by: -
-- Updated at: -
-- ***************************************************************************** 

CREATE TABLE ProductCategory (
    Id VARCHAR(36) PRIMARY KEY,
    CategoryName VARCHAR(255) NOT NULL,
    CategoryDescription VARCHAR(500) NOT NULL,
    CreatedBy VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY User(Id),
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY User(Id),
    UpdatedAt DATETIME NOT NULL
)