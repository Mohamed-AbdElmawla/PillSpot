CREATE PROCEDURE InsertRandomUsersData
    @NumberOfUsers INT -- The number of random users to insert
AS
BEGIN
    DECLARE @Counter INT = 0;
    DECLARE @Name NVARCHAR(100);
    DECLARE @Age INT;
    DECLARE @SOSNumber NVARCHAR(20);
    DECLARE @Gender INT; -- 0 for Male, 1 for Female
    DECLARE @CreatedAt DATETIME;
    DECLARE @RefreshToken NVARCHAR(255);
    DECLARE @PhotoUrl NVARCHAR(255) = NULL; -- Set PhotoUrl to NULL
    DECLARE @RefreshTokenExpiryTime DATETIME;
    DECLARE @LocationId INT;

    -- Default values for IdentityUser required fields
    DECLARE @Email NVARCHAR(255);
    DECLARE @NormalizedEmail NVARCHAR(255);
    DECLARE @UserName NVARCHAR(255);
    DECLARE @NormalizedUserName NVARCHAR(255);
    DECLARE @PasswordHash NVARCHAR(255) = 'AQAAAAEAACcQAAAAEDewWjxq0zXwSgVpPOXkUsX2E60FfDPXNU2AK97dkk0xhvhbm6AmM4Mvq0uHg35Wrw=='; -- Example password hash
    DECLARE @SecurityStamp NVARCHAR(255) = NEWID(); -- Unique SecurityStamp for each user

    -- Loop to generate random users
    WHILE @Counter < @NumberOfUsers
    BEGIN
        -- Generate a unique GUID for UserId
        DECLARE @UserId UNIQUEIDENTIFIER = NEWID(); -- Generate a new GUID for each user

        -- Random Name (using dummy names for simplicity)
        SET @Name = CONCAT('User_', CAST(ABS(CHECKSUM(NEWID())) % 10000 AS NVARCHAR(10)));

        -- Ensure Name is not NULL
        IF @Name IS NULL OR @Name = '' 
        BEGIN
            SET @Name = 'Default User';
        END

        -- Random Age between 18 and 60
        SET @Age = CAST((RAND() * (60 - 18) + 18) AS INT);

        -- Random SOSNumber (dummy number for the example)
        SET @SOSNumber = CONCAT('SOS', CAST(ABS(CHECKSUM(NEWID())) % 1000000 AS NVARCHAR(6)));

        -- Random Gender (0 for Male, 1 for Female)
        SET @Gender = CAST(RAND() * 2 AS INT); -- Random 0 or 1

        -- Random CreatedAt date (within the last 365 days)
        SET @CreatedAt = DATEADD(DAY, -1 * (ABS(CHECKSUM(NEWID())) % 365), GETDATE());

        -- Random RefreshToken (dummy token)
        SET @RefreshToken = CONCAT('Token_', CAST(NEWID() AS NVARCHAR(50)));

        -- Set PhotoUrl to NULL (no photo)
        SET @PhotoUrl = NULL;

        -- Random RefreshTokenExpiryTime (set 1 year after CreatedAt)
        SET @RefreshTokenExpiryTime = DATEADD(YEAR, 1, @CreatedAt);

        -- Random LocationId (ensure LocationId exists in the Location table)
        SET @LocationId = (SELECT TOP 1 LocationId FROM Locations ORDER BY NEWID()); 

        -- Generate random Email and UserName
        SET @Email = CONCAT('user', CAST(ABS(CHECKSUM(NEWID())) % 10000 AS NVARCHAR(10)), '@example.com');
        SET @NormalizedEmail = UPPER(@Email);
        SET @UserName = CONCAT('user', CAST(ABS(CHECKSUM(NEWID())) % 10000 AS NVARCHAR(10)));
        SET @NormalizedUserName = UPPER(@UserName);

        -- Insert the random user into the Users table (using IdentityUser model)
        INSERT INTO Users (Id, UserName, NormalizedUserName, Email, NormalizedEmail, Age, SOSNumber, Gender, CreatedAt, RefreshToken, PhotoUrl, RefreshTokenExpiryTime, LocationId, PasswordHash, SecurityStamp, AccessFailedCount, EmailConfirmed, LockoutEnabled, PhoneNumberConfirmed, Name)
        VALUES (@UserId, @UserName, @NormalizedUserName, @Email, @NormalizedEmail, @Age, @SOSNumber, @Gender, @CreatedAt, @RefreshToken, @PhotoUrl, @RefreshTokenExpiryTime, @LocationId, @PasswordHash, @SecurityStamp, 0, 1, 0, 0, @Name);

        -- Increment the counter
        SET @Counter = @Counter + 1;
    END;

    PRINT 'Random Users Seeder Completed';
END;
