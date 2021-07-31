-- *****************************************************************************
-- Created by: Carlos Daniel
-- Created at: 2021/07/31
-- Updated by: -
-- Updated at: -
-- ***************************************************************************** 

CREATE TABLE ProductType (
    Id VARCHAR(36) PRIMARY KEY,
    TypeName VARCHAR(255) NOT NULL,
    TypeDescription VARCHAR(500),
    CreatedBy VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY User(Id),
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) NOT NULL REFERENCES FOREIGN KEY User(Id),
    UpdatedAt DATETIME NOT NULL
)