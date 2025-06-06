﻿CREATE PROCEDURE [dbo].[SeedTable_PokemonTypes] AS
BEGIN

    PRINT 'Populating records in [dbo].[PokemonTypes]';

    IF OBJECT_ID('tempdb.dbo.#dbo_SeedPokemonTypes') IS NOT NULL DROP TABLE #dbo_SeedPokemonTypes;

    SELECT 
        [TypeIDOne], [TypeIDTwo] 
    INTO #dbo_SeedPokemonTypes 
    FROM [dbo].[PokemonTypes] 
    WHERE 0 = 1;

    INSERT INTO #dbo_SeedPokemonTypes 
        ( [TypeIDOne], [TypeIDTwo] )
    SELECT 
          [TypeIDOne], [TypeIDTwo] 
    FROM 
    (  VALUES
        (4, 7),
        (4, 7),
        (4, 7),
        (1, 1),
        (1, 1),
        (1, 9),
        (2, 2),
        (2, 2),
        (2, 2),
        (11, 11),
        (11, 11),
        (11, 9),
        (11, 7),
        (11, 7),
        (11, 7),
        (0, 9),
        (0, 9),
        (0, 9),
        (0, 0),
        (0, 0),
        (0, 9),
        (0, 9),
        (7, 7),
        (7, 7),
        (3, 3),
        (3, 3),
        (8, 8),
        (8, 8),
        (7, 7),
        (7, 7),
        (7, 8),
        (7, 7),
        (7, 7),
        (7, 8),
        (0, 17),
        (0, 17),
        (1, 1),
        (1, 1),
        (0, 17),
        (0, 17),
        (7, 9),
        (7, 9),
        (4, 7),
        (4, 7),
        (4, 7),
        (11, 4),
        (11, 4),
        (11, 7),
        (11, 7),
        (8, 8),
        (8, 8),
        (0, 0),
        (0, 0),
        (2, 2),
        (2, 2),
        (6, 6),
        (6, 6),
        (1, 1),
        (1, 1),
        (2, 2),
        (2, 2),
        (2, 6),
        (10, 10),
        (10, 10),
        (10, 10),
        (6, 6),
        (6, 6),
        (6, 6),
        (4, 7),
        (4, 7),
        (4, 7),
        (2, 7),
        (2, 7),
        (12, 8),
        (12, 8),
        (12, 8),
        (1, 1),
        (1, 1),
        (2, 10),
        (2, 10),
        (3, 17),
        (3, 17),
        (0, 9),
        (0, 9),
        (0, 9),
        (2, 2),
        (2, 5),
        (7, 7),
        (7, 7),
        (2, 2),
        (2, 5),
        (13, 7),
        (13, 7),
        (13, 7),
        (12, 8),
        (10, 10),
        (10, 10),
        (2, 2),
        (2, 2),
        (3, 3),
        (3, 3),
        (4, 10),
        (4, 10),
        (8, 8),
        (8, 8),
        (6, 6),
        (6, 6),
        (0, 0),
        (7, 7),
        (7, 7),
        (8, 12),
        (8, 12),
        (0, 0),
        (4, 4),
        (0, 0),
        (2, 2),
        (2, 2),
        (2, 2),
        (2, 2),
        (2, 2),
        (2, 10),
        (10, 17),
        (11, 9),
        (5, 10),
        (3, 3),
        (1, 1),
        (11, 11),
        (0, 0),
        (2, 2),
        (2, 9),
        (2, 5),
        (0, 0),
        (0, 0),
        (2, 2),
        (3, 3),
        (1, 1),
        (0, 0),
        (12, 2),
        (12, 2),
        (12, 2),
        (12, 2),
        (12, 9),
        (0, 0),
        (5, 9),
        (3, 9),
        (1, 9),
        (14, 14),
        (14, 14),
        (14, 9),
        (10, 10),
        (10, 10)
          


    ) AS v ( [TypeIDOne], [TypeIDTwo] );

    WITH cte_data as 
        (SELECT 
            [TypeIDOne], [TypeIDTwo] 
        FROM #dbo_SeedPokemonTypes)
    MERGE [dbo].[PokemonTypes] as t
        USING cte_data as s ON t.[TypeIDOne] = s.[TypeIDOne]
        WHEN NOT MATCHED BY TARGET THEN
            INSERT 
                ([TypeIDOne], [TypeIDTwo])
            VALUES 
                (s.[TypeIDOne], s.[TypeIDTwo])
        WHEN MATCHED 
            THEN UPDATE SET 
                [TypeIDTwo] = s.[TypeIDTwo];

    DROP TABLE #dbo_SeedPokemonTypes;

    PRINT 'Finished Populating records in [dbo].[PokemonTypes]'
END
GO

EXEC [dbo].[SeedTable_PokemonTypes];

DROP PROCEDURE IF EXISTS [dbo].[SeedTable_PokemonTypes] 
GO
