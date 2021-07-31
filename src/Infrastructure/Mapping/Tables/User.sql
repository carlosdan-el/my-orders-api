-- *****************************************************************************
-- Created by: Carlos Daniel
-- Created at: 2021/07/31
-- Updated by: -
-- Updated at: -
-- ***************************************************************************** 

CREATE TABLE User (
    Id VARCHAR(36) PRIMARY KEY,
    FirstName VARCHAR(255) NOT NULL,
    LastName VARCHAR(255),
    CreatedBy VARCHAR(36) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    UpdatedBy VARCHAR(36) NOT NULL,
    UpdatedAt DATETIME NOT NULL
)