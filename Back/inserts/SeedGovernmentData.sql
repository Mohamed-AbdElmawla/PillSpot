CREATE PROCEDURE SeedGovernmentData
AS
BEGIN
    SET NOCOUNT ON;

    -- Use a temporary table to hold the data to be seeded
    DECLARE @GovernmentSeedData TABLE (
        Governmente_Name_AR NVARCHAR(100),
        Governmente_Name_EN NVARCHAR(100)
    );

    -- Insert all the seed data into the temporary table
    INSERT INTO @GovernmentSeedData (Governmente_Name_AR, Governmente_Name_EN)
    VALUES 
        (N'القاهرة', 'Cairo'),
        (N'الجيزة', 'Giza'),
        (N'الأسكندرية', 'Alexandria'),
        (N'الدقهلية', 'Dakahlia'),
        (N'البحر الأحمر', 'Red Sea'),
        (N'البحيرة', 'Beheira'),
        (N'الفيوم', 'Fayoum'),
        (N'الغربية', 'Gharbiya'),
        (N'الإسماعلية', 'Ismailia'),
        (N'المنوفية', 'Menofia'),
        (N'المنيا', 'Minya'),
        (N'القليوبية', 'Qaliubiya'),
        (N'الوادي الجديد', 'New Valley'),
        (N'السويس', 'Suez'),
        (N'اسوان', 'Aswan'),
        (N'اسيوط', 'Assiut'),
        (N'بني سويف', 'Beni Suef'),
        (N'بورسعيد', 'Port Said'),
        (N'دمياط', 'Damietta'),
        (N'الشرقية', 'Sharkia'),
        (N'جنوب سيناء', 'South Sinai'),
        (N'كفر الشيخ', 'Kafr Al sheikh'),
        (N'مطروح', 'Matrouh'),
        (N'الأقصر', 'Luxor'),
        (N'قنا', 'Qena'),
        (N'شمال سيناء', 'North Sinai'),
        (N'سوهاج', 'Sohag');

    -- Insert into Government table only those records not already present
    INSERT INTO Governments (Governmente_Name_AR, Governmente_Name_EN)
    SELECT s.Governmente_Name_AR, s.Governmente_Name_EN
    FROM @GovernmentSeedData AS s
    WHERE NOT EXISTS (
        SELECT 1 FROM Governments AS g
        WHERE g.Governmente_Name_AR = s.Governmente_Name_AR
          AND g.Governmente_Name_EN = s.Governmente_Name_EN
    );

    PRINT 'Random Governmente Seeder Completed';
END;
