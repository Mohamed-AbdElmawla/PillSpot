CREATE PROCEDURE InsertRandomLocationsData
    @NumberOfLocations INT -- The number of random locations to insert
AS
BEGIN
    DECLARE @Counter INT = 0;
    DECLARE @Longitude FLOAT;
    DECLARE @Latitude FLOAT;
    DECLARE @AdditionalInfo NVARCHAR(255);
    DECLARE @CityId INT;
    DECLARE @GovernmentId INT;
    
    -- Loop to generate random locations
    WHILE @Counter < @NumberOfLocations
    BEGIN
        -- Random Longitude (between -180 and 180)
        SET @Longitude = (RAND() * 360.0) - 180.0;

        -- Random Latitude (between -90 and 90)
        SET @Latitude = (RAND() * 180.0) - 90.0;

        -- Random AdditionalInfo (example text)
        SET @AdditionalInfo = CONCAT('Location Info ', CAST(ABS(CHECKSUM(NEWID())) % 1000 AS NVARCHAR(10)));

        -- Random CityId (ensure CityId exists in the City table)
        SET @CityId = (SELECT TOP 1 CityId FROM Cities ORDER BY NEWID());

        -- Random GovernmentId (ensure GovernmentId exists in the Government table)
        SET @GovernmentId = (SELECT TOP 1 GovernmentId FROM Governments ORDER BY NEWID());

        -- Insert the random location into the Location table
        INSERT INTO Locations (Longitude, Latitude, AdditionalInfo, CityId, GovernmentId)
        VALUES (@Longitude, @Latitude, @AdditionalInfo, @CityId, @GovernmentId);

        -- Increment the counter
        SET @Counter = @Counter + 1;
    END;

    PRINT 'Random Locations seeded successfully';
END;
