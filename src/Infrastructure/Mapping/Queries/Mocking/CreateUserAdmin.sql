USE [Shopcart]
GO

DECLARE @UserId VARCHAR(36)

SET @UserId = NEWID()

INSERT INTO dbo.tbUsers
(
    Id
    ,FirstName
    ,LastName
    ,CreatedBy
    ,CreatedAt
    ,UpdatedBy
    ,UpdatedAt
)
VALUES
(
    @UserId
    ,'System'
    ,'Admin'
    ,@UserId
    ,GETDATE()
    ,@UserId
    ,GETDATE()
)
GO