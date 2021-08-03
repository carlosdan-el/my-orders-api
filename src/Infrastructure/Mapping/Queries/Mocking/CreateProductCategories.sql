USE Shopcart
GO

DECLARE @adminUser VARCHAR(36)

SET @adminUser = (SELECT Id FROM tbUsers WHERE FirstName = 'System' AND LastName = 'Admin')

INSERT INTO dbo.tbProductCategory
(
    Id
    ,CategoryName
    ,CategoryDescription
    ,CreatedBy
    ,CreatedAt
    ,UpdatedBy
    ,UpdatedAt
)
VALUES
(
    NEWID()
    ,'Meal'
    ,'Lorem Ipsum'
    ,@adminUser
    ,GETDATE()
    ,@adminUser
    ,GETDATE()
),
(
    NEWID()
    ,'Breakfast'
    ,'Lorem Ipsum'
    ,@adminUser
    ,GETDATE()
    ,@adminUser
    ,GETDATE()
),
(
    NEWID()
    ,'Dessert'
    ,'Lorem Ipsum'
    ,@adminUser
    ,GETDATE()
    ,@adminUser
    ,GETDATE()
)
GO