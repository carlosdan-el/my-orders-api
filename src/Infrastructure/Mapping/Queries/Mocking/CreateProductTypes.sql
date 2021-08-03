USE Shopcart
GO

DECLARE @adminUser VARCHAR(36)
,@meal VARCHAR(36)
,@dessert VARCHAR(36)
,@breakfast VARCHAR(36) 

SET @adminUser = (SELECT Id FROM tbUsers WHERE FirstName = 'System' AND LastName = 'Admin')
SET @meal = (SELECT Id FROM tbProductCategories WHERE CategoryName = 'Meal')
SET @dessert = (SELECT Id FROM tbProductCategories WHERE CategoryName = 'Dessert')
SET @breakfast = (SELECT Id FROM tbProductCategories WHERE CategoryName = 'Breakfast')

INSERT INTO tbProductTypes
(
    Id
    ,TypeName
    ,TypeDescription
    ,ProductCategoryId
    ,CreatedBy
    ,CreatedAt
    ,UpdatedBy
    ,UpdatedAt
)
VALUES
(
    NEWID()
    ,'Pasta'
    ,'Lorem Ipsum'
    ,@meal
    ,@adminUser
    ,GETDATE()
    ,@adminUser
    ,GETDATE()
),
(
    NEWID()
    ,'Ice cream'
    ,'Lorem Ipsum'
    ,@dessert
    ,@adminUser
    ,GETDATE()
    ,@adminUser
    ,GETDATE()
)
(
    NEWID()
    ,'Fried Eggs'
    ,'Lorem Ipsum'
    ,@breakfast
    ,@adminUser
    ,GETDATE()
    ,@adminUser
    ,GETDATE()
)
GO