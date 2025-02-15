CREATE PROCEDURE InsertRandomPharmaciesData
    @NumberOfRecords INT -- The number of pharmacies to insert
AS
BEGIN
    DECLARE @Counter INT = 0;
    DECLARE @Name NVARCHAR(100);
    DECLARE @Logo NVARCHAR(100);
    DECLARE @ContactNumber NVARCHAR(15);
    DECLARE @OpeningHours NVARCHAR(100);
    DECLARE @IsOpen24Hours BIT;
    DECLARE @CreatedAt DATETIME;
    DECLARE @LicenseID NVARCHAR(50);
    DECLARE @LocationId INT;

    -- Loop to generate random pharmacies
    WHILE @Counter < @NumberOfRecords
    BEGIN
        -- Random Pharmacy Name
        SET @Name = 'Pharmacy ' + CAST(@Counter AS NVARCHAR(10));

        -- Random Logo (can be null, so use NULL or a random logo path)
        SET @Logo = CASE WHEN RAND() > 0.5 THEN NULL ELSE 'LogoPath' + CAST(@Counter AS NVARCHAR(10)) + '.png' END;

        -- Random Contact Number (a random 10-digit number)
        SET @ContactNumber = '01' + CAST(CAST(RAND() * 1000000000 AS INT) AS NVARCHAR(10));

        -- Random Opening Hours (from 9 AM to 6 PM, or 24 hours)
        SET @OpeningHours = CASE 
                            WHEN RAND() > 0.5 THEN '9:00 AM - 6:00 PM'
                            ELSE '24 Hours'
                          END;

        -- Random IsOpen24Hours (boolean)
        SET @IsOpen24Hours = CASE WHEN RAND() > 0.5 THEN 1 ELSE 0 END;

        -- Random CreatedAt (random date within the last year)
        SET @CreatedAt = DATEADD(DAY, -CAST(RAND() * 365 AS INT), GETDATE());

        -- Random LicenseID (can be a random string)
        SET @LicenseID = 'LIC' + CAST(CAST(RAND() * 10000 AS INT) AS NVARCHAR(5));

        -- Select a random LocationId that exists in the Locations table
        SET @LocationId = (SELECT TOP 1 LocationId FROM Locations ORDER BY NEWID());

        -- Insert the random pharmacy into the Pharmacy table
        INSERT INTO Pharmacies (Name, Logo, ContactNumber, OpeningHours, IsOpen24Hours, CreatedAt, LicenseID, LocationId)
        VALUES (@Name, @Logo, @ContactNumber, @OpeningHours, @IsOpen24Hours, @CreatedAt, @LicenseID, @LocationId);

        -- Increment the counter
        SET @Counter = @Counter + 1;
    END;

    PRINT 'Random Pharmacies Seeder Completed';
END;
