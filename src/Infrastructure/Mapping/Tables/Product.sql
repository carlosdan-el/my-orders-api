-- *****************************************************************************
-- Created by: Carlos Daniel
-- Created at: 2021/07/31
-- Updated by: -
-- Updated at: -
-- *****************************************************************************

CREATE TABLE tbProduct (
    Id VARCHAR(36) PRIMARY KEY,
    ProductNameName VARCHAR(255) NOT NULL,
    ProductDescription VARCHAR(500),
    Price MONEY NOT NULL,
    CategoryId VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY ProductCategory(Id),
    TypeId VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY ProductType(Id),
    SizeId VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY ProductSize(Id),
    Tags VARCHAR(500),
    CreatedBy VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY User(Id),
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY User(Id),
    UpdatedAt DATETIME NOT NULL
)