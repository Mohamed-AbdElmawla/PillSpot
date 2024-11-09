CREATE PROCEDURE InsertRandomMedicineData
    @NumberOfRecords INT -- Parameter to specify how many records to insert
AS
BEGIN
    DECLARE @Counter INT = 0;

    -- Loop to insert the specified number of random records
    WHILE @Counter < @NumberOfRecords
    BEGIN
        INSERT INTO Medicines (Name, Description, ActiveIngredient, Dosage, Brand, Logo)
        VALUES (
            CONCAT('Medicine ', FLOOR(RAND() * 1000)),  -- Random Medicine Name
            CONCAT('Description for Medicine ', FLOOR(RAND() * 1000)),  -- Random Description
            CONCAT('Active Ingredient ', FLOOR(RAND() * 1000)),  -- Random Active Ingredient
            CONCAT(FLOOR(RAND() * 100) + 1, ' mg'),  -- Random Dosage (1 to 100 mg)
            CONCAT('Brand ', FLOOR(RAND() * 1000)),  -- Random Brand
            CONCAT('logo', FLOOR(RAND() * 1000), '.png')  -- Random Logo Filename
        );
        
        SET @Counter = @Counter + 1;
    END
	PRINT 'Random Medicines Seeder Completed';
END;
