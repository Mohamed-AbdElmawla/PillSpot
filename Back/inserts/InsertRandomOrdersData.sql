CREATE PROCEDURE InsertRandomOrdersData
    @NumberOfOrders INT -- The number of random orders to insert
AS
BEGIN
    DECLARE @Counter INT = 0;
    DECLARE @LocationId INT;
    DECLARE @UserId NVARCHAR(50);
    DECLARE @Status NVARCHAR(50);
    DECLARE @TotalPrice DECIMAL(18, 2);
    DECLARE @OrderedAt DATETIME;
    DECLARE @OrderId INT;

    -- List of possible statuses from the Status enum
    DECLARE @Statuses TABLE (Status NVARCHAR(50));
    INSERT INTO @Statuses (Status)
    VALUES ('Pinding'), ('ReadyToDeliver'), ('Delivered');

    -- Loop to generate random orders
    WHILE @Counter < @NumberOfOrders
    BEGIN
        -- Randomly pick a LocationId (ensure LocationId exists in the Location table)
        SET @LocationId = (SELECT TOP 1 LocationId FROM Locations ORDER BY NEWID());  

        -- Randomly pick a UserId (ensure UserId exists in the User table)
        SET @UserId = (SELECT TOP 1 Id FROM Users ORDER BY NEWID());            

        -- Randomly pick a Status from the @Statuses table
        SET @Status = (SELECT Status FROM @Statuses ORDER BY NEWID() OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY);

        -- Random TotalPrice between 10 and 500 (adjust range as needed)
        SET @TotalPrice = CAST((RAND() * (500 - 10) + 10) AS DECIMAL(18, 2));

        -- Random OrderedAt date (within the last 30 days)
        SET @OrderedAt = DATEADD(DAY, -1 * (ABS(CHECKSUM(NEWID())) % 30), GETDATE());  -- Random date within the last 30 days

        -- Insert the random order into the Orders table
        INSERT INTO Orders (OrderedAt, TotalPrice, Status, LocationId, UserId)
        VALUES (@OrderedAt, @TotalPrice, @Status, @LocationId, @UserId);

        -- Increment the counter
        SET @Counter = @Counter + 1;
    END;

    PRINT 'Random Orders Seeder Completed';
END;
