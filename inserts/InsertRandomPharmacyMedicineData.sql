CREATE PROCEDURE InsertRandomPharmacyMedicinesData
    @NumberOfRecords INT -- The number of records to insert
AS
BEGIN
    DECLARE @Counter INT = 0;
    DECLARE @Price DECIMAL(18, 2);
    DECLARE @LastUpdated DATETIME;
    DECLARE @Quantity INT;
    DECLARE @PharmacyId INT;
    DECLARE @MedicineId INT;

    -- Loop to insert the random data
    WHILE @Counter < @NumberOfRecords
    BEGIN
        -- Generate a random Price between 10 and 500
        SET @Price = ROUND((RAND() * 490) + 10, 2);

        -- Generate a random LastUpdated date within the past year
        SET @LastUpdated = DATEADD(DAY, -CAST(RAND() * 365 AS INT), GETDATE());

        -- Generate a random Quantity between 1 and 100
        SET @Quantity = CAST(RAND() * 100 AS INT) + 1;

        -- Select a random PharmacyId that exists in the Pharmacy table
        SET @PharmacyId = (SELECT TOP 1 PharmacyId FROM Pharmacies ORDER BY NEWID());

        -- Select a random MedicineId that exists in the Medicine table
        SET @MedicineId = (SELECT TOP 1 MedicineId FROM Medicines ORDER BY NEWID());

        -- Insert the generated data into the PharmacyMedicine table
        INSERT INTO PharmacyMedicines (Price, LastUpdated, Quantity, PharmacyId, MedicineId)
        VALUES (@Price, @LastUpdated, @Quantity, @PharmacyId, @MedicineId);

        -- Increment the counter
        SET @Counter = @Counter + 1;
    END;

    PRINT 'Random PharmacyMedicine Seeder Completed';
END;
